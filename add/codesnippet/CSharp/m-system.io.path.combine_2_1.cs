string p1 = @"d:\archives\";
string p2 = "media";
string p3 = "images";
string combined = Path.Combine(p1, p2, p3);
Console.WriteLine(combined);