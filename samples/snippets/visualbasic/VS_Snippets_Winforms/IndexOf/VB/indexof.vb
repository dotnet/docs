Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class TestForm
   Inherits Form
' <snippet1>
Public Sub InitializeMyMenu()
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
   
   ' Retrieve the index of the Exit menu item.
   Dim indexValue As String = fileMenu.MenuItems.IndexOf(exitProgram).ToString()
   ' Display the result in a message box.
   MessageBox.Show("The index of the Exit menu item = " + indexValue, "MenuItem Information")
End Sub 'InitializeMyMenu
' </snippet1>

   Public Shared Sub Main()
      Application.Run(New TestForm())
   End Sub

End Class

