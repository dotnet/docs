<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> HtmlAnchor Constructor Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)
         
         ' Create a new HtmlAnchor control.
         Dim NewAnchorControl As New HtmlAnchor()

         ' Set the properties of the new HtmlAnchor control.
         NewAnchorControl.Name = "NewAnchorControl"
         NewAnchorControl.HRef = "http://www.microsoft.com"
         NewAnchorControl.Target = "_blank"
         NewAnchorControl.InnerHtml = "Microsoft Home"

         ' Add the new HtmlAnchor control to the Controls collection of the
         ' PlaceHolder control. 
         ControlContainer.Controls.Add(NewAnchorControl)

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlAnchor Constructor Example </h3>

      <asp:PlaceHolder ID="ControlContainer"
           runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->