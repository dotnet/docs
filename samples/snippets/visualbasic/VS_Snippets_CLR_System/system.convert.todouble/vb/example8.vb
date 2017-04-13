' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example
   Public Sub Main()
      Dim values() As String = { "-1,035.77219", "1AFF", "1e-35", _
                                 "1,635,592,999,999,999,999,999,999", "-17.455", _
                                 "190.34001", "1.29e325"}
      Dim result As Double
      
      For Each value As String In values
         Try
            result = Convert.ToDouble(value)
            Console.WriteLine("Converted '{0}' to {1}.", value, result)
         Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to a Double.", value)            
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of a Double.", value)
         End Try
      Next       
   End Sub   
End Module
' The example displays the following output:
'       Converted '-1,035.77219' to -1035.77219.
'       Unable to convert '1AFF' to a Double.
'       Converted '1e-35' to 1E-35.
'       Converted '1,635,592,999,999,999,999,999,999' to 1.635593E+24.
'       Converted '-17.455' to -17.455.
'       Converted '190.34001' to 190.34001.
'       '1.29e325' is outside the range of a Double.
' </Snippet8>

