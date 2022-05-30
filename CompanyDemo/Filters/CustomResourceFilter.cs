using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyDemo.Filters;

public class CustomResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {

    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (!BrowserProperties.IsGoodBrowser(context.HttpContext.Request))
        {
            context.Result = new JsonResult(new {Error = "Unsupported Browser"}){StatusCode = 400};
        }
    }
}
