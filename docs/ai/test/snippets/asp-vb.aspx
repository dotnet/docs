<!-- <Snippet1> -->
<%@ Page Language="VB" %>

    <!DOCTYPE html
        PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' <Snippet2>
    Dim sb As New StringBuilder()
    Dim pathstring As String = Context.Request.FilePath.ToString()
        sb.Append("Current file path = " & pathstring & "<br />")
        sb.Append("File name = " & VirtualPathUtility.GetFileName(pathstring).ToString() & "<br />")
        sb.Append("File extension = " & VirtualPathUtility.GetExtension(pathstring).ToString() & "<br />")
        sb.Append("Directory = " & VirtualPathUtility.GetDirectory(pathstring).ToString() & "<br />")
        Response.Write(sb.ToString())
        ' </Snippet2>

        ' <Snippet3>
    Dim sb2 As New StringBuilder()
    Dim pathstring1 As String = Context.Request.CurrentExecutionFilePath.ToString()
        sb2.Append("Current Executing File Path = " & pathstring1.ToString() & "<br />")
        sb2.Append("Is Absolute = " & VirtualPathUtility.IsAbsolute(pathstring1).ToString() & "<br />")
        sb2.Append("Is AppRelative = " & VirtualPathUtility.IsAppRelative(pathstring1).ToString() & "<br />")
        sb2.Append("Make AppRelative = " & VirtualPathUtility.ToAppRelative(pathstring1).ToString() & "<br />")
        Response.Write(sb2.ToString())
        ' </Snippet3>

  End Sub

    </script>

    </html>
    <!-- </Snippet1> -->
