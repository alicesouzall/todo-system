namespace models
{
    public class ResponseStatus<T> where T : class
    {
        public ResponseStatus(
            int statusCode, string message, T? data = null
        )
        {
            this.Status = statusCode;
            this.Message = message;
            this.Data = data;
        }
        public int Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
