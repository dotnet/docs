<!--<Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Attributes Property of a Web Control</title>
<script language="c#" runat="server">

       void Page_Load(Object sender, EventArgs e) {
          TextBox1.Attributes["onblur"]="javascript:alert('Hello! Focus lost from text box!!');";    
       }
   </script>

</head>
<body>
   <h3>Attributes Property of a Web Control</h3>
<form id="form1" runat="server">

   <asp:TextBox id="TextBox1" columns="54" 
    Text="Click here and then tab out of this text box" 
    runat="server"/>  

</form>
</body>
</html>
   
<!--</Snippet1>-->
