      ' Specify the date to be formatted using various cultures.
      Dim tDate As New Date(2010, 4, 15, 20, 30, 40, 333)
      ' Specify the cultures.
      Dim cultureNames() As String = { "en-US", "es-AR", "fr-FR", "hi-IN", _
                                       "ja-JP", "nl-NL", "ru-RU", "ur-PK" }
      
      Console.WriteLine("Converting the date {0}: ", _
                        Convert.ToString(tDate, _
                                System.Globalization.CultureInfo.InvariantCulture))

      For Each cultureName As String In CultureNames
         Dim culture As New System.Globalization.CultureInfo(cultureName)
         Dim dateString As String = Convert.ToString(tDate, culture)
         Console.WriteLine("   {0}:  {1,-12}", _
                           culture.Name, dateString)
      Next             
      ' The example displays the following output:
      '       Converting the date 04/15/2010 20:30:40:
      '          en-US:  4/15/2010 8:30:40 PM
      '          es-AR:  15/04/2010 08:30:40 p.m.
      '          fr-FR:  15/04/2010 20:30:40
      '          hi-IN:  15-04-2010 20:30:40
      '          ja-JP:  2010/04/15 20:30:40
      '          nl-NL:  15-4-2010 20:30:40
      '          ru-RU:  15.04.2010 20:30:40
      '          ur-PK:  15/04/2010 8:30:40 PM      