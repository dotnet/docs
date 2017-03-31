<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<script language="VB" runat="server">
    Sub Page_Load(sender As Object, e As EventArgs)
        Message.InnerHtml = "<h4>" & "The select box's attributes collection contains:" & "</h4>"
        
        Dim keys As IEnumerator = Select1.Attributes.Keys.GetEnumerator()
        
        While keys.MoveNext()
            
            Dim key As String = CType(keys.Current, String)
            Message.InnerHtml &= key & "=" & Select1.Attributes(key) & "<br />"
        End While 
    End Sub 'Page_Load

</script>

<head runat="server">
    <title>" & "The select box's attributes collection contains:" & "</title>
</head>
<body>
<form id="Form1" runat="server">

   <h3>HtmlControl Attribute Collection Example</h3>

   Make a selection:

   <select id="Select1" 
           style="font: 12pt verdana;
                 background-color:yellow;
                 color:red;" 
           runat="server">

      <option>Item 1</option>
      <option>Item 2</option>
      <option>Item 3</option>

   </select>

   <br />

   <span id="Message" enableviewstate="false" runat="server" />
   
</form>
</body>
</html>
   
<!--</Snippet1>-->
