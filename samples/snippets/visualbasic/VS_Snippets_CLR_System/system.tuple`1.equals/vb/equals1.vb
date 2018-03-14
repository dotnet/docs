Option Infer On

' <Snippet1>
Module Example
    Sub Main()
        Dim doubleTuple1 = Tuple.Create(12.3455)

        Dim doubleTuple2 = Tuple.Create(16.8912)
        Dim doubleTuple3 = Tuple.Create(12.3455)
        Dim singleTuple1 = Tuple.Create(CSng(12.3455))
        Dim tuple2 = Tuple.Create("James", 97.3) 
        ' Compare first tuple with a Tuple(Of Double) with a different value.
        TestEquality(doubleTuple1, doubleTuple2)
        ' Compare first tuple with a Tuple(Of Double) with the same value.
        TestEquality(doubleTuple1, doubleTuple3)
        ' Compare first tuple with a Tuple(Of Single) with the same value.
        TestEquality(doubleTuple1, singleTuple1)
        ' Compare a 1-tuple with a 2-tuple.
        TestEquality(doubleTuple1, tuple2) 
    End Sub
    
   Private Sub TestEquality(tuple As Tuple(Of Double), obj As Object)
      Try
         Console.WriteLine("{0} = {1}: {2}", tuple.ToString(),
                                            obj.ToString,
                                            tuple.Equals(obj))
      
      Catch e As ArgumentException
         If obj.GetType.IsGenericType Then 
            If obj.GetType().Name = "Tuple`1" Then 
               Console.WriteLine("Cannot compare a Tuple(Of {0}) with a Tuple(Of {1}).", 
                              tuple.Item1.GetType().Name, obj.Item1.GetType().Name)
            Else
               Console.WriteLine("Cannot compare a {0} with a {1}.", tuple.GetType().Name, 
                                                                     obj.GetType().Name)
            End If
         Else
            Console.WriteLine("Cannot compare a {0} with a {1}.", tuple.GetType().Name,
                                                                  obj.GetType().Name)
         End If
      End Try
   End Sub
End Module
' The example displays the following output:
'       (12.3455) = (16.8912): False
'       (12.3455) = (12.3455): True
'       (12.3455) = (12.3455): False
'       (12.3455) = (James, 97.3): False
' </Snippet1>