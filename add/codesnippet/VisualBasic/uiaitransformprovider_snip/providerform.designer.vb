Imports System
Namespace UIAITransformProvider_snip
	Partial Public Class ProviderForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnResize = New System.Windows.Forms.Button()
			Me.btnRotate = New System.Windows.Forms.Button()
			Me.btnMove = New System.Windows.Forms.Button()
			Me.ResizeWidth = New System.Windows.Forms.TextBox()
			Me.RotateDegrees = New System.Windows.Forms.TextBox()
			Me.MoveX = New System.Windows.Forms.TextBox()
			Me.MoveY = New System.Windows.Forms.TextBox()
			Me.Exit = New System.Windows.Forms.Button()
			Me.ResizeHeight = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' btnResize
			' 
			Me.btnResize.Location = New System.Drawing.Point(12, 231)
			Me.btnResize.Name = "btnResize"
			Me.btnResize.Size = New System.Drawing.Size(75, 23)
			Me.btnResize.TabIndex = 0
			Me.btnResize.Text = "Resize"
			Me.btnResize.UseVisualStyleBackColor = True
'			Me.btnResize.Click += New System.EventHandler(Me.btnResize_Click)
			' 
			' btnRotate
			' 
			Me.btnRotate.Location = New System.Drawing.Point(110, 231)
			Me.btnRotate.Name = "btnRotate"
			Me.btnRotate.Size = New System.Drawing.Size(75, 23)
			Me.btnRotate.TabIndex = 1
			Me.btnRotate.Text = "Rotate"
			Me.btnRotate.UseVisualStyleBackColor = True
			' 
			' btnMove
			' 
			Me.btnMove.Location = New System.Drawing.Point(205, 231)
			Me.btnMove.Name = "btnMove"
			Me.btnMove.Size = New System.Drawing.Size(75, 23)
			Me.btnMove.TabIndex = 2
			Me.btnMove.Text = "Move"
			Me.btnMove.UseVisualStyleBackColor = True
			' 
			' ResizeWidth
			' 
			Me.ResizeWidth.Location = New System.Drawing.Point(12, 205)
			Me.ResizeWidth.Name = "ResizeWidth"
			Me.ResizeWidth.Size = New System.Drawing.Size(34, 20)
			Me.ResizeWidth.TabIndex = 3
			' 
			' RotateDegrees
			' 
			Me.RotateDegrees.Location = New System.Drawing.Point(110, 205)
			Me.RotateDegrees.Name = "RotateDegrees"
			Me.RotateDegrees.Size = New System.Drawing.Size(75, 20)
			Me.RotateDegrees.TabIndex = 4
			' 
			' MoveX
			' 
			Me.MoveX.Location = New System.Drawing.Point(205, 205)
			Me.MoveX.Name = "MoveX"
			Me.MoveX.Size = New System.Drawing.Size(34, 20)
			Me.MoveX.TabIndex = 5
			' 
			' MoveY
			' 
			Me.MoveY.Location = New System.Drawing.Point(245, 205)
			Me.MoveY.Name = "MoveY"
			Me.MoveY.Size = New System.Drawing.Size(34, 20)
			Me.MoveY.TabIndex = 6
			' 
			' Exit
			' 
			Me.Exit.Location = New System.Drawing.Point(205, 13)
			Me.Exit.Name = "Exit"
			Me.Exit.Size = New System.Drawing.Size(75, 23)
			Me.Exit.TabIndex = 7
			Me.Exit.Text = "Exit"
			Me.Exit.UseVisualStyleBackColor = True
'			Me.Exit.Click += New System.EventHandler(Me.Exit_Click)
			' 
			' ResizeHeight
			' 
			Me.ResizeHeight.Location = New System.Drawing.Point(53, 205)
			Me.ResizeHeight.Name = "ResizeHeight"
			Me.ResizeHeight.Size = New System.Drawing.Size(34, 20)
			Me.ResizeHeight.TabIndex = 8
			' 
			' ProviderForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(292, 266)
			Me.Controls.Add(Me.ResizeHeight)
			Me.Controls.Add(Me.Exit)
			Me.Controls.Add(Me.MoveY)
			Me.Controls.Add(Me.MoveX)
			Me.Controls.Add(Me.RotateDegrees)
			Me.Controls.Add(Me.ResizeWidth)
			Me.Controls.Add(Me.btnMove)
			Me.Controls.Add(Me.btnRotate)
			Me.Controls.Add(Me.btnResize)
			Me.Name = "ProviderForm"
			Me.Text = "Form1"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnResize As System.Windows.Forms.Button
		Private btnRotate As System.Windows.Forms.Button
		Private btnMove As System.Windows.Forms.Button
		Private ResizeWidth As System.Windows.Forms.TextBox
		Private RotateDegrees As System.Windows.Forms.TextBox
		Private MoveX As System.Windows.Forms.TextBox
		Private MoveY As System.Windows.Forms.TextBox
		Private WithEvents [Exit] As System.Windows.Forms.Button
		Private ResizeHeight As System.Windows.Forms.TextBox
	End Class
End Namespace

