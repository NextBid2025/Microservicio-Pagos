using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el identificador único de un usuario asociado al pago.
/// </summary>
public class IdUsuario
{
    /// <summary>
    /// Valor del identificador del usuario.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="IdUsuario"/>.
    /// </summary>
    /// <param name="value">Identificador único del usuario.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el identificador es nulo o está vacío.
    /// </exception>
    public IdUsuario(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValorInvalidoException("El identificador del usuario no puede ser nulo o vacío.");
        }
        Value = value;
    }
}