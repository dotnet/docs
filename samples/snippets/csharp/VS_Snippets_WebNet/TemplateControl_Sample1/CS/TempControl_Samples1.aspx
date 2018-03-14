<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    // This is a supporting file for TempControl_Samples1.cs.
    // <Snippet3>
    void Page_Init(object sender, System.EventArgs e)
    {
        // Instantiate the UserControl object
        MyControl myControl1 =
            (MyControl)LoadControl("TempControl_Samples1.ascx.cs");
        PlaceHolder1.Controls.Add(myControl1);
    }
    // </Snippet3>
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
