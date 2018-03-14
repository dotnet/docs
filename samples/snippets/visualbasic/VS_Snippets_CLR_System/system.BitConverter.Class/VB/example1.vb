' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim value As Integer = -16
      Dim bytes() As Byte = BitConverter.GetBytes(value) 
      
      ' Convert bytes back to Int32.
      Dim intValue As Integer = BitConverter.ToInt32(bytes, 0)
      Console.WriteLine("{0} = {1}: {2}", 
                        value, intValue, 
                        If(value.Equals(intValue), "Round-trips", "Does not round-trip"))
      ' Convert bytes to UInt32.
      Dim uintValue As UInteger = BitConverter.ToUInt32(bytes, 0)
      Console.WriteLine("{0} = {1}: {2}", value, uintValue, 
                        If(value.Equals(uintValue), "Round-trips", "Does not round-trip"))
   End Sub
End Module
' The example displays the following output:
'       -16 = -16: Round-trips
'       -16 = 4294967280: Does not round-trip
' </Snippet3>
