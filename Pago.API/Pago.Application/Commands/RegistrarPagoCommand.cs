
using BluidingBlocks.CQRS;

namespace Pago.Application.Commands;

/// <summary>
/// Comando para registrar un nuevo pago.
/// </summary>
public class RegistrarPagoCommand : ICommand<string>
{
    /// <summary>
    /// Identificador de la subasta asociada.
    /// </summary>
    public string SubastaId { get; }

    /// <summary>
    /// Identificador del usuario que realiza el pago.
    /// </summary>
    public string UsuarioId { get; }

    /// <summary>
    /// Monto del pago.
    /// </summary>
    public decimal Monto { get; }

    /// <summary>
    /// Método de pago utilizado.
    /// </summary>
    public string Metodo { get; }

    /// <summary>
    /// Detalles adicionales de la transacción.
    /// </summary>
    public string? DetallesTransaccion { get; }

    /// <summary>
    /// Constructor para inicializar el comando de registro de pago.
    /// </summary>
    public RegistrarPagoCommand(
        string subastaId,
        string usuarioId,
        decimal monto,
        string metodo,
        string? detallesTransaccion = null)
    {
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        Monto = monto;
        Metodo = metodo;
        DetallesTransaccion = detallesTransaccion;
    }
}