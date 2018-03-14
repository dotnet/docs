'<Snippet1>
Imports System
Imports System.Globalization
Imports System.Text
Imports Microsoft.VisualBasic


Class SamplesNumberFormatInfo
   
   
   Public Shared Sub Main()
      
      ' Gets the InvariantInfo.
      Dim myInv As NumberFormatInfo = NumberFormatInfo.InvariantInfo
      
      ' Gets a UnicodeEncoding to display the Unicode value of symbols.
      Dim myUE As New UnicodeEncoding(True, False)
      Dim myCodes() As Byte
      
      ' Displays the default values for each of the properties.
      Console.WriteLine("InvariantInfo:")
      Console.WriteLine("Note: Symbols might not display correctly on the console,")
      Console.WriteLine("therefore, Unicode values are included.")
      Console.WriteLine(ControlChars.Tab + "CurrencyDecimalDigits" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.CurrencyDecimalDigits)
      Console.WriteLine(ControlChars.Tab + "CurrencyDecimalSeparator" + ControlChars.Tab + "{0}", myInv.CurrencyDecimalSeparator)
      Console.WriteLine(ControlChars.Tab + "CurrencyGroupSeparator" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.CurrencyGroupSeparator)
      Console.WriteLine(ControlChars.Tab + "CurrencyGroupSizes" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.CurrencyGroupSizes(0))
      Console.WriteLine(ControlChars.Tab + "CurrencyNegativePattern" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.CurrencyNegativePattern)
      Console.WriteLine(ControlChars.Tab + "CurrencyPositivePattern" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.CurrencyPositivePattern)
      myCodes = myUE.GetBytes(myInv.CurrencySymbol)
      Console.WriteLine(ControlChars.Tab + "CurrencySymbol" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}" + ControlChars.Tab + "(U+{1:x2}{2:x2})", myInv.CurrencySymbol, myCodes(0), myCodes(1))
      Console.WriteLine(ControlChars.Tab + "NaNSymbol" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NaNSymbol)
      Console.WriteLine(ControlChars.Tab + "NegativeInfinitySymbol" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NegativeInfinitySymbol)
      Console.WriteLine(ControlChars.Tab + "NegativeSign" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NegativeSign)
      Console.WriteLine(ControlChars.Tab + "NumberDecimalDigits" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NumberDecimalDigits)
      Console.WriteLine(ControlChars.Tab + "NumberDecimalSeparator" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NumberDecimalSeparator)
      Console.WriteLine(ControlChars.Tab + "NumberGroupSeparator" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NumberGroupSeparator)
      Console.WriteLine(ControlChars.Tab + "NumberGroupSizes" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NumberGroupSizes(0))
      Console.WriteLine(ControlChars.Tab + "NumberNegativePattern" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.NumberNegativePattern)
      Console.WriteLine(ControlChars.Tab + "PercentDecimalDigits" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentDecimalDigits)
      Console.WriteLine(ControlChars.Tab + "PercentDecimalSeparator" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentDecimalSeparator)
      Console.WriteLine(ControlChars.Tab + "PercentGroupSeparator" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentGroupSeparator)
      Console.WriteLine(ControlChars.Tab + "PercentGroupSizes" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentGroupSizes(0))
      Console.WriteLine(ControlChars.Tab + "PercentNegativePattern" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentNegativePattern)
      Console.WriteLine(ControlChars.Tab + "PercentPositivePattern" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PercentPositivePattern)
      myCodes = myUE.GetBytes(myInv.PercentSymbol)
      Console.WriteLine(ControlChars.Tab + "PercentSymbol" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}" + ControlChars.Tab + "(U+{1:x2}{2:x2})", myInv.PercentSymbol, myCodes(0), myCodes(1))
      myCodes = myUE.GetBytes(myInv.PerMilleSymbol)
      Console.WriteLine(ControlChars.Tab + "PerMilleSymbol" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}" + ControlChars.Tab + "(U+{1:x2}{2:x2})", myInv.PerMilleSymbol, myCodes(0), myCodes(1))
      Console.WriteLine(ControlChars.Tab + "PositiveInfinitySymbol" + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PositiveInfinitySymbol)
      Console.WriteLine(ControlChars.Tab + "PositiveSign" + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "{0}", myInv.PositiveSign)
   End Sub 'Main 
End Class 'SamplesNumberFormatInfo


' This code produces the following output.
'
' InvariantInfo:
' Note: Symbols might not display correctly on the console,
' therefore, Unicode values are included.
'         CurrencyDecimalDigits           2
'         CurrencyDecimalSeparator        .
'         CurrencyGroupSeparator          ,
'         CurrencyGroupSizes              3
'         CurrencyNegativePattern         0
'         CurrencyPositivePattern         0
'         CurrencySymbol                         (U+00a4)
'         NaNSymbol                       NaN
'         NegativeInfinitySymbol          -Infinity
'         NegativeSign                    -
'         NumberDecimalDigits             2
'         NumberDecimalSeparator          .
'         NumberGroupSeparator            ,
'         NumberGroupSizes                3
'         NumberNegativePattern           1
'         PercentDecimalDigits            2
'         PercentDecimalSeparator         .
'         PercentGroupSeparator           ,
'         PercentGroupSizes               3
'         PercentNegativePattern          0
'         PercentPositivePattern          0
'         PercentSymbol                   %       (U+0025)
'         PerMilleSymbol                  %       (U+2030)
'         PositiveInfinitySymbol          Infinity
'         PositiveSign                    +
'</Snippet1>
