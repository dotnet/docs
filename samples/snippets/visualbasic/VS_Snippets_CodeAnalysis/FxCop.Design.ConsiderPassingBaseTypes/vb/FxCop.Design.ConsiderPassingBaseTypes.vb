'<Snippet1>
Imports System
Imports System.IO

Namespace DesignLibrary

    Public Class StreamUser

        Sub ManipulateFileStream(ByVal stream As IO.FileStream)
            If stream Is Nothing Then Throw New ArgumentNullException("stream")

            Dim anInteger As Integer = stream.ReadByte()
            While (anInteger <> -1)
                ' Do something.
                anInteger = stream.ReadByte()
            End While
        End Sub

        Sub ManipulateAnyStream(ByVal anyStream As IO.Stream)
            If anyStream Is Nothing Then Throw New ArgumentNullException("anyStream")

            Dim anInteger As Integer = anyStream.ReadByte()
            While (anInteger <> -1)
                ' Do something.
                anInteger = anyStream.ReadByte()
            End While
        End Sub
    End Class


   Public Class TestStreams
   
      Shared Sub Main()
            Dim someStreamUser As New StreamUser()
            Dim testFileStream As New FileStream( _
               "test.dat", FileMode.OpenOrCreate)
            Dim testMemoryStream As New MemoryStream(New Byte() {})

            ' Cannot be used with testMemoryStream.
            someStreamUser.ManipulateFileStream(testFileStream)
            someStreamUser.ManipulateAnyStream(testFileStream)
            someStreamUser.ManipulateAnyStream(testMemoryStream)
            testFileStream.Close()
        End Sub
   End Class
End Namespace
'</Snippet1>
