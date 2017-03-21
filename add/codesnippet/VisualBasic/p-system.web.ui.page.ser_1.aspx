  Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs)
    
    Dim sb As New StringBuilder()
    sb.Append("URL that caused the error: <br/>")
    sb.Append(Server.HtmlEncode(Request.Url.ToString()))
    sb.Append("<br/><br/>")
    sb.Append("Error message: <br/>")
    sb.Append(Server.GetLastError().ToString())
    Response.Write(sb.ToString())
    Server.ClearError()    

  End Sub