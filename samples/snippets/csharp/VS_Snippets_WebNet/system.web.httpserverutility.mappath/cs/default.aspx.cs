// <snippet1>
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pathToFiles = Server.MapPath("/UploadedFiles");
    }
}
// </snippet1>