'<Snippet1>
Imports System
Imports System.Windows.Forms

Namespace ComboBoxSampleNamespace

    Public Class ComboBoxSample
        Inherits System.Windows.Forms.Form

        Private addButton As System.Windows.Forms.Button
        Private textBox2 As System.Windows.Forms.TextBox
        Private addGrandButton As System.Windows.Forms.Button
        Private comboBox1 As System.Windows.Forms.ComboBox
        Private showSelectedButton As System.Windows.Forms.Button
        Private textBox1 As System.Windows.Forms.TextBox
        Private findButton As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label

        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
        End Sub

        <System.STAThreadAttribute()> Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New ComboBoxSample())
        End Sub

        Private Sub InitializeComponent()
            Me.addButton = New System.Windows.Forms.Button()
            Me.textBox2 = New System.Windows.Forms.TextBox()
            Me.addGrandButton = New System.Windows.Forms.Button()
            Me.comboBox1 = New System.Windows.Forms.ComboBox()
            Me.showSelectedButton = New System.Windows.Forms.Button()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.findButton = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.addButton.Location = New System.Drawing.Point(248, 32)
            Me.addButton.Size = New System.Drawing.Size(40, 24)
            Me.addButton.TabIndex = 1
            Me.addButton.Text = "Add"
            AddHandler Me.addButton.Click, AddressOf Me.addButton_Click
            Me.textBox2.Location = New System.Drawing.Point(8, 64)
            Me.textBox2.Size = New System.Drawing.Size(232, 20)
            Me.textBox2.TabIndex = 6
            Me.textBox2.Text = ""
            Me.addGrandButton.Location = New System.Drawing.Point(8, 96)
            Me.addGrandButton.Size = New System.Drawing.Size(280, 23)
            Me.addGrandButton.TabIndex = 2
            Me.addGrandButton.Text = "Add 1,000 Items"
            AddHandler Me.addGrandButton.Click, AddressOf Me.addGrandButton_Click
            Me.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.comboBox1.DropDownWidth = 280
            Me.comboBox1.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5"})
            Me.comboBox1.Location = New System.Drawing.Point(8, 248)
            Me.comboBox1.Size = New System.Drawing.Size(280, 21)
            Me.comboBox1.TabIndex = 7
            Me.showSelectedButton.Location = New System.Drawing.Point(8, 128)
            Me.showSelectedButton.Size = New System.Drawing.Size(280, 24)
            Me.showSelectedButton.TabIndex = 4
            Me.showSelectedButton.Text = "What Item is Selected?"
            AddHandler Me.showSelectedButton.Click, AddressOf Me.showSelectedButton_Click
            Me.textBox1.Location = New System.Drawing.Point(8, 32)
            Me.textBox1.Size = New System.Drawing.Size(232, 20)
            Me.textBox1.TabIndex = 5
            Me.textBox1.Text = ""
            Me.findButton.Location = New System.Drawing.Point(248, 64)
            Me.findButton.Size = New System.Drawing.Size(40, 24)
            Me.findButton.TabIndex = 3
            Me.findButton.Text = "Find"
            AddHandler Me.findButton.Click, AddressOf Me.findButton_Click
            Me.label1.Location = New System.Drawing.Point(8, 224)
            Me.label1.Size = New System.Drawing.Size(144, 23)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Test ComboBox"
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.comboBox1, Me.textBox2, Me.textBox1, Me.showSelectedButton, Me.findButton, Me.addGrandButton, Me.addButton, Me.label1})
            Me.Text = "ComboBox Sample"
        End Sub

        Private Sub addButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            comboBox1.Items.Add(textBox1.Text)
        End Sub

        Private Sub findButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim index As Integer
            index = comboBox1.FindString(textBox2.Text)
            comboBox1.SelectedIndex = index
        End Sub

        Private Sub addGrandButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            comboBox1.BeginUpdate()
            Dim I As Integer
            For I = 0 To 1000
                comboBox1.Items.Add("Item 1" + i.ToString())
            Next
            comboBox1.EndUpdate()
        End Sub

        Private Sub showSelectedButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim selectedIndex As Integer
            selectedIndex = comboBox1.SelectedIndex
            Dim selectedItem As Object
            selectedItem = comboBox1.SelectedItem

            MessageBox.Show("Selected Item Text: " & selectedItem.ToString() & Microsoft.VisualBasic.Constants.vbCrLf & _
                                "Index: " & selectedIndex.ToString())
        End Sub
    End Class
End Namespace
'</Snippet1>
