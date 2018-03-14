' <Snippet2>
Imports System.Web
Imports System.Security.Permissions
Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCompareValidatorEvaluateIsValid
        Inherits System.Web.UI.WebControls.CompareValidator

        Protected Overrides Function EvaluateIsValid() As Boolean

            ' Get the values from the two controls
            Dim controlToValidateValue As String = Me.GetControlValidationValue(Me.ControlToValidate)
            Dim controlToCompareValue As String = Me.GetControlValidationValue(Me.ControlToCompare)

            ' If the values are the same, return true, else return false.
            If (System.String.Compare(controlToValidateValue, 0, controlToCompareValue, 0, controlToCompareValue.Length, False, System.Globalization.CultureInfo.InvariantCulture) = 0) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
' </Snippet2>