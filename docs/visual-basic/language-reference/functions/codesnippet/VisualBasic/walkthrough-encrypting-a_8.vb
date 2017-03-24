    Sub TestEncoding()
        Dim plainText As String = InputBox("Enter the plain text:")
        Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText( 
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & 
            "\cipherText.txt", cipherText, False)
    End Sub