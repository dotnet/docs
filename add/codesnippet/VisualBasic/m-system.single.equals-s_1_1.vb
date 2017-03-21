      ' Initialize two singles with apparently identical values
      Dim single1 As Single = .33333
      Dim single2 As Object = 1/3
      ' Compare them for equality
      Console.WriteLine(single1.Equals(single2))    ' displays False