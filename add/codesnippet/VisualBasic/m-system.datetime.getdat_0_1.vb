		Dim july28 As Date = #7/28/2009 5:23:15#
		
		Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
		' Get the short date formats using the "fr-FR" culture.
		Dim frenchJuly28Formats() As String = july28.GetDateTimeFormats("d"c, culture)

		' Display july28 in short date formats using "fr-FR" culture.
		For Each format As String In frenchJuly28Formats
			Console.WriteLine(format)
		Next
      ' The example displays the following output:
      '       28/07/2009
      '       28/07/09
      '       28.07.09
      '       28-07-09
      '       2009-07-28