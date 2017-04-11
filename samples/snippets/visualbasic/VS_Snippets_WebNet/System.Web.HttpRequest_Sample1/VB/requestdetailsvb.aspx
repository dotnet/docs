<%--<snippet1>--%>
<%@ Page Language="VB" %>
<%@ import Namespace="System.Threading" %>
<%@ import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    '  NOTE: To use this sample, create a c:\temp\CS folder,
    '  add the ASP.NET account (in IIS 5.x <machinename>\ASPNET,
    '  in IIS 6.x NETWORK SERVICE), and give it write permissions
    '  to the folder.

    Private Const INFO_DIR As String = "c:\temp\VB\RequestDetails"
    Public Shared requestCount As Integer

    Private Sub Page_Load(sender As Object, e As System.EventArgs)

        ' Create a variable to use when iterating
        ' through the UserLanguages property.
        Dim langCount As Integer

        ' Create a counter to name the file.
        Dim requestNumber As Integer = _
          Interlocked.Increment(requestCount)

        ' Create the file to contain information about the request.
        Dim strFilePath As String = INFO_DIR & requestNumber.ToString() & ".txt"
        Dim sw As StreamWriter = File.CreateText(strFilePath)

        Try

' <snippet2>
            ' Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(DateTime.Now.ToString()))
            sw.WriteLine(Server.HtmlEncode(Request.CurrentExecutionFilePath))
            sw.WriteLine(Server.HtmlEncode(Request.ApplicationPath))
            sw.WriteLine(Server.HtmlEncode(Request.FilePath))
            sw.WriteLine(Server.HtmlEncode(Request.Path))
' </snippet2>

' <snippet3>
            ' Iterate through the Form collection and write
            ' the values to the file with HTML encoding.
            For Each s As String In Request.Form
                sw.WriteLine("Form: " & Server.HtmlEncode(s))
            Next s
' </snippet3>

' <snippet4>
            ' Write the PathInfo property value
            ' or a string if it is empty.
            If Request.PathInfo = String.Empty Then
                sw.WriteLine("The PathInfo property contains no information.")
            Else
                sw.WriteLine(Server.HtmlEncode(Request.PathInfo))
            End If
' </snippet4>

' <snippet5>
            ' Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalApplicationPath))
            sw.WriteLine(Server.HtmlEncode(Request.PhysicalPath))
            sw.WriteLine(Server.HtmlEncode(Request.RawUrl))
' </snippet5>

' <snippet6>
            ' Write a message to the file dependent upon
            ' the value of the TotalBytes property.
            If Request.TotalBytes > 1000 Then
                sw.WriteLine("The request is 1KB or greater")
            Else
                sw.WriteLine("The request is less than 1KB")
            End If
' </snippet6>

' <snippet7>
            ' Write request information to the file with HTML encoding.
            sw.WriteLine(Server.HtmlEncode(Request.RequestType))
            sw.WriteLine(Server.HtmlEncode(Request.UserHostAddress))
            sw.WriteLine(Server.HtmlEncode(Request.UserHostName))
            sw.WriteLine(Server.HtmlEncode(Request.HttpMethod))
' </snippet7>

' <snippet8>
            ' Iterate through the UserLanguages collection and
            ' write its HTML encoded values to the file.
            For langCount = 0 To Request.UserLanguages.Length - 1
                sw.WriteLine("User Language " & langCount.ToString() & _
                 ": " & Server.HtmlEncode( _
                     Request.UserLanguages(langCount)))
            Next
' </snippet8>

        Finally
            ' Close the stream to the file.
            sw.Close()
        End Try

        lblInfoSent.Text = _
         "Information about this request has been sent to a file."
    End Sub 'Page_Load



    Private Sub btnSendInfo_Click(sender As Object, e As System.EventArgs)
        lblInfoSent.Text = _
         "Hello, " & Server.HtmlEncode(txtBoxName.Text) & _
          ". You have created a new  request info file."
    End Sub 'btnSendInfo_Click

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        </p>
        <p>
            Enter your name here:
            <asp:TextBox id="txtBoxName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button id="btnSendInfo" onclick="btnSendInfo_Click" runat="server" Text="Click Here"></asp:Button>
        </p>
        <p>
            <asp:Label id="lblInfoSent" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
<%--</snippet1>--%>
