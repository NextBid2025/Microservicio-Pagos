namespace Pago.Domain.Exceptions;

/// <summary>
/// Excepción que se lanza cuando un valor de un Value Object es inválido.
/// </summary>
public class ValorInvalidoException : Exception
{
    public ValorInvalidoException(string message) : base(message)
    {
    }
}