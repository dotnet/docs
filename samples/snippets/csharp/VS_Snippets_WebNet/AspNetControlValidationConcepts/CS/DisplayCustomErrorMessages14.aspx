<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Display Custom Error Messages for ASP.NET Server Controls</title>
</head>

<script runat="server">
    private void Page_Load()
    {
      //<Snippet14>
      if (this.IsPostBack)
        {
            ValidationControl1.Validate();
            if (ValidationControl1.IsValid)
            {
                lblOutput.Text = "All entries are valid.";
            }
            else
            {
                lblOutput.Text = "There are one or more invalid entries.";
            }
        }
        //</Snippet14>
    }
   
    
</script>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblOutput" runat="server" AssociatedControlID="TextBox1"></asp:Label>
      <asp:TextBox id="TextBox1" runat="server" ></asp:TextBox>
      <asp:RequiredFieldValidator id="ValidationControl1"  ControlToValidate="TextBox1" runat="server"></asp:RequiredFieldValidator>
    </div>
    </form>
</body>
</html>
