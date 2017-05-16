' The following code example demonstrates how setting the 
' Label.Autosize property to True will causes the width of 
' the label to adjust.
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeLabel()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ClientSize = New System.Drawing.Size(266, 300)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    ' Declare a label.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    
    ' Initialize the label.
    Private Sub InitializeLabel()
        Me.Label1 = New Label
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0

        ' Set the label to a small size, but set the AutoSize property 
        ' to true. The label will adjust its length so all the text
        ' is visible, however if the label is wider than the form,
        ' the entire label will not be visible.
        Me.Label1.Size = New System.Drawing.Size(10, 10)
        Me.Controls.Add(Me.Label1)
        Me.Label1.AutoSize = True
        Me.Label1.Text = "The text in this label is longer than the set size."

    End Sub
    '</snippet1>
End Class
