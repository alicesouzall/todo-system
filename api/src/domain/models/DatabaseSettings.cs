namespace models
{
    public class DatabaseSettings
    {
        public DatabaseSettings()
        {
            Host = "";
            Name = "";
            User = "";
            Password = "";
        }
        public string Host { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
