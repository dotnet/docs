
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic


Class HttpWebResponseSnippet
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Public Shared Sub Main(args() As String)
      If args.Length < 1 Then
         Console.WriteLine(ControlChars.NewLine + "Please enter the url as command line parameter:")
         Console.WriteLine("Example:")
         Console.WriteLine("HttpWebResponse_ContentLength_ContentType http://www.microsoft.com/net/")
      Else
         GetPage(args(0))
      End If
      Console.WriteLine("Press any key to continue...")
      Console.ReadLine()
      Return
   End Sub 'Main
   
   
   Public Shared Sub GetPage(url As [String])
      ' <Snippet1>
      Try
         Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
         Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
         
         Console.WriteLine(("The encoding method used is: " + myHttpWebResponse.ContentEncoding))
         Console.WriteLine(("The character set used is :" + myHttpWebResponse.CharacterSet))
         
         Dim seperator As Char = "/"c
         Dim contenttype As [String] = myHttpWebResponse.ContentType
         ' Retrieve 'text' if the content type is of 'text/html.
         Dim maintype As [String] = contenttype.Substring(0, contenttype.IndexOf(seperator))
         ' Display only 'text' type.
         If [String].Compare(maintype, "text") = 0 Then
            Console.WriteLine(ControlChars.NewLine + " Content type is 'text'.")
            
            ' </Snippet1>
            ' <Snippet2>
            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim readStream As New StreamReader(receiveStream, encode)
            
            Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "Response stream received.")
            Dim read(256) As Char
            
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine(ControlChars.NewLine + "Text retrieved from the URL follows:" + ControlChars.Lf + ControlChars.NewLine)
            
            Dim index As Integer = 0
            While index < myHttpWebResponse.ContentLength
               ' Dump the 256 characters on a string and display the string onto the console.
               Dim str As New [String](read, 0, count)
               Console.WriteLine(str)
               index += count
               count = readStream.Read(read, 0, 256)
            End While
            ' Release the resources of the stream object.
            receiveStream.Close()
            Console.WriteLine("")
         End If
         ' Release the resources of response object.
         myHttpWebResponse.Close()
      
      ' </Snippet2>
      Catch e As WebException
         Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "WebException Raised. The following error occured : {0}", e.Status)
      Catch e As Exception
         Console.WriteLine(ControlChars.NewLine + "The following Exception was raised : {0}", e.Message)
      End Try
   End Sub 'GetPage
End Class 'HttpWebResponseSnippet