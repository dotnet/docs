Imports System.Drawing
Imports System.Windows.Forms

Public Class Class1


    '******************************************************************************
    Public Sub Test3()
        '<Snippet21>
        Dim regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                          "SOFTWARE\\Microsoft\\TestApp\\1.0", True)
        If regVersion Is Nothing Then
            ' Key doesn't exist; create it.
            regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                         "SOFTWARE\\Microsoft\\TestApp\\1.0")
        End If

        Dim intVersion As Integer = 0
        If regVersion IsNot Nothing Then
            intVersion = regVersion.GetValue("Version", 0)
            intVersion = intVersion + 1
            regVersion.SetValue("Version", intVersion)
            regVersion.Close()
        End If
        '</Snippet21>
    End Sub


    '******************************************************************************
    Public Sub Test2()
        '<Snippet20>
        Dim regVersion As Microsoft.Win32.RegistryKey
        Dim keyValue = "Software\\Microsoft\\TestApp\\1.0"
        regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyValue, False)
        Dim intVersion As Integer = 0
        If regVersion IsNot Nothing Then
            intVersion = regVersion.GetValue("Version", 0)
            regVersion.Close()
        End If
        '</Snippet20>
    End Sub


    '******************************************************************************
    Public Sub Test()

        '<Snippet18>
        My.Computer.Registry.SetValue(
            "HKEY_CURRENT_USER\Software\TestApp", "Name", "Author's Name")
        '</Snippet18>

        '<Snippet19>
        My.Computer.Registry.CurrentUser.DeleteSubKey(
            "Software\TestApp")
        '</Snippet19>
    End Sub


    '******************************************************************************
    ' HowtoDetermineIfaRemoteComputerIsAvailableInVisualBasic
    Public Sub Method1()
        ' <snippet1>
        If My.Computer.Network.Ping("198.01.01.01") Then
            MsgBox("Server pinged successfully.")
        Else
            MsgBox("Ping request timed out.")
        End If
        ' </snippet1>
    End Sub

    Public Sub Method2()
        ' <snippet2>
        If My.Computer.Network.Ping("www.cohowinery.com", 1000) Then
            MsgBox("Server pinged successfully.")
        Else
            MsgBox("Ping request timed out.")
        End If
        ' </snippet2>
    End Sub


    '******************************************************************************
    ' HowtoCheckConnectionStatusInVisualBasic
    Public Sub Method3()
        ' <snippet3>
        If My.Computer.Network.IsAvailable Then
            MsgBox("Computer is connected.")
        Else
            MsgBox("Computer is not connected.")
        End If
        ' </snippet3>
    End Sub


    '******************************************************************************
    ' HowtoReadAValueFromARegistryKeyInVisualBasic
    Public Sub Method4()
        ' <snippet4>
        Dim readValue = My.Computer.Registry.GetValue(
            "HKEY_CURRENT_USER\Software\MyApp", "Name", Nothing)
        MsgBox("The value is " & readValue)
        ' </snippet4>
    End Sub


    '******************************************************************************
    ' HowtoSaveAnAudioStreamToTheClipboardInVisualBasic
    Public Sub Method5()
        ' <snippet5>
        Dim musicReader = My.Computer.FileSystem.ReadAllBytes("cool.wav")
        My.Computer.Clipboard.SetAudio(musicReader)
        ' </snippet5>
    End Sub


    '******************************************************************************
    ' HowtoUploadAFileInVisualBasic
    Public Sub Method6()
        ' <snippet6>
        My.Computer.Network.UploadFile(
          "C:\My Documents\Order.txt",
          "http://www.cohowinery.com/upload.aspx")
        ' </snippet6>
    End Sub

    Public Sub Method7()
        ' <snippet7>
        My.Computer.Network.UploadFile(
          "C:\My Documents\Order.txt",
          "http://www.cohowinery.com/upload.aspx", "", "", True, 500)
        ' </snippet7>
    End Sub

    Public Sub Method8()
        ' <snippet8>
        My.Computer.Network.UploadFile(
          "C:\My Documents\Order.txt",
          "http://www.cohowinery.com/upload.aspx", "anonymous", "")
        ' </snippet8>
    End Sub


    '******************************************************************************
    ' HowtoDownloadAFileInVisualBasic
    Public Sub Method9()
        ' <snippet9>
        My.Computer.Network.DownloadFile(
            "http://www.cohowinery.com/downloads/WineList.txt",
            "C:\Documents and Settings\All Users\Documents\WineList.txt")
        ' </snippet9>
    End Sub

    Public Sub Method10()
        ' <snippet10>
        My.Computer.Network.DownloadFile(
            "http://www.cohowinery.com/downloads/WineList.txt",
            "C:\Documents and Settings\All Users\Documents\WineList.txt", False, 500)
        ' </snippet10>
    End Sub

    Public Sub Method11()
        ' <snippet11>
        My.Computer.Network.DownloadFile(
            "http://www.cohowinery.com/downloads/WineList.txt",
            "C:\Documents and Settings\All Users\Documents\WineList.txt", "anonymous", "")
        ' </snippet11>
    End Sub


    '******************************************************************************
    ' HowtoDetermineIfAValueExistsInARegistryKeyInVisualBasic
    Public Sub Method12()
        ' <snippet12>
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\TestApp",
        "TestValue", Nothing) Is Nothing Then
            MsgBox("Value does not exist.")
        End If
        ' </snippet12>
    End Sub


    '******************************************************************************
    ' HowtoDetermineWhatTypeofFileIsStoredOnTheClipboardInVisualBasic
    Public Sub Method13()
        ' <snippet13>
        If My.Computer.Clipboard.ContainsImage() Then
            MsgBox("Clipboard contains an image.")
        Else
            MsgBox("Clipboard does not contain an image.")
        End If
        ' </snippet13>
    End Sub


    '******************************************************************************
    ' HowtoCreateARegistryKeyAndSetItsValuesInVisualBasic
    Public Sub Method14()
        ' <snippet14>
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\MyTestKey",
          "MyTestKeyValue", "This is a test value.")
        ' </snippet14>
    End Sub

    Public Sub Method15()
        ' <snippet15>
        '<Snippet17>
        My.Computer.Registry.CurrentUser.CreateSubKey("MyTestKey")
        '</Snippet17>
        ' Change MyTestKeyValue to This is a test value.
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\MyTestKey",
          "MyTestKeyValue", "This is a test value.")
        ' </snippet15>
    End Sub


    '******************************************************************************
    ' HowtoRetrieveAnImageFromTheClipboardInVisualBasic
    Public Sub Method16()
        Dim picturebox1 As New System.Windows.Forms.PictureBox
        ' <snippet16>
        If My.Computer.Clipboard.ContainsImage() Then
            Dim grabpicture As System.Drawing.Image
            grabpicture = My.Computer.Clipboard.GetImage()
            picturebox1.Image = grabpicture
        End If
        ' </snippet16>
    End Sub

End Class
