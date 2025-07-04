using MongoDB.Bson;
using Pago.Infrastructure.Persistence.MongoRead.Documents;


namespace Pago.Infrastructure.Interfaces;

/// <summary>
/// Interfaz para el repositorio de lectura de pagos en la base de datos.
/// Proporciona métodos para obtener, agregar, actualizar y eliminar pagos.
/// </summary>
public interface IPagoReadRepository
{

    Task<string> RegistrarPagoAsync(BsonDocument pago);


}