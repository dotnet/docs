<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new HtmlInputButton control.
    Dim NewButtonControl As New HtmlInputButton()

    ' Set the properties of the new HtmlInputButton control.
    NewButtonControl.ID = "NewButtonControl"
    NewButtonControl.Value = "Click Me"

    ' Create an EventHandler delegate for the method you want to handle the event
    ' and then add it to the list of methods called when the event is raised.
    AddHandler NewButtonControl.ServerClick, AddressOf Button_Click

    ' Add the new HtmlInputButton control to the Controls collection of the
    ' PlaceHolder control. 
    ControlContainer.Controls.Add(NewButtonControl)

  End Sub


  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Display a simple message. 
    Message.InnerHtml = "Thank you for clicking the button."

  End Sub

</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HtmlInputButton ServerClick Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3> HtmlInputButton ServerClick Example </h3>

      <asp:PlaceHolder ID="ControlContainer"
           runat="server"/>

      <br /><br />
 
      <span id="Message"
            runat="server"/>

   </form>

</body>
</html>
<!-- </Snippet1> -->