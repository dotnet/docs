      Const minimumAge As Integer = 16
      Dim dateToday As DateTimeOffset = DateTimeOffset.Now
      Dim latestBirthday As DateTimeOffset = dateToday.AddYears(-1 * minimumAge)
      Console.WriteLine("To possess a driver's license, you must have been born on or before {0:d}.", _
                        latestBirthday)