' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text

Module Example
   Public Sub Main()
      Dim uppercaseStart As Integer = &h0041
      Dim uppercaseEnd As Integer = &h005a
      Dim lowercaseStart As Integer = &h0061
      Dim lowercaseEnd As Integer = &h007a
      ' Instantiate a UTF8 encoding object with BOM support.
      Dim utf8 As New UTF8Encoding(True)
      
      ' Populate array with characters.
      Dim chars(lowercaseEnd - lowercaseStart + uppercaseEnd - uppercaseStart + 1) As Char
      Dim index As Integer = 0
      For ctr As Integer = uppercaseStart To uppercaseEnd
         chars(index) = ChrW(ctr)
         index += 1
      Next
      For ctr As Integer = lowercaseStart To lowercaseEnd
         chars(index) = ChrW(ctr)
         index += 1
      Next

      ' Display the bytes needed for the lowercase characters.
        Console.WriteLine("Bytes needed for lowercase Latin characters:")
        Console.WriteLine("   Maximum:         {0,5:N0}",
                          utf8.GetMaxByteCount(lowercaseEnd - lowercaseStart + 1))
        Console.WriteLine("   Actual:          {0,5:N0}",
                          utf8.GetByteCount(chars, uppercaseEnd - uppercaseStart + 1,
                                            lowercaseEnd - lowercaseStart + 1))
        Console.WriteLine("   Actual with BOM: {0,5:N0}",
                          utf8.GetByteCount(chars, uppercaseEnd - uppercaseStart + 1,
                                            lowercaseEnd - lowercaseStart + 1) +
                                            utf8.GetPreamble().Length)
   End Sub
End Module
' The example displays the following output:
'       Bytes needed for lowercase Latin characters:
'          Maximum:            81
'          Actual:             26
'          Actual with BOM:    29
' </Snippet2>
