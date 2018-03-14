Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class TestForm
   Inherits Form

' <snippet1>
Public Sub InitializeMenu()
   ' Create the MainMenu object.
   Dim myMainMenu As New MainMenu()
   
   ' Create the MenuItem objects.
   Dim fileMenu As New MenuItem("&File")
   Dim editMenu As New MenuItem("&Edit")
   Dim newFile As New MenuItem("&New")
   Dim openFile As New MenuItem("&Open")
   Dim exitProgram As New MenuItem("E&xit")
   
   ' Add the MenuItem objects to myMainMenu.
   myMainMenu.MenuItems.Add(fileMenu)
   myMainMenu.MenuItems.Add(editMenu)
   
   ' Add three submenus to the File menu.
   fileMenu.MenuItems.Add(newFile)
   fileMenu.MenuItems.Add(openFile)
   fileMenu.MenuItems.Add(exitProgram)
   
   ' Assign myMainMenu to the form.
   Menu = myMainMenu
   
   ' Check that the File menu contains the Open menu item.
   If fileMenu.MenuItems.Contains(openFile) Then
      MessageBox.Show("The File menu contains 'Open' ", fileMenu.Text)
   End If
End Sub 
'InitializeMenu
' </snippet1>

   Public Shared Sub Main()
      Application.Run(New TestForm())
   End Sub

End Class

