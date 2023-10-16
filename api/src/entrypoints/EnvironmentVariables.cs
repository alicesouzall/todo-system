using models;

namespace entrypoints
{
    public class EnvironmentVariables
    {
        private readonly IConfiguration _configuration;
        public EnvironmentVariables(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DatabaseSettings GetDatabaseSettings()
        {
            string? Host = _configuration["DatabaseSettings:Host"];
            string? User = _configuration["DatabaseSettings:User"];
            string? Password = _configuration["DatabaseSettings:Password"];
            string? Name = _configuration["DatabaseSettings:Name"];
            return new DatabaseSettings
            {
                Host= Host != null ? Host.ToString() : "127.0.0.1",
                User= User != null ? User.ToString() : "postgres",
                Password= Password != null ? Password.ToString() : "081519",
                Name= Name != null ?  Name.ToString() : "crud_project"
            };
        }
    }
}
