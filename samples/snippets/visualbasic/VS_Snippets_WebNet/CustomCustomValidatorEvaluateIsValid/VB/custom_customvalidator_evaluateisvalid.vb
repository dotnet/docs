' <Snippet2>
Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCustomValidatorEvaluateIsValid
        Inherits System.Web.UI.WebControls.CustomValidator

        Protected Overrides Function EvaluateIsValid() As Boolean
            Dim isValid As Boolean = False

            ' Get the name of the control to validate.
            Dim controlToValidate As String = Me.ControlToValidate
            If controlToValidate.Length > 0 Then

                ' Get the control's value.
                Dim controlValue As String = GetControlValidationValue(controlToValidate)

                ' If the value is not null and not empty, test whether 
                ' check if the value entered into the text box is even,
                ' if so return true, else return false in all other cases.
                If Not (controlValue Is Nothing) AndAlso _
                   Not controlValue.Trim().Equals(System.String.Empty) Then
                    Try
                        Dim i As Integer = Integer.Parse(controlValue)
                        isValid = ((i Mod 2) = 0)
                    Catch
                    End Try
                End If
            End If
            Return isValid
        End Function

    End Class
End Namespace
' </Snippet2>
