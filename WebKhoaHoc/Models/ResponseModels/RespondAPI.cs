namespace WebKhoaHoc.Models.ResponseModels
{
    public class RespondAPI<T> where T : class
    {
        public ResultRespond Result { get; set; }
        public string Code { get; set; } = "00";
        public string Message { get; set; }
        public T Data { get; set; }
        public RespondAPI()
        {

        }
        public RespondAPI(ResultRespond Result, string Code, string Message, T Data)
        {
            this.Result = Result;
            this.Code = Code;
            this.Message = Message;
            this.Data = Data;
        }
    }

    public enum ResultRespond
    {
        Error, Succeeded, Failed, NotFound, Duplication
    }
}
