' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class MyZone
    Inherits WebPartZone
    Private _renderVerbsInMenu As Boolean

    Protected Overrides Function CreateWebPartChrome() As WebPartChrome
      Dim theChrome As WebPartChrome = _
        New MyWebPartChrome(Me, Me.WebPartManager)
      If RenderVerbsInMenu Then
        Me.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu
      Else
        Me.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar
      End If
      Return theChrome
    End Function

    Public Property RenderVerbsInMenu() As Boolean
      Get
        Return _renderVerbsInMenu
      End Get
      Set(ByVal value As Boolean)
        _renderVerbsInMenu = value
      End Set
    End Property

  End Class

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class MyWebPartChrome
    Inherits WebPartChrome
    Dim theManager As WebPartManager
    Dim theZone As WebPartZoneBase

    ' <snippet3>
    Public Sub New(ByVal aZone As WebPartZoneBase, _
      ByVal aManager As WebPartManager)

      MyBase.New(aZone, aManager)
      theManager = aManager
      theZone = aZone
    End Sub
    ' </snippet3>

    ' <snippet4>
    Protected Overrides Function GetWebPartVerbs _
      (ByVal webPart As WebPart) As WebPartVerbCollection

      Dim verbSet As New ArrayList()
      Dim verb As WebPartVerb
      For Each verb In MyBase.GetWebPartVerbs(webPart)
        If verb.Text <> "Close" Then
          verbSet.Add(verb)
        End If
      Next verb

      Dim reducedVerbSet As WebPartVerbCollection = _
        New WebPartVerbCollection(verbSet)

      Return reducedVerbSet
    End Function
    ' </snippet4>

    ' <snippet5>
    Protected Overrides Function CreateWebPartChromeStyle _
      (ByVal part As WebPart, ByVal chromeType As PartChromeType) As Style

      Dim finalStyle As New Style()
      finalStyle.CopyFrom(MyBase.CreateWebPartChromeStyle(Part, chromeType))
      finalStyle.Font.Name = "Verdana"
      Return finalStyle
    End Function
    ' </snippet5>

    ' <snippet6>
    Protected Overrides Sub RenderPartContents _
      (ByVal writer As HtmlTextWriter, ByVal part As WebPart)

      If part Is Me.WebPartManager.SelectedWebPart Then
        HttpContext.Current.Response.Write("<span>Not rendered</span>")
      Else
        If (Me.Zone.GetType() Is GetType(MyZone)) Then
          part.RenderControl(writer)
        End If
      End If

    End Sub
    ' </snippet6>

  End Class

End Namespace
' </snippet2>

