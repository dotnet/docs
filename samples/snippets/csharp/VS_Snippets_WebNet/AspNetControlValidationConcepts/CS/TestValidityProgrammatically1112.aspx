<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Test Validity Programmatically for ASP.NET Server Controls</title>
</head>
<script runat="server">
    //<Snippet11>
    void Button1_Click(object sender, System.EventArgs e)
    {
        if (IsValid)
        {
            // Perform database updates or other logic here.
        }
    }
   //</Snippet11>

    private void Page_Loaod()
    {
        //<Snippet12>
        if (this.IsPostBack)
        {
            this.Validate();
            if (!this.IsValid)
            {
                string msg = "";
                // Loop through all validation controls to see which
                // generated the errors.
                foreach (IValidator aValidator in this.Validators)
                {
                    if (!aValidator.IsValid)
                    {
                        msg += "<br />" + aValidator.ErrorMessage;
                    }
                }
                Label1.Text = msg;
            }
        }
        //</Snippet12>
    }
</script>

<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button id="Button1" runat="server" />
      <asp:Label id="Label1" runat="server" AssociatedControlID="Button1"></asp:Label>
    </div>
    </form>
</body>
</html>
