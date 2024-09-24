using FluentValidation;

namespace MeuDinheiro.Identidade.Registrar
{
    public class RegistrarCommandValidation : AbstractValidator<RegistrarCommand>
    {
        public RegistrarCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A senha é obrigatório!");

        }
    }
}
