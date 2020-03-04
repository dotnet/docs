<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create an HtmlSelect control.
         Dim selectlist As HtmlSelect = New HtmlSelect()

         ' Populate the HtmlSelect control.

         Dim i As Integer
         For i=0 to 4

            Dim item As ListItem = _
                New ListItem("Item " + i.ToString(), i.ToString())
            selectlist.Items.Add(item)

         Next i
 
         ' Add the control to the Controls collection of the 
         ' PlaceHolder control.
         Place.Controls.Clear()
         Place.Controls.Add(selectlist)
         
      End Sub
  
   </script>
  
<head runat="server">
    <title> HtmlSelect Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlSelect Constructor Example </h3> 
  
      <asp:PlaceHolder id="Place" runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
