using CompanyDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyDemo.Filters;

public class CustomResourceFilter : Attribute, IResourceFilter
{ 
    private readonly string[] _headers;

    public CustomResourceFilter(params string[] headers)
    {
        _headers = headers;
    }
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
