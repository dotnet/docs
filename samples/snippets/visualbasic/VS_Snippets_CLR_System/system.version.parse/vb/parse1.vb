' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim input As String = "4.0"
      ParseVersion(input)
      
      input = "4.0."
      ParseVersion(input)
      
      input = "1.1.2"
      ParseVersion(input)
      
      input = "1.1.2.01702"
      ParseVersion(input)
      
      input = "1.1.2.0702.119"
      ParseVersion(input)
      
      input =  "1.3.5.2150000000"
      ParseVersion(input)
   End Sub
   
   Private Sub ParseVersion(input As String)
      Try
         Dim ver As Version = Version.Parse(input)
         Console.WriteLine("Converted '{0} to {1}.", input, ver)
      Catch e As ArgumentNullException
         Console.WriteLine("Error: String to be parsed is null.")
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("Error: Negative value in '{0}'.", input)
      Catch e As ArgumentException
         Console.WriteLine("Error: Bad number of components in '{0}'.", 
                           input)
      Catch e As FormatException
         Console.WriteLine("Error: Non-integer value in '{0}'.", input)
      Catch e As OverflowException   
         Console.WriteLine("Error: Number out of range in '{0}'.", input)                  
      End Try   
   End Sub
End Module
' The example displays the following output:
'       Converted '4.0 to 4.0.
'       Error: Non-integer value in '4.0.'.
'       Converted '1.1.2 to 1.1.2.
'       Converted '1.1.2.01702 to 1.1.2.1702.
'       Error: Bad number of components in '1.1.2.0702.119'.
'       Error: Number out of range in '1.3.5.2150000000'.
' </Snippet1>
