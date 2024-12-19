namespace FinTrack.Dtos
{
    public class ResponseData<T>
    {
        public T Data { get; set; } = default!;
        public string Message { get; set; } = default!;
        public int Code { get; set; } = default!;
        public ResponseData(T data,string message, int code) 
        {
            Data = data;
            Message = message;
            Code = code;
        }
    }
}
