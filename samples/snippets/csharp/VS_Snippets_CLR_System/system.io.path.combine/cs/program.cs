using System;
using System.IO;

namespace combine
{
    class Program
    {
        static void Main(string[] args)
        {
// <Snippet1>
string p1 = @"d:\archives\";
string p2 = "media";
string p3 = "images";
string combined = Path.Combine(p1, p2, p3);
Console.WriteLine(combined);
// </Snippet1>

// <Snippet2>
string path1 = @"d:\archives\";
string path2 = "2001";
string path3 = "media";
string path4 = "images";
string combinedPath = Path.Combine(path1, path2, path3, path4);
Console.WriteLine(combinedPath);
 // </Snippet2>

// <Snippet3>
string[] paths = {@"d:\archives", "2001", "media", "images"};
string fullPath = Path.Combine(paths);
Console.WriteLine(fullPath);
// </Snippet3>

        }
    }
}
