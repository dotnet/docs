' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Module Example
   Public Sub Main()
      ' Get all files in the current directory.
      Dim files() As String = Directory.GetFiles(".")
      Array.Sort(files)
      
      ' Display the files to the current output source to the console.
      Console.WriteLine("First display of filenames to the console:")
      Array.ForEach(files, Function(s) WriteOutput(s))   
      Console.Out.WriteLine()

      ' Redirect output to a file named Files.txt and write file list.
      Dim sw As StreamWriter = New StreamWriter(".\Files.txt")
      sw.AutoFlush = True
      Console.SetOut(sw)
      Console.Out.WriteLine("Display filenames to a file:")
      Array.ForEach(files, Function(s) WriteOutput(s))
      Console.Out.WriteLine()

      ' Close previous output stream and redirect output to standard output.
      Console.Out.Close()
      sw = New StreamWriter(Console.OpenStandardOutput())
      sw.AutoFlush = True
      Console.SetOut(sw)
           
      ' Display the files to the current output source to the console.
      Console.Out.WriteLine("Second display of filenames to the console:")
      Array.ForEach(files, Function(s) WriteOutput(s))   
   End Sub
   
   Private Function WriteOutput(s As String) As Boolean
      Console.Out.WriteLine(s)
      Return True
   End Function
End Module
' </Snippet1>
