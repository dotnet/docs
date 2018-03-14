'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This designer provides a set of designer verb shortcut menu commands
' that call methods of the IUIService.
Public Class IUIServiceTestDesigner
   Inherits System.Windows.Forms.Design.ControlDesigner
   
   Public Sub New()
    End Sub

    ' Provides a set of designer verb menu commands that call 
    ' IUIService methods.
    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Return New DesignerVerbCollection(New DesignerVerb() { _
                New DesignerVerb("Show a test message box using the IUIService", _
                New EventHandler(AddressOf Me.showTestMessage)), _
                New DesignerVerb("Show a test error message using the IUIService", _
                New EventHandler(AddressOf Me.showErrorMessage)), _
                New DesignerVerb("Show an example Form using the IUIService", _
                New EventHandler(AddressOf Me.showDialog)), _
                New DesignerVerb("Show the Task List tool window using the IUIService", _
                New EventHandler(AddressOf Me.showToolWindow))})
        End Get
    End Property

    ' Displays a message box with message text, caption text 
    ' and buttons of a particular MessageBoxButtons style.
    Private Sub showTestMessage(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet2>
        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowMessage("Test message", "Test caption", _
                System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore)
        End If
        '</Snippet2>
    End Sub

    ' Displays an error message box that displays the message
    ' contained within a specified exception.
    Private Sub showErrorMessage(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet3>
        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowError(New Exception( _
                "This is a message in a test exception, displayed by the IUIService", _
                New ArgumentException("Test inner exception")))
        End If
        '</Snippet3>
    End Sub

    ' Displays an example Windows Form using the 
    ' IUIService.ShowDialog method.
    Private Sub showDialog(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet4>
        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowDialog(New ExampleForm())
        End If
        '</Snippet4>
    End Sub

    ' Displays a standard tool window using the 
    ' IUIService.ShowToolWindow method.
    Private Sub showToolWindow(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet5>
        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowToolWindow(StandardToolWindows.TaskList)
        End If
        '</Snippet5>
    End Sub

End Class

' Provides an example Form class used by the 
' IUIServiceTestDesigner.showDialog method.
Friend Class ExampleForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        Me.Text = "Example Form"
        Dim okButton As New System.Windows.Forms.Button()
        okButton.Location = New Point(Me.Width - 70, Me.Height - 70)
        okButton.Size = New Size(50, 20)
        okButton.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
        okButton.DialogResult = System.Windows.Forms.DialogResult.OK
        okButton.Text = "OK"
        Me.Controls.Add(okButton)
    End Sub
End Class

' This control is associated with the IUIServiceTestDesigner, 
' and can be sited in design mode to use the sample.
<DesignerAttribute(GetType(IUIServiceTestDesigner), GetType(IDesigner))> _
Public Class IUIServiceExampleControl
    Inherits UserControl

    Public Sub New()
        Me.BackColor = Color.Beige
        Me.Width = 255
        Me.Height = 60
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.DesignMode Then
            e.Graphics.DrawString("Right-click this control to display a list of the", _
                New Font("Arial", 9), Brushes.Black, 5, 6)
            e.Graphics.DrawString("designer verb menu commands provided", _
                New Font("Arial", 9), Brushes.Black, 5, 20)
            e.Graphics.DrawString("by the IUIServiceTestDesigner.", _
                New Font("Arial", 9), Brushes.Black, 5, 34)
        End If
    End Sub
End Class
'</Snippet1>