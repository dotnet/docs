      ' Initialize two doubles with apparently identical values
      Dim double1 As Double = .33333
      Dim double2 As Double = 1/3
      ' Define the tolerance for variation in their values
      Dim difference As Double = Math.Abs(double1 * .00001)
      
      ' Compare the values
      ' The output to the console indicates that the two values are equal
      If Math.Abs(double1 - double2) <= difference Then
         Console.WriteLine("double1 and double2 are equal.")
      Else
         Console.WriteLine("double1 and double2 are unequal.")
      End If