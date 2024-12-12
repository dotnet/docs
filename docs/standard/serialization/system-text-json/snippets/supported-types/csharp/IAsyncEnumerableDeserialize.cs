using System.Text;
using System.Text.Json;

namespace IAsyncEnumerableDeserialize;

public class Program
{
    public static async Task Main()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
        await foreach (int item in JsonSerializer.DeserializeAsyncEnumerable<int>(stream))
        {
            Console.WriteLine(item);
        }
    }
}
// output:
//0
//1
//2
//3
//4
