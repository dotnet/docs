<%-- <Snippet1> --%>
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' <Snippet2>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        System.Threading.Thread.Sleep(3000)
        Label1.Text = DateTime.Now.ToString()
    End Sub
    ' </Snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>UpdateProgress Tutorial</title>
    <%-- <Snippet4> --%>
    <style type="text/css">    
    #UpdatePanel1 {
      width:200px; height:100px;
      border: 1px solid gray;
    }
    #UpdateProgress1 {
      width:200px; background-color: #FFC080;
      bottom: 0%; left: 0px; position: absolute;
    }
    </style>
    <%-- </Snippet4> --%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <%-- <Snippet3> --%>
        <script language="javascript" type="text/javascript">
        <!-- 
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        function CancelAsyncPostBack() {
            if (prm.get_isInAsyncPostBack()) {
              prm.abortPostBack();
            }
        }
        // -->
        </script>
        <%-- </Snippet3> --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Panel rendered."></asp:Label><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="refresh" />
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                Processing...
                <%-- <Snippet5> --%>
                <input id="Button2" 
                       type="button" 
                       value="cancel" 
                       onclick="CancelAsyncPostBack()" />
                <%-- </Snippet5> --%>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
<%-- </Snippet1> --%>
