using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyDemo.Filters;

public class CustomResultFilter : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("Time", DateTime.Now.ToString(CultureInfo.CurrentCulture));

        base.OnResultExecuting(context);
    }
}