      Dim outputDate As New DateTimeOffset(#10/31/2007 9:00PM#, _
                                           New TimeSpan(-8, 0, 0))
      Dim specifier As String 
            
      ' Output date using each standard date/time format specifier
      specifier = "d"
      ' Displays   d: 10/31/2007
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 
      
      specifier = "D"
      ' Displays   D: Wednesday, October 31, 2007
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "t"
      ' Displays   t: 9:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "T"
      ' Displays   T: 9:00:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "f"
      ' Displays   f: Wednesday, October 31, 2007 9:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "F"
      ' Displays   F: Wednesday, October 31, 2007 9:00:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "g"
      ' Displays   g: 10/31/2007 9:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "G"
      ' Displays   G: 10/31/2007 9:00:00 PM
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "M"           ' 'm' is identical
      ' Displays   M: October 31
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 
      
      specifier = "R"           ' 'r' is identical
      ' Displays   R: Thu, 01 Nov 2007 05:00:00 GMT
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 
      
      specifier = "s"
      ' Displays   s: 2007-10-31T21:00:00
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      specifier = "u"
      ' Displays   u: 2007-11-01 05:00:00Z
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 

      ' Specifier is not supported
      specifier = "U"
      Try
         Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 
      Catch e As FormatException
         Console.WriteLine("{0}: Not supported.", specifier)   
      End Try

      specifier = "Y"         ' 'y' is identical
      ' Displays   Y: October, 2007
      Console.WriteLine("{0}: {1}", specifier, outputDate.ToString(specifier)) 