'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace EventDesignerTest
    ' This designer provides a "Connect testEvent" designer verb shortcut 
    ' menu command. When invoked, the command attaches a new event-handler 
    ' method named "testEventHandler" to the "testEvent" event of an 
    ' associated control.
    ' If a "testEvent" event of the associated control does not exist, 
    ' the IEventBindingService declares it.
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class EventDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Public Sub New()
        End Sub

        ' When the "Connect testEvent" designer verb shortcut menu 
        ' command is invoked, this method uses the 
        ' IEventBindingService to attach an event handler to a "textEvent" event of the associated control.
        Private Sub ConnectEvent(ByVal sender As Object, ByVal e As EventArgs)
            Dim eventservice As IEventBindingService = CType(Me.Component.Site.GetService(GetType(System.ComponentModel.Design.IEventBindingService)), IEventBindingService)
            If (eventservice IsNot Nothing) Then
                ' Attempt to obtain a PropertyDescriptor for a 
                ' component event named "testEvent".
                Dim edc As EventDescriptorCollection = TypeDescriptor.GetEvents(Me.Component)
                If edc Is Nothing Or edc.Count = 0 Then
                    Return
                End If
                Dim ed As EventDescriptor = Nothing
                ' Search for an event named "testEvent".
                Dim edi As EventDescriptor
                For Each edi In edc
                    If edi.Name = "testEvent" Then
                        ed = edi
                        Exit For
                    End If
                Next edi
                If ed Is Nothing Then
                    Return
                End If
                ' Use the IEventBindingService to get a 
                ' PropertyDescriptor for the event.
                Dim pd As PropertyDescriptor = eventservice.GetEventProperty(ed)
                If pd Is Nothing Then
                    Return
                End If
                ' Set the value of the event to "testEventHandler".
                pd.SetValue(Me.Component, "testEventHandler")
            End If
        End Sub

        ' Provides a designer verb command for the designer's 
        ' shortcut menu.
        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                Dim dvc As New DesignerVerbCollection()
                dvc.Add(New DesignerVerb("Connect testEvent", New EventHandler(AddressOf ConnectEvent)))
                Return dvc
            End Get
        End Property
    End Class

    ' EventControl is associated with the EventDesigner and displays 
    ' instructions for demonstrating the service.
    <Designer(GetType(EventDesigner))> _
    Public Class EventControl
        Inherits System.Windows.Forms.UserControl
        Public Event testEvent As System.EventHandler

        Public Sub New()
            Me.BackColor = Color.White
            Me.Size = New Size(320, 96)
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawString("IEventBindingService Example Control", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Blue), 5, 5)
            e.Graphics.DrawString("Use the ""Connect testEvent"" command of the", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 22)
            e.Graphics.DrawString("right-click shortcut menu provided by this", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 32)
            e.Graphics.DrawString("control's associated EventDesigner to create", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 42)
            e.Graphics.DrawString("a new event handler linked with the testEvent", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 52)
            e.Graphics.DrawString("of this control in the initialization code", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 62)
            e.Graphics.DrawString("for this control.", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, 72)
        End Sub

    End Class
End Namespace
'</Snippet1>