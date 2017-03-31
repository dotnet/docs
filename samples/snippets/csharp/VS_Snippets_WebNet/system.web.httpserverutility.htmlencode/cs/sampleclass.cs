// <snippet2>
public class SampleClass
{
    public string GetEncodedText()
    {
        return HttpContext.Current.Server.HtmlEncode("<script>unsafe</script>");
    }
}
// </snippet2>