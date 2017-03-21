		Dim july28 As Date = #7/28/2009 5:23:15#
		
		' Get the long date formats using the current culture.
		Dim longJuly28Formats() As String = july28.GetDateTimeFormats("D"c)

		' Display july28 in all long date formats.
		For Each format As String In longJuly28Formats
			Console.WriteLine(format)
      Next			
      ' The example displays the following output:
      '       Tuesday, July 28, 2009
      '       July 28, 2009
      '       Tuesday, 28 July, 2009
      '       28 July, 2009