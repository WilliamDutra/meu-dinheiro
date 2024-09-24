using System;
using MeuDinheiro.Shared;

namespace MeuDinheiro.Identidade.Registrar
{
    public interface IRegistrarHandler : ICommandHandler<RegistrarCommand, CommandResult>
    {
    }
}
