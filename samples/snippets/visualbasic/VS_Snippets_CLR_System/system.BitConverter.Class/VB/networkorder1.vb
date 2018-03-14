' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim value As Integer = 12345678
      Dim bytes() As Byte = BitConverter.GetBytes(value)
      Console.WriteLine(BitConverter.ToString(bytes))
      
      If BitConverter.IsLittleEndian Then
         Array.Reverse(bytes) 
      End If
      Console.WriteLine(BitConverter.ToString(bytes))
      ' Call method to send byte stream across machine boundaries.
      
      ' Receive byte stream from beyond machine boundaries.
      Console.WriteLine(BitConverter.ToString(bytes))
      If BitConverter.IsLittleEndian Then     
         Array.Reverse(bytes)
      End If   
      Console.WriteLine(BitConverter.ToString(bytes))
      Dim result As Integer = BitConverter.ToInt32(bytes, 0)
      Console.WriteLine("Original value: {0}", value)
      Console.WriteLine("Returned value: {0}", result)
   End Sub
End Module
' The example displays the following output on a little-endian system:
'       4E-61-BC-00
'       00-BC-61-4E
'       00-BC-61-4E
'       4E-61-BC-00
'       Original value: 12345678
'       Returned value: 12345678
' </Snippet4>
