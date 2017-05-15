Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddButton As Button
    Friend WithEvents AddRangeButton As Button
    Friend WithEvents RemoveButton As Button
    Friend WithEvents RemoveAtButton As Button
    Friend WithEvents ClearButton As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RemoveAtButton = New Button()
        Me.ClearButton = New Button()
        Me.Panel1 = New Panel()
        Me.AddButton = New Button()
        Me.AddRangeButton = New Button()
        Me.RemoveButton = New Button()
        Me.SuspendLayout()
        '
        'RemoveAtButton
        '
        Me.RemoveAtButton.Location = New System.Drawing.Point(96, 200)
        Me.RemoveAtButton.Name = "RemoveAtButton"
        Me.RemoveAtButton.TabIndex = 4
        Me.RemoveAtButton.Text = "RemoveAt"
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(96, 232)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.TabIndex = 5
        Me.ClearButton.Text = "Clear"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 136)
        Me.Panel1.TabIndex = 0
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(8, 168)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.TabIndex = 1
        Me.AddButton.Text = "Add"
        '
        'AddRangeButton
        '
        Me.AddRangeButton.Location = New System.Drawing.Point(8, 200)
        Me.AddRangeButton.Name = "AddRangeButton"
        Me.AddRangeButton.TabIndex = 2
        Me.AddRangeButton.Text = "AddRange"
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(96, 168)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.TabIndex = 3
        Me.RemoveButton.Text = "Remove"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(248, 261)
        Me.Controls.AddRange(New Control() {Me.ClearButton, Me.RemoveAtButton, Me.RemoveButton, Me.AddRangeButton, Me.AddButton, Me.Panel1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

'<snippet1>
    ' Clear all the controls in the Panel.
    Private Sub ClearButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles ClearButton.Click
        Panel1.Controls.Clear()
    End Sub
'</snippet1>

'<snippet2>
    ' Create a TextBox to add to the Panel.
    Dim TextBox1 As TextBox = New TextBox()

    ' Add controls to the Panel using the Add method.
    Private Sub AddButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles AddButton.Click
        Panel1.Controls.Add(TextBox1)
    End Sub
'</snippet2>

'<snippet3>
    ' Create two RadioButtons to add to the Panel.
    Dim RadioAddButton As RadioButton = New RadioButton()
    Dim RadioAddRangeButton As RadioButton = New RadioButton()

    ' Add controls to the Panel using the AddRange method.
    Private Sub AddRangeButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles AddRangeButton.Click
        ' Set the Text the RadioButtons will display.
        RadioAddButton.Text = "RadioAddButton"
        RadioAddRangeButton.Text = "RadioAddRangeButton"

        ' Set the appropriate location of RadioAddRangeButton.
        RadioAddRangeButton.Location = New System.Drawing.Point( _
        RadioAddButton.Location.X, _
        RadioAddButton.Location.Y + RadioAddButton.Height)

        ' Add the controls to the Panel.
        Panel1.Controls.AddRange(New Control() {RadioAddButton, RadioAddRangeButton})
    End Sub
'</snippet3>

'<snippet4>
    ' Remove the RadioButton control if it exists.
    Private Sub RemoveButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles RemoveButton.Click
        If Panel1.Controls.Contains(RemoveButton) Then
            Panel1.Controls.Remove(RemoveButton)
        End If
    End Sub
'</snippet4>

'<snippet5>
    ' Remove the first control in the collection.
    Private Sub RemoveAtButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles RemoveAtButton.Click
        If (Panel1.Controls.Count > 0) Then
            Panel1.Controls.RemoveAt(0)
        End If
    End Sub
'</snippet5>

    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1())
    End Sub
End Class
