'
'This code examples shows a use of the Control.Capture property.
'
Imports System.Windows.Forms

Public Class CaptureForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents listbox1 As System.Windows.Forms.ListBox
    Friend WithEvents listbox2 As System.Windows.Forms.ListBox

    Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label
        Me.listbox1 = New System.Windows.Forms.ListBox
        Me.listbox2 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(168, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 72)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Click around the form to see what control has captured  the mouse."
        '
        'LunchBox
        '
        Me.listbox2.AllowDrop = True
        Me.listbox2.Items.AddRange(New Object() {"Sandwich", "Chips", "Soda", "Soup", "Salad"})
        Me.listbox2.Location = New System.Drawing.Point(296, 64)
        Me.listbox2.Name = "LunchBox"
        Me.listbox2.Size = New System.Drawing.Size(120, 95)
        Me.listbox2.TabIndex = 5
        '
        'BreakfastBox
        '
        Me.listbox1.AllowDrop = True
        Me.listbox1.Items.AddRange(New Object() {"Bagels", "Pancakes", "Donuts", "Eggs", "Hashbrowns", "Orange Juice"})
        Me.listbox1.Location = New System.Drawing.Point(24, 64)
        Me.listbox1.Name = "BreakfastBox"
        Me.listbox1.Size = New System.Drawing.Size(120, 95)
        Me.listbox1.TabIndex = 6
        '
        'CaptureForm
        '
        Me.ClientSize = New System.Drawing.Size(440, 266)
        Me.Controls.Add(Me.listbox1)
        Me.Controls.Add(Me.listbox2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CaptureForm"
        Me.Text = "CaptureForm"
        Me.ResumeLayout(False)

    End Sub
    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New CaptureForm)
    End Sub

    '<snippet1>
    'This method handles the mouse down event for all the controls on the form.  When a control has
    'captured the mouse, the control's name will be output on label1.
    Private Sub Control_MouseDown(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, _
        label1.MouseDown, listbox1.MouseDown, listbox2.MouseDown
        Dim control As Control = CType(sender, Control)
        If (control.Capture) Then
            label1.Text = control.Name & " has captured the mouse"
        End If
    End Sub
    '</snippet1>

End Class
