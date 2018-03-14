' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage
    Private button1 As Button
    Private button2 As Button

    Private Sub InitializeMyTabs()
        tabControl1 = New System.Windows.Forms.TabControl()
        tabPage1 = New System.Windows.Forms.TabPage()
        tabPage2 = New System.Windows.Forms.TabPage()
        button1 = New System.Windows.Forms.Button()
        button2 = New System.Windows.Forms.Button()

        tabControl1.Controls.AddRange(New System.Windows.Forms.Control() {tabPage1, tabPage2})
        tabControl1.Location = New System.Drawing.Point(40, 24)
        tabControl1.Size = New System.Drawing.Size(216, 216)
        tabControl1.TabIndex = 0

        tabPage1.Controls.AddRange(New System.Windows.Forms.Control() {button1})
        tabPage1.TabIndex = 0
        tabPage2.Controls.AddRange(New System.Windows.Forms.Control() {button2})
        tabPage2.TabIndex = 1

        button1.Location = New System.Drawing.Point(64, 72)
        button2.Location = New System.Drawing.Point(64, 72)
        button2.Text = "button2"

        ClientSize = New System.Drawing.Size(292, 273)
        Controls.AddRange(New System.Windows.Forms.Control() {tabControl1})

        ' Gets the index of the TabPage containing button2.
        ' Selects the index of the TabPage containing button2. 
        tabControl1.SelectedIndex = TabPage.GetTabPageOfComponent(button2).TabIndex
    End Sub

    Public Sub New()
        InitializeMyTabs()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>