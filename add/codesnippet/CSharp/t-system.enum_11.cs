      string[] names = Enum.GetNames(typeof(ArrivalStatus));
      Console.WriteLine("Members of {0}:", typeof(ArrivalStatus).Name);
      Array.Sort(names);
      foreach (var name in names) {
         ArrivalStatus status = (ArrivalStatus) Enum.Parse(typeof(ArrivalStatus), name);
         Console.WriteLine("   {0} ({0:D})", status);
      }
      // The example displays the following output:
      //       Members of ArrivalStatus:
      //          Early (1)
      //          Late (-1)
      //          OnTime (0)
      //          Unknown (-3)      