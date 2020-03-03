<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>HtmlImage Example</title>
<script language="VB" runat="server">
        
    Sub Image1_Click(sender As Object, e As EventArgs)
        Image1.Src = "Image1.jpg"
        Image1.Height = 226
        Image1.Width = 500
        Image1.Border = 5
        Image1.Align = "center"
        Image1.Alt = "Image 1"
    End Sub 'Image1_Click


    Sub Image2_Click(sender As Object, e As EventArgs)
        Image1.Src = "Image2.jpg"
        Image1.Height = 480
        Image1.Width = 640
        Image1.Border = 7
        Image1.Align = "left"
        Image1.Alt = "Image 2"
    End Sub 'Image2_Click


    Sub Image3_Click(sender As Object, e As EventArgs)
        Image1.Src = "Image3.jpg"
        Image1.Height = 413
        Image1.Width = 631
        Image1.Border = 3
        Image1.Align = "right"
        Image1.Alt = "Image 3"
    End Sub 'Image3_Click
 
  </script>
 
 </head>
 
 <body>
 
    <form id="form1" runat="server">
 
       <h3>HtmlImage Example</h3>
       
       <center>
 
          <button id="Button1"
                  onserverclick="Image1_Click" 
                  runat="server">
          Image 1
          </button>
 
          <button id="Button2"
                  onserverclick="Image2_Click" 
                  runat="server">
          Image 2
          </button>
 
          <button id="Button3"
                  onserverclick="Image3_Click" 
                  runat="server">
          Image 3
          </button>
 
       </center>
       
       <br /><br />
     
       <img id ="Image1"
            src="Image1.jpg"
            alt="Image 1"
            runat="server"
            style="width:500; height:226; border:5; text-align:center" />
      Enter the caption for this image here.
    
    </form>
 
 </body>
 </html>
   
<!--</Snippet1>-->
