' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim stdCulture As CultureInfo = CultureInfo.GetCultureInfo("en-US")
      Dim custCulture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US") 
            
      Dim value As String = "310,16"
      Try
         Console.WriteLine("{0} culture reflects user overrides: {1}", 
                           stdCulture.Name, stdCulture.UseUserOverride)
         Dim amount As Decimal = Decimal.Parse(value, stdCulture)
         Console.WriteLine("'{0}' --> {1}", value, amount.ToString(CultureInfo.InvariantCulture))                                                                                        
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'", value)
      End Try   
      Console.WriteLine()
                                            
      Try
         Console.WriteLine("{0} culture reflects user overrides: {1}", 
                           custCulture.Name, custCulture.UseUserOverride)
         Dim amount As Decimal = Decimal.Parse(value, custCulture)
         Console.WriteLine("'{0}' --> {1}", value, amount.ToString(CultureInfo.InvariantCulture))                                                                                        
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'", value)
      End Try   
   End Sub
End Module
' The example displays the following output:
'       en-US culture reflects user overrides: False
'       '310,16' --> 31016
'       
'       en-US culture reflects user overrides: True
'       '310,16' --> 310.16
' </Snippet5>
