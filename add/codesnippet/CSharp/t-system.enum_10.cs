      string[] formats= { "G", "F", "D", "X"};
      ArrivalStatus status = ArrivalStatus.Late;
      foreach (var fmt in formats)
         Console.WriteLine(status.ToString(fmt));

      // The example displays the following output:
      //       Late
      //       Late
      //       -1
      //       FFFFFFFF