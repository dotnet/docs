' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim dateStrings() As String = {"2008-05-01T07:34:42-5:00", _
                                     "2008-05-01 7:34:42Z", _
                                     "Thu, 01 May 2008 07:34:42 GMT"}
      
      For Each dateString As String In dateStrings
         Dim convertedDate As Date = Date.Parse(dateString)
         Console.WriteLine("Converted {0} to {1} time {2}", _
                           dateString, _
                           convertedDate.Kind.ToString(), _
                           convertedDate)
      Next 
   End Sub
End Module
' These calls to the DateTime.Parse method display the following output:
'   Converted 2008-05-01T07:34:42-5:00 to Local time 5/1/2008 5:34:42 AM
'   Converted 2008-05-01 7:34:42Z to Local time 5/1/2008 12:34:42 AM
'   Converted Thu, 01 May 2008 07:34:42 GMT to Local time 5/1/2008 12:34:42 AM                                             
' </Snippet2>

