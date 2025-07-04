using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el identificador único de un pago.
/// </summary>
public class IdPago
{
    /// <summary>
    /// Valor del identificador del pago.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="IdPago"/>.
    /// </summary>
    /// <param name="value">Identificador único del pago.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el identificador es nulo o está vacío.
    /// </exception>
    public IdPago(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValorInvalidoException("El identificador del pago no puede ser nulo o vacío.");
        }
        Value = value;
    }
}