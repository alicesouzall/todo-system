using Microsoft.AspNetCore.Mvc;
using models;
using infra;
using usecases;
using services;
using Microsoft.Extensions.DependencyInjection;
using requestModels;

namespace entrypoints
{
    [ApiController]
    [Route("tb01")]
    public class TasksRoute : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly GlobalAdapters _globalAdapters;
        private EnvironmentVariables environmentVariables;
        public TasksRoute(
            IConfiguration configuration,
            EnvironmentVariables environmentVariables,
            GlobalAdapters globalAdapters
        )
        {
            _globalAdapters = globalAdapters;
            this.configuration = configuration;
            this.environmentVariables = new EnvironmentVariables(configuration);
        }

        [Route("")]
        [HttpGet(Name = "GetAllTasks")]
        public async Task<ResponseStatus<IEnumerable<TaskTable>>> Get()
        {
            DatabaseExecutor databaseExecutor = _globalAdapters.databaseConnection.CreateConnection(
                this.environmentVariables.GetDatabaseSettings()
            );
            GetAllTasks getAllTasks = new GetAllTasks(databaseExecutor, _globalAdapters.taskRepository);
            return await getAllTasks.Call();
        }

        [Route("get_task_by_id")]
        [HttpPost(Name = "GetTaskById")]
        public async Task<ResponseStatus<TaskTable>> GetById([FromBody] GetByIdRequest id)
        {
            DatabaseExecutor databaseExecutor = _globalAdapters.databaseConnection.CreateConnection(
                this.environmentVariables.GetDatabaseSettings()
            );
            GetTaskById getTaskById = new GetTaskById(databaseExecutor, _globalAdapters.taskRepository);
            return await getTaskById.Call(id.Id);
        }

        [Route("update")]
        [HttpPost(Name = "UpdateTask")]
        public ResponseStatus<string> Update([FromBody] UpdateByIdRequest update)
        {
            DatabaseExecutor databaseExecutor = _globalAdapters.databaseConnection.CreateConnection(
                this.environmentVariables.GetDatabaseSettings()
            );
            UpdateTask updateTask = new UpdateTask(databaseExecutor, _globalAdapters.taskRepository);
            return updateTask.Call(
                new TaskModifier
                {

                    ColTexto= update.ColTexto,
                    ColDt=DateTime.Now
                },
                update.Id
            );
        }

        [Route("create")]
        [HttpPost(Name = "CreateTask")]
        public ResponseStatus<string> Create([FromBody] InsertRequest insertRequest)
        {
            DatabaseExecutor databaseExecutor = _globalAdapters.databaseConnection.CreateConnection(
                this.environmentVariables.GetDatabaseSettings()
            );
            CreateTask createTask = new CreateTask(databaseExecutor, _globalAdapters.taskRepository);
            return createTask.Call(
                new TaskModifier
                {
                    ColDt = DateTime.Now,
                    ColTexto = insertRequest.ColTexto
                }
            );
        }

        [Route("delete")]
        [HttpPost(Name = "DeleteTask")]
        public ResponseStatus<string> Delete([FromBody] GetByIdRequest id)
        {
            DatabaseExecutor databaseExecutor = _globalAdapters.databaseConnection.CreateConnection(
                this.environmentVariables.GetDatabaseSettings()
            );
            DeleteTask DeleteTask = new DeleteTask(databaseExecutor, _globalAdapters.taskRepository);
            return DeleteTask.Call(id.Id);
        }
    }
}
