<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new HtmlGenericControl.
    HtmlGenericControl NewControl = new HtmlGenericControl();

    // Set the properties of the new HtmlGenericControl control.
    NewControl.ID = "NewControl";
    NewControl.InnerHtml = "This is a dynamically created HTML server control.";

    // Add the new HtmlGenericControl to the Controls collection of the
    // PlaceHolder control. 
    ControlContainer.Controls.Add(NewControl);

  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>HtmlGenericControl Constructor Example</title>
</head>
<body>

   <form id="form1" runat="server">
   <div>

      <h3> HtmlGenericControl Constructor Example </h3>

      <asp:PlaceHolder ID="ControlContainer"
                       runat="server"/>
   </div>
   </form>

</body>
</html>
<!--</Snippet1>-->