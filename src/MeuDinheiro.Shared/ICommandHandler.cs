using System;

namespace MeuDinheiro.Shared
{
    public interface ICommandHandler<TCommand, TCommandResult> where TCommand : ICommand
    {
        TCommandResult Handle(TCommand command);
    }
}
