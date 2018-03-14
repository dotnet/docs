' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "hu-HU", "pt-PT" }
      Dim objects() As Object = { 12, 17.2, False, #1/1/2010#, "today", _
                                  New System.Collections.ArrayList(), "c"c, _
                                  "05/10/2009 6:13:18 PM", "September 8, 1899" }
      
      For Each cultureName As String In cultureNames
         Console.WriteLine("{0} culture:", cultureName)
         Dim provider As New CustomProvider(cultureName)
         For Each obj As Object In objects
            Try
               Dim dateValue As Date = Convert.ToDateTime(obj, provider)      
               Console.WriteLine("{0} --> {1}", obj, _
                                 dateValue.ToString(New CultureInfo(cultureName)))
            Catch e As FormatException
               Console.WriteLine("{0} --> Bad Format", obj)
            Catch e As InvalidCastException
               Console.WriteLine("{0} --> Conversion Not Supported", obj)
            End Try
         Next
         Console.WriteLine()
      Next
   End Sub
End Module

Public Class CustomProvider : Implements IFormatProvider
   Private cultureName As String
   
   Public Sub New(cultureName As String)
      Me.cultureName = cultureName
   End Sub
   
   Public Function GetFormat(formatType As Type) As Object _
          Implements IFormatProvider.GetFormat
      If formatType Is GetType(DateTimeFormatInfo) Then
         Console.Write("(CustomProvider retrieved.) ")
         Return New CultureInfo(cultureName).GetFormat(formatType)
      Else
         Return Nothing
      End If   
   End Function
End Class
' The example displays the following output:
'    en-US culture:
'    12 --> Conversion Not Supported
'    17.2 --> Conversion Not Supported
'    False --> Conversion Not Supported
'    1/1/2010 12:00:00 AM --> 1/1/2010 12:00:00 AM
'    (CustomProvider retrieved.) today --> Bad Format
'    System.Collections.ArrayList --> Conversion Not Supported
'    c --> Conversion Not Supported
'    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 5/10/2009 6:13:18 PM
'    (CustomProvider retrieved.) September 8, 1899 --> 9/8/1899 12:00:00 AM
'    
'    hu-HU culture:
'    12 --> Conversion Not Supported
'    17.2 --> Conversion Not Supported
'    False --> Conversion Not Supported
'    1/1/2010 12:00:00 AM --> 2010. 01. 01. 0:00:00
'    (CustomProvider retrieved.) today --> Bad Format
'    System.Collections.ArrayList --> Conversion Not Supported
'    c --> Conversion Not Supported
'    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 2009. 05. 10. 18:13:18
'    (CustomProvider retrieved.) September 8, 1899 --> 1899. 09. 08. 0:00:00
'    
'    pt-PT culture:
'    12 --> Conversion Not Supported
'    17.2 --> Conversion Not Supported
'    False --> Conversion Not Supported
'    1/1/2010 12:00:00 AM --> 01-01-2010 0:00:00
'    (CustomProvider retrieved.) today --> Bad Format
'    System.Collections.ArrayList --> Conversion Not Supported
'    c --> Conversion Not Supported
'    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 05-10-2009 18:13:18
'    (CustomProvider retrieved.) September 8, 1899 --> 08-09-1899 0:00:00
' </Snippet4>
