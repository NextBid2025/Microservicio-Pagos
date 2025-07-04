namespace BluidingBlocks.CQRS;

using MediatR;

/// <summary>
/// Define un manejador para comandos que no retornan un valor específico.
/// </summary>
/// <typeparam name="TCommand">Tipo del comando a manejar.</typeparam>
public interface ICommandHandler<in TCommand> 
    : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

/// <summary>
/// Define un manejador para comandos que retornan un valor de tipo <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TCommand">Tipo del comando a manejar.</typeparam>
/// <typeparam name="TResponse">Tipo de la respuesta del comando.</typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}