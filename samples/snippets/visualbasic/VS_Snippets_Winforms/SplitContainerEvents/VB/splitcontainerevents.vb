' <snippet1>
' Compile this example using the following command line:
' vbc splitcontainerevents.vb /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.dll /r:System.Data.dll
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic

' Create an empty Windows form.
Public Class Form1
    Inherits System.Windows.Forms.Form
    ' This is the event handler for the SplitterMoving and SplitterMoved events.
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

    Public Sub New()
        InitializeComponent()
    End Sub


Private Sub InitializeComponent()
SplitContainer1 = New System.Windows.Forms.SplitContainer
SplitContainer1.SuspendLayout()
SuspendLayout()

' Place a basic SplitContainer control onto Form1.
SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
SplitContainer1.Location = New System.Drawing.Point(0, 0)
SplitContainer1.Name = "SplitContainer1"
SplitContainer1.Size = New System.Drawing.Size(292, 273)
SplitContainer1.SplitterDistance = 39
SplitContainer1.SplitterWidth = 6
SplitContainer1.TabIndex = 0
SplitContainer1.Text = "SplitContainer1"

' This is the left panel of the vertical SplitContainer control.

SplitContainer1.Panel1.Name = "SplitterPanel1"

' This is the right panel of the vertical SplitContainer control.
SplitContainer1.Panel2.Name = "SplitterPanel2"

' Lay out the basic properties of the form.
ClientSize = New System.Drawing.Size(292, 273)
Controls.Add(SplitContainer1)
Name = "Form1"
Text = "Form1"
SplitContainer1.ResumeLayout(False)
ResumeLayout(False)

    End Sub

<STAThread()>  _
Shared Sub Main()
    Application.Run(New Form1())
End Sub 'Main

    Private Sub SplitContainer1_SplitterMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles SplitContainer1.SplitterMoving
        ' Define what happens while the splitter is moving.
        Cursor.Current = System.Windows.Forms.Cursors.NoMoveVert
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        ' Define what happens when the splitter is no longer moving.
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class
' </snippet1>