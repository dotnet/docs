// <snippet2>
public class SampleClass
{
    public string GetUrl()
    {
        string destinationURL = "http://www.contoso.com/default.aspx?user=test";

        return "~/Finish?url=" + HttpContext.Current.Server.UrlEncode(destinationURL);
    }
}
// </snippet2>