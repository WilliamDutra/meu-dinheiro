using MeuDinheiro.Shared;

namespace MeuDinheiro.Identidade.Login
{
    public class LoginCommand : Command
    {

        public string Email { get; set; }

        public string Senha { get; set; }

        public override void Validate()
        {
            var validator = new LoginCommandValidation();
            var validate = validator.Validate(this);
            foreach (var erro in validate.Errors)
            {
                AddError(erro.ErrorMessage);
            }
        }
    }
}
