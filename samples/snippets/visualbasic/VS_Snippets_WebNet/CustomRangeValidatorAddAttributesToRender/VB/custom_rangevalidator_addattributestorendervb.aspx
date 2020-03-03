<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom RangeValidator - AddAttributesToRender - VB.NET Example</title>
        <script runat="server">
            Sub ButtonClick(sender As Object, e As EventArgs)
                If Page.IsValid Then
                    Label1.Text="Page is valid."
                Else
                    Label1.Text="Page is not valid!"
                End If
            End Sub
        </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom RangeValidator - AddAttributesToRender - VB.NET Example</h3>

            Enter a number from 1 to 10:<br />
            <asp:TextBox id="TextBox1" Runat="server" />
            
            <aspSample:CustomRangeValidatorAddAttributesToRender id="RangeValidator1" runat="server" 
             ControlToValidate="TextBox1" MinimumValue="1" MaximumValue="10" Type="Integer" 
             EnableClientScript="false" Text="The value must be from 1 to 10!" /><br />
             <br />
             
            <asp:Button id="Button1" Text="Submit" OnClick="ButtonClick" runat="server" /><br />
             <br />
             
            <asp:Label id="Label1" runat="server"/>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
