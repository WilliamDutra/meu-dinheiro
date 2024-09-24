using System;
using MeuDinheiro.Shared;

namespace MeuDinheiro.Identidade.Login
{
    public interface ILoginHandler : ICommandHandler<LoginCommand, CommandResult>
    {

    }
}
