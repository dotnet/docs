' <Snippet1>
Imports System
Imports System.Xml

' Reads an XML document using ReadChars
Public Class Sample
    Private Const filename As String = "items.xml"
    
    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing
        
        Try
            ' Declare variables used by ReadChars
            Dim buffer() As Char
            Dim iCnt As Integer = 0
            Dim charbuffersize As Integer
            
            ' Load the reader with the data file.  Ignore white space.
            reader = New XmlTextReader(filename)
            reader.WhitespaceHandling = WhitespaceHandling.None
            
            ' Set variables used by ReadChars.
            charbuffersize = 10
            buffer = New Char(charbuffersize) {}
            
            ' Parse the file.  Read the element content  
            ' using the ReadChars method.
            reader.MoveToContent()
            iCnt = reader.ReadChars(buffer,0,charbuffersize)
            while (iCnt > 0)
              ' Print out chars read and the buffer contents.
              Console.WriteLine("  Chars read to buffer:" & iCnt)
              Console.WriteLine("  Buffer: [{0}]", New String(buffer, 0, iCnt))
              ' Clear the buffer.
              Array.Clear(buffer, 0, charbuffersize)
              iCnt = reader.ReadChars(buffer,0,charbuffersize)
           end while

        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 
End Class 
' </Snippet1>
