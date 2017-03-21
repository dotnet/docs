      ' Illustrate Date property and date formatting
      Dim thisDate As New DateTimeOffset(#3/17/2008 1:32AM#, New TimeSpan(-5, 0, 0))
      Dim fmt As String                    ' format specifier
      ' Display date only using "D" format specifier
      ' For en-us culture, displays:
      '   'D' format specifier: Monday, March 17, 2008
      fmt = "D"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
      
      ' Display date only using "d" format specifier
      ' For en-us culture, displays:
      '   'd' format specifier: 3/17/2008
      fmt = "d"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
      
      ' Display date only using "Y" (or "y") format specifier
      ' For en-us culture, displays:
      '   'Y' format specifier: March, 2008
      fmt = "Y"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
                        
      ' Display date only using custom format specifier
      ' For en-us culture, displays:
      '   'dd MMM yyyy' format specifier: 17 Mar 2008
      fmt = "dd MMM yyyy"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))