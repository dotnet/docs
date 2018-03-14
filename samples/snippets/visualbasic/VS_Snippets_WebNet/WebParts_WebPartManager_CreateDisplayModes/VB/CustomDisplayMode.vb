' <snippet3> 
Imports System
Imports System.Collections.Generic
Imports System.Configuration
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
  Public Class NewWebPartManager
    Inherits WebPartManager
    Private Shared _inLineEditDisplayMode As WebPartDisplayMode = _
      New InlineWebPartEditDisplayMode()

    Public Sub New()
    End Sub

    ' <snippet4>
    Protected Overrides Function CreateDisplayModes() As WebPartDisplayModeCollection
      Dim displayModes As WebPartDisplayModeCollection = MyBase.CreateDisplayModes()
      displayModes.Add(_inLineEditDisplayMode)
      Return displayModes

    End Function 

    Public ReadOnly Property InLineEditDisplayMode() As WebPartDisplayMode
        Get
            Return _inLineEditDisplayMode
        End Get
    End Property
    ' </snippet4>

    ' <snippet5>
    Private NotInheritable Class InlineWebPartEditDisplayMode
      Inherits WebPartDisplayMode

      Public Sub New()
        MyBase.New("Inline Edit Display")
      End Sub

      Public Overrides ReadOnly Property AllowPageDesign() As Boolean
        Get
          Return True
        End Get
      End Property

      Public Overrides ReadOnly Property RequiresPersonalization() _
        As Boolean
        Get
          Return True
        End Get
      End Property

      Public Overrides ReadOnly Property ShowHiddenWebParts() As Boolean
        Get
          Return False
        End Get
      End Property

      Public Overrides ReadOnly Property AssociatedWithToolZone() _
        As Boolean
        Get
          Return False
        End Get
      End Property

      Public Overrides Function IsEnabled(ByVal webPartManager _
        As WebPartManager) As Boolean

        Return True

      End Function

    End Class
    ' </snippet5>

  End Class

End Namespace
' </snippet3> 