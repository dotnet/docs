' The following code example shows that CultureInfo.Clone also clones the DateTimeFormatInfo and NumberFormatInfo instances associated with the CultureInfo.

' <snippet1>
Imports System
Imports System.Globalization


Public Class SamplesCultureInfo
   
   Public Shared Sub Main()
      
      ' Creates and initializes a CultureInfo.
      Dim myCI As New CultureInfo("en-US", False)
      
      ' Clones myCI and modifies the DTFI and NFI instances associated with the clone.
      Dim myCIclone As CultureInfo = CType(myCI.Clone(), CultureInfo)
      myCIclone.DateTimeFormat.AMDesignator = "a.m."
      myCIclone.DateTimeFormat.DateSeparator = "-"
      myCIclone.NumberFormat.CurrencySymbol = "USD"
      myCIclone.NumberFormat.NumberDecimalDigits = 4
      
      ' Displays the properties of the DTFI and NFI instances associated with the original and with the clone. 
      Console.WriteLine("DTFI/NFI PROPERTY" + ControlChars.Tab + "ORIGINAL" + ControlChars.Tab + "MODIFIED CLONE")
      Console.WriteLine("DTFI.AMDesignator" + ControlChars.Tab + "{0}" + ControlChars.Tab + ControlChars.Tab + "{1}", myCI.DateTimeFormat.AMDesignator, myCIclone.DateTimeFormat.AMDesignator)
      Console.WriteLine("DTFI.DateSeparator" + ControlChars.Tab + "{0}" + ControlChars.Tab + ControlChars.Tab + "{1}", myCI.DateTimeFormat.DateSeparator, myCIclone.DateTimeFormat.DateSeparator)
      Console.WriteLine("NFI.CurrencySymbol" + ControlChars.Tab + "{0}" + ControlChars.Tab + ControlChars.Tab + "{1}", myCI.NumberFormat.CurrencySymbol, myCIclone.NumberFormat.CurrencySymbol)
      Console.WriteLine("NFI.NumberDecimalDigits" + ControlChars.Tab + "{0}" + ControlChars.Tab + ControlChars.Tab + "{1}", myCI.NumberFormat.NumberDecimalDigits, myCIclone.NumberFormat.NumberDecimalDigits)

   End Sub 'Main 

End Class 'SamplesCultureInfo


' This code produces the following output.
'
' DTFI/NFI PROPERTY       ORIGINAL        MODIFIED CLONE
' DTFI.AMDesignator       AM              a.m.
' DTFI.DateSeparator      /               -
' NFI.CurrencySymbol      $               USD
' NFI.NumberDecimalDigits 2               4
' </snippet1>