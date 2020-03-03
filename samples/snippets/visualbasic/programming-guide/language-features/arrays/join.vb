Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks As New List(Of Task(Of Integer()))
      ' Generate four arrays.
      For ctr = 0 To 3
         Dim value = ctr
         tasks.Add(Task.Run(Function()
                               Dim arr(9) As Integer
                               For ndx = 0 To arr.GetUpperBound(0)
                                  arr(ndx) = value
                               Next
                               Return arr
                            End Function))   
       Next
       Task.WaitAll(tasks.ToArray())
       ' Compute the number of elements in all arrays.
       Dim elements = 0
       For Each task In tasks
          elements += task.Result.Length
       Next
       Dim newArray(elements - 1) As Integer
       Dim index = 0
       For Each task In tasks
          Dim n = task.Result.Length
          Array.Copy(task.Result, 0, newArray, index, n)
          index += n
       Next 
      Console.WriteLine($"The new array has {newArray.Length} elements.")
   End Sub
End Module
' The example displays the following output:
'     The new array has 40 elements.

