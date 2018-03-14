<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Locate the Web Forms Controls on a Page by Walking the Controls Collection</title>
</head>

<script runat="server">
    
    '<Snippet10>
    Private Sub Button1_Click(ByVal sender As System.Object, _
     ByVal e As System.EventArgs) Handles Button1.Click
        Dim allTextBoxValues As String = ""
        Dim c As Control
        Dim childc As Control
        For Each c In Page.Controls
            For Each childc In c.Controls
                If TypeOf childc Is TextBox Then
                    allTextBoxValues &= CType(childc, TextBox).Text & ","
                End If
            Next
        Next
        If allTextBoxValues <> "" Then
            Label1.Text = allTextBoxValues
        End If
    End Sub
    '</Snippet10>
    
</script>

<body>
    <form id="form1" runat="server">
      <asp:Button id="Button1" runat="server" />
      <asp:Label id="Label1" runat="server" AssociatedControlID="Button1"></asp:Label>
    </form>
</body>
</html>
