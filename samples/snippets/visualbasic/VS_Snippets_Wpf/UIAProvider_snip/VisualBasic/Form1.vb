
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Partial Class Form1
    Inherits Form
    Public Sub New()
        ' Create an instance of the custom control.
        Dim controlRect As Rectangle = New Rectangle(15, 15, 40, 40)
        Dim myColorButton As RootButton = New RootButton(Me, controlRect)

        myColorButton.Text = "ColorControl"   ' This becomes the Name property for UI Automation.

        ' Give the control a location and size so that it will trap mouse clicks
        ' and will be repainted as necessary.
        myColorButton.Location = New System.Drawing.Point(controlRect.X, controlRect.Y)
        myColorButton.Size = New System.Drawing.Size(controlRect.Width, controlRect.Bottom)
        myColorButton.TabIndex = 1

        ' Add it to the form's controls. Among other things, this makes it possible for
        ' UI Automation to discover it, as it will become a child of the application window.
        Me.Controls.Add(myColorButton)

        InitializeComponent()

    End Sub 'New
End Class 'Form1
'
