<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Page_Load(Object sender, EventArgs e)
      {

         // Create an HtmlSelect control.
         HtmlSelect selectlist = new HtmlSelect();

         // Populate the HtmlSelect control.
         for(int i=0; i<5; i++)
         {

            ListItem item = 
                new ListItem("Item " + i.ToString(), i.ToString());
            selectlist.Items.Add(item);

         }
 
         // Add the control to the Controls collection of the 
         // PlaceHolder control.
         Place.Controls.Clear();
         Place.Controls.Add(selectlist);
         
      }
  
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
