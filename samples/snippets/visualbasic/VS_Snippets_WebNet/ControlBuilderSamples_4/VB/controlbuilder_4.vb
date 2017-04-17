' <snippet1>
Imports System
Imports System.Web.UI
Imports System.Web
Imports System.Security.Permissions

Namespace ASPNET.Samples

   <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
   Public NotInheritable Class AppendControlBuilder
      Inherits ControlBuilder

      ' Override the OnAppendToParentBuilder method.
      Overrides Public Sub OnAppendToParentBuilder( _
         ByVal parentBuilder As ControlBuilder _
      )
            ' Check whether the type of the control this builder
            ' is applied to is CustomTextBox. If so, check whether
            ' ASP code blocks exist in the control. If so, call
            ' throw an Exception, if not, call the HasBody method.        
            If ControlType Is Type.GetType("CustomTextBox") Then
                If HasAspCode = True Then
                    Throw New Exception("This control cannot contain code blocks.")
                Else
                    HasBody()
                End If
            End If

        End Sub

   End Class

End Namespace
' </snippet1>
   
   
