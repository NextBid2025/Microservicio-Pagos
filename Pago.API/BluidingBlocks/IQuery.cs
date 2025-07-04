using MediatR;

namespace BluidingBlocks.CQRS;

/// <summary>
/// Representa una consulta que retorna un valor de tipo <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">Tipo de la respuesta de la consulta.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>  
    where TResponse : notnull
{
}