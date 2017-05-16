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
   Dim newFile As New MenuItem("&New")
   Dim openFile As New MenuItem("&Open")
   Dim exitProgram As New MenuItem("E&xit")
   
   ' Add the File menu item to myMainMenu.
   myMainMenu.MenuItems.Add(fileMenu)
   
   ' Add three submenus to the File menu.
   fileMenu.MenuItems.Add(newFile)
   fileMenu.MenuItems.Add(openFile)
   fileMenu.MenuItems.Add(exitProgram)
   
   ' Assign myMainMenu to the form.
   Me.Menu = myMainMenu
   
   ' Count the number of objects in the File menu and display the result.
   Dim objectNumber As String = fileMenu.MenuItems.Count.ToString()
   MessageBox.Show(("Number of objects in the File menu = " + objectNumber))
End Sub 
'InitializeMyMenu
' </snippet1>

   Public Shared Sub Main()
      Application.Run(New TestForm())
   End Sub

End Class

