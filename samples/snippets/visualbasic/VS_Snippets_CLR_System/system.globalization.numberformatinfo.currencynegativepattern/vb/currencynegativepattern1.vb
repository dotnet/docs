' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Globalization

Public Class Example : Implements IComparer(Of CultureInfo)
   Public Shared Sub Main()
      ' Assign possible values and their associated patterns to a 
      ' generic Dictionary object.
      Dim patterns As New Dictionary(Of Integer, String)
      Dim patternStrings() As String = { "($n)", "-$n", "$-n", "$n-", "(n$)", 
                                         "-n$", "n-$", "n$-", "-n $", "-$ n",
                                         "n $-", "$ n-", "$ -n", "n- $", "($ n)",
                                         "(n $)" }    
      For ctr As Integer = patternStrings.GetLowerBound(0) To patternStrings.GetUpperBound(0)
         patterns.Add(ctr, patternStrings(ctr))
      Next

      ' Retrieve all specific cultures.
      Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
      Array.Sort(cultures, New Example())
      
      Dim number As Double = -16.335
      ' Display the culture, CurrencyNegativePattern value, associated pattern, and result.
      For Each culture In cultures
         Console.WriteLine("{0,-15} {1,2} ({2,5}) {3,15}", culture.Name + ":", 
                           culture.NumberFormat.CurrencyNegativePattern,
                           patterns.Item(culture.NumberFormat.CurrencyNegativePattern),
                           number.ToString("C", culture))
      Next
   End Sub
   
   Public Function Compare(x As CultureInfo, y As CultureInfo) As Integer _
                           Implements IComparer(Of CultureInfo).Compare
      Return String.Compare(x.Name, y.Name)                           
   End Function                           
End Class
' A portion of the output appears as follows:
'       ca-ES:           8 ( -n $)        -16,34 €
'       co-FR:           8 ( -n $)        -16,34 €
'       cs-CZ:           8 ( -n $)       -16,34 Kč
'       cy-GB:           1 (  -$n)         -£16.34
'       da-DK:          12 ( $ -n)      kr. -16,34
'       de-AT:           9 ( -$ n)        -€ 16,34
'       de-CH:           2 (  $-n)       Fr.-16.34
'       de-DE:           8 ( -n $)        -16,34 €
'       de-LI:           2 (  $-n)       CHF-16.34
'       de-LU:           8 ( -n $)        -16,34 €
'       dsb-DE:          8 ( -n $)        -16,34 €
' </Snippet1>
