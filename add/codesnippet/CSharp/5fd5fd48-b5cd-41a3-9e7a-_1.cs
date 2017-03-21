      // Create TimeSpan and Validator.
      TimeSpan testTimeSpan = new TimeSpan(0,1,05);
      TimeSpan minTimeSpan = new TimeSpan(0,1,0);
      TimeSpan maxTimeSpan = new TimeSpan(0,1,10);
      TimeSpanValidator myTimeSpanValidator = new TimeSpanValidator(minTimeSpan, maxTimeSpan, false, 65);