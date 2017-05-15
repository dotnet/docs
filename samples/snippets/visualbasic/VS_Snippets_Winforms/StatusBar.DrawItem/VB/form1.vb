Public NotInheritable Class Form1
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
   Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
   Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
   Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
   Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.StatusBar1 = New System.Windows.Forms.StatusBar()
      Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
      Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
      Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
      CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'StatusBar1
      '
      Me.StatusBar1.Location = New System.Drawing.Point(0, 296)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
      Me.StatusBar1.ShowPanels = True
      Me.StatusBar1.Size = New System.Drawing.Size(504, 22)
      Me.StatusBar1.TabIndex = 0
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarPanel1
      '
      Me.StatusBarPanel1.Text = "StatusBarPanel1"
      '
      'StatusBarPanel2
      '
      Me.StatusBarPanel2.Text = "StatusBarPanel2"
      '
      'StatusBarPanel3
      '
      Me.StatusBarPanel3.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
      Me.StatusBarPanel3.Text = "StatusBarPanel3"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(504, 318)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   '<Snippet1>
   Private Sub StatusBar1_DrawItem(ByVal sender As Object, ByVal sbdevent As System.Windows.Forms.StatusBarDrawItemEventArgs) Handles StatusBar1.DrawItem

      ' Create a StringFormat object to align text in the panel.
      Dim sf As New StringFormat()
      ' Format the String of the StatusBarPanel to be centered.
      sf.Alignment = StringAlignment.Center
      sf.LineAlignment = StringAlignment.Center

      ' Draw a black background in owner-drawn panel.
      sbdevent.Graphics.FillRectangle(Brushes.Black, sbdevent.Bounds)
      ' Draw the current date (short date format) with white text in the control's font.
      sbdevent.Graphics.DrawString(DateTime.Today.ToShortDateString(), StatusBar1.Font, Brushes.White, _
            New RectangleF(sbdevent.Bounds.X, sbdevent.Bounds.Y, _
            sbdevent.Bounds.Width, sbdevent.Bounds.Height), sf)
   End Sub
   '</Snippet1>
End Class
