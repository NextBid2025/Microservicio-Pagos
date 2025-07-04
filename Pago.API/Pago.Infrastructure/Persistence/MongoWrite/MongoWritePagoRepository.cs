using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Pago.Domain.Aggregates;
using Pago.Domain.Repositories;
using Pago.Infrastructure.Configuracions;

namespace Pago.Infrastructure.Persistence.MongoWrite
{
    public class MongoWritePagoRepository : IPagoRepository
    {
        private readonly IMongoCollection<BsonDocument> _pagosCollection;

        public MongoWritePagoRepository(MongoWriteDbConfig mongoConfig)
        {
            _pagosCollection = mongoConfig.Db.GetCollection<BsonDocument>("pagos_write");
        }

        public async Task<string> RegistrarPagoAsync(AggregatePago pago)
        {
            var bsonPago = new BsonDocument
            {
                { "_id", pago.IdPago.Value },
                { "subastaId", pago.IdSubasta.Value },
                { "usuarioId", pago.IdUsuario.Value },
                { "monto", pago.Monto.Value },
                { "metodo", pago.Metodo.Value },
                { "fecha", pago.Fecha },
                { "estado", pago.Estado.Value },
                { "mensajeError", BsonValue.Create(pago.MensajeError) },
                { "detallesTransaccion", BsonValue.Create(pago.DetallesTransaccion) },
                { "fechaCreacion", pago.FechaCreacion },
                { "fechaModificacion", pago.FechaModificacion }
            };

            await _pagosCollection.InsertOneAsync(bsonPago);
            return bsonPago["_id"].AsString;
        }
    }
}