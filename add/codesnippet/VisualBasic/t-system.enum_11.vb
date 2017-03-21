      Dim names() As String = [Enum].GetNames(GetType(ArrivalStatus))
      Console.WriteLine("Members of {0}:", GetType(ArrivalStatus).Name)
      Array.Sort(names)
      For Each name In names
         Dim status As ArrivalStatus = CType([Enum].Parse(GetType(ArrivalStatus), name),
                                       ArrivalStatus)
         Console.WriteLine("   {0} ({0:D})", status)
      Next
      ' The example displays the following output:
      '       Members of ArrivalStatus:
      '          Early (1)
      '          Late (-1)
      '          OnTime (0)
      '          Unknown (-3)      