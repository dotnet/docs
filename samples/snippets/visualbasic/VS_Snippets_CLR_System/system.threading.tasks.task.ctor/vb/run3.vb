' Visual Basic .NET Document
Option Strict On

' The Task.Run(Func(Of TResult) method.

' <Snippet2>
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim pattern As String = "\p{P}*\s+"
      Dim titles() As String = { "Sister Carrie",
                                 "The Financier" }
      Dim tasks(titles.Length - 1) As Task(Of Integer)

      For ctr As Integer = 0 To titles.Length - 1
         Dim s As String = titles(ctr)
         tasks(ctr) = New Task(Of Integer)( Function()
                                   ' Number of words.
                                   Dim nWords As Integer = 0
                                   ' Create filename from title.
                                   Dim fn As String = s + ".txt"

                                   Dim sr As New StreamReader(fn)
                                   Dim input As String = sr.ReadToEndAsync().Result
                                   sr.Close()
                                   nWords = Regex.Matches(input, pattern).Count
                                   Return nWords
                                End Function)
      Next

      ' Ensure files exist before launching tasks.
      Dim allExist As Boolean = True
      For Each title In titles
         Dim fn As String = title + ".txt"
         If Not File.Exists(fn) Then
            allExist = false
            Console.WriteLine("Cannot find '{0}'", fn)
            Exit For
         End If   
      Next
      ' Launch tasks 
      If allExist Then
         For Each t in tasks
            t.Start()
         Next
         Task.WaitAll(tasks)

         Console.WriteLine("Word Counts:")
         Console.WriteLine()
         For ctr As Integer = 0 To titles.Length - 1
         Console.WriteLine("{0}: {1,10:N0} words", titles(ctr), tasks(ctr).Result)
         Next
      End If   
   End Sub
End Module
' The example displays the following output:
'       Sister Carrie:    159,374 words
'       The Financier:    196,362 words
' </Snippet2>

