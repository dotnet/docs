'<snippet1>
' This example demonstrates Math.Atan()
'                           Math.Atan2()
'                           Math.Tan()
Imports System

Class Sample
   Public Shared Sub Main()
      Dim x As Double = 1.0
      Dim y As Double = 2.0
      Dim angle As Double
      Dim radians As Double
      Dim result As Double
      
      ' Calculate the tangent of 30 degrees.
      angle = 30
      radians = angle *(Math.PI / 180)
      result = Math.Tan(radians)
      Console.WriteLine("The tangent of 30 degrees is {0}.", result)
      
      ' Calculate the arctangent of the previous tangent.
      radians = Math.Atan(result)
      angle = radians *(180 / Math.PI)
      Console.WriteLine("The previous tangent is equivalent to {0} degrees.", angle)
      
      ' Calculate the arctangent of an angle.
      Dim line1 As [String] = "{0}The arctangent of the angle formed by the x-axis and "
      Dim line2 As [String] = "a vector to point ({0},{1}) is {2}, "
      Dim line3 As [String] = "which is equivalent to {0} degrees."
      
      radians = Math.Atan2(y, x)
      angle = radians *(180 / Math.PI)
      
      Console.WriteLine(line1, Environment.NewLine)
      Console.WriteLine(line2, x, y, radians)
      Console.WriteLine(line3, angle)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'The tangent of 30 degrees is 0.577350269189626.
'The previous tangent is equivalent to 30 degrees.
'
'The arctangent of the angle formed by the x-axis and
'a vector to point (1,2) is 1.10714871779409,
'which is equivalent to 63.434948822922 degrees.
'
'</snippet1>