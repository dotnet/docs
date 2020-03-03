<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>RadioButton Example</title>
<script language="VB" runat="server">

    Sub SubmitBtn_Click(Sender As Object, e As EventArgs)
        
        If Radio1.Checked Then
            Label1.Text = "You selected " & Radio1.Text
        ElseIf Radio2.Checked Then
            Label1.Text = "You selected " & Radio2.Text
        ElseIf Radio3.Checked Then
            Label1.Text = "You selected " & Radio3.Text
        End If
    End Sub
 
     </script>
 
 </head>
 <body>
 
     <h3>RadioButton Example</h3>
 
     <form id="form1" runat="server">
     
         <h4>Select the type of installation you want to perform:</h4>
     
         <asp:RadioButton id="Radio1" Text="Typical" Checked="True" GroupName="RadioGroup1" runat="server" /><br />
         
         This option installs the features most typically used.  <i>Requires 1.2 MB disk space.</i><br />
             
         <asp:RadioButton id="Radio2" Text="Compact" GroupName="RadioGroup1" runat="server"/><br />
         
         This option installs the minimum files required to run the product.  <i>Requires 350 KB disk space.</i><br />
          
         <asp:RadioButton id="Radio3" runat="server" Text="Full" GroupName="RadioGroup1" /><br />
         
         This option installs all features for the product.  <i>Requires 4.3 MB disk space.</i><br />
 
         <asp:button text="Submit" OnClick="SubmitBtn_Click" runat="server"/>
 
         <asp:Label id="Label1" font-bold="true" runat="server" />
             
     </form>
 
 </body>
 </html>
 
<!--</Snippet1>-->
