using System.IO;

class Example3
{
    static void Main()
    {
        var fi = new FileInfo(@".\test.txt");
        fi.MoveTo(@".\Test.txt");
    }
}
