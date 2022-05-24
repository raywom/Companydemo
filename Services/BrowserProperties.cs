namespace CompanyDemo.Repository;

public class BrowserProperties
{
    public static bool IsGoodBrowser(HttpRequest? httpRequest)
    {
        if (httpRequest == null || string.IsNullOrWhiteSpace(httpRequest.Headers["User-Agent"].ToString()))
        {
            return false;
        }
        
        var userAgent = httpRequest.Headers["sec-ch-ua"].ToString();
        if (userAgent.Contains("Edge"))
        {
            return false;
        }
        
        return true;
    }
}