' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      ' Define an array of 20 elements and display it.
      Dim arr(19) As Integer 
      Dim value As Integer = 1
      For ctr As Integer = 0 To arr.GetUpperBound(0)
         arr(ctr) = value
         value = value * 2 + 1
      Next
      DisplayArray(arr)

      ' Convert the array of integers to a byte array.
      Dim bytes(arr.Length * 4 - 1) As Byte 
      For ctr As Integer = 0 To arr.Length - 1
         Array.Copy(BitConverter.GetBytes(arr(ctr)), 0, 
                    bytes, ctr * 4, 4)
      Next
         
      ' Encode the byte array using Base64 encoding
      Dim base64 As String = Convert.ToBase64String(bytes)
      Console.WriteLine("The encoded string: ")
      For ctr As Integer = 0 To base64.Length \ 50 - 1 
         Console.WriteLine(base64.Substring(ctr * 50, 
                                            If(ctr * 50 + 50 <= base64.Length, 
                                               50, base64.Length - ctr * 50)))
      Next
      Console.WriteLine()
      
      ' Convert the string back to a byte array.
      Dim newBytes() As Byte = Convert.FromBase64String(base64)

      ' Convert the byte array back to an integer array.
      Dim newArr(newBytes.Length\4 - 1) As Integer
      For ctr As Integer = 0 To newBytes.Length \ 4 - 1
         newArr(ctr) = BitConverter.ToInt32(newBytes, ctr * 4)
      Next   
      DisplayArray(newArr)
   End Sub

   Private Sub DisplayArray(arr As Array)
      Console.WriteLine("The array:")
      Console.Write("{ ")
      For ctr As Integer = 0 To arr.GetUpperBound(0) - 1
         Console.Write("{0}, ", arr.GetValue(ctr))
         If (ctr + 1) Mod 10 = 0 Then Console.Write("{0}  ", vbCrLf)
      Next
      Console.WriteLine("{0} {1}", arr.GetValue(arr.GetUpperBound(0)), "}")
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'     The array:
'     { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
'       2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
'     
'     The encoded string:
'     AQAAAAMAAAAHAAAADwAAAB8AAAA/AAAAfwAAAP8AAAD/AQAA/w
'     MAAP8HAAD/DwAA/x8AAP8/AAD/fwAA//8AAP//AQD//wMA//8H
'     
'     The array:
'     { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023,
'       2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575 }
' </Snippet2>
