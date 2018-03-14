<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
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
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanel Error Handling Example</title>
    <style type="text/css">
    #UpdatePanel1 {
      width: 200px; height: 50px;
      border: solid 1px gray;
    }
    #AlertDiv{
    left: 40%; top: 40%;
    position: absolute; width: 200px;
    padding: 12px; 
    border: #000000 1px solid;
    background-color: white; 
    text-align: left;
    visibility: hidden;
    z-index: 99;
    }
    #AlertButtons{
    position: absolute; right: 5%; bottom: 5%;
    }
    </style>
</head>
<body id="bodytag">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" 
            OnAsyncPostBackError="ScriptManager1_AsyncPostBackError" runat="server" >
            <Scripts>
            <asp:ScriptReference Path="ErrorHandling.js" />
            </Scripts>
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
            <div id="AlertDiv">
                <div id="AlertMessage">
                </div>
                <br />
                <div id="AlertButtons">
                    <input id="OKButton" type="button" value="OK" runat="server" onclick="ClearErrorState()" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->