
using Npgsql;

namespace ClienteApi.Services
{
    public class ConexaoBanco : IDisposable
    {
        private readonly NpgsqlDataSource _dataSource;

        public ConexaoBanco(IConfiguration configuration)
        {
            string conexao = configuration.GetConnectionString("PostgreSQL")
                ?? throw new InvalidOperationException(
                    "String de conexão não encontrada."
                );

            _dataSource = NpgsqlDataSource.Create(conexao);
        }

        public async Task<int> TestarConexao()
        {
            await using var conexao =
                await _dataSource.OpenConnectionAsync();

            await using var comando =
                new NpgsqlCommand("SELECT 1", conexao);

            var resultado = await comando.ExecuteScalarAsync();

            return Convert.ToInt32(resultado);
        }

        public void Dispose()
        {
            _dataSource.Dispose();
        }
    }
}
