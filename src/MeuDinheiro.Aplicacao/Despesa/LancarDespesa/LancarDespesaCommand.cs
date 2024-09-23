using System;
using MeuDinheiro.Shared;
using MeuDinheiro.Dominio;

namespace MeuDinheiro.Aplicacao.Despesa.LancarDespesa
{
    public class LancarDespesaCommand : Command
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public ETipoDespesa Tipo { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
