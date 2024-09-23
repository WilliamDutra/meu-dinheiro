using System;
using MeuDinheiro.Shared;
using MeuDinheiro.Dominio.Repositorios;

namespace MeuDinheiro.Aplicacao.Despesa.LancarDespesa
{
    public class LancarDespesaCommandHandler : ICommandHandler<LancarDespesaCommand, CommandResult>
    {
        private IContaRepositorio _contaRepositorio;

        public LancarDespesaCommandHandler(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        public CommandResult Handle(LancarDespesaCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult(false, string.Join(",", command.Errors.ToArray()));

            var lancamento = MeuDinheiro.Dominio.Despesa.Criar(command.Nome, command.Valor, command.Tipo, DateTime.Now);
            int lancamentoId = _contaRepositorio.Salvar(lancamento);

            return new CommandResult(true, "Lançamento incluído com sucesso!", lancamentoId);
        }
    }
}
