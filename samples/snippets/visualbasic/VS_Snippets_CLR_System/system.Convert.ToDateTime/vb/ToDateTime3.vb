' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main( )
      Console.WriteLine("{0,-18}{1,-12}{2}", "Date String", "Culture", "Result")
      Console.WriteLine()

      Dim cultureNames() As String = { "en-US", "ru-RU","ja-JP" }
      Dim dateStrings() As String = { "01/02/09", "2009/02/03",  "01/2009/03", _
                                      "01/02/2009", "21/02/09", "01/22/09",   _
                                      "01/02/23" }
      ' Iterate each culture name in the array.
      For Each cultureName As String In cultureNames
         Dim culture As CultureInfo = New CultureInfo(cultureName)
        
         ' Parse each date using the designated culture.
         For Each dateStr As String In dateStrings
            Dim dateTimeValue As DateTime
            Try
               dateTimeValue = Convert.ToDateTime(dateStr, culture)
                ' Display the date and time in a fixed format.
                Console.WriteLine("{0,-18}{1,-12}{2:yyyy-MMM-dd}", _
                                  dateStr, cultureName, dateTimeValue)
            Catch e As FormatException 
                Console.WriteLine("{0,-18}{1,-12}{2}", _
                                  dateStr, cultureName, e.GetType().Name)
            End Try            
         Next
         Console.WriteLine()
      Next
   End Sub 
End Module 
' The example displays the following output:
'       Date String       Culture     Result
'       
'       01/02/09          en-US       2009-Jan-02
'       2009/02/03        en-US       2009-Feb-03
'       01/2009/03        en-US       2009-Jan-03
'       01/02/2009        en-US       2009-Jan-02
'       21/02/09          en-US       FormatException
'       01/22/09          en-US       2009-Jan-22
'       01/02/23          en-US       2023-Jan-02
'       
'       01/02/09          ru-RU       2009-Feb-01
'       2009/02/03        ru-RU       2009-Feb-03
'       01/2009/03        ru-RU       2009-Jan-03
'       01/02/2009        ru-RU       2009-Feb-01
'       21/02/09          ru-RU       2009-Feb-21
'       01/22/09          ru-RU       FormatException
'       01/02/23          ru-RU       2023-Feb-01
'       
'       01/02/09          ja-JP       2001-Feb-09
'       2009/02/03        ja-JP       2009-Feb-03
'       01/2009/03        ja-JP       2009-Jan-03
'       01/02/2009        ja-JP       2009-Jan-02
'       21/02/09          ja-JP       2021-Feb-09
'       01/22/09          ja-JP       FormatException
'       01/02/23          ja-JP       2001-Feb-23
' </Snippet3>
