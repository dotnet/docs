      // Illustrate Date property and date formatting
      DateTimeOffset thisDate = new DateTimeOffset(2008, 3, 17, 1, 32, 0, new TimeSpan(-5, 0, 0));
      string fmt;                      // format specifier

      // Display date only using "D" format specifier
      // For en-us culture, displays:
      //   'D' format specifier: Monday, March 17, 2008
      fmt = "D";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
      
      // Display date only using "d" format specifier
      // For en-us culture, displays:
      //   'd' format specifier: 3/17/2008
      fmt = "d";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
      
      // Display date only using "Y" (or "y") format specifier
      // For en-us culture, displays:
      //   'Y' format specifier: March, 2008
      fmt = "Y";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));
                        
      // Display date only using custom format specifier
      // For en-us culture, displays:
      //   'dd MMM yyyy' format specifier: 17 Mar 2008
      fmt = "dd MMM yyyy";
      Console.WriteLine("'{0}' format specifier: {1}",  
                        fmt, thisDate.Date.ToString(fmt));