      Dim localNow As Date = Date.Now
      Dim localOffset As New DateTimeOffset(localNow)
      Console.WriteLine(localOffset.ToString())
      
      Dim utcNow As Date = Date.UtcNow
      Dim utcOffset As New DateTimeOffset(utcNow)
      Console.WriteLine(utcOffset.ToString())
      
      Dim unspecifiedNow As Date = Date.SpecifyKind(Date.Now, _
                                        DateTimeKind.Unspecified)
      Dim unspecifiedOffset As New DateTimeOffset(unspecifiedNow)
      Console.WriteLine(unspecifiedOffset.ToString())
      '
      ' The code produces the following output if run on Feb. 23, 2007, on
      ' a system 8 hours earlier than UTC:
      '    2/23/2007 4:21:58 PM -08:00
      '    2/24/2007 12:21:58 AM +00:00
      '    2/23/2007 4:21:58 PM -08:00      