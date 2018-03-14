' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Module Example
   Public Sub Main()
      Dim hexStrings() As String = { "8000000000000000", "0FFFFFFFFFFFFFFF", _
                                     "F000000000000000", "00A3000000000000", _
                                     "D", "-13", "9AC61", "GAD", _
                                     "FFFFFFFFFFFFFFFFF" }
      For Each hexString As String In hexStrings
         Console.Write("{0,-18}  -->  ", hexString)
         Try
            Dim number As ULong = Convert.ToUInt64(hexString, 16)
            Console.WriteLine("{0,26:N0}", number)
         Catch e As FormatException
            Console.WriteLine("{0,26}", "Bad Format")
         Catch e As OverflowException
            Console.WriteLine("{0,26}", "Numeric Overflow")
         Catch e As ArgumentException
            Console.WriteLine("{0,26}", "Invalid in Base 16")
         End Try
      Next                                            
   End Sub
End Module
' The example displays the following output:
'    8000000000000000    -->   9,223,372,036,854,775,808
'    0FFFFFFFFFFFFFFF    -->   1,152,921,504,606,846,975
'    F000000000000000    -->  17,293,822,569,102,704,640
'    00A3000000000000    -->      45,880,421,203,836,928
'    D                   -->                          13
'    -13                 -->          Invalid in Base 16
'    9AC61               -->                     633,953
'    GAD                 -->                  Bad Format
'    FFFFFFFFFFFFFFFFF   -->            Numeric Overflow
' </Snippet16>
