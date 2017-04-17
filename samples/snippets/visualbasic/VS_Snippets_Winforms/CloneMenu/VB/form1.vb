Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

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
   Private components As System.ComponentModel.Container

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
      CloneMyMainMenu()
   End Sub
   
   ' <snippet1>
   Private Sub CloneMyMainMenu()
      ' Create the main menu.
      Dim mainMenu1 As New MainMenu()

      ' Create the menu items to add.
      Dim menuItem1 As New MenuItem()
      Dim menuItem2 As New MenuItem()
      Dim menuItem3 As New MenuItem()

      ' Set the caption for the menu items.
      menuItem1.Text = "File"
      menuItem2.Text = "Edit"
      menuItem3.Text = "View"

      ' Add the menu item to mainMenu1.
      mainMenu1.MenuItems.Add(menuItem1)
      mainMenu1.MenuItems.Add(menuItem2)
      mainMenu1.MenuItems.Add(menuItem3)

      ' Clone the mainMenu1 and name it mainMenu2.
      Dim mainMenu2 As MainMenu = mainMenu1.CloneMenu()

      ' Assign mainMenu2 to the form.
      Menu = mainMenu2
   End Sub 'CloneMyMainMenu
   ' </snippet1>

   Public Shared Sub Main()
      Application.Run(new Form1())
   End Sub
End Class
