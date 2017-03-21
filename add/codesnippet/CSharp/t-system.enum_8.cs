      ArrivalStatus status = ArrivalStatus.Early;
      var number = Convert.ChangeType(status, Enum.GetUnderlyingType(typeof(ArrivalStatus)));
      Console.WriteLine("Converted {0} to {1}", status, number);
      // The example displays the following output:
      //       Converted Early to 1