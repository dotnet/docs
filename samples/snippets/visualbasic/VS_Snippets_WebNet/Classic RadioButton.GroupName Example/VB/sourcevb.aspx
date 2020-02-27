<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Panel Example</title>
<script language="VB" runat="server">
 
    Sub Button1_Click(sender As Object, e As EventArgs)
        If Radio3.GroupName = "RegularMenu" Then
            Radio3.GroupName = "vegetarianMenu"
            Radio3.BackColor = System.Drawing.Color.LightGreen
        Else
            Radio3.GroupName = "RegularMenu"
            Radio3.BackColor = System.Drawing.Color.Pink
        End If
    End Sub
 
    </script>
 </head>
 <body>
 
     <h3>Panel Example</h3>
 
     <form id="form1" runat="server">
 
        <asp:Label id="Label1" BackColor="Pink" Text="RegularMenu" runat="server"/>
        &nbsp;
 
        <asp:Label id="Label2" BackColor="LightGreen" Text="vegetarianMenu" runat="server"/>
        <br />
 
        <asp:RadioButton id="Radio1" GroupName="RegularMenu"
             Text="Beef" BackColor="Pink" runat="server"/>
 
        <br />
        <asp:RadioButton id="Radio2" GroupName="RegularMenu"
             Text="Pork" BackColor="Pink" runat="server"/>
 
        <br />
        <asp:RadioButton id="Radio3" GroupName="RegularMenu"
             Text="Fish" BackColor="Pink" runat="server"/>
 
        <br />
        <asp:RadioButton id="Radio4" GroupName="vegetarianMenu"
             Text="Mushroom" BackColor="LightGreen" runat="server"/>
 
        <br />
        <asp:RadioButton id="Radio5" GroupName="vegetarianMenu"
             Text="Tofu" BackColor="LightGreen" runat="server"/>
 
        <br />
        <asp:Button id="Button1" OnClick="Button1_Click"
             Text="Regroup the radio buttons" runat="server"/>
 
    </form>
 
 </body>
 </html>
 
<!--</Snippet1>-->
