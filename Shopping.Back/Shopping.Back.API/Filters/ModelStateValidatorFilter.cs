using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping.Back.API.Model;

namespace Shopping.Back.API.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new Result();

                var errors = context.ModelState.Values.SelectMany(x => x.Errors);

                foreach (var e in errors)
                {
                    result.AddErrorMessage(e.ErrorMessage);
                }

                context.Result = new BadRequestObjectResult(result);
            }
        }
    }
}
