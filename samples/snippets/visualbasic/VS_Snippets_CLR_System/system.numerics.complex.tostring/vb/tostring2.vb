' Visual Basic .NET Document
Option Strict On

' <Snippet2>
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
      For Each c1 As Complex In c
         For Each culture As CultureInfo In cultures
            Console.Write("{0} ({1})    ", c1.ToString(culture), culture.Name)
         Next
         Console.WriteLine()
      Next                          
   End Sub
End Module
' The example displays the following output:
'       (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
'       (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
'       (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
'       (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
' </Snippet2>

