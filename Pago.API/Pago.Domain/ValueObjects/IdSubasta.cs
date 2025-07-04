using Pago.Domain.Exceptions;

namespace Pago.Domain.ValueObjects;

/// <summary>
/// Value Object que representa el identificador único de una subasta asociada al pago.
/// </summary>
public class IdSubasta
{
    /// <summary>
    /// Valor del identificador de la subasta.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="IdSubasta"/>.
    /// </summary>
    /// <param name="value">Identificador único de la subasta.</param>
    /// <exception cref="ValorInvalidoException">
    /// Se lanza si el identificador es nulo o está vacío.
    /// </exception>
    public IdSubasta(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValorInvalidoException("El identificador de la subasta no puede ser nulo o vacío.");
        }
        Value = value;
    }
}