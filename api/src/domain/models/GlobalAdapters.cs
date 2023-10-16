using services;
using Microsoft.Extensions.DependencyInjection;

namespace models
{
    public class GlobalAdapters
    {
        public GlobalAdapters(
            DatabaseConnection databaseConnection,
            TaskRepository taskRepository
        )
        {
            this.databaseConnection = databaseConnection;
            this.taskRepository = taskRepository;
        }
        public readonly DatabaseConnection databaseConnection;
        public readonly TaskRepository taskRepository;
    }
}
