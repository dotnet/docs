<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void page_load(object sender, EventArgs e)
  {
    if (IsPostBack)
    {
      // Add code to process the Login.
    }

  }

  protected void Page_Init(object sender, EventArgs e)
  {

    // Pass "password" to make the HtmlInput control render a
    // password input type.
    HtmlInputPassword passwordText = new HtmlInputPassword();
    passwordText.MaxLength = 20;
    Placeholder1.Controls.Add(passwordText);

    // Pass "submit" to make the HtmlInput control render a
    // form submit button.
    HtmlInputSubmit submitButton = new HtmlInputSubmit("submit");
    submitButton.Value = "Log On to System";
    Placeholder2.Controls.Add(submitButton);

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" runat="server">

      <table cellpadding="2">
        <tr>
        <td>Password
            <asp:placeholder
                runat="server"
                id="Placeholder1" />
        </td></tr>
        <tr><td><asp:placeholder
                runat="server"
                id="Placeholder2" />
        </td></tr>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet1> -->