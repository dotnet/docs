<%-- <Snippet1> --%>
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' <Snippet2>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim a As Int32
            a = Int32.Parse(TextBox1.Text)
            Dim b As Int32
            b = Int32.Parse(TextBox2.Text)
            Dim res As Int32 = a / b
            Label1.Text = res.ToString()
        Catch ex As Exception
            If (TextBox1.Text.Length > 0 AndAlso TextBox2.Text.Length > 0) Then
                ex.Data("ExtraInfo") = " You can't divide " & _
                  TextBox1.Text & " by " & TextBox2.Text & "."
            End If
            Throw ex
        End Try

    End Sub
    ' </Snippet2>
    ' <Snippet3>
    Protected Sub ScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs)
        If (e.Exception.Data("ExtraInfo") <> Nothing) Then
            ScriptManager1.AsyncPostBackErrorMessage = _
               e.Exception.Message & _
               e.Exception.Data("ExtraInfo").ToString()
        Else
            ScriptManager1.AsyncPostBackErrorMessage = _
               "An unspecified error occurred."
        End If
    End Sub
    ' </Snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partial-Page Update Error Handling Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" OnAsyncPostBackError="ScriptManager1_AsyncPostBackError">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="39px"></asp:TextBox>
                    /
                    <asp:TextBox ID="TextBox2" runat="server" Width="39px"></asp:TextBox>
                    =
                    <asp:Label ID="Label1" runat="server"></asp:Label><br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="calculate" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>
