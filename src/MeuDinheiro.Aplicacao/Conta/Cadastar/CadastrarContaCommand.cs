using System;
using MeuDinheiro.Shared;

namespace MeuDinheiro.Aplicacao.Conta.Cadastar
{
    public class CadastrarContaCommand : Command
    {
        public string Nome { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
