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
    HtmlInputText userText = new HtmlInputText();
    userText.MaxLength = 20;
    Placeholder1.Controls.Add(userText);

    HtmlInputPassword passwordText = new HtmlInputPassword();
    passwordText.MaxLength = 20;
    Placeholder2.Controls.Add(passwordText);

    HtmlInputSubmit submitButton = new HtmlInputSubmit();
    submitButton.Value = "Submit";
    Placeholder3.Controls.Add(submitButton);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <table cellpadding="2">
        <tr>
        <td>User Name
            <asp:placeholder
                runat="server"
                id="Placeholder1" />
        </td></tr>
        <tr>
        <td>Password
            <asp:placeholder
                runat="server"
                id="Placeholder2" />
        </td></tr>
        <tr><td><asp:placeholder
                runat="server"
                id="Placeholder3" />
        </td></tr>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet1> -->