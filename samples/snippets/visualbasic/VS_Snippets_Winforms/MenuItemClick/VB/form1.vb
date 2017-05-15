Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateMyMenu()
    End Sub

    ' <snippet1>
    Public Sub CreateMyMenu()
      ' Create a main menu object.
      Dim mainMenu1 As New MainMenu()

      ' Create empty menu item objects.
      Dim topMenuItem As New MenuItem()
      Dim menuItem1 As New MenuItem()

      ' Set the caption of the menu items.
      topMenuItem.Text = "&File"
      menuItem1.Text = "&Open"

      ' Add the menu items to the main menu.
      topMenuItem.MenuItems.Add(menuItem1)
      mainMenu1.MenuItems.Add(topMenuItem)

      ' Add functionality to the menu items using the Click event. 
      AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
      ' Assign mainMenu1 to the form.
      Me.Menu = mainMenu1
   End Sub


   Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      ' Create a new OpenFileDialog and display it.
      Dim fd As New OpenFileDialog()
      fd.DefaultExt = "*.*"
      fd.ShowDialog()
   End Sub
   ' </snippet1>
End Class
