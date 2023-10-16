using services;
using models;
using Npgsql;

namespace infra
{
    public class TaskRepositoryPostgres : TaskRepository
    {
        private async Task<List<TaskTable>> returnData(NpgsqlDataReader reader)
        {
            List<TaskTable> rows = new List<TaskTable>();
            while (await reader.ReadAsync())
            {

                TaskTable taskTable = new TaskTable
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    ColDt = reader.GetDateTime(reader.GetOrdinal("col_dt")).ToString("yyyy-MM-dd:HH:mm:ss"),
                    ColTexto = reader.GetString(reader.GetOrdinal("col_texto"))
                };
                rows.Add(taskTable);
            }
            return rows;
        }

        public async void CreateTask(DatabaseExecutor databaseExecutor, TaskModifier taskModifier)
        {
            NpgsqlDataReader? reader = await databaseExecutor.ExecuteQuery<NpgsqlDataReader, object>(
                "INSERT INTO TB01 (col_dt, col_texto) VALUES ($1, $2)",
                new List<object>(){taskModifier.ColDt, taskModifier.ColTexto}
            );
        }

        public async void DeleteTask(DatabaseExecutor databaseExecutor, int Id)
        {
            NpgsqlDataReader? reader = await databaseExecutor.ExecuteQuery<NpgsqlDataReader, int>(
                "DELETE FROM TB01 WHERE id = $1",
                new List<int>(){Id}
            );
        }

        public async void UpdateTask(DatabaseExecutor databaseExecutor, TaskModifier taskModifier, int Id)
        {
            NpgsqlDataReader? reader = await databaseExecutor.ExecuteQuery<NpgsqlDataReader, object>(
                "UPDATE TB01 SET col_dt = $1, col_texto = $2 WHERE id = $3",
                new List<object>(){taskModifier.ColDt, taskModifier.ColTexto, Id}
            );
        }

        public async Task<IEnumerable<TaskTable>?> GetAllTasks(DatabaseExecutor databaseExecutor)
        {
            NpgsqlDataReader? reader = await databaseExecutor.ExecuteQuery<NpgsqlDataReader, string>(
                "SELECT * FROM TB01 ORDER BY col_dt DESC LIMIT 10"
            );
            if (reader != null)
            {
                return await this.returnData(reader);
            }
            else
            {
                return null;
            }
        }

        public async Task<TaskTable?> GetTaskById(DatabaseExecutor databaseExecutor, int Id)
        {
            NpgsqlDataReader? reader = await databaseExecutor.ExecuteQuery<NpgsqlDataReader, int>(
                "SELECT * FROM TB01 WHERE ID = $1",
                new List<int>(){Id}
            );

            if (reader != null)
            {
                List<TaskTable> returnData = await this.returnData(reader);
                return returnData[0];
            }
            else
            {
                return null;
            }
        }
    }
}
