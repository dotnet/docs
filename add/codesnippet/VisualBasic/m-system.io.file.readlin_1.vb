For Each line As String In File.ReadLines("d:\data\episodes.txt")
    If line.Contains("episode") And line.Contains("2006") Then
        Console.WriteLine(line)
    End If
Next line