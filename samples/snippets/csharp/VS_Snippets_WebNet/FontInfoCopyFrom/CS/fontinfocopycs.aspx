<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

   <head>
    <title>FontInfo CopyFrom Example</title>
<script runat="server">

         void CopyFontInfo(Object sender, EventArgs e)
         {

            // Copy the FontInfo of Sample1Label to ResultLabel.
            ResultLabel.Font.CopyFrom(Sample1Label.Font);
    
            ResultLabel.Text = "Copy Result";

         }

       </script>

   </head>

   <body>

      <form id="form1" runat="server">

         <h3>FontInfo CopyFrom Example</h3>

         Click <b>Copy</b> to copy the font style of Font Sample 1 
         and display the result <br /> in the Operation Result label.
         

         <br /><br />

         <asp:Label id="Sample1Label" 
              Text="Font Sample 1" 
              Font-Names="Times New Roman" 
              Font-Italic="true" 
              Font-Strikeout="true" 
              runat="server" />

         <br /><br />

         <asp:Button id="CopyButton" 
              Text="Copy" 
              OnClick="CopyFontInfo" 
              runat="server" />

         <br /><br />

         Operation Result: <br />

         <asp:Label id="ResultLabel"
              runat="server" />

      </form>

   </body>

</html>
<!-- </Snippet1> -->
