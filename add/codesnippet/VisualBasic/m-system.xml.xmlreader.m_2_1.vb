reader.ReadToFollowing("book")
reader.MoveToFirstAttribute()
Dim genre As String = reader.Value
Console.WriteLine("The genre value: " + genre)