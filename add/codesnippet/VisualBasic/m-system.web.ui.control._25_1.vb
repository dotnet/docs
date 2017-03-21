        ' Override the OnInit method to set _text to 
        ' a default value if it is null.
        <System.Security.Permissions.PermissionSetAttribute( _
          System.Security.Permissions.SecurityAction.Demand, _
            Name:="FullTrust")> _
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub 'OnInit