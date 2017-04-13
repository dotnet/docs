// <snippet1>
public partial class _Default : Page
{       
    protected void Page_Load(object sender, EventArgs e)
    {
        string returnUrl = Server.UrlDecode(Request.QueryString["url"]);
        ReturnPage.NavigateUrl = returnUrl;
    }
}
// </snippet1>