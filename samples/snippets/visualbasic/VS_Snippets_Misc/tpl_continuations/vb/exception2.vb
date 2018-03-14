' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet4>
Imports System.IO
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t = Task.Run( Function()
                           Dim s As String = File.ReadAllText("C:\NonexistentFile.txt")
                           Return s
                        End Function)

      Dim c = t.ContinueWith( Sub(antecedent)
                                 ' Get the antecedent's exception information.
                                 For Each ex In antecedent.Exception.InnerExceptions
                                    If TypeOf ex Is FileNotFoundException
                                       Console.WriteLine(ex.Message)
                                    End If
                                 Next
                              End Sub, TaskContinuationOptions.OnlyOnFaulted)

      c.Wait()
   End Sub
End Module
' The example displays the following output:
'       Could not find file 'C:\NonexistentFile.txt'.
' </Snippet4>

Module Example2
   Public Sub ShowTaskException()
      Dim t = Task.Run( Function()
                           Dim s As String = File.ReadAllText("C:\NonexistentFile.txt")
                           Return s
                        End Function)

      Dim c = t.ContinueWith( Sub(antecedent)
                                ' <Snippet11>
                                ' Determine whether an exception occurred.
                                 If antecedent.Exception IsNot Nothing Then
                                   ' Get the antecedent's exception information.
                                    For Each ex In antecedent.Exception.InnerExceptions
                                       If TypeOf ex Is FileNotFoundException
                                          Console.WriteLine(ex.Message)
                                       End If
                                    Next
                                 End If
                                 ' </Snippet11>
                              End Sub, TaskContinuationOptions.OnlyOnFaulted)

      c.Wait()
   End Sub
End Module