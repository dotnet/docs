<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputCheckBox Constructor Sample</title>
<script language="C#" runat="server">
       
       
       // Create a new instance of HtmlInputCheckBox.
       HtmlInputCheckBox cb = new HtmlInputCheckBox();

       // Create a new instance of Label.
       Label label = new Label();
       
       // Create a new instance of Button.
       HtmlButton b = new HtmlButton();

       protected void Page_Load(object sender, EventArgs e)
       {
           // Define attributes of Button and Label.
           b.InnerText = "Click";
           label.Text = "checkbox";
           
           // Add controls to placeholder
           Container.Controls.Add(cb);
           Container.Controls.Add(label);
           Container.Controls.Add(new LiteralControl("<br />"));
           Container.Controls.Add(b);
           
           // Add EventHandler
           b.ServerClick += new EventHandler(button_ServerClick);

       }
       
       void button_ServerClick(object sender, EventArgs e)
       {
           switch (cb.Checked)
           {
               case true:
                   Message.InnerHtml = "Checkbox is checked.";
                   break;

               default:
                   Message.InnerHtml = "Checkbox is not checked.";
                   break;
           }
       }
</script>

</head>

<body>

   <h3>HtmlInputCheckBox Constructor Sample</h3>

   <form id="form1" runat="server">

      <asp:PlaceHolder id="Container" runat="server"></asp:PlaceHolder>    
       
      <br />
      <span id="Message" 
            style="color:red" 
            runat="server"/>

   </form>

</body>
</html>
   
<!--</Snippet1>-->
