Imports System
Imports System.IO

Namespace ConsoleApplication1
   Class MyBinaryFile
      Private m_author As String = Nothing
      
      Public Overloads Shared Sub Main()
         Dim bf1 As New MyBinaryFile()
         bf1.Author = "Marin Millar"
         bf1.Save("a.dat")
         
         Dim bf2 As New MyBinaryFile()
         bf2.Load("a.dat")
         Console.WriteLine(bf2.Author)
         
         
         bf2.PrintEncodingInfo(System.Text.Encoding.Default)
      End Sub
      
      Public Sub New()
      End Sub
      
      Public Property Author() As String
         Get
            Return m_author
         End Get
         Set
            m_author = value
         End Set
      End Property
      
      Public Sub Save(filename As String)
         Dim fs As FileStream = File.Open(filename, FileMode.Create)
         WriteAuthor(fs, m_author)
         fs.Flush()
         fs.Close()
      End Sub
      
      Private Sub WriteAuthor(binary_file As Stream, author As String)
         Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
         ' Get buffer size required for conversion
         Dim buffersize As Integer = encoding.GetByteCount(author)
         If buffersize < 30 Then
            buffersize = 30
         End If
         ' Write string into binary file with UTF8 encoding
         Dim buffer(buffersize) As Byte
         encoding.GetBytes(author, 0, author.Length, buffer, 0)
         binary_file.Write(buffer, 0, 30)
      End Sub
      
      Public Sub Load(filename As String)
         Dim fs As FileStream = File.OpenRead(filename)
         m_author = ReadAuthor(fs)
         fs.Close()
      End Sub
      
      ' <Snippet1>
      Private Function ReadAuthor(binary_file As Stream) As String
         Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
         ' Read string from binary file with UTF8 encoding
         Dim buffer(30) As Byte
         binary_file.Read(buffer, 0, 30)
         Return encoding.GetString(buffer)
      End Function

' This code produces the following output.
'
'Marin Millar                  
'BodyName:        iso-8859-1
'HeaderName:      Windows-1252
'WebName:         Windows-1252
'CodePage:        1252
'EncodingName:    Western European (Windows)
'WindowsCodePage: 1252
'MailNewsDisplay: True
'MailNewsSave:    True
'BrowserDisplay:  True
'BrowserSave:     True
'
' </Snippet1>

      Private Sub PrintEncodingInfo(encoding As System.Text.Encoding)
         ' Print information of encoding
         Console.WriteLine("BodyName:        " + encoding.BodyName)
         Console.WriteLine("HeaderName:      " + encoding.HeaderName)
         Console.WriteLine("WebName:         " + encoding.WebName)
         Console.WriteLine("CodePage:        " + CStr(encoding.CodePage))
         Console.WriteLine("EncodingName:    " + encoding.EncodingName)
         Console.WriteLine("WindowsCodePage: " + CStr(encoding.WindowsCodePage))
         Console.WriteLine("MailNewsDisplay: " + CStr(encoding.IsMailNewsDisplay))
         Console.WriteLine("MailNewsSave:    " + CStr(encoding.IsMailNewsSave))
         Console.WriteLine("BrowserDisplay:  " + CStr(encoding.IsBrowserDisplay))
         Console.WriteLine("BrowserSave:     " + CStr(encoding.IsBrowserSave))
      End Sub
   End Class
End Namespace



