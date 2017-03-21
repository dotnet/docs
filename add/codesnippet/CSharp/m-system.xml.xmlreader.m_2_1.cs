reader.ReadToFollowing("book");
reader.MoveToFirstAttribute();
string genre = reader.Value;
Console.WriteLine("The genre value: " + genre);