using Microsoft.AspNetCore.Mvc;
using Shopping.Back.API.Model;

namespace Shopping.Back.API.Utility
{
    public static class ControllerExtensions
    {
        private const string MessageSuccessDefault = "Request made successfully.";
        private const string MessageErrorDefault = "An unexpected error has occurred.";

        /// <summary>
        /// Returns OK (Status Code: 200)
        /// </summary>
        public static IActionResult SetOk(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetSuccess(message ?? MessageSuccessDefault);

            return controllerBase.StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Returns OK (Status Code: 200) - With a Content (T)
        /// </summary>
        public static IActionResult SetOk<T>(this ControllerBase controllerBase, T content, string message = null)
        {
            var result = new Result<T>(content);

            result.SetSuccess(message ?? MessageSuccessDefault);

            return controllerBase.StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Returns Bad Request (Status Code: 400)
        /// </summary>
        public static IActionResult SetBadRequest(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetError(message ?? MessageErrorDefault);

            return controllerBase.StatusCode(StatusCodes.Status400BadRequest, result);
        }

        /// <summary>
        /// Returns Not Found (Status Code: 404)
        /// </summary>
        public static IActionResult SetNotFound(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetError(message ?? MessageErrorDefault);

            return controllerBase.StatusCode(StatusCodes.Status404NotFound, result);
        }

        /// <summary>
        /// Returns Internal Server Error (Status Code: 500)
        /// </summary>
        public static IActionResult SetInternalServerError(this ControllerBase controllerBase, string message = null)
        {
            var result = new Result();

            result.SetError(message ?? MessageErrorDefault);

            return controllerBase.StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
