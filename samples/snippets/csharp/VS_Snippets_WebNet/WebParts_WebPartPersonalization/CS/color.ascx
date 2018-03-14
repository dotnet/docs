<!-- <snippet3> -->
<%@ Control Language="C#" %>

<script runat="server">
    // User a field to reference the current WebPartManager.
    private WebPartManager _manager;
    
    //  Defines personalized property for User scope. In this case, the property is
    //   the background color of the text box.
    [Personalizable(PersonalizationScope.User)]
    public System.Drawing.Color UserColorChoice
    {
        get
        {
            return _coloruserTextBox.BackColor;
        }
        set
        {
            _coloruserTextBox.BackColor = value;
        }
    }

    // Defines personalized property for Shared scope. In this case, the property is
    //   the background color of the text box.
    [Personalizable(PersonalizationScope.Shared) ]
    public System.Drawing.Color SharedColorChoice
    {
        get
        {
            return _colorsharedTextBox.BackColor;
        }
        set
        {
            _colorsharedTextBox.BackColor = value;
        }
    }


    void Page_Init(object sender, EventArgs e)
    {
       _manager = WebPartManager.GetCurrentWebPartManager(Page);       
    }

    protected void Page_Load(object src, EventArgs e) 
    {
     // If Web Parts manager scope is User, hide the button that changes shared control.
       if (_manager.Personalization.Scope == PersonalizationScope.User)
       {
           _sharedchangeButton.Visible = false;
                  if (!_manager.Personalization.IsModifiable)
                      _userchangeButton.Enabled = false;
       }
       else
       {
           _sharedchangeButton.Visible = true; 
                  if (!_manager.Personalization.IsModifiable)
                    {
                      _sharedchangeButton.Enabled = false;
                      _userchangeButton.Enabled = false;
                    }
       } 
    }
    
    // Changes color of the User text box background when button clicked by authorized user.
    protected void _userButton_Click(object src, EventArgs e)
    {
        switch(_coloruserTextBox.BackColor.Name)
        {
            case "Red":
                _coloruserTextBox.BackColor = System.Drawing.Color.Yellow;
                break;
            case "Yellow":
                _coloruserTextBox.BackColor = System.Drawing.Color.Green;
                break;
            case "Green":
                _coloruserTextBox.BackColor = System.Drawing.Color.Red;
                break;
        }
    }
        
    // Changes color of the Shared text box background when button clicked by authorized user.
    protected void _sharedButton_Click(object src, EventArgs e)
    {
        switch (_colorsharedTextBox.BackColor.Name)
        {
            case "Red":
                _colorsharedTextBox.BackColor = System.Drawing.Color.Yellow;
                break;
            case "Yellow":
                _colorsharedTextBox.BackColor = System.Drawing.Color.Green;
                break;
            case "Green":
                _colorsharedTextBox.BackColor = System.Drawing.Color.Red;
                break;
        }        
    }   

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