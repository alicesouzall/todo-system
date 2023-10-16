using errors;
using models;
using services;

namespace usecases
{
    public class CreateTask
    {
        private TaskRepository taskRepository;
        private DatabaseExecutor databaseExecutor;
        public CreateTask(
            DatabaseExecutor databaseExecutor,
            TaskRepository taskRepository
        )
        {
            this.databaseExecutor = databaseExecutor;
            this.taskRepository = taskRepository;
        }

        public ResponseStatus<string> Call(
            TaskModifier taskModifier
        )
        {
            try
            {
                this.taskRepository.CreateTask(
                    this.databaseExecutor, taskModifier
                );
                return new ResponseStatus<string>(
                    201, "Task created successfully"
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
