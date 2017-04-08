
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


'/ <summary>
'/ Summary description for Form1.
'/ </summary>

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
   
   
    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub 'New
   
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose

    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(288, 32)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 0
        Me.button1.Text = "button1"
        ' 
        ' button2
        ' 
        Me.button2.Location = New System.Drawing.Point(288, 72)
        Me.button2.Name = "button2"
        Me.button2.TabIndex = 1
        Me.button2.Text = "button2"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(376, 334)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent
  
    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main


    '<Snippet1>
    ' This example demonstrates the use of the ControlAdded and
    ' ControlRemoved events. This example assumes that two Button controls 
    ' are added to the form and connected to the addControl_Click and 
    ' removeControl_Click event-handler methods.
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Connect the ControlRemoved and ControlAdded event handlers to the event-handler methods.
        ' ControlRemoved and ControlAdded are not available at design time.
        AddHandler Me.ControlRemoved, AddressOf Me.Control_Removed
        AddHandler Me.ControlAdded, AddressOf Me.Control_Added
    End Sub 'Form1_Load


    Private Sub Control_Added(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        MessageBox.Show(("The control named " + e.Control.Name + " has been added to the form."))
    End Sub


    Private Sub Control_Removed(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        MessageBox.Show(("The control named " + e.Control.Name + " has been removed from the form."))
    End Sub


    ' Click event handler for a Button control. Adds a TextBox to the form.
    Private Sub addControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        ' Create a new TextBox control and add it to the form.
        Dim textBox1 As New TextBox()
        textBox1.Size = New Size(100, 10)
        textBox1.Location = New Point(10, 10)
        ' Name the control in order to remove it later. 
        ' The name must be specified if a control is added at run time.
        textBox1.Name = "textBox1"

        ' Add the control to the form's control collection.
        Me.Controls.Add(textBox1)
    End Sub


    ' Click event handler for a Button control.
    ' Removes the previously added TextBox from the form.
    Private Sub removeControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
        ' Loop through all controls in the form's control collection.
        Dim tempCtrl As Control
        For Each tempCtrl In Me.Controls
            ' Determine whether the control is textBox1,
            ' and if it is, remove it.
            If tempCtrl.Name = "textBox1" Then
                Me.Controls.Remove(tempCtrl)
            End If
        Next tempCtrl
    End Sub
    '</Snippet1>
End Class 'Form1 