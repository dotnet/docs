<!-- <snippet3> -->
<%@ Control Language="VB" %>

<script runat="server">
     ' User a field to reference the current WebPartManager.
Private _manager As WebPartManager

'  Defines personalized property for User scope. In this case, the property is
'   the background color of the text box.

<Personalizable(PersonalizationScope.User)>  _
Public Property UserColorChoice() As System.Drawing.Color 
    Get
        Return _coloruserTextBox.BackColor
    End Get
    Set
        _coloruserTextBox.BackColor = value
    End Set
End Property

' Defines personalized property for Shared scope. In this case, the property is
'   the background color of the text box.

<Personalizable(PersonalizationScope.Shared)>  _
Public Property SharedColorChoice() As System.Drawing.Color 
    Get
        Return _colorsharedTextBox.BackColor
    End Get
    Set
        _colorsharedTextBox.BackColor = value
    End Set
End Property



Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) 
    _manager = WebPartManager.GetCurrentWebPartManager(Page)

End Sub 'Page_Init


Protected Sub Page_Load(ByVal src As Object, ByVal e As EventArgs) 
    ' If Web Parts manager scope is User, hide the button that changes shared control.
    If _manager.Personalization.Scope = PersonalizationScope.User Then
        _sharedchangeButton.Visible = False
        If Not _manager.Personalization.IsModifiable Then
            _userchangeButton.Enabled = False
        End If
    Else
        _sharedchangeButton.Visible = True
        If Not _manager.Personalization.IsModifiable Then
            _sharedchangeButton.Enabled = False
            _userchangeButton.Enabled = False
        End If
    End If

End Sub 'Page_Load
 
' Changes color of the User text box background when button clicked by authorized user.
Protected Sub _userButton_Click(ByVal src As Object, ByVal e As EventArgs) 
    Select Case _coloruserTextBox.BackColor.Name
        Case "Red"
            _coloruserTextBox.BackColor = System.Drawing.Color.Yellow
        Case "Yellow"
            _coloruserTextBox.BackColor = System.Drawing.Color.Green
        Case "Green"
            _coloruserTextBox.BackColor = System.Drawing.Color.Red
    End Select

End Sub '_userButton_Click


' Changes color of the Shared text box background when button clicked by authorized user.
Protected Sub _sharedButton_Click(ByVal src As Object, ByVal e As EventArgs) 
    Select Case _colorsharedTextBox.BackColor.Name
        Case "Red"
            _colorsharedTextBox.BackColor = System.Drawing.Color.Yellow
        Case "Yellow"
            _colorsharedTextBox.BackColor = System.Drawing.Color.Green
        Case "Green"
            _colorsharedTextBox.BackColor = System.Drawing.Color.Red
    End Select

End Sub '_sharedButton_Click

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>WebParts Personalization Example</title>
</head>
<body>
<p>
    <asp:LoginName ID="LoginName1" runat="server" BorderWidth="500" BorderStyle="none" />
    <asp:LoginStatus ID="LoginStatus1" LogoutAction="RedirectToLoginPage" runat="server" />
</p>
    <asp:Label ID="ScopeLabel" Text="Scoped Properties:" runat="server" Width="289px"></asp:Label>
    <br />
    <table style="width: 226px">
        
        <tr>
            <td>
                <asp:TextBox ID="_coloruserTextBox" Font-Bold="True" Height="110px" 
                runat="server" Text="User Property" BackColor="red" Width="110px" /> 
            </td>
            <td>       
                <asp:TextBox ID="_colorsharedTextBox" runat="server" Height="110px" 
                Width="110px" Text="Shared Property" BackColor="red" Font-Bold="true" />
            </td>
       </tr>
        <tr>
            <td>
                <asp:Button Text="Change User Color" ID="_userchangeButton" 
                runat="server" OnClick="_userButton_Click" />
            </td>
            <td >
                <asp:Button Text="Change Shared Color" ID="_sharedchangeButton" 
                runat="server" OnClick="_sharedButton_Click" />
            </td>
        </tr>
    </table>
</body>
</html>
<!-- </snippet3> -->