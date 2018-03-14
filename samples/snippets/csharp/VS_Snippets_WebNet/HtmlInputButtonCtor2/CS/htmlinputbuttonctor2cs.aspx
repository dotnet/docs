<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new HtmlInputButton control as a Submit button.
    HtmlInputButton button = new HtmlInputButton("submit");
    button.ID = "SubmitButton";
    button.Value = "Submit";

    // Create a new HtmlInputButton control as a Reset button.
    HtmlInputButton button2 = new HtmlInputButton("reset");
    button2.ID = "ResetButton";
    button2.Value = "Reset";

    // Add the controls to the Controls collection of the
    // PlaceHolder control.
    Place.Controls.Clear();
    Place.Controls.Add(button);
    Place.Controls.Add(button2);

  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlInputButton Constructor Example</title>
</head>
<body>
   <form id="form1" runat="server">
      <h3> HtmlInputButton Constructor Example </h3>

      <asp:Placeholder id="Place" 
           runat="server"/>

   </form>
</body>
</html>
<!-- </Snippet1> -->