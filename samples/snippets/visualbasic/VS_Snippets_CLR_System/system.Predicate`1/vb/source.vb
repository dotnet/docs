'REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Drawing

Public Class Example

    Public Shared Sub Main()

        ' Create an array of five Point structures.
        Dim points() As Point = { new Point(100, 200), _
            new Point(150, 250), new Point(250, 375), _
            new Point(275, 395), new Point(295, 450) }

        ' To find the first Point structure for which X times Y 
        ' is greater than 100000, pass the array and a delegate 
        ' that represents the ProductGT10 method to the Shared
        ' Find method of the Array class.
        Dim first As Point = Array.Find(points, _
            AddressOf ProductGT10)

        ' Note that you do not need to create the delegate 
        ' explicitly, or to specify the type parameter of the 
        ' generic method, because the compiler has enough
        ' context to determine that information for you.

        ' Display the first structure found.
        Console.WriteLine("Found: X = {0}, Y = {1}", _
            first.X, first.Y)
    End Sub

    ' This method implements the test condition for the Find
    ' method.
    Private Shared Function ProductGT10(ByVal p As Point) As Boolean
        If p.X * p.Y > 100000 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

' This code example produces the following output:
'
'Found: X = 275, Y = 395
'</Snippet1>