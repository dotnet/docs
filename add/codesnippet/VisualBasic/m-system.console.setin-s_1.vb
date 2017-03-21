Imports System.IO

Public Class InsertTabs
   Private Const tabSize As Integer = 4
   Private Const usageText As String = "Usage: INSERTTABS inputfile.txt outputfile.txt"
   
   Public Shared Function Main(args() As String) As Integer
      Dim writer As StreamWriter = Nothing

      If args.Length < 2 Then
         Console.WriteLine(usageText)
         Return 1
      End If
      
      Try
         ' Attempt to open output file.
         writer = New StreamWriter(args(1))
         ' Redirect standard output from the console to the output file.
         Console.SetOut(writer)
         ' Redirect standard input from the console to the input file.
         Console.SetIn(New StreamReader(args(0)))
      Catch e As IOException
         Dim errorWriter As TextWriter = Console.Error
         errorWriter.WriteLine(e.Message)
         errorWriter.WriteLine(usageText)
         Return 1
      End Try

      Dim line As String = Console.ReadLine()
      While line IsNot Nothing
         Dim newLine As String = line.Replace("".PadRight(tabSize, " "c), ControlChars.Tab)
         Console.WriteLine(newLine)
         line = Console.ReadLine()
      End While
      writer.Close()
      ' Recover the standard output stream so that a 
      ' completion message can be displayed.
      Dim standardOutput As New StreamWriter(Console.OpenStandardOutput())
      standardOutput.AutoFlush = True
      Console.SetOut(standardOutput)
      Console.WriteLine("INSERTTABS has completed the processing of {0}.", args(0))
      Return 0
   End Function 
End Class