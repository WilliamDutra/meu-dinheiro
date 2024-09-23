using System;

namespace MeuDinheiro.Dominio
{
    public class Conta
    {
        public int Id { get; set; }

        public string Nome { get; private set; }

        public IReadOnlyCollection<Despesa> Despesas => _Despesas;

        private List<Despesa> _Despesas = new List<Despesa>();

        private Conta(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            _Despesas.Add(despesa);
        }

        public static Conta Criar(string nome)
        {
            return new Conta(0, nome);
        }

        public static Conta Restaurar(int id, string nome)
        {
            return new Conta(id, nome);
        }

    }
}
