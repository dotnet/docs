' <Snippet2>
Imports System.Drawing

Public Module Example
   Public Sub Main()
      ' Create an array of five Point structures.
      Dim points() As Point = { new Point(100, 200), _
            new Point(150, 250), new Point(250, 375), _
            new Point(275, 395), new Point(295, 450) }

      ' Find the first Point structure for which X times Y 
      ' is greater than 100000. 
      Dim first As Point = Array.Find(points, 
                                      Function(p) p.X * p.Y > 100000)

      ' Display the first structure found.
      Console.WriteLine("Found: X = {0}, Y = {1}", _
            first.X, first.Y)
   End Sub
End Module
' The example displays the following output:
'       Found: X = 275, Y = 395
' </Snippet2>
