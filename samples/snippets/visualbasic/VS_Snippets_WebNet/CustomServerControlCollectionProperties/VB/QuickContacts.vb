' <Snippet1>
' QuickContacts.vb
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls
    < _
    DefaultProperty("Contacts"), _
    ParseChildren(True, "Contacts"), _
    ToolboxData( _
        "<{0}:QuickContacts runat=""server""> </{0}:QuickContacts>") _
    > _
    Public Class QuickContacts
        Inherits WebControl

        Private contactsList As ArrayList

        < _
        Category("Behavior"), _
        Description("The contacts collection"), _
        DesignerSerializationVisibility( _
            DesignerSerializationVisibility.Content), _
        Editor(GetType(ContactCollectionEditor), _
            GetType(ContactCollectionEditor)), _
        PersistenceMode(PersistenceMode.InnerDefaultProperty) _
        > _
        Public ReadOnly Property Contacts() As ArrayList
            Get
                If contactsList Is Nothing Then
                    contactsList = New ArrayList
                End If
                Return contactsList
            End Get
        End Property

        ' The contacts are rendered in an HTML table.
        Protected Overrides Sub RenderContents( _
        ByVal writer As HtmlTextWriter)
            Dim t As Table = CreateContactsTable()
            If t IsNot Nothing Then
                t.RenderControl(writer)
            End If
        End Sub

        Private Function CreateContactsTable() As Table
            Dim t As Table = Nothing
            If (contactsList IsNot Nothing) AndAlso _
                (contactsList.Count > 0) Then
                t = New Table
                For Each item As Contact In contactsList
                    Dim aContact As Contact = TryCast(item, Contact)
                    If aContact IsNot Nothing Then
                        Dim r As New TableRow
                        Dim c1 As New TableCell
                        c1.Text = aContact.Name
                        r.Controls.Add(c1)

                        Dim c2 As New TableCell
                        c2.Text = aContact.Email
                        r.Controls.Add(c2)

                        Dim c3 As New TableCell
                        c2.Text = aContact.Phone
                        r.Controls.Add(c3)

                        t.Controls.Add(r)
                    End If
                Next
            End If
            Return t
        End Function
    End Class
End Namespace
' </Snippet1>
