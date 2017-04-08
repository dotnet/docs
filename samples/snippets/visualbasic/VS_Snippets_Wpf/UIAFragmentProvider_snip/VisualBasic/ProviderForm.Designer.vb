

Partial Class UIAFragmentProviderForm
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

#Region "Windows Form Designer generated code"


    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(201, 74)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(68, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "&OK"
        ' 
        ' UIAFragmentProviderForm
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 120)
        Me.Controls.Add(button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "UIAFragmentProviderForm"
        Me.Text = "UIAutomation Fragment Provider"
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 

#End Region

    Private WithEvents button1 As System.Windows.Forms.Button
End Class 'UIAFragmentProviderForm 

