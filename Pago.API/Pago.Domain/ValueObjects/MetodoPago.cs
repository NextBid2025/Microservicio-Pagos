using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el método de pago.
/// </summary>
public class MetodoPago
{
    /// <summary>
    /// Valor del método de pago (ej: tarjeta, transferencia, etc.).
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="MetodoPago"/>.
    /// </summary>
    /// <param name="value">Método de pago.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el método es nulo o vacío.
    /// </exception>
    public MetodoPago(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValorInvalidoException("El método de pago no puede ser nulo o vacío.");
        }
        Value = value;
    }
}