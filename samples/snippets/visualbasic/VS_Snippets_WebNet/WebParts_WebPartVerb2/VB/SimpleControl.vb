'<SNIPPET2>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Collections.Generic
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

' This code snippet creates a simple Web Part control.
Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class SimpleControl
    Inherits System.Web.UI.WebControls.WebParts.WebPart

    Private _text As String = "Simple control text"

    Public Property [Text]() As String
      Get
        If Not (_text Is Nothing) Then
          Return _text
        Else
          Return String.Empty
        End If
      End Get
      Set(ByVal value As String)
        _text = value
      End Set
    End Property

    Protected Overrides Sub Render(ByVal writer _
      As System.Web.UI.HtmlTextWriter)

      writer.Write(Me.Text)

    End Sub

  End Class

End Namespace
'</SNIPPET2>