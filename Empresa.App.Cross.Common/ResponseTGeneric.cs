namespace Empresa.App.Cross.Common
{
    public class ResponseTGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        //public IEnumerable<ValidationFailure>? ListErrors { get; set; }
        public IEnumerable<string>? ListErrors { get; set; }
    }
}
