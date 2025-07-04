using MediatR;

namespace Pago.Domain.Events;

/// <summary>
/// Evento que representa la actualización de un pago.
/// </summary>
public class PagoActualizadoEvent : INotification
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
    /// Nuevo monto del pago.
    /// </summary>
    public decimal Monto { get; }

    /// <summary>
    /// Nuevo método de pago utilizado.
    /// </summary>
    public string Metodo { get; }

    /// <summary>
    /// Nueva fecha y hora del pago.
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Nuevo estado del pago.
    /// </summary>
    public string Estado { get; }

    /// <summary>
    /// Detalles adicionales de la transacción.
    /// </summary>
    public string? DetallesTransaccion { get; }

    /// <summary>
    /// Inicializa una nueva instancia del evento <see cref="PagoActualizadoEvent"/>.
    /// </summary>
    public PagoActualizadoEvent(
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