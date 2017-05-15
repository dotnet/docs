' System.Console.OpenStandartInput

' <Snippet1>
Imports System.Text
Imports System.IO

Public Class Decoder
   Public Shared Sub Main()
      Dim inputStream As Stream = Console.OpenStandardInput()
      Dim bytes(100) As Byte
      Console.WriteLine("To decode, type or paste the UTF7 encoded string and press enter:")
      Console.WriteLine("(Example: ""M+APw-nchen ist wundervoll"")")
      Dim outputLength As Integer = inputStream.Read(bytes, 0, 100)
      Dim chars As Char() = Encoding.UTF7.GetChars(bytes, 0, outputLength)
      Console.WriteLine("Decoded string:")
      Console.WriteLine(New String(chars))
   End Sub 'Main
End Class 'Decoder
' </Snippet1>