    Public Sub New()
        MyBase.New()
        formCount = 0

        ' Handle the ApplicationExit event to know when the application is exiting.
        AddHandler Application.ApplicationExit, AddressOf OnApplicationExit

        Try
            ' Create a file that the application will store user specific data in.
            userData = New FileStream(Application.UserAppDataPath + "\appdata.txt", FileMode.OpenOrCreate)

        Catch e As IOException
            ' Inform the user that an error occurred.
            MessageBox.Show("An error occurred while attempting to show the application." + _
                            "The error is:" + e.ToString())

            ' Exit the current thread instead of showing the windows.
            ExitThread()
        End Try

        ' Create both application forms and handle the Closed event
        ' to know when both forms are closed.
        form1 = New AppForm1()
        AddHandler form1.Closed, AddressOf OnFormClosed
        AddHandler form1.Closing, AddressOf OnFormClosing
        formCount = formCount + 1

        form2 = New AppForm2()
        AddHandler form2.Closed, AddressOf OnFormClosed
        AddHandler form2.Closing, AddressOf OnFormClosing
        formCount = formCount + 1

        ' Get the form positions based upon the user specific data.
        If (ReadFormDataFromFile()) Then
            ' If the data was read from the file, set the form
            ' positions manually.
            form1.StartPosition = FormStartPosition.Manual
            form2.StartPosition = FormStartPosition.Manual

            form1.Bounds = form1Position
            form2.Bounds = form2Position
        End If

        ' Show both forms.
        form1.Show()
        form2.Show()
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        ' When the application is exiting, write the application data to the
        ' user file and close it.
        WriteFormDataToFile()

        Try
            ' Ignore any errors that might occur while closing the file handle.
            userData.Close()
        Catch
        End Try
    End Sub