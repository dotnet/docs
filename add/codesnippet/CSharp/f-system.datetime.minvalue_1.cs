      // Define an uninitialized date.
      DateTime date1 = new DateTime();
      Console.Write(date1);
      if (date1.Equals(DateTime.MinValue))
         Console.WriteLine("  (Equals Date.MinValue)");
      // The example displays the following output:
      //    1/1/0001 12:00:00 AM  (Equals Date.MinValue)