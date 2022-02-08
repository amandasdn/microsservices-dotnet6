using Newtonsoft.Json;

namespace Shopping.Back.API.Model
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class AResult : Interfaces.Model.IResult
    {
        [JsonProperty(Order = 1)]
        public DateTime Date
        {
            get => DateTime.UtcNow;
        }

        [JsonProperty(Order = 2)]
        public bool Success { get; private set; } = true;

        [JsonProperty(Order = 4)]
        public string Message { get; private set; }

        [JsonProperty(Order = 5)]
        public List<string> Errors { get; private set; }

        public void SetSuccess(string message = null)
        {
            Success = true;
            Message = message;
        }

        public void SetError(string message = null)
        {
            Success = false;
            Message = message;
        }

        public void AddErrorMessage(string error)
        {
            if (Errors == null)
            {
                Success = false;
                Errors = new List<string>();
            }

            Errors.Add(error);
        }
    }

    public class Result : AResult
    {
        public Result() { }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Result<T> : AResult
    {
        public Result(T content)
        {
            Content = content;
        }

        [JsonProperty(Order = 3)]
        public T Content { get; private set; }
    }
}
