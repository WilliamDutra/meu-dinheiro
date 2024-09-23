using System;
using MeuDinheiro.Shared;

namespace MeuDinheiro.Dominio.Repositorios
{
    public interface IContaRepositorio : IAggregateRoot
    {
        int Salvar(Conta conta);

        int Salvar(Despesa despesa);

        void Alterar(Despesa despesa);

    }
}
