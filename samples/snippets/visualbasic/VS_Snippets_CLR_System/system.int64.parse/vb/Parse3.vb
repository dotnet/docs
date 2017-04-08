' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module ParseInt64
   Public Sub Main()
      Convert("12,000", NumberStyles.Float Or NumberStyles.AllowThousands, _
              New CultureInfo("en-GB"))      
      Convert("12,000", NumberStyles.Float Or NumberStyles.AllowThousands, _
              New CultureInfo("fr-FR"))
      Convert("12,000", NumberStyles.Float, New CultureInfo("en-US"))
      
      Convert("12 425,00", NumberStyles.Float Or NumberStyles.AllowThousands, _
              New CultureInfo("sv-SE")) 
      Convert("12,425.00", NumberStyles.Float Or NumberStyles.AllowThousands, _
              NumberFormatInfo.InvariantInfo) 
      Convert("631,900", NumberStyles.Integer Or NumberStyles.AllowDecimalPoint, _ 
              New CultureInfo("fr-FR"))
      Convert("631,900", NumberStyles.Integer Or NumberStyles.AllowDecimalPoint, _
              New CultureInfo("en-US"))
      Convert("631,900", NumberStyles.Integer Or NumberStyles.AllowThousands, _
              New CultureInfo("en-US"))
   End Sub

   Private Sub Convert(value As String, style As NumberStyles, _
                       provider As IFormatProvider)
      Try
         Dim number As Long = Int64.Parse(value, style, provider)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", value)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of the Int64 type.", value)   
      End Try
   End Sub                       
End Module
' This example displays the following output to the console:
'       Converted '12,000' to 12000.
'       Converted '12,000' to 12.
'       Unable to convert '12,000'.
'       Converted '12 425,00' to 12425.
'       Converted '12,425.00' to 12425.
'       '631,900' is out of range of the Int64 type.
'       Unable to convert '631,900'.
'       Converted '631,900' to 631900.
' </Snippet3>

