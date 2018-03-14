// <snippet1>
public partial class _Default : Page
{        
    protected void Page_Load(object sender, EventArgs e)
    {
        Result.Text = Server.HtmlEncode("<script>unsafe</script>");      
    } 
}
// </snippet1> 