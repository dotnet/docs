<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' This is a supporting file for TempControl_Samples1.vb.
    ' <Snippet3>
    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        ' Obtain a UserControl object MyControl from the
        ' user control file TempControl_Samples1.ascx.vb
        Dim myControl1 As MyControl = CType(LoadControl("TempControl_Samples1.vb.ascx"), MyControl)
        Controls.Add(myControl1)
    End Sub
    ' </Snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:placeholder id="PlaceHolder1"
          runat="Server">
        </asp:placeholder>     

    </div>
    </form>
</body>
</html>
