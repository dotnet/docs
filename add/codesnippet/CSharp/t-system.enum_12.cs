      var values = Enum.GetValues(typeof(ArrivalStatus));
      Console.WriteLine("Members of {0}:", typeof(ArrivalStatus).Name);
      foreach (var value in values) {
         ArrivalStatus status = (ArrivalStatus) Enum.ToObject(typeof(ArrivalStatus), value);
         Console.WriteLine("   {0} ({0:D})", status);
      }                                       
      // The example displays the following output:
      //       Members of ArrivalStatus:
      //          OnTime (0)
      //          Early (1)
      //          Unknown (-3)
      //          Late (-1)