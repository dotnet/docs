<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Determine which Web Server Control Raised an Event</title>
</head>

<script runat="server">
    
    '<Snippet1>
    Private Sub Button1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles Button1.Click, Button2.Click, Button3.Click
        
        Dim b As Button
        b = CType(sender, Button)
        
        Select Case b.ID
            Case "Button1"
                Label1.Text = "You clicked the first button"
            Case "Button2"
                Label1.Text = "You clicked the second button"
            Case "Button3"
                Label1.Text = "You clicked the third button"
        End Select
    End Sub
    '</Snippet1>
  
</script>

<body>
    <form id="form1" runat="server">
      
      <div>
      <asp:Button id="Button1" runat="server"></asp:Button>
      <asp:Button id="Button2" runat="server"></asp:Button>
      <asp:Button id="Button3" runat="server"></asp:Button> 
      <asp:Label ID="Label1" runat="server"></asp:Label>
      </div>
      
    </form>
</body>
</html>
