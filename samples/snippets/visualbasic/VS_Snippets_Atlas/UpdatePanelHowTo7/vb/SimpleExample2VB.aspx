<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    ' <Snippet6>
    Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        System.Threading.Thread.Sleep(3000)
        Label1.Text = "Last successful postback to server at " & DateTime.Now.ToString()
    End Sub
    ' </Snippet6>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Canceling an Existing Postback</title>
    <style type="text/css">
    body {
        font-family: Tahoma;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <script type="text/javascript" language="Javascript">
    
    // <Snippet4>
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(InitializeRequest);
    // </Snippet4>
    
    // <Snippet5>
    function InitializeRequest(sender, args)
    {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm.get_isInAsyncPostBack() & args.get_postBackElement().id == 'CancelPostBack') {
            prm.abortPostBack();
        }    
    }
    // </Snippet5>

    </script>
    <!-- <Snippet3> -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <fieldset>
      <legend>UpdatePanel</legend>
      <asp:Label ID="Label1" runat="server"/> <br />
      Last action: <%=DateTime.Now.ToString() %>
      <br />
      <asp:Button ID="RefreshButton" Text="Refresh" runat="server" OnClick="RefreshButton_Click" />
      &nbsp;
      <asp:Button ID="CancelPostBack" Text="Cancel" runat="server" />
      </fieldset>
    </ContentTemplate>
    </asp:UpdatePanel>
    <!-- </Snippet3> -->
    </div>
    </form>
</body>
</html>
