using System;
using FluentValidation;

namespace MeuDinheiro.Aplicacao.Despesa.LancarDespesa
{
    public class LancarDespesaCommandValidation : AbstractValidator<LancarDespesaCommand>
    {
        public LancarDespesaCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da despesa é obrigatório!");

            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor da despesa é obrigatório!");

            RuleFor(x => x.Tipo)
                .NotEmpty()
                .WithMessage("O tipo da despesa é obrigatória!");
        }
    }
}
