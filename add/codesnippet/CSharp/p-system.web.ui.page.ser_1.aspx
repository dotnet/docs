  protected void Page_Error(object sender, EventArgs e)
  {
    StringBuilder sb = new StringBuilder();
    sb.Append("URL that caused the error: <br/>");
    sb.Append(Server.HtmlEncode(Request.Url.ToString()));
    sb.Append("<br/><br/>");
    sb.Append("Error message: <br/>");
    sb.Append(Server.GetLastError().ToString());
    Response.Write(sb.ToString());
    Server.ClearError();
  }