' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim value As String 
      Dim toDelete As Boolean = False
      
      ' Check whether the environment variable exists.
      value = Environment.GetEnvironmentVariable("Test1")
      ' If necessary, create it.
      If value Is Nothing Then
         Environment.SetEnvironmentVariable("Test1", "Value1")
         toDelete = True
         
         ' Now retrieve it.
         value = Environment.GetEnvironmentVariable("Test1")
      End If
      ' Display the value.
      Console.WriteLine("Test1: {0}", value)
      Console.WriteLine()
      
      ' Confirm that the value can only be retrieved from the process
      ' environment block.
      Console.WriteLine("Attempting to retrieve Test1 from:")
      For Each enumValue As EnvironmentVariableTarget In 
                         [Enum].GetValues(GetType(EnvironmentVariableTarget))
         value = Environment.GetEnvironmentVariable("Test1", enumValue)
         Console.WriteLine("   {0}: {1}", enumValue, 
                           If(value IsNot Nothing, value, "not found"))
      Next
      Console.WriteLine()
      
      ' If we've created it, now delete it.
      If toDelete Then 
         Environment.SetEnvironmentVariable("Test1", Nothing)
         ' Confirm the deletion.
         If Environment.GetEnvironmentVariable("Test1") = Nothing Then
            Console.WriteLine("Test1 has been deleted.")
         End If
      End If         
   End Sub
End Module
' The example displays output like the following:
'       Test1: Value1
'       
'       Attempting to retrieve Test1 from:
'          Process: Value1
'          User: not found
'          Machine: not found
'       
'       Test1 has been deleted.
' </Snippet2>
