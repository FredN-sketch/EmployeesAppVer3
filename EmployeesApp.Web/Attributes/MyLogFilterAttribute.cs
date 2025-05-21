using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesApp.Web.Attributes;

public class MyLogFilterAttribute(ILogger<MyLogFilterAttribute> logger) : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Log the action method name and parameters
        var actionName = context.ActionDescriptor.DisplayName;
        var parameters = context.ActionArguments;
        logger.LogInformation($"Action: {actionName}, Parameters: {string.Join(", ", parameters.Select(p => $"{p.Key}: {p.Value}"))}");
        Console.WriteLine($"Action: {actionName}, Parameters: {string.Join(", ", parameters.Select(p => $"{p.Key}: {p.Value}"))}");
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Log the result of the action method
        var result = context.Result;
        Console.WriteLine($"Result: {result?.ToString()}");
    }
}
