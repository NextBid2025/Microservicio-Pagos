using MongoDB.Bson.Serialization.Attributes;

namespace Pago.Infrastructure.Persistence.MongoRead.Documents;

public class PagoMongoRead
{
    [BsonId]
    [BsonElement("_id")]
    public required string Id { get; set; }

    [BsonElement("subastaId")]
    public required string SubastaId { get; set; }

    [BsonElement("usuarioId")]
    public required string UsuarioId { get; set; }

    [BsonElement("monto")]
    public required decimal Monto { get; set; }

    [BsonElement("metodo")]
    public required string Metodo { get; set; }

    [BsonElement("fecha")]
    public required DateTime Fecha { get; set; }

    [BsonElement("estado")]
    public required string Estado { get; set; }

    [BsonElement("detallesTransaccion")]
    public required string DetallesTransaccion { get; set; }

    [BsonElement("fechaCreacion")]
    public required DateTime FechaCreacion { get; set; }
}