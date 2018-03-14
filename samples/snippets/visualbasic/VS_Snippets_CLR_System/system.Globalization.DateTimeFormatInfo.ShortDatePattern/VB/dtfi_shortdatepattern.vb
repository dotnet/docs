' <Snippet1>
Imports System.Globalization

Public Class SamplesDTFI
   Public Shared Sub Main()
      Dim cultures() As String = { "en-US", "ja-JP", "fr-FR" }
      Dim date1 As Date = #05/01/2011#
      
      Console.WriteLine(" {0,7} {1,19} {2,10}", "CULTURE", "PROPERTY VALUE", "DATE")
      Console.WriteLine()
      
      For Each culture As String In cultures
         Dim dtfi As DateTimeFormatInfo = CultureInfo.CreateSpecificCulture(culture).DateTimeFormat
         Console.WriteLine(" {0,7} {1,19} {2,10}", culture, 
                           dtfi.ShortDatePattern, 
                           date1.ToString("d", dtfi))
      Next                     
   End Sub 
End Class
' The example displays the following output:
'        CULTURE      PROPERTY VALUE       DATE
'       
'          en-US            M/d/yyyy   5/1/2011
'          ja-JP          yyyy/MM/dd 2011/05/01
'          fr-FR          dd/MM/yyyy 01/05/2011
' </Snippet1>
