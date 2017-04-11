' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim formatStrings() As String = { "C2", "E1", "F", "G3", "N", 
                                        "#,##0.000", "0,000,000,000.0##" }
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim values() As Decimal = { 1345.6538d, 1921651.16d }
      
      For Each value In values
         For Each formatString In formatStrings
            Dim resultString As String = value.ToString(formatString, culture)
            Console.WriteLine("{0,-18} -->  {1}", formatString, resultString)
         Next
         Console.WriteLine()      
      Next   
   End Sub
End Module
' The example displays the following output:
'       C2                 -->  $1,345.65
'       E1                 -->  1.3E+003
'       F                  -->  1345.65
'       G3                 -->  1.35E+03
'       N                  -->  1,345.65
'       #,##0.000          -->  1,345.654
'       0,000,000,000.0##  -->  0,000,001,345.654
'       
'       C2                 -->  $1,921,651.16
'       E1                 -->  1.9E+006
'       F                  -->  1921651.16
'       G3                 -->  1.92E+06
'       N                  -->  1,921,651.16
'       #,##0.000          -->  1,921,651.160
'       0,000,000,000.0##  -->  0,001,921,651.16
' </Snippet2>
