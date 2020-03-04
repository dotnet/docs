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
      Console.WriteLine($"Test1: {value}")
      Console.WriteLine()
      
      ' Confirm that the value can only be retrieved from the process
      ' environment block if running on a Windows system.
      If Environment.OSVersion.Platform = PlatformID.Win32NT Then
         Console.WriteLine("Attempting to retrieve Test1 from:")
         For Each enumValue As EnvironmentVariableTarget In 
                           [Enum].GetValues(GetType(EnvironmentVariableTarget))
            value = Environment.GetEnvironmentVariable("Test1", enumValue)
            Console.WriteLine($"   {enumValue}: {If(value IsNot Nothing, "found", "not found")}")
         Next
         Console.WriteLine()
      End If

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
' The example displays the following output if run on a Windows system:
'      Test1: Value1
'
'      Attempting to retrieve Test1 from:
'         Process: found
'         User: not found
'         Machine: not found
'
'      Test1 has been deleted.
'
' The example displays the following output if run on a Unix-based system:
'      Test1: Value1
'
'      Test1 has been deleted.

