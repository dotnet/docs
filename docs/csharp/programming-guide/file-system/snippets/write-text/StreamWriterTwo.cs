using System.IO;
using System.Threading.Tasks;

class StreamWriterTwo
{
    public static async Task ExampleAsync()
    {
        using StreamWriter file = new(@"WriteLines2.txt", true);
        await file.WriteLineAsync("Fourth line");
    }
}
