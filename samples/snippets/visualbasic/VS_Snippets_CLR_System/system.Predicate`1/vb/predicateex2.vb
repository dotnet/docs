' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Drawing

Public Class Example
   Public Shared Sub Main()

      ' Create an array of Point structures. 
      Dim points() As Point = { new Point(100, 200), new Point(150, 250), 
                                new Point(250, 375), new Point(275, 395), 
                                new Point(295, 450) }
      
      ' Define the Predicate(Of T) delegate.
      Dim predicate As Predicate(Of Point) = AddressOf Example.FindPoints
      
      ' Find the first Point structure for which X times Y  
      ' is greater than 100000. 
      Dim first As Point = Array.Find(points, predicate)

      ' Display the first structure found.
      Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y)
   End Sub 
   
   Private Shared Function FindPoints(obj As Point) As Boolean
      Return obj.X * obj.Y > 100000
   End Function

End Class 
' The example displays the following output:
'       Found: X = 275, Y = 395
' </Snippet4>
