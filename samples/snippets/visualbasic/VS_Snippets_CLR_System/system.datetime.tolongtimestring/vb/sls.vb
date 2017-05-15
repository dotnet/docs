' <Snippet1>
Imports System.Threading
Imports System.Globalization

Public Class Example
   Public Shared Sub Main() 
      ' Create an array of culture names.
      Dim names() As String = { "en-US", "en-GB", "fr-FR", "de-DE" }
      ' Initialize a DateTime object.
      Dim dateValue As New DateTime(2013, 5, 28, 10, 30, 15)
        
      ' Iterate the array of culture names.
      For Each name In names
         ' Change the culture of the current thread.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name)
         ' Display the name of the current culture and the date.
         Console.WriteLine("Current culture: {0}", CultureInfo.CurrentCulture.Name)
         Console.WriteLine("Date: {0:G}", dateValue)        

         ' Display the long time pattern and the long time.
         Console.WriteLine("Long time pattern: '{0}'", DateTimeFormatInfo.CurrentInfo.LongTimePattern)
         Console.WriteLine("Long time with format string:     {0:T}", dateValue)
         Console.WriteLine("Long time with ToLongTimeString:  {0}", dateValue.ToLongTimeString())
         Console.WriteLine()
      Next
   End Sub 
End Class 
' The example displays the following output:
'       Current culture: en-US
'       Date: 5/28/2013 10:30:15 AM
'       Long time pattern: 'h:mm:ss tt'
'       Long time with format string:     10:30:15 AM
'       Long time with ToLongTimeString:  10:30:15 AM
'       
'       Current culture: en-GB
'       Date: 28/05/2013 10:30:15
'       Long time pattern: 'HH:mm:ss'
'       Long time with format string:     10:30:15
'       Long time with ToLongTimeString:  10:30:15
'       
'       Current culture: fr-FR
'       Date: 28/05/2013 10:30:15
'       Long time pattern: 'HH:mm:ss'
'       Long time with format string:     10:30:15
'       Long time with ToLongTimeString:  10:30:15
'       
'       Current culture: de-DE
'       Date: 28.05.2013 10:30:15
'       Long time pattern: 'HH:mm:ss'
'       Long time with format string:     10:30:15
'       Long time with ToLongTimeString:  10:30:15
' </Snippet1>