namespace BluidingBlocks.CQRS;

using MediatR;

/// <summary>
/// Representa un comando que no retorna un valor específico.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Representa un comando que retorna un valor de tipo <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">Tipo de la respuesta del comando.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}