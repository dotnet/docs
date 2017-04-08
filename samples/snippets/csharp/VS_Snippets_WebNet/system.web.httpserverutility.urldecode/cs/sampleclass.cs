// <snippet2>
public class SampleClass
{
    public string RetrievePassedUrl()
    {
        return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["url"]);
    }
}
// </snippet2>