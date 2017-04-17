' <snippet2>
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class MyManagerAuthorize
    Inherits WebPartManager

    Public Overrides Function IsAuthorized(ByVal type As Type, _
      ByVal path As String, ByVal authorizationFilter As String, _
      ByVal isShared As Boolean) As Boolean

      If Not String.IsNullOrEmpty(authorizationFilter) Then
        If authorizationFilter = "admin" Then
          Return True
        Else
          Return False
        End If
      Else
        Return True
      End If

    End Function

  End Class

End Namespace
' </snippet2>