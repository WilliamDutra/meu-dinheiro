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

        public override void Validate()
        {
            var validator = new LancarDespesaCommandValidation();
            var validate = validator.Validate(this);
            foreach (var erro in validate.Errors)
            {
                AddError(erro.ErrorMessage);
            }
        }
    }
}
