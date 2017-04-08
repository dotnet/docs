
'The following code example handles the ListView.BeforeLabelEdit event
' and demonstrates the EditLabelEventArgs.Item and CancelEdit properties. 

Imports System.Windows.Forms
Imports System.Drawing


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub


    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Dim ListViewItem1 As ListViewItem = New ListViewItem("VisualBasic.Net", 0)
        Dim ListViewItem2 As ListViewItem = New ListViewItem("Advanced VisualBasic.Net", 1)
        Dim ListViewItem3 As ListViewItem = New ListViewItem("Object-Oriented Design")
        Dim ListViewItem4 As ListViewItem = New ListViewItem("Design Patterns for VB")
        Dim ListViewItem5 As ListViewItem = New ListViewItem("UI Design")
        Dim ListViewItem6 As ListViewItem = New ListViewItem("E-Commerce")
        Dim ListViewItem7 As ListViewItem = New ListViewItem("Software Testing Techniques")
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.ListView1.Items.AddRange(New ListViewItem() {ListViewItem1, _
            ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, _
            ListViewItem6, ListViewItem7})
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(16, 48)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(248, 120)
        Me.ListView1.TabIndex = 0
        Me.ListView1.View = System.Windows.Forms.View.List
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Proposed Class Schedule (The first two classes are required):"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    '<snippet1>
    
    Private Sub ListView1_BeforeLabelEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.LabelEditEventArgs) _
        Handles ListView1.BeforeLabelEdit

        ' Allow all but the first two items of the list to be modified by
        ' the user.
        If (e.Item < 2) Then
            e.CancelEdit = True
        End If
    End Sub
    '</snippet1>

End Class
