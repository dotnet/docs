<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputCheckBox Sample</title>
<script language="VB" runat="server">

    Sub Button1_Click(sender As Object, e As EventArgs)
        
        If Prev_Check_State.Value = Check1.Checked.ToString() Then
            Span2.InnerHtml = "CheckBox1 did not change state between clicks."
        End If
        If Check1.Checked = True Then
            Span1.InnerHtml = "CheckBox1 is selected!"
            Prev_Check_State.Value = "True"
        Else
            Span1.InnerHtml = "CheckBox1 is not selected!"
            Prev_Check_State.Value = "False"
        End If
    End Sub 'Button1_Click
     

    Sub Server_Changed(sender As Object, e As EventArgs)
        Span2.InnerHtml = "CheckBox1 changed state between clicks."
    End Sub 'Server_Changed

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
