'<Snippet1>
Imports System
Imports System.IO

Class StrmRdrRead
   
   Public Shared Sub Main()
      'Create a FileInfo instance representing an existing text file.
      Dim MyFile As New FileInfo("c:\csc.txt")
      'Instantiate a StreamReader to read from the text file.
      Dim sr As StreamReader = MyFile.OpenText()
      'Read a single character.
      Dim FirstChar As Integer = sr.Read()
      'Display the ASCII number of the character read in both decimal and hexadecimal format.
      Console.WriteLine("The ASCII number of the first character read is {0:D} in decimal and {1:X} in hexadecimal.", FirstChar, FirstChar)
      sr.Close()
   End Sub 'Main
End Class 'StrmRdrRead
'</Snippet1>
    
    
