<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_Load(object sender, EventArgs e)
  {
    // <Snippet2> 
    StringBuilder sb = new StringBuilder();
    String pathstring = Context.Request.FilePath.ToString();
    sb.Append("Current file path = " + pathstring + "<br />");
    sb.Append("File name = " + VirtualPathUtility.GetFileName(pathstring).ToString() + "<br />");
    sb.Append("File extension = " + VirtualPathUtility.GetExtension(pathstring).ToString() + "<br />");
    sb.Append("Directory = " + VirtualPathUtility.GetDirectory(pathstring).ToString() + "<br />");
    Response.Write(sb.ToString());
    // </Snippet2>
    
    // <Snippet3>
    StringBuilder sb2 = new StringBuilder();
    String pathstring1 = Context.Request.CurrentExecutionFilePath.ToString();
    sb2.Append("Current Executing File Path = " + pathstring1.ToString() + "<br />");
    sb2.Append("Is Absolute = " + VirtualPathUtility.IsAbsolute(pathstring1).ToString() + "<br />");
    sb2.Append("Is AppRelative = " + VirtualPathUtility.IsAppRelative(pathstring1).ToString() + "<br />");
    sb2.Append("Make AppRelative = " + VirtualPathUtility.ToAppRelative(pathstring1).ToString() + "<br />");
    Response.Write(sb2.ToString());
    // </Snippet3>
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>VirtualPathUtility Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
