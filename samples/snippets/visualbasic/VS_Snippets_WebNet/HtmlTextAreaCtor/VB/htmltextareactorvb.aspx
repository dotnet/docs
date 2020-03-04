<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create an HtmlTextArea control.
    Dim area As HtmlTextArea = New HtmlTextArea()
    area.ID = "TextArea1"
    area.Value = "Enter text here."
    area.Cols = 20
    area.Rows = 5
 
    ' Add the control to the Controls collection of the 
    ' PlaceHolder control.
    Place.Controls.Clear()
    Place.Controls.Add(area)
         
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTextArea Constructor Example</title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3>HtmlTextArea Constructor Example</h3> 
  
      <asp:PlaceHolder id="Place" 
                       runat="server"/>
  
   </form>

</body>
</html>
<!--</Snippet1>-->
