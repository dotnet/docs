<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Literal.Mode Property Example</title>
<script runat="Server">
       
        Sub PassThroughButton_Click(ByVal sender As Object, ByVal e As EventArgs)
   
            Literal1.Mode = LiteralMode.PassThrough
            
            Label1.Text = "The contents of the Literal.Text property " + _
                          "passed through to the browser:"
           
        End Sub
     
   </script>
</head>
<body>
    <form id="Form1" runat="server">
        
        <h3>Literal.Mode Property Example</h3>        
                             
        <asp:Label ID="Label1"
            Text="The HTML-encoded contents of the Literal.Text property:"
            runat="server">     
        </asp:Label><br /><br />
        
        <asp:Literal ID="Literal1"
            Mode="Encode"
            Text= "<b>bold</b><br/><i>italic</i><br/>"          
            runat="server">
        </asp:Literal>
       
        <hr />
       
        <asp:Button ID="PassThroughButton"
            Text="Pass Through Mode"
            OnClick="PassThroughButton_Click"
            runat="server">
        </asp:Button>
         
    </form>
</body>
</html>
<!--</Snippet1>-->
