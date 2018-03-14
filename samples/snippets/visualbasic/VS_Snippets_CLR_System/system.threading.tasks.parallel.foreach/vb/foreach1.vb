' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim task As Task(Of String) = ReadCharacters(".\CallOfTheWild.txt")
      Dim text As String = task.Result
      
      Dim nVowels As Integer = 0
      Dim nNonWhiteSpace As Integer = 0
      Dim obj As New Object()

      Dim result As ParallelLoopResult = Parallel.ForEach(text, 
                                                          Sub(ch)
                                                             Dim uCh As Char = Char.ToUpper(ch)
                                                             If "AEIOUY".IndexOf(uCh) >= 0 Then
                                                                SyncLock obj
                                                                   nVowels += 1
                                                                End SyncLock
                                                             End If
                                                             If Not Char.IsWhiteSpace(uCh) Then
                                                                SyncLock obj
                                                                   nNonWhiteSpace += 1
                                                                End SyncLock   
                                                             End If
                                                          End Sub)
      Console.WriteLine("Total characters:      {0,10:N0}", text.Length)
      Console.WriteLine("Total vowels:          {0,10:N0}", nVowels)
      Console.WriteLine("Total non-whitespace:  {0,10:N0}", nNonWhiteSpace)
   End Sub
   
   Private Async Function ReadCharacters(fn As String) As Task(Of String)
      Dim text As String
      Using sr As New StreamReader(fn)
         text = Await sr.ReadToEndAsync()
      End Using
      Return text
   End Function
End Module
' The output from the example resembles the following:
'       Total characters:         198,548
'       Total vowels:              58,421
'       Total non-whitespace:     159,461
' </Snippet1>
