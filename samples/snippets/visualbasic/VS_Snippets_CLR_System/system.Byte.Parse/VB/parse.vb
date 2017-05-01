' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      CallParse1()
      Console.WriteLine()
      CallParse2()
      Console.WriteLine()
      CallParse3()
      Console.WriteLine()
      CallParse4()
   End Sub
   
   Private Sub CallParse1()
      ' <Snippet1>
      Dim stringToConvert As String = " 162"
      Dim byteValue As Byte
      Try
         byteValue = Byte.Parse(stringToConvert)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      ' The example displays the following output to the console:
      '       Converted ' 162' to 162.         
      ' </Snippet1>
   End Sub
   
   Private Sub CallParse2()
      ' <Snippet2>
      Dim stringToConvert As String 
      Dim byteValue As Byte
      
      stringToConvert = " 214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      
      stringToConvert = " + 214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      
      stringToConvert = " +214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 214 ' to 214.
      '       Unable to parse ' + 214 '.
      '       Converted ' +214 ' to 214.
      ' </Snippet2>
   End Sub
   
   Private Sub CallParse3()
      ' <Snippet3>
      Dim value As String
      Dim style As NumberStyles
      Dim number As Byte
      
      ' Parse value with no styles allowed.
      style = NumberStyles.None
      value = " 241 "
      Try
         number = Byte.Parse(value, style)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End Try
        
      ' Parse value with trailing sign.
      style = NumberStyles.Integer Or NumberStyles.AllowTrailingSign
      value = " 163+"
      number = Byte.Parse(value, style)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      
      ' Parse value with leading sign.
      value = "   +253  "
      number = Byte.Parse(value, style)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      ' This example displays the following output to the console:
      '       Unable to parse ' 241 '.
      '       Converted ' 163+' to 163.
      '       Converted '   +253  ' to 253.            
      ' </Snippet3>      
   End Sub
   
   Private Sub CallParse4()
      ' <Snippet4>
      Dim style As NumberStyles
      Dim culture As CultureInfo
      Dim value As String
      Dim number As Byte
      
      ' Parse number with decimals.
      ' NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
      style = NumberStyles.Float       
      culture = CultureInfo.CreateSpecificCulture("fr-FR")
      value = "12,000"

      number = Byte.Parse(value, style, culture)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)

      culture = CultureInfo.CreateSpecificCulture("en-GB")
      Try
         number = Byte.Parse(value, style, culture)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End Try      

      value = "12.000"
      number = Byte.Parse(value, style, culture)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      ' The example displays the following output to the console:
      '       Converted '12,000' to 12.
      '       Unable to parse '12,000'.
      '       Converted '12.000' to 12.
      ' </Snippet4>
   End Sub
End Module

