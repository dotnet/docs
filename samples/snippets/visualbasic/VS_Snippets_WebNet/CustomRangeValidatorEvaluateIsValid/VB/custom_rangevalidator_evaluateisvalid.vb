' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRangeValidatorEvaluateIsValid
        Inherits System.Web.UI.WebControls.RangeValidator

        Protected Overrides Function EvaluateIsValid() As Boolean

            ' Get the value of the control to validate.
            Dim controlValue As String = GetControlValidationValue(ControlToValidate)

            ' If no value was entered, show the validation error by returning false.
            If controlValue.Trim().Length = 0 Then
                Return False
            End If

            ' Compare the ControlToValidate's value against the minimum and maximum values.
            Return Compare(controlValue, Me.MinimumValue, System.Web.UI.WebControls.ValidationCompareOperator.GreaterThanEqual, Me.Type) AndAlso _
                   Compare(controlValue, Me.MaximumValue, System.Web.UI.WebControls.ValidationCompareOperator.LessThanEqual, Me.Type)
        End Function
    End Class
End Namespace
' </Snippet2>
