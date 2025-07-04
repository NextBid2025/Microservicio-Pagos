using BluidingBlocks.CQRS;
using MassTransit.Mediator;
using Pago.Application.Commands;
using Pago.Application.Interfaces;
using Pago.Domain.Aggregates;
using Pago.Domain.Events;
using Pago.Domain.Repositories;
using Pago.Domain.ValueObjects;

namespace Pago.Application.Handlers
{
    public class RegistrarPagoCommandHandler : ICommandHandler<RegistrarPagoCommand, string>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMediator _mediator;
        private readonly ISubastaService _subastaService;

        public RegistrarPagoCommandHandler(
            IPagoRepository pagoRepository,
            IMediator mediator,
            ISubastaService subastaService)
        {
            _pagoRepository = pagoRepository ?? throw new ArgumentNullException(nameof(pagoRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _subastaService = subastaService ?? throw new ArgumentNullException(nameof(subastaService));
        }

        public async Task<string> Handle(RegistrarPagoCommand request, CancellationToken cancellationToken)
        {
            var ganadorId = await _subastaService.ObtenerGanadorSubastaAsync(request.SubastaId);
            if (ganadorId != request.UsuarioId)
                throw new InvalidOperationException("Solo el usuario ganador puede registrar el pago.");

            var aggregatePago = new AggregatePago(
                new IdPago(Guid.NewGuid().ToString()),
                new IdSubasta(request.SubastaId),
                new IdUsuario(request.UsuarioId),
                new MontoPago(request.Monto),
                new MetodoPago(request.Metodo),
                DateTime.UtcNow, // Fecha del pago
                new EstadoPago("Pendiente"),
                null, // Mensaje de error
                request.DetallesTransaccion // Detalles de la transacción
            );

            await _pagoRepository.RegistrarPagoAsync(aggregatePago);

            var pagoRealizadoEvent = new PagoRealizadoEvent(
                aggregatePago.IdPago.Value,
                aggregatePago.IdSubasta.Value,
                aggregatePago.IdUsuario.Value,
                aggregatePago.Monto.Value,
                aggregatePago.Metodo.Value,
                aggregatePago.Fecha, // Fecha del pago
                aggregatePago.Estado.Value,
                aggregatePago.DetallesTransaccion ?? string.Empty, // Detalles de la transacción
                aggregatePago.FechaCreacion // Fecha de creación
            );

            await _mediator.Publish(pagoRealizadoEvent, cancellationToken);

            return aggregatePago.IdPago.Value;
        }
    }
}