namespace BasicERP.Utilities.Helpers
{
    public class Result<T>
    {
        public string Message { get; set; }
        public T? Data { get; set; }

        public Result(string message, T data)
        {
            Message = message;
            Data = data;
        }

        public Result(string message)
        {
            Message = message;
        }
    }
}
