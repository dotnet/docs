
' This sample takes a given input and replaces each
' occurence of the tab character with 4 space characters.
' It also takes two command-line arguements: input file name, & output file name.
' Usage:
'  EXPANDTABS inputfile.txt outputfile.txt
' System.Console.Read
' System.Console.WriteLine
' System.Console.Write
' System.Console.SetIn
' System.Console.SetOut
' System.Console.Error
' System.Console.Out
' <Snippet1>
Imports System.IO

Public Class ExpandTabs
   Private Const tabSize As Integer = 4
   Private Const usageText As String = "Usage: EXPANDTABSEX inputfile.txt outputfile.txt"
   
   Public Shared Sub Main(args() As String)
      Dim writer As StreamWriter = Nothing

      If args.Length < 2 Then
         Console.WriteLine(usageText)
         Exit Sub
      End If
      
      Try
         writer = New StreamWriter(args(1))
         Console.SetOut(writer)
         Console.SetIn(New StreamReader(args(0)))
      Catch e As IOException
         Console.Error.WriteLine(e.Message)
         Console.Error.WriteLine(usageText)
         Exit Sub
      End Try
      
      Dim i As Integer = Console.Read()
      While i <> -1 
         Dim c As Char = Convert.ToChar(i)
         If c = ControlChars.Tab Then
            Console.Write("".PadRight(tabSize, " "c))
         Else
            Console.Write(c)
         End If
         i = Console.Read()
      End While
      writer.Close()
      
      ' Reacquire the standard output stream so that a
      ' completion message can be displayed.
      Dim standardOutput As New StreamWriter(Console.OpenStandardOutput)
      standardOutput.AutoFlush = True
      Console.SetOut(standardOutput)
      Console.WriteLine("EXPANDTABSEX has completed the processing of {0}.", args(0))
   End Sub
End Class
' </Snippet1>
