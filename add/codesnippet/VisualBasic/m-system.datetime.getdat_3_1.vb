      Dim july28 As New DateTime(2009, 7, 28, 5, 23, 15, 16)
      Dim july28Formats As String()
      july28Formats = july28.GetDateTimeFormats()

      ' Print out july28 in all DateTime formats using the default culture.
      For Each format As String In july28Formats
         Console.WriteLine(format)
      Next