      Dim cultures() As CultureInfo = {CultureInfo.InvariantCulture, _
                                       New CultureInfo("en-us"), _
                                       New CultureInfo("fr-fr"), _
                                       New CultureInfo("de-DE"), _
                                       New CultureInfo("es-ES")}

      Dim thisDate As New DateTimeOffset(#5/1/2007 9:00AM#, TimeSpan.Zero)                                            
 
      For Each culture As CultureInfo In cultures
         Dim cultureName As String 
         If String.IsNullOrEmpty(culture.Name) Then
            cultureName = culture.NativeName
         Else
            cultureName = culture.Name
         End If
         Console.WriteLine("In {0}, {1}", _
                           cultureName, thisDate.ToString(culture))
      Next                                            
      ' The example produces the following output:
      '    In Invariant Language (Invariant Country), 05/01/2007 09:00:00 +00:00
      '    In en-US, 5/1/2007 9:00:00 AM +00:00
      '    In fr-FR, 01/05/2007 09:00:00 +00:00
      '    In de-DE, 01.05.2007 09:00:00 +00:00
      '    In es-ES, 01/05/2007 9:00:00 +00:00