using Npgsql;
using models;
using services;
using errors;

namespace infra
{
    public class DatabaseConnectionPostgres : DatabaseConnection
    {
        public DatabaseExecutor CreateConnection(DatabaseSettings databaseSettings)
        {
            try
            {
                var connectionString = $"Host={databaseSettings.Host};Username={databaseSettings.User};Password={databaseSettings.Password};Database={databaseSettings.Name}";
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return new DatabaseExecutorPostgres(connection);
            }
            catch (NpgsqlException e)
            {
                throw new DatabaseError($"Authentication failed <Postgres>: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                throw new DatabaseError($"Connection failed <Postgres>: {e.Message}");
            }
        }
    }
}
