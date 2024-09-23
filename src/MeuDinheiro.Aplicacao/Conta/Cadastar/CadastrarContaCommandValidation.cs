using System;
using FluentValidation;

namespace MeuDinheiro.Aplicacao.Conta.Cadastar
{
    public class CadastrarContaCommandValidation : AbstractValidator<CadastrarContaCommand>
    {
        public CadastrarContaCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome da conta é obrigatório!");
        }
    }
}
