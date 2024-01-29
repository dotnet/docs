' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      CompareUsingEquals()
      Console.WRiteLine()
      CompareApproximateValues()
      Console.WriteLIne()
      CompareObjectsUsingEquals()
      Console.WRiteLine()
      CompareApproximateObjectValues()
      Console.WriteLIne()
   End Sub
      
   Private Sub CompareUsingEquals()
      ' <Snippet1>
      ' Initialize two doubles with apparently identical values
      Dim double1 As Double = .33333
      Dim double2 As Double = 1/3
      ' Compare them for equality
      Console.WriteLine(double1.Equals(double2))    ' displays False
      ' </Snippet1>   
   End Sub
   
   Private Sub CompareApproximateValues()
      ' <Snippet2> 
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
      ' </Snippet2>
   End Sub

   Private Sub CompareObjectsUsingEquals()
      ' <Snippet3>
      ' Initialize two doubles with apparently identical values
      Dim double1 As Double = .33333
      Dim double2 As Object = 1/3
      ' Compare them for equality
      Console.WriteLine(double1.Equals(double2))    ' displays False
      ' </Snippet3>   
   End Sub
   
   Private Sub CompareApproximateObjectValues()
      ' <Snippet4> 
      ' Initialize two doubles with apparently identical values
      Dim double1 As Double = .33333
      Dim double2 As Object = 1/3
      ' Define the tolerance for variation in their values
      Dim difference As Double = Math.Abs(double1 * .0001)
      
      ' Compare the values
      ' The output to the console indicates that the two values are equal
      If Math.Abs(double1 - CDbl(double2)) <= difference Then
         Console.WriteLine("double1 and double2 are equal.")
      Else
         Console.WriteLine("double1 and double2 are unequal.")
      End If
      ' </Snippet4>
   End Sub
End Module

