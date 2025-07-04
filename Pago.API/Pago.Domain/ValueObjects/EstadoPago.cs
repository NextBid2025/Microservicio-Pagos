using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el estado de un pago.
/// </summary>
public class EstadoPago
{
    /// <summary>
    /// Valor del estado del pago (ej: Pendiente, Exitoso, Fallido).
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="EstadoPago"/>.
    /// </summary>
    /// <param name="value">Estado del pago.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el estado es nulo o vacío.
    /// </exception>
    public EstadoPago(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValorInvalidoException("El estado del pago no puede ser nulo o vacío.");
        }
        Value = value;
    }
}