using MongoDB.Bson;
using MongoDB.Driver;
using Pago.Infrastructure.Interfaces;
using Pago.Infrastructure.Configuracions;

namespace Pago.Infrastructure.Persistence.MongoRead
{
    /// <summary>
    /// Repositorio de solo lectura para pagos, utilizando MongoDB.
    /// Proporciona métodos para obtener, agregar, actualizar y eliminar pagos en la base de datos de lectura.
    /// </summary>
    public class MongoReadPagoRepository : IPagoReadRepository
    {
        private readonly IMongoCollection<BsonDocument> _pagosCollection;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="MongoReadPagoRepository"/>.
        /// </summary>
        /// <param name="mongoConfig">Configuración de la base de datos de lectura de MongoDB.</param>
        public MongoReadPagoRepository(MongoReadDbConfig mongoConfig)
        {
            _pagosCollection = mongoConfig.Db.GetCollection<BsonDocument>("pago_read");
        }

        /// <summary>
        /// Registra un pago en la base de datos de lectura.
        /// </summary>
        /// <param name="pagoDocument">Documento BSON que representa el pago.</param>
        /// <returns>El ID del pago registrado.</returns>
        public async Task<string> RegistrarPagoAsync(BsonDocument pagoDocument)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", pagoDocument["_id"]);
            var exists = await _pagosCollection.Find(filter).AnyAsync();

            if (!exists)
            {
                await _pagosCollection.InsertOneAsync(pagoDocument);
            }
            else
            {
                var update = Builders<BsonDocument>.Update
                    .Set("monto", pagoDocument["monto"])
                    .Set("metodo", pagoDocument["metodo"])
                    .Set("fecha", pagoDocument["fecha"])
                    .Set("estado", pagoDocument["estado"])
                    .Set("detallesTransaccion", pagoDocument["detallesTransaccion"]);

                await _pagosCollection.UpdateOneAsync(filter, update);
            }

            return pagoDocument["_id"].AsString;
        }
    }
}