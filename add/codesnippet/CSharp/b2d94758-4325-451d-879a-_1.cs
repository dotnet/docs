string path1 = @"d:\archives\";
string path2 = "2001";
string path3 = "media";
string path4 = "images";
string combinedPath = Path.Combine(path1, path2, path3, path4);
Console.WriteLine(combinedPath);