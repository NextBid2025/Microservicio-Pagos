using MediatR;

namespace Pago.Domain.Events;

/// <summary>
/// Evento que representa la eliminación de un pago.
/// </summary>
public class PagoEliminadoEvent : INotification
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
    /// Identificador del usuario que realizó el pago.
    /// </summary>
    public string UsuarioId { get; }

    /// <summary>
    /// Fecha y hora de la eliminación.
    /// </summary>
    public DateTime FechaEliminacion { get; }

    /// <summary>
    /// Motivo de la eliminación.
    /// </summary>
    public string? Motivo { get; }

    /// <summary>
    /// Inicializa una nueva instancia del evento <see cref="PagoEliminadoEvent"/>.
    /// </summary>
    public PagoEliminadoEvent(
        string pagoId,
        string subastaId,
        string usuarioId,
        DateTime fechaEliminacion,
        string? motivo = null)
    {
        PagoId = pagoId;
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        FechaEliminacion = fechaEliminacion;
        Motivo = motivo;
    }
}