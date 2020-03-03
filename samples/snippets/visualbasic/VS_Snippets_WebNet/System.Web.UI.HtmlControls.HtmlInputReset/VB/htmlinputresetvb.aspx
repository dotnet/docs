<!--<Snippet1>-->

<%@ Page Language="VB" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Define an HtmlInputReset button using the default constructor.
    Dim reset1 As New HtmlInputReset()
    reset1.ID = "ResetButton1"
    reset1.Value = "Reset 1"
       
    ' Define an HtmlInputReset button as type "reset".
    Dim reset2 As New HtmlInputReset("reset")
    reset2.ID = "ResetButton2"
    reset2.Value = "Reset 2"

    ' Define an HtmlInputReset button as custom type "custom".
    ' This is not a valid HTML input type so a standared input
    ' field will be displayed.
    Dim reset3 As New HtmlInputReset("custom")
    reset3.ID = "ResetButton3"
    reset3.Value = "Reset 3"
       
    ' Clear the PlaceHolder control and add the Reset buttons to it.
    PlaceHolder.Controls.Clear()
    PlaceHolder.Controls.Add(reset1)
    PlaceHolder.Controls.Add(New LiteralControl("<br />"))
    PlaceHolder.Controls.Add(reset2)
    PlaceHolder.Controls.Add(New LiteralControl("<br />"))
    PlaceHolder.Controls.Add(reset3)
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>

  <title>HtmlInputReset Example</title>

</head>

<body>
    <form id="form1" runat="server">

      <h3> HtmlInputReset Example </h3>

      <asp:PlaceHolder id="PlaceHolder"
                       runat="server">
      </asp:PlaceHolder>
      
      <br />

      Change the text in the input field and then click 
      "Reset 1" or "Reset 2" to change it back to its initial
      value.

    </form>
</body>

</html>
<!--</Snippet1>-->