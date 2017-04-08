' Visual Basic .NET Document
Option Strict On

' <Snippet5>
   
Imports System.Threading.Tasks

Module AdditionTester
   Public Sub Main()
      Dim rnd As New Random()
      Dim tasks(1) As Task(Of Integer)
      Dim obj As New Object()
      
      Do While True
         For ctr As Integer = 0 To 1
            tasks(ctr) = Task.Factory.StartNew(Function()
                                                  Dim i As Integer
                                                  SyncLock(obj)
                                                     i = rnd.Next(101)
                                                  End SyncLock
                                                  Return i
                                               End Function)
         Next
         Task.WaitAll(tasks)
         Dim n1 As Integer = tasks(0).Result
         Dim n2 As Integer = tasks(1).Result
         Dim result As Integer = n1 + n2
         Dim validInput As Boolean = False
         Do While Not validInput
            ShowMessage(n1, n2)
            Dim userInput As String = Console.ReadLine()
            ' Process user input.
            If userInput.Trim().ToUpper = "X" Then Exit Sub
            Dim answer As Integer
            validInput = Int32.TryParse(userInput, answer)
            If Not validInput Then
               Console.WriteLine("Invalid input. Try again, but enter only numbers. ")
            Else If answer = result Then
               Console.WriteLine("Correct!")
            Else
               Console.WriteLine("Incorrect. The correct answer is {0}.", result)
            End If
         Loop
      Loop
   End Sub
   
   Private Sub ShowMessage(n1 As Integer, n2 As Integer)
      Console.WriteLine()
      Console.WriteLine("Enter 'x' to exit...")
      Console.Write("{0} + {1} = ", n1, n2)
   End Sub
End Module
' The example displays output like the following:
'       Enter 'x' to exit...
'       15 + 11 = 26
'       Correct!
'
'       Enter 'x' to exit...
'       75 + 33 = adc
'       Invalid input. Try again, but enter only numbers.
'
'       Enter 'x' to exit...
'       75 + 33 = 108
'       Correct!
'
'       Enter 'x' to exit...
'       67 + 55 = 133
'       Incorrect. The correct answer is 122.
'
'       Enter 'x' to exit...
'       92 + 51 = 133
'       Incorrect. The correct answer is 143.
'
'       Enter 'x' to exit...
'       81 + 65 = x
' </Snippet5>
