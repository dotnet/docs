Imports System
Imports System.Web
Imports System.IO

Class MyNewClass
   Public Shared Sub Main()
      Dim myString As String
      Console.WriteLine("Enter a string having '&' or '""'  in it: ")
      myString = Console.ReadLine()
      Dim myEncodedString As String
      ' Encode the string.
      myEncodedString = HttpUtility.HtmlEncode(myString)
      Console.WriteLine("HTML Encoded string is " + myEncodedString)
      Dim myWriter As New StringWriter()
      ' Decode the encoded string.
      HttpUtility.HtmlDecode(myEncodedString, myWriter)
      Console.Write("Decoded string of the above encoded string is " + myWriter.ToString())
   End Sub 'Main
End Class 'MyNewClass