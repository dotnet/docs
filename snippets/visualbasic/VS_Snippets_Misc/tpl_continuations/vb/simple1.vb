' <Snippet1>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      ' Execute the antecedent.
      Dim taskA As Task(Of DayOfWeek) = Task.Run(Function() DateTime.Today.DayOfWeek )

      ' Execute the continuation when the antecedent finishes.
      Dim continuation As Task = taskA.ContinueWith(Sub(antecedent)
                                                       Console.WriteLine("Today is {0}.", antecedent.Result)
                                                    End Sub)
   End Sub
End Module
' The example displays output like the following output:
'       Today is Monday.
' </Snippet1>

