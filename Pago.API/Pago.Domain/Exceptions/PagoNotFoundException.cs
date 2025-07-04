namespace Pago.Domain.Exceptions;

/// <summary>
/// Excepción que se lanza cuando no se encuentra un pago.
/// </summary>
public class PagoNotFoundException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la excepción <see cref="PagoNotFoundException"/> con un mensaje específico.
    /// </summary>
    /// <param name="message">Mensaje que describe el error.</param>
    public PagoNotFoundException(string message) : base(message)
    {
    }
}