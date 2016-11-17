var title = ".NET Primer";
var list = new List<string>();

using System.IO;

using (FileStream stream = GetFileStream(context))
{
    // Operations on the stream
}

int[] numbers = new int[42];
int number = numbers[42]; // Will throw an exception (indexes are 0-based)