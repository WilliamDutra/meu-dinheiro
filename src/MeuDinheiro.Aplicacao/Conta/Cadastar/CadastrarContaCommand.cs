using System;
using MeuDinheiro.Shared;

namespace MeuDinheiro.Aplicacao.Conta.Cadastar
{
    public class CadastrarContaCommand : Command
    {
        public string Nome { get; set; }

        public override void Validate()
        {
            var validator = new CadastrarContaCommandValidation();
            var validate = validator.Validate(this);
            foreach (var erro in validate.Errors)
            {
                AddError(erro.ErrorMessage);
            }
        }
    }
}
