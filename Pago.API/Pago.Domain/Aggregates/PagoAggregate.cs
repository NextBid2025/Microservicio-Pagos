using Pago.Domain.ValueObjects;

namespace Pago.Domain.Aggregates;

/// <summary>
/// Representa la entidad agregada de un pago, incluyendo sus propiedades y comportamientos principales.
/// </summary>
public class AggregatePago
{
    public IdPago IdPago { get; set; }
    public IdSubasta IdSubasta { get; set; }
    public IdUsuario IdUsuario { get; set; }
    public MontoPago Monto { get; set; }
    public MetodoPago Metodo { get; set; }
    public DateTime Fecha { get; set; }
    public EstadoPago Estado { get; set; }
    public string? MensajeError { get; set; }
    public string? DetallesTransaccion { get; set; }
    public DateTime FechaCreacion { get; private set; } = DateTime.UtcNow;
    public DateTime FechaModificacion { get; set; }

    private AggregatePago() { }

    public AggregatePago(
        IdPago idPago,
        IdSubasta idSubasta,
        IdUsuario idUsuario,
        MontoPago monto,
        MetodoPago metodo,
        DateTime fecha,
        EstadoPago estado,
        string? mensajeError = null,
        string? detallesTransaccion = null)
    {
        IdPago = idPago;
        IdSubasta = idSubasta;
        IdUsuario = idUsuario;
        Monto = monto;
        Metodo = metodo;
        Fecha = fecha;
        Estado = estado;
        MensajeError = mensajeError;
        DetallesTransaccion = detallesTransaccion;
        FechaCreacion = DateTime.UtcNow;
    }

    /// <summary>
    /// Actualiza el estado y mensaje de error del pago.
    /// </summary>
    public void ActualizarEstado(EstadoPago nuevoEstado, string? mensajeError = null)
    {
        Estado = nuevoEstado;
        MensajeError = mensajeError;
        FechaModificacion = DateTime.UtcNow;
    }

    public void UpdatePago(
        MontoPago? monto,
        MetodoPago? metodo,
        DateTime? fecha,
        EstadoPago? estado,
        string? mensajeError,
        string? detallesTransaccion)
    {
        if (monto != null)
            Monto = monto;
        if (metodo != null)
            Metodo = metodo;
        if (fecha != null)
            Fecha = fecha.Value;
        if (estado != null)
            Estado = estado;
        if (mensajeError != null)
            MensajeError = mensajeError;
        if (detallesTransaccion != null)
            DetallesTransaccion = detallesTransaccion;

        FechaModificacion = DateTime.UtcNow;
    }

    /// <summary>
    /// Indica si el pago fue exitoso.
    /// </summary>
    public bool EsExitoso()
    {
        return Estado != null && Estado.Value == "Exitoso";
    }
}