' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c() As Complex = { New Complex(17.3, 14.1), 
                             New Complex(-18.9, 147.2), 
                             New Complex(13.472, -18.115), 
                             New Complex(-11.154, -17.002) }
      Dim cultures() As CultureInfo = { New CultureInfo("en-US"), 
                                        New CultureInfo("fr-FR") } 
      Dim formats() As String = { "F2", "N2", "G5" } 

      For Each c1 As Complex In c
         For Each format As String In formats
            Console.Write("{0} format string:   ", format)
            For Each culture As CultureInfo In cultures
               Console.Write("{0} ({1})    ", c1.ToString(format, culture), 
                                              culture.Name)
            Next
            Console.WriteLine()
         Next
         Console.WriteLine()
      Next                          
   End Sub
End Module
' The example displays the following output:
'    F2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
'    N2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
'    G5 format string:   (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
'    
'    F2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
'    N2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
'    G5 format string:   (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
'    
'    F2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
'    N2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
'    G5 format string:   (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
'    
'    F2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
'    N2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
'    G5 format string:   (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
' </Snippet4>

