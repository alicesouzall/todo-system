using models;

namespace services
{
    public interface TaskRepository
    {
        void CreateTask(DatabaseExecutor databaseExecutor, TaskModifier taskModifier);
        void DeleteTask(DatabaseExecutor databaseExecutor, int Id);
        void UpdateTask(DatabaseExecutor databaseExecutor, TaskModifier taskModifier, int Id);
        Task<IEnumerable<TaskTable>?> GetAllTasks(DatabaseExecutor databaseExecutor);
        Task<TaskTable?> GetTaskById(DatabaseExecutor databaseExecutor, int Id);
    }
}
