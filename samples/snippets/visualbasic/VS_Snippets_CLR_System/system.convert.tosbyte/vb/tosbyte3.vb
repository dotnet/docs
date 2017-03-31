' Visual Basic .NET Document
Option Strict On
' String to SByte base conversion.
' <Snippet16>
Module Example
   Public Sub Main()
      Dim bases() As Integer = { 2, 8, 16}
      Dim values() As String = { "FF", "81", "03", "11", "8F", "01", "1C", _ 
                                 "111", "123", "18A" } 
   
      ' Convert to each supported base.
      For Each base As Integer In bases
         Console.WriteLine("Converting strings in base {0}:", base)
         For Each value As String In values
            Console.Write("   '{0,-5}  -->  ", value + "'")
            Try
               Console.WriteLine(Convert.ToSByte(value, base))
            Catch e As FormatException
               Console.WriteLine("Bad Format")
            Catch e As OverflowException
               Console.WriteLine("Out of Range")
            End Try   
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       Converting strings in base 2:
'          'FF'    -->  Bad Format
'          '81'    -->  Bad Format
'          '03'    -->  Bad Format
'          '11'    -->  3
'          '8F'    -->  Bad Format
'          '01'    -->  1
'          '1C'    -->  Bad Format
'          '111'   -->  7
'          '123'   -->  Bad Format
'          '18A'   -->  Bad Format
'       
'       Converting strings in base 8:
'          'FF'    -->  Bad Format
'          '81'    -->  Bad Format
'          '03'    -->  3
'          '11'    -->  9
'          '8F'    -->  Bad Format
'          '01'    -->  1
'          '1C'    -->  Bad Format
'          '111'   -->  73
'          '123'   -->  83
'          '18A'   -->  Bad Format
'       
'       Converting strings in base 16:
'          'FF'    -->  -1
'          '81'    -->  -127
'          '03'    -->  3
'          '11'    -->  17
'          '8F'    -->  -113
'          '01'    -->  1
'          '1C'    -->  28
'          '111'   -->  Out of Range
'          '123'   -->  Out of Range
'          '18A'   -->  Out of Range
' </Snippet16>
