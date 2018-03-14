' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomRegularExpressionValidatorEvaluateIsValid
        Inherits System.Web.UI.WebControls.RegularExpressionValidator

        Protected Overrides Function EvaluateIsValid() As Boolean

            ' Get the control to validate's validation value
            Dim controlValue As String = GetControlValidationValue(Me.ControlToValidate)

            ' If the value is null or empty, then return true
            If controlValue Is Nothing OrElse controlValue.Trim().Length = 0 Then
                Return True
            Else
                ' Else try running the Regular Expression against the value 
                ' and see if there is a match.
                Try
                    Dim regExpMatch As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(controlValue, Me.ValidationExpression)
                    Return regExpMatch.Success AndAlso regExpMatch.Index = 0 AndAlso regExpMatch.Length = controlValue.Length
                Catch
                    Return True
                End Try
            End If
        End Function
    End Class
End Namespace
' </Snippet2>
