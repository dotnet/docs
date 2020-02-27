<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputCheckBox Constructor Sample</title>
<script language="VB" runat="server">

       ' Create a new instance of HtmlInputCheckBox.
       Dim cb As New HtmlInputCheckBox()

       ' Create a new instance of Label.
       Dim label As New Label()
       
       ' Create a new instance of Button.
       Dim b As New HtmlButton()
       
       Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
           
           ' Define attributes of Button and Label.
           b.InnerText = "Click"
           label.Text = "checkbox"
           
           ' Add controls to placeholder
           Container.Controls.Add(cb)
           Container.Controls.Add(label)
           Container.Controls.Add(New LiteralControl("<br />"))
           Container.Controls.Add(b)
           
           ' Add EventHandler
           AddHandler b.ServerClick, AddressOf button_ServerClick
          
       End Sub
       
       Sub button_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
           Select Case cb.Checked
               Case True
                   Message.InnerHtml = "Checkbox is checked."
        
               Case Else
                   Message.InnerHtml = "Checkbox is not checked."
           End Select

       End Sub

</script>

</head>

<body>

   <h3>HtmlInputCheckBox Constructor Sample</h3>

   <form id="Form1" runat="server">

      <asp:PlaceHolder id="Container" runat="server"></asp:PlaceHolder>    
       
      <br />
      <span id="Message" 
            style="color:red" 
            runat="server"/>

   </form>

</body>
</html>
   
<!--</Snippet1>-->
