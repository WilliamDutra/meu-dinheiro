using MeuDinheiro.Shared;

namespace MeuDinheiro.Identidade.Api.Identidade.Registrar
{
    public class RegistrarCommand : Command
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public override void Validate()
        {
            var validator = new RegistrarCommandValidation();
            var validate = validator.Validate(this);
            foreach (var erro in validate.Errors)
            {
                AddError(erro.ErrorMessage);
            }
        }
    }
}
