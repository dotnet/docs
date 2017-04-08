<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>HtmlImage Example</title>
<script language="C#" runat="server">
        
       void Button_Click1(object sender, EventArgs e) 
       {
          Image1.Height=500;
          Image1.Width=1000;
       }
    
       void Button_Click2(object sender, EventArgs e) 
       {
          Image1.Height=226;
          Image1.Width=500;
       }
 
    </script>
 
 </head>
 
 <body>
 
    <form id="form1" runat="server">
 
       <h3>HtmlImage Example</h3>
     
       <img id ="Image1"
            src="Image1.jpg"
            alt="Image 1"
            runat="server"
            style="width:500; height:226; border:5; text-align:center" />
       <br /><br />
       <button id="Button1"
               onserverclick="Button_Click1"
               runat="server">
       Zoom Image
       </button>
       <button id="Button2"
               onserverclick="Button_Click2"
               runat="server">
       Normal Size
       </button>
    
    </form>
 
 </body>
 </html>

<!--</Snippet1>-->
