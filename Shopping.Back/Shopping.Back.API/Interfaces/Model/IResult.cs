namespace Shopping.Back.API.Interfaces.Model
{
    public interface IResult
    {
        public void SetSuccess(string message = null);

        public void SetError(string message = null);

        public void AddErrorMessage(string error);
    }
}
