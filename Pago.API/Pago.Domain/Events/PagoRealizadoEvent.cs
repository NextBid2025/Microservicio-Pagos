using MediatR;

namespace Pago.Domain.Events;

/// <summary>
/// Evento que representa un pago realizado.
/// </summary>
public class PagoRealizadoEvent : INotification
{
    public string PagoId { get; }
    public string SubastaId { get; }
    public string UsuarioId { get; }
    public decimal Monto { get; }
    public string Metodo { get; }
    public DateTime Fecha { get; }
    public string Estado { get; }
    public string DetallesTransaccion { get; }
    public DateTime FechaCreacion { get; }

    public PagoRealizadoEvent(
        string pagoId,
        string subastaId,
        string usuarioId,
        decimal monto,
        string metodo,
        DateTime fecha,
        string estado,
        string detallesTransaccion,
        DateTime fechaCreacion)
    {
        PagoId = pagoId;
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        Monto = monto;
        Metodo = metodo;
        Fecha = fecha;
        Estado = estado;
        DetallesTransaccion = detallesTransaccion;
        FechaCreacion = fechaCreacion;
    }
}