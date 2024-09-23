using Npgsql;

namespace MeuDinheiro.Data
{
    public class MeuDinheiroContext
    {
        public NpgsqlConnection Connection;

        public MeuDinheiroContext(string connectionStrings)
        {
            Connection = new NpgsqlConnection(connectionStrings);
            Connection.Open();
        }
    }
}