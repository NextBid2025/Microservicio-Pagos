using MediatR;

namespace BluidingBlocks.CQRS;

/// <summary>
/// Define un manejador para consultas que retornan un valor de tipo <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TQuery">Tipo de la consulta a manejar.</typeparam>
/// <typeparam name="TResponse">Tipo de la respuesta de la consulta.</typeparam>
public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}