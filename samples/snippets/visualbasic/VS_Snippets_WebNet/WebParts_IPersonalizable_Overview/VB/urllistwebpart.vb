' <snippet2>

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class UrlListWebPart
      Inherits WebPart
      Implements IPersonalizable
      Private _sharedUrls As ArrayList
      Private _userUrls As ArrayList
      Private _listDirty As Boolean

      Private _nameTextBox As TextBox
      Private _urlTextBox As TextBox
      Private _addButton As Button
      Private _list As BulletedList


      Protected Overrides Sub CreateChildControls()
          Dim nameLabel As New Label()
          Dim urlLabel As New Label()
          Dim breakLiteral1 As New LiteralControl("<br />")
          Dim breakLiteral2 As New LiteralControl("<br />")
          Dim breakLiteral3 As New LiteralControl("<br />")

          _nameTextBox = New TextBox()
          _urlTextBox = New TextBox()
          _addButton = New Button()
          _list = New BulletedList()

          nameLabel.Text = "Name: "
          urlLabel.Text = "URL: "
          _nameTextBox.ID = "nameTextBox"
          _urlTextBox.ID = "urlTextBox"
          _addButton.Text = "Add"
          _addButton.ID = "addButton"
          AddHandler _addButton.Click, AddressOf Me.OnClickAddButton
          _list.DisplayMode = BulletedListDisplayMode.HyperLink
          _list.ID = "list"

          Controls.Add(nameLabel)
          Controls.Add(_nameTextBox)
          Controls.Add(breakLiteral1)

          Controls.Add(urlLabel)
          Controls.Add(_urlTextBox)
          Controls.Add(breakLiteral2)

          Controls.Add(_addButton)
          Controls.Add(breakLiteral3)

          Controls.Add(_list)

      End Sub 'CreateChildControls


      Private Sub OnClickAddButton(ByVal sender As Object, ByVal e As EventArgs)
          Dim name As String = _nameTextBox.Text.Trim()
          Dim url As String = _urlTextBox.Text.Trim()

          Dim p As New Pair(name, url)
          If WebPartManager.Personalization.Scope = PersonalizationScope.Shared Then
              If _sharedUrls Is Nothing Then
                  _sharedUrls = New ArrayList()
              End If
              _sharedUrls.Add(p)
          Else
              If _userUrls Is Nothing Then
                  _userUrls = New ArrayList()
              End If
              _userUrls.Add(p)
          End If

          OnUrlAdded()

      End Sub 'OnClickAddButton


      Protected Overridable Sub OnUrlAdded()
          _listDirty = True
          ChildControlsCreated = False

      End Sub 'OnUrlAdded


      Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
          If Not (_sharedUrls Is Nothing) Then
              Dim p As Pair
              For Each p In _sharedUrls
                  _list.Items.Add(New ListItem(CStr(p.First), CStr(p.Second)))
              Next p
          End If
          If Not (_userUrls Is Nothing) Then
              Dim p As Pair
              For Each p In _userUrls
                  _list.Items.Add(New ListItem(CStr(p.First), CStr(p.Second)))
              Next p
          End If

          MyBase.RenderContents(writer)

      End Sub 'RenderContents


      Public Overridable ReadOnly Property IsDirty() As Boolean _
        Implements IPersonalizable.IsDirty
          Get
              Return _listDirty
          End Get
      End Property

      ' <snippet3>
      Public Overridable Shadows Sub Load(ByVal state As PersonalizationDictionary) _
        Implements IPersonalizable.Load
          If Not (state Is Nothing) Then
              Dim sharedUrlsEntry As PersonalizationEntry = state("sharedUrls")
              If Not (sharedUrlsEntry Is Nothing) Then
                  _sharedUrls = CType(sharedUrlsEntry.Value, ArrayList)
              End If

              Dim userUrlsEntry As PersonalizationEntry = state("userUrls")
              If Not (userUrlsEntry Is Nothing) Then
                  _userUrls = CType(userUrlsEntry.Value, ArrayList)
              End If
          End If

      End Sub 'Load

      ' </snippet3>
      ' <snippet4>
      Public Overridable Sub Save(ByVal state As PersonalizationDictionary) _
        Implements IPersonalizable.Save
          If Not (_sharedUrls Is Nothing) AndAlso _sharedUrls.Count <> 0 Then
              state("sharedUrls") = New PersonalizationEntry(_sharedUrls, PersonalizationScope.Shared)
          End If
          If Not (_userUrls Is Nothing) AndAlso _userUrls.Count <> 0 Then
              state("userUrls") = New PersonalizationEntry(_userUrls, PersonalizationScope.User)
          End If

      End Sub
      ' </snippet4>
  End Class


End Namespace
' </snippet2>