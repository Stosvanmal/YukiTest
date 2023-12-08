using System.Net;

namespace YukiTest.Presentation.Bases
{
    public struct Result<T>
    {
        public class ResultError
        {
            public HttpStatusCode StatusCode { get; set; }

            public string Title { get; set; }

            public string Detail { get; set; }

            public List<string> DetailList { get; set; }

            public Dictionary<string, object> Errors { get; set; }
        }

        private T _value;

        private bool _succeeded;

        private ResultError _error;

        public bool Succeeded => _succeeded;

        public ResultError Error => _error;

        public T Value => _value;

        public static Result<T> Build(T value)
        {
            Result<T> result = default(Result<T>);
            result._value = value;
            result._succeeded = true;
            result._error = new ResultError
            {
                StatusCode = HttpStatusCode.BadRequest,
                Title = null
            };
            return result;
        }     
        public static implicit operator bool(Result<T> result)
        {
            return result._succeeded;
        }
    }
}
