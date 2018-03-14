// <snippet1>
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string destinationURL = "http://www.contoso.com/default.aspx?user=test";

        NextPage.NavigateUrl = "~/Finish?url=" + Server.UrlEncode(destinationURL);
    }             
}
// </snippet1>  