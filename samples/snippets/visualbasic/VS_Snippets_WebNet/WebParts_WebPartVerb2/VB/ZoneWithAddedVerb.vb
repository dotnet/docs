'<SNIPPET3>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Security.Permissions
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

' This code sample creates a Web Part zone and adds the 
' "Copy Web Part" verb to any control in the zone.
Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class ZoneWithAddedVerb
    Inherits WebPartZone

    'public class ExtendedWebPartZoneBase 
    Protected Overrides Sub OnCreateVerbs(ByVal e _
      As WebPartVerbsEventArgs)

      Dim newVerbs As List(Of WebPartVerb) = _
        New List(Of WebPartVerb)
      newVerbs.Add(New CopyWebPartVerb(AddressOf CopyWebPartToNewOne))
      e.Verbs = New WebPartVerbCollection(e.Verbs, newVerbs)
      MyBase.OnCreateVerbs(e)

    End Sub 'OnCreateVerbs


    Sub CopyWebPartToNewOne(ByVal sender As Object, _
      ByVal e As WebPartEventArgs)

      Dim wpmgr As WebPartManager = _
        WebPartManager.GetCurrentWebPartManager(Page)
      Dim wp As System.Web.UI.WebControls.WebParts.WebPart
      Dim tp As Type = e.WebPart.GetType()
      wp = CType(Activator.CreateInstance(tp), _
        System.Web.UI.WebControls.WebParts.WebPart)
      wpmgr.AddWebPart(wp, e.WebPart.Zone, e.WebPart.ZoneIndex + 1)

    End Sub

  End Class


  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Friend Class CopyWebPartVerb
    Inherits WebPartVerb
    Private Const _copyWebPartImageUrl As String = "~/CopyVerb.ico"

    Friend Sub New(ByVal serverClickHandler As WebPartEventHandler)
      MyBase.New("MyVerb", serverClickHandler)

    End Sub 'New

    Public Overrides Property [Text]() As String
      Get
        Return "Copy Web Part"
      End Get
      Set(ByVal value As String)
      End Set
    End Property

    Public Overrides Property Description() As String
      Get
        Return "This verb will copy this web part control to a " _
               & "new one below"
      End Get
      Set(ByVal value As String)
      End Set
    End Property

    Public Overrides Property Enabled() As Boolean
      Get
        Return MyBase.Enabled
      End Get
      Set(ByVal value As Boolean)
        MyBase.Enabled = value
      End Set
    End Property
    
    Public Overrides Property ImageUrl() As String
      Get
        Return Me._copyWebPartImageUrl
      End Get
      Set(ByVal value As String)
      End Set
    End Property

  End Class

End Namespace
'</SNIPPET3>