/// <summary>
/// DTO para registrar un nuevo pago.
/// </summary>
public class RegistrarPagoDto
{
    public string SubastaId { get; set; }
    public string UsuarioId { get; set; }
    public decimal Monto { get; set; }
    public string Metodo { get; set; }
    public string DetallesTransaccion { get; set; }
}