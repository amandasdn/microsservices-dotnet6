using Microsoft.AspNetCore.Mvc;
using Shopping.Back.API.Model;

namespace Shopping.Back.API.Utility
{
    public static class ControllerExtensions
    {
        private const string MessageSuccessDefault = "Request made successfully.";
        private const string MessageErrorDefault = "An unexpected error has occurred.";

        /// <summary>
        /// Returns 200 Status Code
        /// </summary>
        public static IActionResult SetOk(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetSuccess(message ?? MessageSuccessDefault);

            return controllerBase.StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Returns 200 Status Code with a Content (T)
        /// </summary>
        public static IActionResult SetOk<T>(this ControllerBase controllerBase, T content, string message = null)
        {
            var result = new Result<T>(content);

            result.SetSuccess(message ?? MessageSuccessDefault);

            return controllerBase.StatusCode(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// Returns 500 Status Code
        /// </summary>
        public static IActionResult SetInternal(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetError(message ?? MessageErrorDefault);

            return controllerBase.StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
