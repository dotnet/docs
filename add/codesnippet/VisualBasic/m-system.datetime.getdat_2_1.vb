      Dim july28 As New DateTime(2009, 7, 28, 5, 23, 15, 16)
      Dim culture As New System.Globalization.CultureInfo("fr-FR", True)

      Dim july28Formats As String()
      ' Get the short date formats using the "fr-FR" culture.
      july28Formats = july28.GetDateTimeFormats(culture)

      ' Print out july28 in various formats using "fr-FR" culture.
      For Each format As String In july28Formats
         Console.WriteLine(format)
      Next 