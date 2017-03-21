      Dim values = [Enum].GetValues(GetType(ArrivalStatus))
      Console.WriteLine("Members of {0}:", GetType(ArrivalStatus).Name)
      For Each value In values
         Dim status As ArrivalStatus = CType([Enum].ToObject(GetType(ArrivalStatus), value),
                                             ArrivalStatus)
         Console.WriteLine("   {0} ({0:D})", status)
      Next                                       
      ' The example displays the following output:
      '       Members of ArrivalStatus:
      '          OnTime (0)
      '          Early (1)
      '          Unknown (-3)
      '          Late (-1)