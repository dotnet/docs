<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Init(object sender, EventArgs e)
  {
    
    string reference = Page.ClientScript.GetPostBackEventReference
      (new PostBackOptions(this, "", "http://www.wingtiptoys.com", false, true, false, true, false, ""));
    Label1.Attributes.Add("onmouseover", reference);
    
  } 

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ActionUrl Example Page</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <h3>PostBackOptions ActionUrl Example</h3>
      <asp:Label runat="server" 
        id="Label1" >
        Placing the mouse pointer on this label will cause a cross-page post to occur.
      </asp:Label>
    </form>
  </body>
</html>
<!-- </snippet1> -->
