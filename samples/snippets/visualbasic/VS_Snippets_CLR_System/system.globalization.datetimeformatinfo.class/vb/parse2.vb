' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim inputDate As String = "14/05/10"
      
      Dim cultures() As CultureInfo = { CultureInfo.GetCultureInfo("en-US"), 
                                        CultureInfo.CreateSpecificCulture("en-US") }
      
      For Each culture In cultures
         Try
            Console.WriteLine("{0} culture reflects user overrides: {1}", 
                              culture.Name, culture.UseUserOverride)
            Dim occasion As DateTime = DateTime.Parse(inputDate, culture)
            Console.WriteLine("'{0}' --> {1}", inputDate, 
                              occasion.ToString("D", CultureInfo.InvariantCulture))
         Catch e As FormatException
            Console.WriteLine("Unable to parse '{0}'", inputDate)                           
         End Try   
         Console.WriteLine()  
      Next
   End Sub
End Module
' The example displays the following output:
'       en-US culture reflects user overrides: False
'       Unable to parse '14/05/10'
'       
'       en-US culture reflects user overrides: True
'       '14/05/10' --> Saturday, 10 May 2014
' </Snippet16>
