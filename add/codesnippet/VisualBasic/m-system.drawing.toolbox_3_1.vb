<System.Drawing.ToolboxBitmap(GetType(System.Windows.Forms.Button))> _
Public Class StopSignControl3
    Inherits System.Windows.Forms.UserControl

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button

        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
            12.0F, System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stop!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(56, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "stop"
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StopSignControl"

    End Sub

    Private Sub StopSignControl_MouseEnter(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        Label1.Text.ToUpper()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 14.0F, _
            System.Drawing.FontStyle.Bold)
        Button1.Enabled = True
    End Sub

    Private Sub StopSignControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        Label1.Text.ToLower()
        Label1.Font = New System.Drawing.Font(Label1.Font.FontFamily, 12.0F, _
             System.Drawing.FontStyle.Regular)
        Button1.Enabled = False
    End Sub

End Class