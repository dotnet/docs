      DateTime departure = new DateTime(2010, 6, 12, 18, 32, 0);
      DateTime arrival = new DateTime(2010, 6, 13, 22, 47, 0);
      TimeSpan travelTime = arrival - departure;  
      Console.WriteLine("{0} - {1} = {2}", arrival, departure, travelTime);      
      // The example displays the following output:
      //       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00