'<snippet1>
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class FileReaderException
    Inherits Exception

    Sub New(description As String)
        MyBase.New(description)
    End Sub
End Class

<Flags()> _
Public Enum ConnectionState
    Closed = 0
    Open = 1
End Enum

Public Class DemoDBClient
    Private connstate As ConnectionState

    Public Sub New()
        connstate = ConnectionState.Open
    End Sub

    Public ReadOnly Property State As ConnectionState
        Get
            Return connstate
        End Get
    End Property

    Public Sub Close()
        connstate = ConnectionState.Closed
    End Sub
End Class

Public Class FileUtils
    Public Shared Function ReadFromFile(filename As String, bytes As Integer) As Byte()
        Return File.ReadAllBytes(filename)
    End Function
End Class

'<snippet4>
Public Class MyFileNotFoundException
    Inherits Exception
End Class
'</snippet4>


Public Class ExceptionHandling
    Public Shared Sub Main()
        Dim conn As New DemoDBClient()

        '<snippet2>
        If conn.State <> ConnectionState.Closed Then
            conn.Close()
        End IF
        '</snippet2>

        '<snippet3>
        Try
            conn.Close()
        Catch ex As InvalidOperationException
            Console.WriteLine(ex.GetType().FullName)
            Console.WriteLine(ex.Message)
        End Try
        '</snippet3>
    End Sub
End Class

'<snippet5>
Class FileRead
    Public Sub ReadAll(fileToRead As FileStream)
        ' This if statement is optional
        ' as it is very unlikely that
        ' the stream would ever be null.
        If fileToRead Is Nothing Then
            Throw New System.ArgumentNullException()
        End If

        Dim b As Integer

        ' Set the stream position to the beginning of the file.
        fileToRead.Seek(0, SeekOrigin.Begin)

        ' Read each byte to the end of the file.
        For i As Integer = 0 To fileToRead.Length - 1
            b = fileToRead.ReadByte()
            Console.Write(b.ToString())
            ' Or do something else with the byte.
        Next i
    End Sub
End Class
'</snippet5>

'<snippet6>
Class FileReader
    Private fileName As String


    Public Sub New(path As String)
        fileName = path
    End Sub

    Public Function Read(bytes As Integer) As Byte()
        Dim results() As Byte = FileUtils.ReadFromFile(fileName, bytes)
        If results Is Nothing
            Throw NewFileIOException()
        End If
        Return results
    End Function

    Function NewFileIOException() As FileReaderException
        Dim description As String = "My NewFileIOException Description"

        Return New FileReaderException(description)
    End Function
End Class
'</snippet6>
'</snippet1>
