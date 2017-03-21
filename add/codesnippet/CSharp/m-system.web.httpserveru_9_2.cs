public class SampleClass
{
    public string RetrievePassedUrl()
    {
        return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["url"]);
    }
}