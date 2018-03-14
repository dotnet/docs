<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Test Validity Programmatically for ASP.NET Server Controls</title>
</head>

<script runat="server" >
    
    '<Snippet11>
    Public Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs) _
    Handles Button1.Click

        If Me.IsValid Then
            ' Perform database updates or other logic here
        End If
    End Sub
    '</Snippet11>
    
    Private Sub Page_Load()
        
        '<Snippet12>
        If (Me.IsPostBack) Then
            Me.Validate()
            If (Not Me.IsValid) Then
                Dim msg As String
                ' Loop through all validation controls to see which 
                ' generated the error(s).
                Dim oValidator As IValidator
                For Each oValidator In Validators
                    If oValidator.IsValid = False Then
                        msg = msg & "<br />" & oValidator.ErrorMessage
                    End If
                Next
                Label1.Text = msg
            End If
        End If
        '</Snippet12>
        
    End Sub
    
</script>

<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button id="Button1" runat="server" />
      <asp:Label id="Label1" runat="server" AssociatedControlID="Button1"></asp:Label>
    </div>
    </form>
</body>
</html>
