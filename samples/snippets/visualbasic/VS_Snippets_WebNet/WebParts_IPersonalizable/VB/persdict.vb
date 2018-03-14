 ' <snippet9>



Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts


Namespace PersTest
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


        Public Overrides ReadOnly Property Subtitle() As String
            Get
                Return [Text]
            End Get
        End Property


        <Personalizable(), WebBrowsable()> _
        Public Overridable Property [Text]() As String
            Get
                Dim o As Object = ViewState("Text")
                If o Is Nothing Then
                    Return "My Links"
                Else
                    Return CType(o, String)
                End If

            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property


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

        ' <snippet1>
        Public Overridable Shadows Sub Load(ByVal state As PersonalizationDictionary) Implements IPersonalizable.Load
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
            '       Return False

        End Sub 'Load

        ' </snippet1>
        ' <snippet2>
        Public Overridable Sub Save(ByVal state As PersonalizationDictionary) Implements IPersonalizable.Save
            If Not (_sharedUrls Is Nothing) AndAlso _sharedUrls.Count <> 0 Then
                state("sharedUrls") = New PersonalizationEntry(_sharedUrls, PersonalizationScope.Shared)
            End If
            If Not (_userUrls Is Nothing) AndAlso _userUrls.Count <> 0 Then
                state("userUrls") = New PersonalizationEntry(_userUrls, PersonalizationScope.User)
            End If

        End Sub 'Save
       ' </snippet2>
    End Class 'UrlListWebPart 


    Public Class UrlListExWebPart
        Inherits UrlListWebPart
        Implements ITrackingPersonalizable

        Private _trackingLog As String = String.Empty
        Private _loading As Boolean
        Private _saving As Boolean


        Public Overrides Property [Text]() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                If MyBase.Text.Equals(value) = False Then
                    MyBase.Text = value
                    SetPersonalizationDirty()
                End If
            End Set
        End Property

        ' <snippet3>
        Protected Overrides Sub OnUrlAdded()
            MyBase.OnUrlAdded()
            SetPersonalizationDirty()

        End Sub 'OnUrlAdded

        ' </snippet3>
        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            MyBase.RenderContents(writer)

            writer.Write("<br />")
            writer.Write("<pre id=""" + ClientID + "$log" + """>")
            writer.Write(_trackingLog)
            writer.Write("</pre>")

        End Sub 'RenderContents


        Public Overrides Sub Load(ByVal state As PersonalizationDictionary)
            If _loading = False Then
                Throw New InvalidOperationException()
            End If
            MyBase.Load(state)

        End Sub 'Load


        Public Overrides Sub Save(ByVal state As PersonalizationDictionary)
            If _saving = False Then
                Throw New InvalidOperationException()
            End If
            MyBase.Save(state)

        End Sub 'Save
        ' <snippet8>

        ReadOnly Property TracksChanges() As Boolean Implements ITrackingPersonalizable.TracksChanges
            Get
                Return True
            End Get
        End Property

        ' </snippet8>
        ' <snippet4>
        Sub BeginLoad() Implements ITrackingPersonalizable.BeginLoad
            _loading = True
            _trackingLog = "1. BeginLoad" + vbCr + vbLf

        End Sub 'ITrackingPersonalizable.BeginLoad

        ' </snippet4>
        ' <snippet5>
        Sub BeginSave() Implements ITrackingPersonalizable.BeginSave
            _saving = True
            _trackingLog += "3. BeginSave" + vbCr + vbLf

        End Sub 'ITrackingPersonalizable.BeginSave

        ' </snippet5>
        ' <snippet6>
        Sub EndLoad() Implements ITrackingPersonalizable.EndLoad
            _loading = False
            _trackingLog += "2. EndLoad" + vbCr + vbLf

        End Sub 'ITrackingPersonalizable.EndLoad

        ' </snippet6>
        ' <snippet7>
        Sub EndSave() Implements ITrackingPersonalizable.EndSave
            _saving = False
            _trackingLog += "4. EndSave"

        End Sub 'ITrackingPersonalizable.EndSave
        ' </snippet7>
    End Class 'UrlListExWebPart 
    ' </snippet9>
End Namespace