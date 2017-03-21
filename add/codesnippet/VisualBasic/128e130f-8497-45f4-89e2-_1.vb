      Dim conIn As TextReader = Console.In
      Dim conOut As TextWriter = Console.Out
      Dim tries As Integer = 0
      Dim input As String = String.Empty
      Dim formats() As String = {"M/dd/yyyy HH:m zzz", "MM/dd/yyyy HH:m zzz", _
                                 "M/d/yyyy HH:m zzz", "MM/d/yyyy HH:m zzz", _
                                 "M/dd/yy HH:m zzz", "MM/dd/yy HH:m zzz", _
                                 "M/d/yy HH:m zzz", "MM/d/yy HH:m zzz", _                                 
                                 "M/dd/yyyy H:m zzz", "MM/dd/yyyy H:m zzz", _
                                 "M/d/yyyy H:m zzz", "MM/d/yyyy H:m zzz", _
                                 "M/dd/yy H:m zzz", "MM/dd/yy H:m zzz", _
                                 "M/d/yy H:m zzz", "MM/d/yy H:m zzz", _                               
                                 "M/dd/yyyy HH:mm zzz", "MM/dd/yyyy HH:mm zzz", _
                                 "M/d/yyyy HH:mm zzz", "MM/d/yyyy HH:mm zzz", _
                                 "M/dd/yy HH:mm zzz", "MM/dd/yy HH:mm zzz", _
                                 "M/d/yy HH:mm zzz", "MM/d/yy HH:mm zzz", _                                 
                                 "M/dd/yyyy H:mm zzz", "MM/dd/yyyy H:mm zzz", _
                                 "M/d/yyyy H:mm zzz", "MM/d/yyyy H:mm zzz", _
                                 "M/dd/yy H:mm zzz", "MM/dd/yy H:mm zzz", _
                                 "M/d/yy H:mm zzz", "MM/d/yy H:mm zzz"}   
      Dim provider As IFormatProvider = CultureInfo.InvariantCulture.DateTimeFormat
      Dim result As DateTimeOffset
     
      Do 
         conOut.WriteLine("Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),")
         conOut.Write("Then press Enter: ")
         input = conIn.ReadLine()
         conOut.WriteLine() 
         Try
            result = DateTimeOffset.ParseExact(input, formats, provider, _
                                               DateTimeStyles.AllowWhiteSpaces)
            Exit Do
         Catch e As FormatException
            Console.WriteLine("Unable to parse {0}.", input)      
            tries += 1
         End Try
      Loop While tries < 3
      If tries >= 3 Then
         Console.WriteLine("Exiting application without parsing {0}", input)
      Else
         Console.WriteLine("{0} was converted to {1}", input, result.ToString())                                                     
      End If 
      ' Some successful sample interactions with the user might appear as follows:
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/08/2007 6:54 -6:00
      '    
      '    12/08/2007 6:54 -6:00 was converted to 12/8/2007 6:54:00 AM -06:00         
      '    
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/8/2007 06:54 -06:00
      '    
      '    12/8/2007 06:54 -06:00 was converted to 12/8/2007 6:54:00 AM -06:00
      '    
      '    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      '    Then press Enter: 12/5/07 6:54 -6:00
      '    
      '    12/5/07 6:54 -6:00 was converted to 12/5/2007 6:54:00 AM -06:00 