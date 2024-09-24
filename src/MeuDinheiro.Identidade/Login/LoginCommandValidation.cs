using FluentValidation;

namespace MeuDinheiro.Identidade.Login
{
    public class LoginCommandValidation  : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A senha é obrigatória!");
        }
    }
}
