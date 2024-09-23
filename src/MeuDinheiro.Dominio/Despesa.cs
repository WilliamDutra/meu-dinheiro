namespace MeuDinheiro.Dominio
{
    public class Despesa
    {
        public int Id { get; set; }

        public string Nome { get; private set; }

        public decimal Valor { get; private set; }

        public ETipoDespesa TipoDespesa { get; set; }

        public DateTime DataLancamento { get; private set; }

        private Despesa(int id, string nome, decimal valor, ETipoDespesa tipoDespesa, DateTime dataLancamento)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            TipoDespesa = tipoDespesa;
            DataLancamento = dataLancamento;
        }

        public static Despesa Criar(string nome, decimal valor, ETipoDespesa tipoDespesa, DateTime dataLancamento)
        {
            return new Despesa(0, nome, valor, tipoDespesa, dataLancamento);
        }

        public static Despesa Restaurar(int id, string nome, decimal valor, ETipoDespesa tipoDespesa, DateTime dataLancamento)
        {
            return new Despesa(id, nome, valor, tipoDespesa, dataLancamento);
        }

    }
}