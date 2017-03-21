      const int minimumAge = 16;
      DateTimeOffset dateToday = DateTimeOffset.Now;
      DateTimeOffset latestBirthday = dateToday.AddYears(-1 * minimumAge);
      Console.WriteLine("To possess a driver's license, you must have been born on or before {0:d}.", 
                        latestBirthday);