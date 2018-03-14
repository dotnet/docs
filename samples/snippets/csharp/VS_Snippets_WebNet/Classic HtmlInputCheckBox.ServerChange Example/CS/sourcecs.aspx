<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputCheckBox Sample</title>
<script language="C#" runat="server">

      void Button1_Click(object sender, EventArgs e) 
      { 

         if (Prev_Check_State.Value == Check1.Checked.ToString())
            Span2.InnerHtml = "CheckBox1 did not change state between clicks.";

         if (Check1.Checked == true)
         {          
            Span1.InnerHtml = "CheckBox1 is selected!";
            Prev_Check_State.Value="True";
         }         
         else
         { 
            Span1.InnerHtml = "CheckBox1 is not selected!";
            Prev_Check_State.Value="False";
         }
         
      }

      void Server_Changed(object sender, EventArgs e) 
      {
         Span2.InnerHtml = "CheckBox1 changed state between clicks.";
      }

   </script>

</head>

<body>

   <h3>HtmlInputCheckBox Sample</h3>

   <form id="form1" runat="server">

      <input id="Check1" 
             type="checkbox"
             onserverchange="Server_Changed" 
             runat="server"/> 
 
      CheckBox1 &nbsp;&nbsp;

      <span id="Span1" 
            style="color:red" 
            runat="server"/>

      <br />

      <input type="button" 
             id="Button1" 
             value="Enter" 
             onserverclick="Button1_Click" 
             runat="server"/>
      
      <br /><br />

      <span id="Span2" 
            runat="server"/>

      <input type="hidden" id="Prev_Check_State"
                       visible="false"
                       runat="server"/>

   </form>

</body>
</html>
   
<!--</Snippet1>-->
