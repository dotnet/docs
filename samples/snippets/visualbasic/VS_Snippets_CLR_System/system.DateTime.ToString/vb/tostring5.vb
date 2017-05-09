' <Snippet5>
Imports System.Globalization
Imports System.Threading

Public Module Example
   Public Sub Main()
      Dim formats() As String = { "G", "MM/yyyy", "MM\/dd\/yyyy HH:mm",
                                  "yyyyMMdd" }
      Dim cultureNames() As String = { "en-US", "fr-FR" }
      Dim dat As New DateTime(2015, 8, 18, 13, 31, 17)
      For Each cultureName In cultureNames
         Dim culture As New CultureInfo(cultureName)
         CultureInfo.CurrentCulture = culture
         Console.WriteLine(culture.NativeName)
         For Each fmt In formats
            Console.WriteLine("   {0}: {1}", fmt,
                              dat.ToString(fmt))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       English (United States)
'          G: 8/18/2015 1:31:17 PM
'          MM/yyyy: 08/2015
'          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
'          yyyyMMdd: 20150818
'
'       français (France)
'          G: 18/08/2015 13:31:17
'          MM/yyyy: 08/2015
'          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
'          yyyyMMdd: 20150818
' </Snippet5>
