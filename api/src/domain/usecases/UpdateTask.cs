using errors;
using models;
using services;

namespace usecases
{
    public class UpdateTask
    {
        private TaskRepository taskRepository;
        private DatabaseExecutor databaseExecutor;
        public UpdateTask(
            DatabaseExecutor databaseExecutor,
            TaskRepository taskRepository
        )
        {
            this.databaseExecutor = databaseExecutor;
            this.taskRepository = taskRepository;
        }

        public ResponseStatus<string> Call(
            TaskModifier taskModifier, int id
        )
        {
            try
            {
                this.taskRepository.UpdateTask(
                    this.databaseExecutor, taskModifier, id
                );
                return new ResponseStatus<string>(
                    200, "Updated successfully."
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
