' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Define cultures whose formatting conventions are to be used.
      Dim cultures() As CultureInfo = {CultureInfo.CreateSpecificCulture("en-US"), _
                                       CultureInfo.CreateSpecificCulture("fr-FR"), _
                                       CultureInfo.CreateSpecificCulture("es-ES") }
      Dim specifiers() As String = {"G", "C", "D4", "E2", "F", "N", "P", "X2"} 
      Dim value As UShort = 22042
      
      For Each specifier As String In specifiers
         For Each culture As CultureInfo In Cultures
            Console.WriteLine("{0,2} format using {1} culture: {2, 16}", _ 
                              specifier, culture.Name, _
                              value.ToString(specifier, culture))

         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'        G format using en-US culture:            22042
'        G format using fr-FR culture:            22042
'        G format using es-ES culture:            22042
'       
'        C format using en-US culture:       $22,042.00
'        C format using fr-FR culture:      22 042,00 €
'        C format using es-ES culture:      22.042,00 €
'       
'       D4 format using en-US culture:            22042
'       D4 format using fr-FR culture:            22042
'       D4 format using es-ES culture:            22042
'       
'       E2 format using en-US culture:        2.20E+004
'       E2 format using fr-FR culture:        2,20E+004
'       E2 format using es-ES culture:        2,20E+004
'       
'        F format using en-US culture:         22042.00
'        F format using fr-FR culture:         22042,00
'        F format using es-ES culture:         22042,00
'       
'        N format using en-US culture:        22,042.00
'        N format using fr-FR culture:        22 042,00
'        N format using es-ES culture:        22.042,00
'       
'        P format using en-US culture:   2,204,200.00 %
'        P format using fr-FR culture:   2 204 200,00 %
'        P format using es-ES culture:   2.204.200,00 %
'       
'       X2 format using en-US culture:             561A
'       X2 format using fr-FR culture:             561A
'       X2 format using es-ES culture:             561A
' </Snippet4>
