Class Class1
   Public Shared Sub Main()
      ShowDefaultFormats()
      Console.WriteLine("----")
      ShowDefaultFrenchFormats()
      Console.WriteLine("----")
      ShowDefaultDFormat()
      Console.WriteLine("----")
      ShowFrenchdFormat()
   End Sub

   Private Shared Sub ShowDefaultFormats()
      ' <Snippet1>
      Dim july28 As New DateTime(2009, 7, 28, 5, 23, 15, 16)
      Dim july28Formats As String()
      july28Formats = july28.GetDateTimeFormats()

      ' Print out july28 in all DateTime formats using the default culture.
      For Each format As String In july28Formats
         Console.WriteLine(format)
      Next
      ' </Snippet1>
   End Sub
   
   Private Shared Sub ShowDefaultFrenchFormats()
      ' <Snippet2>
      Dim july28 As New DateTime(2009, 7, 28, 5, 23, 15, 16)
      Dim culture As New System.Globalization.CultureInfo("fr-FR", True)

      Dim july28Formats As String()
      ' Get the short date formats using the "fr-FR" culture.
      july28Formats = july28.GetDateTimeFormats(culture)

      ' Print out july28 in various formats using "fr-FR" culture.
      For Each format As String In july28Formats
         Console.WriteLine(format)
      Next 
      ' </Snippet2>
   End Sub
   
   Private Shared Sub ShowDefaultDFormat()
      ' <Snippet3>
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
		' </Snippet3>
   End Sub
   
   Private Shared Sub ShowFrenchdFormat()
      ' <Snippet4>
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
		' </Snippet4>
   End Sub
End Class
