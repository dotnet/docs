      Dim departure As DateTime = #06/12/2010 6:32PM#
      Dim arrival As DateTime = #06/13/2010 10:47PM#
      Dim travelTime As TimeSpan = arrival - departure  
      Console.WriteLine("{0} - {1} = {2}", arrival, departure, travelTime)      
      ' The example displays the following output:
      '       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00