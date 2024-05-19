' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      CompareUsingEquals()
      Console.WriteLine()
      CompareApproximateValues()
      Console.WriteLine()
      CompareObjectsUsingEquals()
      Console.WriteLine()
      CompareApproximateObjectValues()
   End Sub
      
   Private Sub CompareUsingEquals()
      ' <Snippet1>
      ' Initialize two singles with apparently identical values
      Dim single1 As Single = .33333
      Dim single2 As Single = 1/3
      ' Compare them for equality
      Console.WriteLine(single1.Equals(single2))    ' displays False
      ' </Snippet1>   
   End Sub
   
   Private Sub CompareApproximateValues()
      ' <Snippet2> 
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
      ' </Snippet2>
   End Sub
   
   Private Sub CompareObjectsUsingEquals()
      ' <Snippet3>
      ' Initialize two singles with apparently identical values
      Dim single1 As Single = .33333
      Dim single2 As Object = 1/3
      ' Compare them for equality
      Console.WriteLine(single1.Equals(single2))    ' displays False
      ' </Snippet3>   
   End Sub
   
   Private Sub CompareApproximateObjectValues()
      ' <Snippet4> 
      ' Initialize two singles with apparently identical values
      Dim single1 As Single = .33333
      Dim single2 As Object = 1/3
      ' Define the tolerance for variation in their values
      Dim difference As Single = Math.Abs(single1 * .0001f)
      
      ' Compare the values
      ' The output to the console indicates that the two values are equal
      If Math.Abs(single1 - CSng(single2)) <= difference Then
         Console.WriteLine("single1 and single2 are equal.")
      Else
         Console.WriteLine("single1 and single2 are unequal.")
      End If
      ' </Snippet4>
   End Sub
End Module

