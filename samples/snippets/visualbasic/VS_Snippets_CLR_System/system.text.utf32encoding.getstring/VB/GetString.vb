
' <Snippet1>
Imports System.Text

Public Module Example  
   Public Sub Main()  
      ' Create two instances of UTF32Encoding: one with little-endian byte order and one with big-endian byte order.
      Dim u32LE As New UTF32Encoding(False, True, True)
      Dim u32BE As New UTF32Encoding(True, True, True)

      ' Create byte arrays from the same string containing the following characters:
      '    Latin Small Letter Z (U+007A)
      '    Latin Small Letter A (U+0061)
      '    Combining Breve (U+0306)
      '    Latin Small Letter AE With Acute (U+01FD)
      '    Greek Small Letter Beta (U+03B2)
      Dim str As String = "za" + ChrW(&h0306) + ChrW(&h01FD) + ChrW(&h03B2)

      ' barrBE uses the big-endian byte order.
      Dim barrBE(u32BE.GetByteCount(str) - 1) As Byte
      u32BE.GetBytes(str, 0, str.Length, barrBE, 0)

      ' barrLE uses the little-endian byte order.
      Dim barrLE(u32LE.GetByteCount(str) - 1) As Byte
      u32LE.GetBytes(str, 0, str.Length, barrLE, 0)

      ' Decode the byte arrays.
      Console.WriteLine("BE array with BE encoding:")
      DisplayString(barrBE, u32BE)
      Console.WriteLine()

      Console.WriteLine("LE array with LE encoding:")
      DisplayString(barrLE, u32LE)
      Console.WriteLine()
   
      ' Decode the byte arrays using an encoding with a different byte order.
      Console.WriteLine("BE array with LE encoding:")
      Try  
         DisplayString(barrBE, u32LE)
      Catch e As ArgumentException
         Console.WriteLine(e.Message)
      End Try
      Console.WriteLine()

      Console.WriteLine("LE array with BE encoding:")
      Try  
         DisplayString(barrLE, u32BE)
      Catch e As ArgumentException
         Console.WriteLine(e.Message)
      End Try
      Console.WriteLine()
   End Sub

   Public Sub DisplayString(bytes As Byte(), enc As Encoding )  
      ' Display the name of the encoding used.
      Console.Write("{0,-25}: ", enc.ToString())

      ' Decode the bytes and display the characters.
      Console.WriteLine(enc.GetString(bytes, 0, bytes.Length))
   End Sub
End Module
' This example displays the following output:
'   BE array with BE encoding:
'   System.Text.UTF32Encoding: zăǽβ
'
'   LE array with LE encoding:
'   System.Text.UTF32Encoding: zăǽβ
'
'   BE array with LE encoding:
'   System.Text.UTF32Encoding: Unable to translate bytes [00][00][00][7A] at index 0 from specified code page to Unicode.
'
'   LE array with BE encoding:
'   System.Text.UTF32Encoding: Unable to translate bytes [7A][00][00][00] at index 0 from specified code page to Unicode.
' </Snippet1>





