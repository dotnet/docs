
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace MenuPopupEx
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private mainMenu1 As System.Windows.Forms.MainMenu
      Private WithEvents menuEdit As System.Windows.Forms.MenuItem
      Private menuCut As System.Windows.Forms.MenuItem
      Private menuCopy As System.Windows.Forms.MenuItem
      Private menuPaste As System.Windows.Forms.MenuItem
      Private textBox1 As System.Windows.Forms.TextBox
      Private button1 As System.Windows.Forms.Button
      Private menuDelete As System.Windows.Forms.MenuItem
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New
       
      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      
      '/ <summary>
      '/ Clean up any resources being used.
      '/ </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose


      '
      'ToDo: Error processing original source shown below
      '
      '  #region Windows Form Designer generated code
      '-----^--- Pre-processor directives not translated
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
         Me.mainMenu1 = New System.Windows.Forms.MainMenu()
         Me.menuEdit = New System.Windows.Forms.MenuItem()
         Me.menuCut = New System.Windows.Forms.MenuItem()
         Me.menuCopy = New System.Windows.Forms.MenuItem()
         Me.menuPaste = New System.Windows.Forms.MenuItem()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me.menuDelete = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' mainMenu1
         ' 
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuEdit})
         ' 
         ' menuEdit
         ' 
         Me.menuEdit.Index = 0
         Me.menuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCut, Me.menuCopy, Me.menuPaste, Me.menuDelete})
         Me.menuEdit.Text = "&Edit"
         ' 
         ' menuCut
         ' 
         Me.menuCut.Index = 0
         Me.menuCut.Text = "Cu&t"
         ' 
         ' menuCopy
         ' 
         Me.menuCopy.Index = 1
         Me.menuCopy.Text = "&Copy"
         ' 
         ' menuPaste
         ' 
         Me.menuPaste.Index = 2
         Me.menuPaste.Text = "&Paste"
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(120, 153)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(168, 20)
         Me.textBox1.TabIndex = 1
         Me.textBox1.Text = "textBox1"
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(304, 152)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' menuDelete
         ' 
         Me.menuDelete.Index = 3
         Me.menuDelete.Text = "&Delete"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(408, 326)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.textBox1})
         Me.Menu = Me.mainMenu1
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      '
      'ToDo: Error processing original source shown below
      '      }
      '  #endregion
      '-----^--- Pre-processor directives not translated
      '/ <summary>
      '/ The main entry point for the application.
      '/ </summary>
      <STAThread()> _
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main


      '<Snippet1>
      Private Sub PopupMyMenu(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEdit.Popup
         If textBox1.Enabled = False OrElse textBox1.Focused = False OrElse textBox1.SelectedText.Length = 0 Then
            menuCut.Enabled = False
            menuCopy.Enabled = False
            menuDelete.Enabled = False
         Else
            menuCut.Enabled = True
            menuCopy.Enabled = True
            menuDelete.Enabled = True
         End If
      End Sub
      '</Snippet1>
   End Class 'Form1 
End Namespace 'MenuPopupEx
