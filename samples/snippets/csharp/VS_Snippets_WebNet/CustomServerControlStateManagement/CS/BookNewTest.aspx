<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="Samples.AspNet.CS" %>
<!-- <Snippet2> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Button_Click(object sender, EventArgs e)
  {
    BookNew1.Author.FirstName = "Bob";
    BookNew1.Author.LastName = "Kelly";
    BookNew1.Title = "Contoso Stories";
    BookNew1.Price = 39.95M;
    Button1.Visible = false;
  }  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      BookNew test page
    </title>
  </head>
  <body>
    <form id="Form1" runat="server">
      <aspSample:BookNew ID="BookNew1" Runat="server" 
        BorderStyle="Solid" BorderWidth="1px" Title="Tailspin Stories"
        CurrencySymbol="$" BackColor="#FFE0C0" Font-Names="Tahoma" 
        Price="16" BookType="Fiction">
        <Author FirstName="Judy" LastName="Lew" />
      </aspSample:BookNew>
      <br />
      <asp:Button ID="Button1" OnClick="Button_Click" 
        Runat="server" Text="Change" />
      <asp:Button ID="Button2" Runat="server" Text="Refresh" />
      <br />
      <br />
      <asp:HyperLink ID="Hyperlink1" NavigateUrl="BookNewTest.aspx" 
        Runat="server">
        Reload Page</asp:HyperLink>
    </form>
  </body>
</html>
<!-- </Snippet2> -->
