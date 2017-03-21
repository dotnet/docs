Module Example
   Public Sub Main()
      Dim s As String

      Console.WriteLine("The value of the string is '{0}'", s)

      Try 
         Console.WriteLine("String length is {0}", s.Length)
      Catch e As NullReferenceException
         Console.WriteLine(e.Message)
      End Try   
   End Sub
End Module
' The example displays the following output:
'     The value of the string is ''
'     Object reference not set to an instance of an object.