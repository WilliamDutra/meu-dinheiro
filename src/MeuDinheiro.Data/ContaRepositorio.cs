using System;
using System.Data;
using MeuDinheiro.Dominio;
using MeuDinheiro.Dominio.Repositorios;
using Npgsql;

namespace MeuDinheiro.Data
{
    public class ContaRepositorio : IContaRepositorio
    {
        private MeuDinheiroContext _DbContext;

        public ContaRepositorio(MeuDinheiroContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Alterar(Despesa despesa)
        {
            throw new NotImplementedException();
        }

        public int Salvar(Conta conta)
        {
            string insert = @"insert into conta 
                            ( 
	                            nome, 
	                            criado_em 
                            )
                            values
                            (
	                            @nome,
	                            @criado_em
                            )
                            returning id";

            int id = 0;

            using (var command = new NpgsqlCommand())
            {
                command.Connection = _DbContext.Connection;
                command.CommandText = insert;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new NpgsqlParameter("@nome", conta.Nome));
                command.Parameters.Add(new NpgsqlParameter("@criado_em", DateTime.Now));
                id = (int)command.ExecuteScalar();
            }

            return id;

        }

        public int Salvar(Despesa despesa)
        {
            string insert = @"insert into despesa 
                            ( 
	                            nome, 
	                            valor,
	                            data_lancamento,
	                            tipo_lancamento_id
                            )
                            values
                            (
	                            @nome,
	                            @valor,
	                            @data_lancamento,
	                            @tipo_lancamento_id
                            )
                            returning id";


            int id = 0;

            using (var command = new NpgsqlCommand())
            {
                command.Connection = _DbContext.Connection;
                command.CommandText = insert;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new NpgsqlParameter("@nome", despesa.Nome));
                command.Parameters.Add(new NpgsqlParameter("@valor", despesa.Valor));
                command.Parameters.Add(new NpgsqlParameter("@data_lancamento", despesa.DataLancamento));
                command.Parameters.Add(new NpgsqlParameter("@tipo_lancamento_id", (int)despesa.TipoDespesa));
                id = (int)command.ExecuteScalar();
            }

            return id;
        }
    }
}
