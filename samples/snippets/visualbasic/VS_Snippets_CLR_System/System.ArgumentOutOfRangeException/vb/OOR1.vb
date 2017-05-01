' Visual Basic .NET Document
Option Strict On

' <Snippet1>
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
' </Snippet1>

Public Class Example2
   Public Sub MakeValid
      ' <Snippet2>
      Dim dimension1 As Integer = 10
      Dim dimension2 As Integer = 10
      Dim arr As Array = Array.CreateInstance(GetType(String), 
                                              dimension1, dimension2)   
      ' </Snippet2>
   End Sub
   
   Public Sub Validate
      Dim dimension1 As Integer = 10
      Dim dimension2 As Integer = 10
      Dim arr As Array
      ' <Snippet3>
      If dimension1 < 0 OrElse dimension2 < 0 Then
         Console.WriteLine("Unable to create the array.")
         Console.WriteLine("Specify non-negative values for the two dimensions.")
      Else
         arr = Array.CreateInstance(GetType(String), 
                                    dimension1, dimension2)   
      End If
      ' </Snippet3>
   End Sub
End Class
   
   