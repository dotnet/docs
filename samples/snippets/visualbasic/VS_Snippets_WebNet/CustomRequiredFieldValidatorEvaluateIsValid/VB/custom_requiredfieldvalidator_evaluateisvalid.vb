' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRequiredFieldValidatorEvaluateIsValid
        Inherits System.Web.UI.WebControls.RequiredFieldValidator

        Protected Overrides Function EvaluateIsValid() As Boolean

            ' Get the ControlToValidate's value.
            Dim controlValue As String = GetControlValidationValue(ControlToValidate)

            ' If ControlToValidate's value is null or empty, then return false.
            If controlValue Is Nothing OrElse controlValue.Trim().Equals(System.String.Empty) Then
                Return False
            Else  ' Else the control contains a value so return true.
                Return True
            End If
        End Function
    End Class
End Namespace
' </Snippet2>
