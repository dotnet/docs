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
        Me.Menu = myMainMenu

        ' Clear the File menu items. 
        fileMenu.MenuItems.Clear()
    End Sub 'InitializeMyMenu