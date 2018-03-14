' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Example
  Private Const SegmentSize As Integer = 10
  
   Public Sub Main()
      Dim tasks As New List(Of Task)
      
       ' Create array.
      Dim arr(49) As Integer
      For ctr As Integer = 0 To arr.GetUpperBound(0)
         arr(ctr) = ctr + 1
      Next

      ' Handle array in segments of 10.
      For ctr As Integer = 1 To CInt(Math.Ceiling(arr.Length / segmentSize))
         Dim multiplier As Integer = ctr
         Dim elements As Integer = If((multiplier - 1) * 10 + segmentSize > arr.Length,
                                      arr.Length - (multiplier - 1) * 10,
                                      segmentSize)
         Dim segment As New ArraySegment(Of Integer)(arr, (ctr - 1) * 10, elements)
         tasks.Add(Task.Run( Sub()
                                Dim list As IList(Of Integer) = CType(segment, IList(Of Integer))
                                For index As Integer = 0 To list.Count - 1
                                   list(index) = list(index) * multiplier
                                Next
                             End Sub ))
      Next
      Try
         Task.WaitAll(tasks.ToArray())
         Dim elementsShown As Integer = 0
         For Each value In arr
            Console.Write("{0,3} ", value)
            elementsShown += 1
            If elementsShown Mod 18 = 0 Then Console.WriteLine()
         Next
      Catch e As AggregateException
         Console.WriteLine("Errors occurred when working with the array:")
         For Each inner As Exception In e.InnerExceptions
            Console.WriteLine("{0}: {1}", inner.GetType().Name, inner.Message)
         Next
      End Try
   End Sub
End Module
' The example displays the following output:
'         1   2   3   4   5   6   7   8   9  10  22  24  26  28  30  32  34  36
'        38  40  63  66  69  72  75  78  81  84  87  90 124 128 132 136 140 144
'       148 152 156 160 205 210 215 220 225 230 235 240 245 250
' </Snippet2>
