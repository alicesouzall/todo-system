using errors;
using models;
using services;
using Microsoft.AspNetCore.Mvc;

namespace usecases
{
    public class GetTaskById
    {
        private TaskRepository taskRepository;
        private DatabaseExecutor databaseExecutor;
        public GetTaskById(
            DatabaseExecutor databaseExecutor,
            TaskRepository taskRepository
        )
        {
            this.databaseExecutor = databaseExecutor;
            this.taskRepository = taskRepository;
        }

        public async Task<ResponseStatus<TaskTable>> Call(int id)
        {
            try
            {
                TaskTable? task = await this.taskRepository.GetTaskById(
                    this.databaseExecutor, id
                );
                if (task != null)
                {
                    return new ResponseStatus<TaskTable>(
                        201, "Task returned", task
                    );
                }
                else
                {
                    return new ResponseStatus<TaskTable>(
                        404, "No task found."
                    );
                }
            }
            catch (DatabaseError e)
            {
                return new ResponseStatus<TaskTable>(
                    500, e.Message
                );
            }
        }
    }
}
