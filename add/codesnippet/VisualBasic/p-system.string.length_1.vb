Imports System.Text

Module Example

   Public Sub Main()
      Dim characters As String = "abc" + ChrW(0) + "def"
      Console.WriteLine(characters.Length)       ' Displays 7
   End Sub
End Module