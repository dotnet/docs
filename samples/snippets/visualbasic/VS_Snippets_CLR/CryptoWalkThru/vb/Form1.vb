Imports System.IO
Imports System.Security.Cryptography

Public Class Form1

#Region "NonSnippets"
    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeButton.Click
        Application.Exit()
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Snippet1 - Global Objects"
    '<Snippet1>
    ' Declare CspParmeters and RsaCryptoServiceProvider 
    ' objects with global scope of your Form class.
    ReadOnly _cspp As New CspParameters
    Dim _rsa As RSACryptoServiceProvider

    ' Path variables for source, encryption, and
    ' decryption folders. Must end with a backslash.
    Const EncrFolder As String = "c:\Encrypt\"
    Const DecrFolder As String = "c:\Decrypt\"
    Const SrcFolder As String = "c:\docs\"

    ' Public key file
    Const PubKeyFile As String = "c:\encrypt\rsaPublicKey.txt"

    ' Key container name for
    ' private/public key value pair.
    Const KeyName As String = "Key01"
    ' </Snippet1>
#End Region

#Region "Snippet2 - buttonCreateAsmKeys"
    '<Snippet2>
    Private Sub buttonCreateAsmKeys_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCreateAsmKeys.Click
        ' Stores a key pair in the key container.
        _cspp.KeyContainerName = KeyName
        _rsa = New RSACryptoServiceProvider(_cspp) With {
            .PersistKeyInCsp = True
        }

        If _rsa.PublicOnly Then
            Label1.Text = $"Key: {_cspp.KeyContainerName} - Public Only"
        Else
            Label1.Text = $"Key: {_cspp.KeyContainerName} - Full Key Pair"
        End If

    End Sub
    '</Snippet2>
#End Region

#Region "Snippet3 - buttonEncryptFile"
    ' <Snippet3>
    Private Sub buttonEncryptFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonEncryptFile.Click
        If _rsa Is Nothing Then
            MsgBox("Key not set.")
        Else
            ' Display a dialog box to select a file to encrypt.
            _encryptOpenFileDialog.InitialDirectory = SrcFolder
            If _encryptOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim fName As String = _encryptOpenFileDialog.FileName
                    If (Not (fName) Is Nothing) Then
                        Dim fInfo As New FileInfo(fName)
                        ' Use just the file name without path.
                        Dim name As String = fInfo.FullName
                        EncryptFile(name)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    ' </Snippet3>
#End Region

#Region "Snippet4 - buttonDecryptFile"
    '<Snippet4>
    Private Sub buttonDecryptFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDecryptFile.Click
        If _rsa Is Nothing Then
            MsgBox("Key not set.")
        Else
            ' Display a dialog box to select the encrypted file.
            _decryptOpenFileDialog.InitialDirectory = EncrFolder
            If (_decryptOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Try
                    Dim fName As String = _decryptOpenFileDialog.FileName
                    If ((fName) IsNot Nothing) Then
                        Dim fi As New FileInfo(fName)
                        Dim name As String = fi.Name
                        DecryptFile(name)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
    '</Snippet4>
#End Region

#Region "Snippet5 - EncryptFile"
    '<Snippet5>
    Private Sub EncryptFile(ByVal inFile As String)
        ' Create instance of Aes for
        ' symmetric encryption of the data.
        Dim aes As Aes = Aes.Create()
        Dim transform As ICryptoTransform = aes.CreateEncryptor

        ' Use RSACryptoServiceProvider to 
        ' encrypt the AES key.
        Dim keyEncrypted() As Byte = _rsa.Encrypt(aes.Key, False)

        ' Create byte arrays to contain
        ' the length values of the key and IV.
        Dim LenK() As Byte = New Byte((4) - 1) {}
        Dim LenIV() As Byte = New Byte((4) - 1) {}
        Dim lKey As Integer = keyEncrypted.Length
        LenK = BitConverter.GetBytes(lKey)
        Dim lIV As Integer = aes.IV.Length
        LenIV = BitConverter.GetBytes(lIV)

        ' Write the following to the FileStream
        ' for the encrypted file (outFs):
        ' - length of the key
        ' - length of the IV
        ' - ecrypted key
        ' - the IV
        ' - the encrypted cipher content
        ' Change the file's extension to ".enc"
        Dim startFileName As Integer = inFile.LastIndexOf("\") + 1
        Dim outFile As String = (EncrFolder _
                    + (inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".enc"))

        Using outFs As New FileStream(outFile, FileMode.Create)
            outFs.Write(LenK, 0, 4)
            outFs.Write(LenIV, 0, 4)
            outFs.Write(keyEncrypted, 0, lKey)
            outFs.Write(aes.IV, 0, lIV)

            ' Now write the cipher text using
            ' a CryptoStream for encrypting.
            Using outStreamEncrypted As New CryptoStream(outFs, transform, CryptoStreamMode.Write)
                ' By encrypting a chunk at
                ' a time, you can save memory
                ' and accommodate large files.
                Dim count As Integer = 0
                Dim offset As Integer = 0

                ' blockSizeBytes can be any arbitrary size.
                Dim blockSizeBytes As Integer = (aes.BlockSize / 8)
                Dim data() As Byte = New Byte((blockSizeBytes) - 1) {}
                Dim bytesRead As Integer = 0
                Using inFs As New FileStream(inFile, FileMode.Open)
                    Do
                        count = inFs.Read(data, 0, blockSizeBytes)
                        offset = (offset + count)
                        outStreamEncrypted.Write(data, 0, count)
                        bytesRead = (bytesRead + blockSizeBytes)
                    Loop Until (count = 0)

                    outStreamEncrypted.FlushFinalBlock()
                    inFs.Close()
                End Using
                outStreamEncrypted.Close()
            End Using
            outFs.Close()
        End Using
    End Sub
    ' </Snippet5>
#End Region

#Region "Snippet6 - DecryptFile"
    '<Snippet6>
    Private Sub DecryptFile(ByVal inFile As String)
        ' Create instance of Aes for
        ' symmetric decryption of the data.
        Dim aes As Aes = Aes.Create()

        ' Create byte arrays to get the length of
        ' the encrypted key and IV.
        ' These values were stored as 4 bytes each
        ' at the beginning of the encrypted package.
        Dim LenK() As Byte = New Byte(4 - 1) {}
        Dim LenIV() As Byte = New Byte(4 - 1) {}

        ' Construct the file name for the decrypted file.
        Dim outFile As String = (DecrFolder _
                    + (inFile.Substring(0, inFile.LastIndexOf(".")) + ".txt"))

        ' Use FileStream objects to read the encrypted
        ' file (inFs) and save the decrypted file (outFs).
        Using inFs As New FileStream((EncrFolder + inFile), FileMode.Open)

            inFs.Seek(0, SeekOrigin.Begin)
            inFs.Read(LenK, 0, 3)
            inFs.Seek(4, SeekOrigin.Begin)
            inFs.Read(LenIV, 0, 3)

            Dim lengthK As Integer = BitConverter.ToInt32(LenK, 0)
            Dim lengthIV As Integer = BitConverter.ToInt32(LenIV, 0)
            Dim startC As Integer = (lengthK + lengthIV + 8)
            Dim lenC As Integer = (CType(inFs.Length, Integer) - startC)
            Dim KeyEncrypted() As Byte = New Byte(lengthK - 1) {}
            Dim IV() As Byte = New Byte(lengthIV - 1) {}

            ' Extract the key and IV
            ' starting from index 8
            ' after the length values.
            inFs.Seek(8, SeekOrigin.Begin)
            inFs.Read(KeyEncrypted, 0, lengthK)
            inFs.Seek(8 + lengthK, SeekOrigin.Begin)
            inFs.Read(IV, 0, lengthIV)
            Directory.CreateDirectory(DecrFolder)
            '<Snippet10>
            ' User RSACryptoServiceProvider
            ' to decrypt the AES key
            Dim KeyDecrypted() As Byte = _rsa.Decrypt(KeyEncrypted, False)

            ' Decrypt the key.
            Dim transform As ICryptoTransform = aes.CreateDecryptor(KeyDecrypted, IV)
            '</Snippet10>
            ' Decrypt the cipher text from
            ' from the FileSteam of the encrypted
            ' file (inFs) into the FileStream
            ' for the decrypted file (outFs).
            Using outFs As New FileStream(outFile, FileMode.Create)
                Dim count As Integer = 0
                Dim offset As Integer = 0

                ' blockSizeBytes can be any arbitrary size.
                Dim blockSizeBytes As Integer = (aes.BlockSize / 8)
                Dim data() As Byte = New Byte(blockSizeBytes - 1) {}
                ' By decrypting a chunk a time,
                ' you can save memory and
                ' accommodate large files.
                ' Start at the beginning
                ' of the cipher text.
                inFs.Seek(startC, SeekOrigin.Begin)
                Using outStreamDecrypted As New CryptoStream(outFs, transform, CryptoStreamMode.Write)
                    Do
                        count = inFs.Read(data, 0, blockSizeBytes)
                        offset += count
                        outStreamDecrypted.Write(data, 0, count)
                    Loop Until (count = 0)

                    outStreamDecrypted.FlushFinalBlock()
                End Using
            End Using
        End Using
    End Sub
    ' </Snippet6>
#End Region

#Region "Snippet7 - buttonGetPrivateKey"
    '<Snippet7>
    Private Sub buttonGetPrivateKey_Click(ByVal sender As Object,
        ByVal e As EventArgs) Handles buttonGetPrivateKey.Click
        _cspp.KeyContainerName = KeyName
        _rsa = New RSACryptoServiceProvider(_cspp) With {
            .PersistKeyInCsp = True
        }
        If _rsa.PublicOnly Then
            Label1.Text = $"Key: {_cspp.KeyContainerName} - Public Only"
        Else
            Label1.Text = $"Key: {_cspp.KeyContainerName} - Full Key Pair"
        End If
    End Sub
    '</Snippet7>
#End Region

#Region "Snippet8 - buttonExportPublicKey"
    '<Snippet8>
    Private Sub buttonExportPublicKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonExportPublicKey.Click
        ' Save the public key created by the RSA
        ' to a file. Caution, persisting the
        ' key to a file is a security risk.
        Directory.CreateDirectory(EncrFolder)
        Using sw As New StreamWriter(PubKeyFile)
            sw.Write(_rsa.ToXmlString(False))
        End Using
    End Sub
    '</Snippet8>
#End Region

#Region "Snippet9 - buttonImportPubicKey"
    '<Snippet9>
    Private Sub buttonImportPublicKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonImportPublicKey.Click
        Using sr As New StreamReader(PubKeyFile)
            _cspp.KeyContainerName = KeyName
            _rsa = New RSACryptoServiceProvider(_cspp)
            Dim keytxt As String = sr.ReadToEnd
            _rsa.FromXmlString(keytxt)
            _rsa.PersistKeyInCsp = True

            If _rsa.PublicOnly Then
                Label1.Text = $"Key: {_cspp.KeyContainerName} - Public Only"
            Else
                Label1.Text = $"Key: {_cspp.KeyContainerName} - Full Key Pair"
            End If
        End Using
    End Sub
    '</Snippet9>
#End Region

End Class
