Module Example
   Public Sub Main()
      Dim dimension1 As Integer = 10
      Dim dimension2 As Integer = -1
      Try
         Dim arr AS Array = Array.CreateInstance(GetType(String), 
                                                 dimension1, dimension2)
      Catch e As ArgumentOutOfRangeException
         If e.ActualValue IsNot Nothing Then
            Console.WriteLine("{0} is an invalid value for {1}: ", 
                              e.ActualValue, e.ParamName)
         End If                     
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'     Non-negative number required.
'     Parameter name: length2