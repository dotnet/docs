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

       ' Dimension the target array and copy each element of each source array to it.
       Dim newArray() As Integer = {}
       ' Define the next position to copy to in newArray.
       Dim index = 0
       For Each task In tasks
          Dim n = Task.Result.Length
          ReDim Preserve newArray(newArray.GetUpperBound(0) + n)
          Array.Copy(task.Result, 0, newArray, index, n)
          index += n
       Next 
      Console.WriteLine($"The new array has {newArray.Length} elements.")
   End Sub
End Module
' The example displays the following output:
'     The new array has 40 elements.

