'<Snippet1>
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text
Imports System.IO

' A simple form that represents a window in our application
Public Class AppForm1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        Me.Size = New System.Drawing.Size(300, 300)
        Me.Text = "AppForm1"

    End Sub

End Class

' A simple form that represents a window in our application
Public Class AppForm2
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        Me.Size = New System.Drawing.Size(300, 300)
        Me.Text = "AppForm2"

    End Sub

End Class

'<Snippet2>
' The class that handles the creation of the application windows
Public Class MyApplicationContext
    Inherits ApplicationContext

    Private _formCount As Integer
    Private _form1 As AppForm1
    Private _form2 As AppForm2

    Private _form1Position As Rectangle
    Private _form2Position As Rectangle

    Private _userData As FileStream

    '<Snippet5>
    Public Sub New()
        MyBase.New()
        _formCount = 0

        ' Handle the ApplicationExit event to know when the application is exiting.
        AddHandler Application.ApplicationExit, AddressOf OnApplicationExit

        Try
            ' Create a file that the application will store user specific data in.
            _userData = New FileStream(Application.UserAppDataPath + "\appdata.txt", FileMode.OpenOrCreate)

        Catch e As IOException
            ' Inform the user that an error occurred.
            MessageBox.Show("An error occurred while attempting to show the application." +
                            "The error is:" + e.ToString())

            ' Exit the current thread instead of showing the windows.
            ExitThread()
        End Try

        ' Create both application forms and handle the Closed event
        ' to know when both forms are closed.
        _form1 = New AppForm1()
        AddHandler _form1.Closed, AddressOf OnFormClosed
        AddHandler _form1.Closing, AddressOf OnFormClosing
        _formCount = _formCount + 1

        _form2 = New AppForm2()
        AddHandler _form2.Closed, AddressOf OnFormClosed
        AddHandler _form2.Closing, AddressOf OnFormClosing
        _formCount = _formCount + 1

        ' Get the form positions based upon the user specific data.
        If (ReadFormDataFromFile()) Then
            ' If the data was read from the file, set the form
            ' positions manually.
            _form1.StartPosition = FormStartPosition.Manual
            _form2.StartPosition = FormStartPosition.Manual

            _form1.Bounds = _form1Position
            _form2.Bounds = _form2Position
        End If

        ' Show both forms.
        _form1.Show()
        _form2.Show()
    End Sub

    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        ' When the application is exiting, write the application data to the
        ' user file and close it.
        WriteFormDataToFile()

        Try
            ' Ignore any errors that might occur while closing the file handle.
            _userData.Close()
        Catch
        End Try
    End Sub
    '</Snippet5>

    Private Sub OnFormClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
        ' When a form is closing, remember the form position so it
        ' can be saved in the user data file.
        If TypeOf sender Is AppForm1 Then
            _form1Position = CType(sender, Form).Bounds
        ElseIf TypeOf sender Is AppForm2 Then
            _form2Position = CType(sender, Form).Bounds
        End If
    End Sub

    '<Snippet3>
    Private Sub OnFormClosed(ByVal sender As Object, ByVal e As EventArgs)
        ' When a form is closed, decrement the count of open forms.

        ' When the count gets to 0, exit the app by calling
        ' ExitThread().
        _formCount = _formCount - 1
        If (_formCount = 0) Then
            ExitThread()
        End If
    End Sub
    '</Snippet3>

    Private Function WriteFormDataToFile() As Boolean
        ' Write the form positions to the file.
        Dim encoding As UTF8Encoding = New UTF8Encoding()

        Dim rectConv As RectangleConverter = New RectangleConverter()
        Dim form1pos As String = rectConv.ConvertToString(_form1Position)
        Dim form2pos As String = rectConv.ConvertToString(_form2Position)

        Dim dataToWrite As Byte() = encoding.GetBytes("~" + form1pos + "~" + form2pos)

        Try
            ' Set the write position to the start of the file and write
            _userData.Seek(0, SeekOrigin.Begin)
            _userData.Write(dataToWrite, 0, dataToWrite.Length)
            _userData.Flush()

            _userData.SetLength(dataToWrite.Length)
            Return True

        Catch
            ' An error occurred while attempting to write, return false.
            Return False
        End Try

    End Function

    Private Function ReadFormDataFromFile() As Boolean
        ' Read the form positions from the file.
        Dim encoding As UTF8Encoding = New UTF8Encoding()
        Dim data As String

        If (_userData.Length <> 0) Then
            Dim dataToRead(_userData.Length) As Byte

            Try
                ' Set the read position to the start of the file and read.
                _userData.Seek(0, SeekOrigin.Begin)
                _userData.Read(dataToRead, 0, dataToRead.Length)

            Catch e As IOException
                Dim errorInfo As String = e.ToString()
                ' An error occurred while attempt to read, return false.
                Return False
            End Try

            ' Parse out the data to get the window rectangles
            data = encoding.GetString(dataToRead)

            Try
                ' Convert the string data to rectangles
                Dim rectConv As RectangleConverter = New RectangleConverter()
                Dim form1pos As String = data.Substring(1, data.IndexOf("~", 1) - 1)

                _form1Position = CType(rectConv.ConvertFromString(form1pos), Rectangle)

                Dim form2pos As String = data.Substring(data.IndexOf("~", 1) + 1)
                _form2Position = CType(rectConv.ConvertFromString(form2pos), Rectangle)

                Return True

            Catch
                ' Error occurred while attempting to convert the rectangle data.
                ' Return false to use default values.
                Return False
            End Try

        Else
            ' No data in the file, return false to use default values.
            Return False
        End If
    End Function

End Class

'<Snippet4>
Public Module MyApplication
    Public Sub Main()
        ' Create the MyApplicationContext, that derives from ApplicationContext,
        ' that manages when the application should exit.

        Dim context As MyApplicationContext = New MyApplicationContext()

        ' Run the application with the specific context. It will exit when
        ' all forms are closed.
        Application.Run(context)
    End Sub
End Module
'</Snippet4>
'</Snippet2>
'</Snippet1>