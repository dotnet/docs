' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCustomValidatorControlPropertiesValid
        Inherits System.Web.UI.WebControls.CustomValidator

        Protected Overrides Function ControlPropertiesValid() As Boolean
            Dim controlToValidate As String = Me.ControlToValidate

            ' Determine whether the ControlToValidate is on the page 
            ' and contains a valid validation property. 
            If controlToValidate.Length > 0 Then
                MyBase.CheckControlValidationProperty(controlToValidate, "ControlToValidate")
            End If

            ' If the control is visible, then control is valid 
            ' and is ready for validation.
            Dim control As System.Web.UI.Control = Me.FindControl(controlToValidate)
            If control.Visible = True Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
' </Snippet2>
