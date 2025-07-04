
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BluidingBlocks.CQRS;
using MediatR;

public class ConsultarMetodosPagoQuery : IQuery<List<string>> { }

public class ConsultarMetodosPagoQueryHandler : IQueryHandler<ConsultarMetodosPagoQuery, List<string>>
{
    public Task<List<string>> Handle(ConsultarMetodosPagoQuery request, CancellationToken cancellationToken)
    {
        var metodos = new List<string> { "Tarjeta", "Transferencia", "PayPal" };
        return Task.FromResult(metodos);
    }
}