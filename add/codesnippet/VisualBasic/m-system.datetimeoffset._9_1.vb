      Dim quarterDate As New DateTimeOffset(#01/01/2007#, DateTimeOffset.Now.Offset)
      For ctr As Integer = 1 To 4
         Console.WriteLine("Quarter {0}: {1:MMMM d}", ctr, quarterDate)
         quarterDate = quarterDate.AddMonths(3)
      Next   
      ' This example produces the following output:
      '       Quarter 1: January 1
      '       Quarter 2: April 1
      '       Quarter 3: July 1
      '       Quarter 4: October 1      