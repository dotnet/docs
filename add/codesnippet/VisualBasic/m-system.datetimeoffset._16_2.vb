      Dim outputDate As New DateTimeOffset(#11/1/2007 9:00AM#, _
                                           New TimeSpan(-7, 0, 0)) 
      Dim format As String = "dddd, MMM dd yyyy HH:mm:ss zzz"
      
      ' Output date and time using custom format specification
      Console.WriteLine(outputDate.ToString(format, Nothing))
      Console.WriteLine(outputDate.ToString(format, CultureInfo.InvariantCulture))
      Console.WriteLine(outputDate.ToString(format, _
                                            New CultureInfo("fr-FR")))
      Console.WriteLine(outputDate.ToString(format, _
                                            New CultureInfo("es-ES")))
      ' The example displays the following output to the console:
      '    Thursday, Nov 01 2007 09:00:00 -07:00
      '    Thursday, Nov 01 2007 09:00:00 -07:00
      '    jeudi, nov. 01 2007 09:00:00 -07:00
      '    jueves, nov 01 2007 09:00:00 -07:00