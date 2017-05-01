' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Module Example
   Public Sub Main()
      Dim hexStrings() As String = { "80000000", "0FFFFFFF", "F0000000", "00A3000", "D", _
                                     "-13", "9AC61", "GAD", "FFFFFFFFFF" }
      For Each hexString As String In hexStrings
         Console.Write("{0,-12}  -->  ", hexString)
         Try
            Dim number As UInteger = Convert.ToUInt32(hexString, 16)
            Console.WriteLine("{0,18:N0}", number)
         Catch e As FormatException
            Console.WriteLine("{0,18}", "Bad Format")
         Catch e As OverflowException
            Console.WriteLine("{0,18}", "Numeric Overflow")
         Catch e As ArgumentException
            Console.WriteLine("{0,18}", "Invalid in Base 16")
         End Try
      Next                                            
   End Sub
End Module
'    ' The example displays the following output:
'    80000000      -->       2,147,483,648
'    0FFFFFFF      -->         268,435,455
'    F0000000      -->       4,026,531,840
'    00A3000       -->             667,648
'    D             -->                  13
'    -13           -->  Invalid in Base 16
'    9AC61         -->             633,953
'    GAD           -->          Bad Format
'    FFFFFFFFFF    -->    Numeric Overflow
' </Snippet16>
