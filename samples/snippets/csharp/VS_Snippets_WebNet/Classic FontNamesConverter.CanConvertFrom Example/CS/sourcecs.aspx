<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FontNamesConverter Example</title>
<script language="C#" runat="server">

      void Page_Load(Object sender, EventArgs e) 
      {

         // Declare local variables.
         System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en");
         System.ComponentModel.ITypeDescriptorContext context = null;
         Object names; 
         Object name_string;

         // Create FontNamesConverter object.
         FontNamesConverter fontconverter = new FontNamesConverter();

         // Create original list of fonts.
         string font_list = "arial, times new roman, verdana";

         // Check for type compatibility.
         if (fontconverter.CanConvertFrom(context, typeof(string)))
         {

            // Display original string.
            Label1.Text = "Original String :" + "<br /><br />" + font_list;

            // Convert string to array to strings and display results.
            names = fontconverter.ConvertFrom(context, culture, font_list);
            Label2.Text = "Converted to Array of Strings : " + "<br /><br />";
            foreach (string name_element in (string[])names)
            {
               Label2.Text += name_element + "<br />";
            }

            // Convert array of strings back to a string and display results.
            name_string = fontconverter.ConvertTo(context, culture, names, typeof(string)); 
            Label3.Text = "Converted back to String :" + "<br /><br />" + (string)name_string;

         }
          
      }

   </script>

</head>
<body>

   <h3>FontNamesConverter Example</h3>
   <br />

   <form id="form1" runat="server">
        
      <asp:Label id="Label1" runat="server"/>
      <br /><hr />
      <asp:Label id="Label2" runat="server"/>
      <br /><hr />
      <asp:Label id="Label3" runat="server"/>
        
   </form>

</body>
</html>
   
<!--</Snippet1>-->
