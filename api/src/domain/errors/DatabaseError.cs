namespace errors
{
    public class DatabaseError : Exception
    {
        public DatabaseError()
        {}

        public DatabaseError(string message)
            : base(message)
        {}

        public DatabaseError(string message, Exception innerException)
            : base(message, innerException)
        {}
    }
}
