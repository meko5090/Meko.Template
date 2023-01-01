namespace Meko.Filters;

using System.Net;
using Meko.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ModelStateFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors);

            var firstError = errors.Select(v => v.ErrorMessage).First();

            if (string.IsNullOrWhiteSpace(firstError))
            {
                firstError = errors.Select(v => v.Exception?.Message).First();
            }

            var responseObj = new ErrorDetails(
                description: firstError ?? "Validation error",
                code: ErrorCodes.Generic.RequestValidationError
            );

            context.Result = new JsonResult(responseObj)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
