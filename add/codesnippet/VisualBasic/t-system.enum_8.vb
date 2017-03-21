      Dim status As ArrivalStatus = ArrivalStatus.Early
      Dim number = Convert.ChangeType(status, [Enum].GetUnderlyingType(GetType(ArrivalStatus)))
      Console.WriteLine("Converted {0} to {1}", status, number)
      ' The example displays the following output:
      '       Converted Early to 1