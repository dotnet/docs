'<SNIPPET1>
Imports System.Drawing
Imports System.Windows.Forms

Namespace ValidateChildrenWithConstraints
    _
    Class Form1
        Inherits Form

        Public Overloads Shared Sub Main(ByVal args() As String)
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Private Sub New()
            AddHandler Me.Load, AddressOf Form1_Load
        End Sub

        Dim WithEvents TextBox1, TextBox2, TextBox3 As TextBox
        Dim FlowPanel1 As FlowLayoutPanel
        Dim WithEvents SubTextBox1 As TextBox
        Dim WithEvents Button1 As Button

        Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create controls on form.

            Me.Size = New Size(500, 300)
            Me.AutoValidate = AutoValidate.Disable

            TextBox1 = New TextBox()
            TextBox1.Location = New Point(20, 20)
            TextBox1.Size = New Size(75, TextBox1.Size.Height)
            TextBox1.CausesValidation = True
            Me.Controls.Add(TextBox1)

            TextBox2 = New TextBox()
            TextBox2.Location = New Point(105, 20)
            TextBox2.Size = New Size(75, TextBox2.Size.Height)
            TextBox2.CausesValidation = True
            Me.Controls.Add(TextBox2)

            TextBox3 = New TextBox()
            TextBox3.Location = New Point(190, 20)
            TextBox3.Size = New Size(75, TextBox3.Size.Height)
            TextBox3.Enabled = False
            TextBox3.CausesValidation = True
            Me.Controls.Add(TextBox3)

            Button1 = New Button()
            Button1.Text = "Click"
            Button1.Location = New Point(270, 20)
            Me.Controls.Add(Button1)

            FlowPanel1 = New FlowLayoutPanel()
            FlowPanel1.Size = New Size(400, 100)
            FlowPanel1.Dock = DockStyle.Bottom
            SubTextBox1 = New TextBox()
            SubTextBox1.CausesValidation = True
            FlowPanel1.Controls.Add(SubTextBox1)
            Me.Controls.Add(FlowPanel1)
        End Sub 'Form1_Load


        Sub SubTextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SubTextBox1.Validating
            MessageBox.Show("SubTextBox1 Validating!")
        End Sub 'SubTextBox1_Validating


        Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
            MessageBox.Show("TextBox1 Validating!")
        End Sub 'TextBox1_Validating


        Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
            MessageBox.Show("TextBox2 Validating!")
        End Sub 'TextBox2_Validating


        Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
            MessageBox.Show("TextBox3 Validating!")
        End Sub 'TextBox3_Validating


        Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Me.ValidateChildren((ValidationConstraints.ImmediateChildren Or ValidationConstraints.Enabled))
        End Sub 'Button1_Click
    End Class 'Form1
End Namespace 'ValidateChildrenWithConstraints
'</SNIPPET1>