<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>HtmlImage Example</title>
<script language="VB" runat="server">
        
    Sub Button_Click1(sender As Object, e As EventArgs)
        Image1.Height = 500
        Image1.Width = 1000
    End Sub 'Button_Click1


    Sub Button_Click2(sender As Object, e As EventArgs)
        Image1.Height = 226
        Image1.Width = 500
    End Sub 'Button_Click2
 
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
