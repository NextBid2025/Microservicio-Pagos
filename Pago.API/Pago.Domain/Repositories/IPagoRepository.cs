using Pago.Domain.Aggregates;
using Pago.Domain.ValueObjects;

namespace Pago.Domain.Repositories;

public interface IPagoRepository
{
   
    Task<string> RegistrarPagoAsync(AggregatePago pago);
}