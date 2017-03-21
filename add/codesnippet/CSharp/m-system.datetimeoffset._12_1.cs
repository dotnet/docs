      string dateString;
      DateTimeOffset offsetDate; 

      // String with date only
      dateString = "05/01/2008";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with time only
      dateString = "11:36 PM";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with date and offset 
      dateString = "05/01/2008 +1:00";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());

      // String with day abbreviation
      dateString = "Thu May 01, 2008";
      offsetDate = DateTimeOffset.Parse(dateString);
      Console.WriteLine(offsetDate.ToString());