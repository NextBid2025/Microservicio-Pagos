using MassTransit;
using MongoDB.Bson;
using Pago.Domain.Events;
using Pago.Infrastructure.Interfaces;

namespace Pago.Infrastructure.Consumer;

/// <summary>
/// Consumidor de eventos de registro de pagos.
/// Procesa el evento <see cref="PagoRealizadoEvent"/> y lo inserta en la base de datos de lectura.
/// </summary>
public class RegistrarPagoConsumer : IConsumer<PagoRealizadoEvent>
{
    private readonly IPagoReadRepository _pagoReadRepository;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="RegistrarPagoConsumer"/>.
    /// </summary>
    /// <param name="pagoReadRepository">Repositorio de lectura de pagos.</param>
    public RegistrarPagoConsumer(IPagoReadRepository pagoReadRepository)
    {
        _pagoReadRepository = pagoReadRepository;
    }

    /// <summary>
    /// Procesa el evento de registro de pago y lo inserta en la base de datos de lectura.
    /// </summary>
    /// <param name="context">Contexto del evento recibido.</param>
    public async Task Consume(ConsumeContext<PagoRealizadoEvent> context)
    {
        var message = context.Message;
        Console.WriteLine($"Mensaje recibido: {message}");

        var readDocument = new BsonDocument
        {
            { "_id", message.PagoId },
            { "subastaId", message.SubastaId },
            { "usuarioId", message.UsuarioId },
            { "monto", message.Monto },
            { "metodo", message.Metodo.ToString() },
            { "fecha", message.Fecha },
            { "estado", message.Estado },
            { "detallesTransaccion", message.DetallesTransaccion },
            { "fechaCreacion", message.FechaCreacion }
        };

        await _pagoReadRepository.RegistrarPagoAsync(readDocument);
        Console.WriteLine("Documento insertado en la base de datos de lectura.");
    }
}
    
