Dim p1 As String = "d:\archives\"
Dim p2 As String = "media"
Dim p3 As String = "images"
Dim combined As String = Path.Combine(p1, p2, p3)
Console.WriteLine(combined)