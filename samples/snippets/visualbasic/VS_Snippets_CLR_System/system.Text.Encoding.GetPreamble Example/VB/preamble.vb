'<snippet1>
Imports System
Imports System.Text

Namespace GetPreambleExample
   Class GetPreambleExampleClass
      Shared Sub Main()
         Dim [unicode] As Encoding = Encoding.Unicode

         ' Get the preamble for the Unicode encoder. 
         ' In this case the preamble contains the byte order mark (BOM).
         Dim preamble As Byte() = [unicode].GetPreamble()

         ' Make sure a preamble was returned 
         ' and is large enough to contain a BOM.
         If preamble.Length >= 2 Then
            If preamble(0) = &HFE And preamble(1) = &HFF Then
               Console.WriteLine("The Unicode encoder is encoding in big-endian order.")
            Else
               If preamble(0) = &HFF And preamble(1) = &HFE Then
                  Console.WriteLine("The Unicode encoder is encoding in little-endian order.")
               End If
            End If
         End If
      End Sub
   End Class
End Namespace

'This code produces the following output.
'
'The Unicode encoder is encoding in little-endian order.
'
'</snippet1>