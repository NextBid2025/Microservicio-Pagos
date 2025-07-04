using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el monto de un pago.
/// </summary>
public class MontoPago
{
    /// <summary>
    /// Valor del monto del pago.
    /// </summary>
    public decimal Value { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="MontoPago"/>.
    /// </summary>
    /// <param name="value">Monto del pago.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el monto es menor o igual a cero.
    /// </exception>
    public MontoPago(decimal value)
    {
        if (value <= 0)
        {
            throw new ValorInvalidoException("El monto del pago debe ser mayor que cero.");
        }
        Value = value;
    }
}