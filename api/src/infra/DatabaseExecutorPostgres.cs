using Npgsql;
using services;

namespace infra
{
    public class DatabaseExecutorPostgres : DatabaseExecutor
    {
        public NpgsqlConnection? connection = null;
        public DatabaseExecutorPostgres(NpgsqlConnection connection)
        {
            this.connection = connection;
        }
        public async Task<T?> ExecuteQuery<T, D>(
            string query, List<D>? parameters = null
        ) where T : class
        {
            try
            {
                await using var command = new NpgsqlCommand(query, this.connection);
                if (parameters != null)
                {
                    foreach (D p in parameters)
                    {
                        NpgsqlParameter parameter = new NpgsqlParameter
                        {
                            Value = p
                        };

                        command.Parameters.Add(parameter);
                    }
                }
                return await command.ExecuteReaderAsync() as T;
            }
            catch (NpgsqlException e)
            {
                throw new Exception($"Command executor failed <Postgres>: {e.Message}");
            }
        }
    }
}
