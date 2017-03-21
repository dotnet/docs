      TextReader conIn = Console.In;
      TextWriter conOut = Console.Out;
      int tries = 0;
      string input = String.Empty;
      string[] formats = new string[] {@"@M/dd/yyyy HH:m zzz", @"MM/dd/yyyy HH:m zzz", 
                                       @"M/d/yyyy HH:m zzz", @"MM/d/yyyy HH:m zzz", 
                                       @"M/dd/yy HH:m zzz", @"MM/dd/yy HH:m zzz", 
                                       @"M/d/yy HH:m zzz", @"MM/d/yy HH:m zzz",                             
                                       @"M/dd/yyyy H:m zzz", @"MM/dd/yyyy H:m zzz", 
                                       @"M/d/yyyy H:m zzz", @"MM/d/yyyy H:m zzz", 
                                       @"M/dd/yy H:m zzz", @"MM/dd/yy H:m zzz", 
                                       @"M/d/yy H:m zzz", @"MM/d/yy H:m zzz",                               
                                       @"M/dd/yyyy HH:mm zzz", @"MM/dd/yyyy HH:mm zzz", 
                                       @"M/d/yyyy HH:mm zzz", @"MM/d/yyyy HH:mm zzz", 
                                       @"M/dd/yy HH:mm zzz", @"MM/dd/yy HH:mm zzz", 
                                       @"M/d/yy HH:mm zzz", @"MM/d/yy HH:mm zzz",                                 
                                       @"M/dd/yyyy H:mm zzz", @"MM/dd/yyyy H:mm zzz", 
                                       @"M/d/yyyy H:mm zzz", @"MM/d/yyyy H:mm zzz", 
                                       @"M/dd/yy H:mm zzz", @"MM/dd/yy H:mm zzz", 
                                       @"M/d/yy H:mm zzz", @"MM/d/yy H:mm zzz"};
      IFormatProvider provider = CultureInfo.InvariantCulture.DateTimeFormat;
      DateTimeOffset result = new DateTimeOffset();
     
      do { 
         conOut.WriteLine("Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),");
         conOut.Write("Then press Enter: ");
         input = conIn.ReadLine();
         conOut.WriteLine();
         try
         {
            result = DateTimeOffset.ParseExact(input, formats, provider, 
                                               DateTimeStyles.AllowWhiteSpaces);
            break;
         }
         catch (FormatException)
         {
            Console.WriteLine("Unable to parse {0}.", input);      
            tries++;
         }
      } while (tries < 3);
      if (tries >= 3)
         Console.WriteLine("Exiting application without parsing {0}", input);
      else
         Console.WriteLine("{0} was converted to {1}", input, result.ToString());                                                     
      // Some successful sample interactions with the user might appear as follows:
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/08/2007 6:54 -6:00
      //    
      //    12/08/2007 6:54 -6:00 was converted to 12/8/2007 6:54:00 AM -06:00         
      //    
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/8/2007 06:54 -06:00
      //    
      //    12/8/2007 06:54 -06:00 was converted to 12/8/2007 6:54:00 AM -06:00
      //    
      //    Enter a date, time, and offset (MM/DD/YYYY HH:MM +/-HH:MM),
      //    Then press Enter: 12/5/07 6:54 -6:00
      //    
      //    12/5/07 6:54 -6:00 was converted to 12/5/2007 6:54:00 AM -06:00 