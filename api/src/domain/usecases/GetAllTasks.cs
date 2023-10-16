using errors;
using models;
using services;

namespace usecases
{
    public class GetAllTasks
    {
        private TaskRepository taskRepository;
        private DatabaseExecutor databaseExecutor;
        public GetAllTasks(
            DatabaseExecutor databaseExecutor,
            TaskRepository taskRepository
        )
        {
            this.databaseExecutor = databaseExecutor;
            this.taskRepository = taskRepository;
        }

        public async Task<ResponseStatus<IEnumerable<TaskTable>>> Call()
        {
            try
            {
                IEnumerable<TaskTable>? allTasks = await this.taskRepository.GetAllTasks(this.databaseExecutor);
                if (allTasks != null)
                {
                    return new ResponseStatus<IEnumerable<TaskTable>>(
                        201, "All tasks returned", allTasks
                    );
                }
                else
                {
                    return new ResponseStatus<IEnumerable<TaskTable>>(
                        404, "No tasks found."
                    );
                }
            }
            catch (DatabaseError e)
            {
                return new ResponseStatus<IEnumerable<TaskTable>>(
                    500, e.Message
                );
            }
        }
    }
}
