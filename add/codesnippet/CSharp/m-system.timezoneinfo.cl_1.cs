      TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
      TimeZoneInfo local = TimeZoneInfo.Local;
      Console.WriteLine(TimeZoneInfo.ConvertTime(DateTime.Now, local, cst));

      TimeZoneInfo.ClearCachedData();
      try
      {
         Console.WriteLine(TimeZoneInfo.ConvertTime(DateTime.Now, local, cst));
      }
      catch (ArgumentException e)
      {
         Console.WriteLine(e.GetType().Name + "\n   " + e.Message);
      }      