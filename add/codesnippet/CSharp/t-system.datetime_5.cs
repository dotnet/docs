      DateTime dat1 = new DateTime();
      // The following method call displays 1/1/0001 12:00:00 AM.
      Console.WriteLine(dat1.ToString(System.Globalization.CultureInfo.InvariantCulture));
      // The following method call displays True.
      Console.WriteLine(dat1.Equals(DateTime.MinValue));