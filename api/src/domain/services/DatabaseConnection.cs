using models;

namespace services
{
    public interface DatabaseConnection
    {
        DatabaseExecutor CreateConnection(DatabaseSettings databaseSettings);

    }
}
