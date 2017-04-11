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
   Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
   Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
   Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
   Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
   Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
   Friend WithEvents menuOpen As System.Windows.Forms.MenuItem
   Friend WithEvents menuSave As System.Windows.Forms.MenuItem
   Friend WithEvents menuExit As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.StatusBar1 = New System.Windows.Forms.StatusBar()
      Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
      Me.MainMenu1 = New System.Windows.Forms.MainMenu()
      Me.MenuItem1 = New System.Windows.Forms.MenuItem()
      Me.menuOpen = New System.Windows.Forms.MenuItem()
      Me.menuSave = New System.Windows.Forms.MenuItem()
      Me.MenuItem4 = New System.Windows.Forms.MenuItem()
      Me.menuExit = New System.Windows.Forms.MenuItem()
      CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'StatusBar1
      '
      Me.StatusBar1.Location = New System.Drawing.Point(0, 344)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
      Me.StatusBar1.ShowPanels = True
      Me.StatusBar1.Size = New System.Drawing.Size(376, 22)
      Me.StatusBar1.TabIndex = 0
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarPanel1
      '
      Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.StatusBarPanel1.Text = "StatusBarPanel1"
      Me.StatusBarPanel1.Width = 360
      '
      'MainMenu1
      '
      Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
      '
      'MenuItem1
      '
      Me.MenuItem1.Index = 0
      Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuOpen, Me.menuSave, Me.MenuItem4, Me.menuExit})
      Me.MenuItem1.Text = "&File"
      '
      'menuOpen
      '
      Me.menuOpen.Index = 0
      Me.menuOpen.Text = "&Open"
      '
      'menuSave
      '
      Me.menuSave.Index = 1
      Me.menuSave.Text = "&Save"
      '
      'MenuItem4
      '
      Me.MenuItem4.Index = 2
      Me.MenuItem4.Text = "-"
      '
      'menuExit
      '
      Me.menuExit.Index = 3
      Me.menuExit.Text = "E&xit"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(376, 366)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1})
      Me.Menu = Me.MainMenu1
      Me.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   '<Snippet1>
   Private Sub MenuSelected(ByVal sender As Object, ByVal e As System.EventArgs) _
                        Handles menuOpen.Select, menuExit.Select, menuSave.Select
      If sender Is menuOpen Then
         StatusBar1.Panels(0).Text = "Opens a file to edit"
      Else
         If sender Is menuSave Then
            StatusBar1.Panels(0).Text = "Saves the current file"
         Else
            If sender Is menuExit Then
               StatusBar1.Panels(0).Text = "Exits the application"
            Else
               StatusBar1.Panels(0).Text = "Ready"
            End If
         End If
      End If
   End Sub
   '</Snippet1>

End Class
