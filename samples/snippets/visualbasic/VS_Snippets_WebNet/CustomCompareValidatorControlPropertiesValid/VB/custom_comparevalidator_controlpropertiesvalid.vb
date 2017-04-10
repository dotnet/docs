' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCompareValidatorControlPropertiesValid
        Inherits System.Web.UI.WebControls.CompareValidator

        Protected Overrides Function ControlPropertiesValid() As Boolean

            ' Determine whether the ControlToValidate is on the page and contains a validation properties. 
            MyBase.CheckControlValidationProperty(Me.ControlToValidate, "ControlToValidate")

            ' If the control is visible, then control is valid and ready for validation.
            Dim control As System.Web.UI.Control = Me.FindControl(Me.ControlToValidate)
            If control.Visible = True Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
' </Snippet2>