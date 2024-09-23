using System;
using MeuDinheiro.Shared;
using MeuDinheiro.Dominio.Repositorios;

namespace MeuDinheiro.Aplicacao.Conta.Cadastar
{
    public class CadastrarContaCommandHandler : ICommandHandler<CadastrarContaCommand, CommandResult>
    {
        private IContaRepositorio _contaRepositorio;

        public CadastrarContaCommandHandler(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        public CommandResult Handle(CadastrarContaCommand command)
        {

            command.Validate();

            if (!command.IsValid)
                return new CommandResult(true, string.Join(",", command.Errors.ToArray()));

            var conta = MeuDinheiro.Dominio.Conta.Criar(command.Nome);
            _contaRepositorio.Salvar(conta);

            return new CommandResult(true, "Conta criada com sucesso!");
        }
    }
}
