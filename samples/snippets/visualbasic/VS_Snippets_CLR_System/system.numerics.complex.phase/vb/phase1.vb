' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c1 As Complex = Complex.FromPolarCoordinates(10, 45 * Math.Pi / 180)
      Console.WriteLine("{0}:", c1)
      Console.WriteLine("   Magnitude: {0}", Complex.Abs(c1))
      Console.WriteLine("   Phase:     {0} radians", c1.Phase)
      Console.WriteLine("   Phase      {0} degrees", c1.Phase * 180/Math.Pi)
      Console.WriteLine("   Atan(b/a): {0}", Math.Atan(c1.Imaginary/c1.Real))
   End Sub
End Module
' The example displays the following output:
'       (7.07106781186548, 7.07106781186547):
'          Magnitude: 10
'          Phase:     0.785398163397448 radians
'          Phase      45 degrees
'          Atan(b/a): 0.785398163397448
' </Snippet1>
