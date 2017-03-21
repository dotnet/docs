private void Page_Load(Object sender, EventArgs e)
{
    System.IO.StringWriter writer = new System.IO.StringWriter();
    Server.Execute("Login.aspx", writer, true);
    Response.Write("<h3>Please Login:</h3><br />" + writer.ToString());
} 