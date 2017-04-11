Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
   Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar
   Friend WithEvents statusBarPanel1 As System.Windows.Forms.StatusBarPanel
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
      Me.statusBar1 = New System.Windows.Forms.StatusBar()
      Me.statusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
      CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(192, 32)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Button1"
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Location = New System.Drawing.Point(32, 32)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(152, 23)
      Me.ProgressBar1.TabIndex = 1
      '
      'statusBar1
      '
      Me.statusBar1.Location = New System.Drawing.Point(0, 244)
      Me.statusBar1.Name = "statusBar1"
      Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanel1})
      Me.statusBar1.ShowPanels = True
      Me.statusBar1.Size = New System.Drawing.Size(292, 22)
      Me.statusBar1.TabIndex = 3
      Me.statusBar1.Text = "statusBar1"
      '
      'statusBarPanel1
      '
      Me.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.statusBarPanel1.Text = "Ready"
      Me.statusBarPanel1.Width = 276
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1, Me.ProgressBar1, Me.Button1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region
   '<Snippet1>
   Private time As New Timer()

   ' Call this method from the constructor of the form.
   Private Sub InitializeMyTimer()
      ' Set the interval for the timer.
      time.Interval = 250
      ' Connect the Tick event of the timer to its event handler.
      AddHandler time.Tick, AddressOf IncreaseProgressBar
      ' Start the timer.
      time.Start()
   End Sub


   Private Sub IncreaseProgressBar(ByVal sender As Object, ByVal e As EventArgs)
      ' Increment the value of the ProgressBar a value of one each time.
      ProgressBar1.Increment(1)
      ' Display the textual value of the ProgressBar in the StatusBar control's first panel.
      statusBarPanel1.Text = ProgressBar1.Value.ToString() + "% Completed"
      ' Determine if we have completed by comparing the value of the Value property to the Maximum value.
      If ProgressBar1.Value = ProgressBar1.Maximum Then
         ' Stop the timer.
         time.Stop()
      End If
   End Sub
   '</Snippet1>

   Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
      InitializeMyTimer()
   End Sub
End Class
