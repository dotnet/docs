    Sub TestDecoding()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText( 
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & 
                "\cipherText.txt")
        Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub