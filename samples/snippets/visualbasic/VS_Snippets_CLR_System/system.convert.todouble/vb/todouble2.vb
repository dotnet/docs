' Visual Basic .NET Document
Option Strict On


' Illustrates Convert.ToDouble(String, IFormatProvider) overload.
Module Example
   Public Sub Main()
      ' <Snippet9>
      Dim values() As String = { "1,5304e16", "1.5304e16", "1,034.1233", _
                                 "1,03221", "1630.34034" }
      Dim cultures() As System.Globalization.CultureInfo = _
                        { New System.Globalization.CultureInfo("en-US"), _
                          New System.Globalization.CultureInfo("fr-FR"), _
                          New System.Globalization.CultureInfo("es-ES") }
      
      For Each culture As System.Globalization.CultureInfo In cultures
         Console.WriteLine("Conversions using {0} culture:", culture.Name)
         For Each value As String In values
            Console.Write("   {0,-15}  -->  ", value)
            Try
               Console.WriteLine("{0}", Convert.ToDouble(value, culture))
            Catch e As FormatException
               Console.WriteLine("Bad Format")
            Catch e As OverflowException
               Console.WriteLine("Overflow")
            End Try      
         Next
         Console.WriteLine()
      Next
      ' The example displays the following output:
      '       Conversions using en-US culture:
      '          1,5304e16        -->  1.5304E+20
      '          1.5304e16        -->  1.5304E+16
      '          1,034.1233       -->  1034.1233
      '          1,03221          -->  103221
      '          1630.34034       -->  1630.34034
      '       
      '       Conversions using fr-FR culture:
      '          1,5304e16        -->  1.5304E+16
      '          1.5304e16        -->  Bad Format
      '          1,034.1233       -->  Bad Format
      '          1,03221          -->  1.03221
      '          1630.34034       -->  Bad Format
      '       
      '       Conversions using es-ES culture:
      '          1,5304e16        -->  1.5304E+16
      '          1.5304e16        -->  1.5304E+20
      '          1,034.1233       -->  Bad Format
      '          1,03221          -->  1.03221
      '          1630.34034       -->  163034034      
      ' </Snippet9>
   End Sub
End Module

