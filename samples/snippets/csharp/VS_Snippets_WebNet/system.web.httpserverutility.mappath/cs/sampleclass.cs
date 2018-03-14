// <snippet2>
public class SampleClass
{
    public string GetFilePath()
    {
        return HttpContext.Current.Server.MapPath("/UploadedFiles");
    }
}
// </snippet2>