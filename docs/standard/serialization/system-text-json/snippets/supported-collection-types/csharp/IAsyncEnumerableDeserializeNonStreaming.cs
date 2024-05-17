using System.Text;
using System.Text.Json;

namespace IAsyncEnumerableDeserializeNonStreaming;

public class MyPoco
{
    public IAsyncEnumerable<int>? Data { get; set; }
}

public class Program
{
    public static async Task Main()
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"{""Data"":[0,1,2,3,4]}"));
        MyPoco? result = await JsonSerializer.DeserializeAsync<MyPoco>(stream)!;
        await foreach (int item in result!.Data!)
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
