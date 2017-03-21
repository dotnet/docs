public class SampleClass
{
    public string GetFilePath()
    {
        return HttpContext.Current.Server.MapPath("/UploadedFiles");
    }
}