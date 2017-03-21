    Public Sub CreateMyMainMenu()
        ' Create two MenuItem objects and assign to array.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        menuItem1.Text = "&File"
        menuItem2.Text = "&Edit"

        ' Create a MainMenu and assign MenuItem objects.
        Dim mainMenu1 As New MainMenu(New MenuItem() {menuItem1, menuItem2})

        ' Determine if mainMenu1 is currently hosted on the form.
        If (mainMenu1.IsParent) Then
            ' Set the RightToLeft property for mainMenu1.
            mainMenu1.RightToLeft = RightToLeft.Yes
            ' Bind the MainMenu to Form1.
            Menu = mainMenu1
        End If

    End Sub