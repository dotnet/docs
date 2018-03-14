' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      Dim sr As StreamReader = Nothing
      Try 
         sr = New StreamReader("file1.txt")
         Dim contents As String = sr.ReadToEnd()
         sr.Close()
         Console.WriteLine("The file has {0} text elements.", 
                           New StringInfo(contents).LengthInTextElements)    
      Catch e As FileNotFoundException
         Console.WriteLine("The file cannot be found.")
      Catch e As IOException
         Console.WriteLine("An I/O error has occurred.")
      Catch e As OutOfMemoryException
         Console.WriteLine("There is insufficient memory to read the file.")   
      Finally 
         If sr IsNot Nothing Then sr.Dispose()     
      End Try
   End Sub
End Module
' </Snippet6>
