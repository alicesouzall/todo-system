using errors;
using models;
using services;

namespace usecases
{
    public class DeleteTask
    {
        private TaskRepository taskRepository;
        private DatabaseExecutor databaseExecutor;
        public DeleteTask(
            DatabaseExecutor databaseExecutor,
            TaskRepository taskRepository
        )
        {
            this.databaseExecutor = databaseExecutor;
            this.taskRepository = taskRepository;
        }

        public ResponseStatus<string> Call(
            int id
        )
        {
            try
            {
                this.taskRepository.DeleteTask(
                    this.databaseExecutor, id
                );
                return new ResponseStatus<string>(
                    201, "Task deleted successfully."
                );
            }
            catch (DatabaseError e)
            {
                return new ResponseStatus<string>(
                    500, e.Message
                );
            }
        }
    }
}
