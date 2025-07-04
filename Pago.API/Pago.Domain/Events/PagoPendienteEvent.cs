using MediatR;

namespace Pago.Domain.Events;

/// <summary>
/// Evento que representa que un pago ha quedado pendiente.
/// </summary>
public class PagoPendienteEvent : INotification
{
    /// <summary>
    /// Identificador único del pago.
    /// </summary>
    public string PagoId { get; }

    /// <summary>
    /// Identificador de la subasta asociada.
    /// </summary>
    public string SubastaId { get; }

    /// <summary>
    /// Identificador del usuario que realiza el pago.
    /// </summary>
    public string UsuarioId { get; }

    /// <summary>
    /// Monto del pago.
    /// </summary>
    public decimal Monto { get; }

    /// <summary>
    /// Método de pago utilizado.
    /// </summary>
    public string Metodo { get; }

    /// <summary>
    /// Fecha y hora del pago.
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Estado actual del pago.
    /// </summary>
    public string Estado { get; }

    /// <summary>
    /// Detalles adicionales de la transacción.
    /// </summary>
    public string? DetallesTransaccion { get; }

    /// <summary>
    /// Inicializa una nueva instancia del evento <see cref="PagoPendienteEvent"/>.
    /// </summary>
    public PagoPendienteEvent(
        string pagoId,
        string subastaId,
        string usuarioId,
        decimal monto,
        string metodo,
        DateTime fecha,
        string estado,
        string? detallesTransaccion = null)
    {
        PagoId = pagoId;
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        Monto = monto;
        Metodo = metodo;
        Fecha = fecha;
        Estado = estado;
        DetallesTransaccion = detallesTransaccion;
    }
}