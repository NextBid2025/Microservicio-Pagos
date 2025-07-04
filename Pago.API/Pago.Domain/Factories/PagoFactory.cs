using Pago.Domain.Aggregates;
using Pago.Domain.ValueObjects;

namespace Pago.Domain.Factories;

/// <summary>
/// Fábrica para la creación de instancias de <see cref="AggregatePago"/>.
/// </summary>
public static class PagoFactory
{
    /// <summary>
    /// Crea una nueva instancia de <see cref="AggregatePago"/> con los valores proporcionados.
    /// </summary>
    /// <param name="idPago">Identificador único del pago.</param>
    /// <param name="idSubasta">Identificador de la subasta asociada.</param>
    /// <param name="idUsuario">Identificador del usuario que realiza el pago.</param>
    /// <param name="monto">Monto del pago.</param>
    /// <param name="metodo">Método de pago utilizado.</param>
    /// <param name="fecha">Fecha y hora del pago.</param>
    /// <param name="estado">Estado actual del pago.</param>
    /// <param name="mensajeError">Mensaje de error, si aplica.</param>
    /// <param name="detallesTransaccion">Detalles adicionales de la transacción.</param>
    /// <returns>Una nueva instancia de <see cref="AggregatePago"/>.</returns>
    public static AggregatePago Create(
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
        return new AggregatePago(
            idPago,
            idSubasta,
            idUsuario,
            monto,
            metodo,
            fecha,
            estado,
            mensajeError,
            detallesTransaccion
        );
    }
}