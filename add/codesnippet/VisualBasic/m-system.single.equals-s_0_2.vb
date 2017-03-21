      ' Initialize two singles with apparently identical values
      Dim single1 As Single = .33333
      Dim single2 As Single = 1/3
      ' Define the tolerance for variation in their values
      Dim difference As Single = Math.Abs(single1 * .0001f)
      
      ' Compare the values
      ' The output to the console indicates that the two values are equal
      If Math.Abs(single1 - single2) <= difference Then
         Console.WriteLine("single1 and single2 are equal.")
      Else
         Console.WriteLine("single1 and single2 are unequal.")
      End If