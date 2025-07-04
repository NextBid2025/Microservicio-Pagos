using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Pago.Domain.Events;

namespace Pago.Application.Handlers.EventsHandler
{
    public class RegistrarPagoEventHandler : INotificationHandler<PagoRealizadoEvent>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public RegistrarPagoEventHandler(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider ?? throw new ArgumentNullException(nameof(sendEndpointProvider));
        }

        public async Task Handle(PagoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Pago realizado: {notification.PagoId} - Monto: {notification.Monto}");
            // Enviar el evento a la cola de RabbitMQ
            await _sendEndpointProvider.Send(notification, cancellationToken);
        }
    }
}