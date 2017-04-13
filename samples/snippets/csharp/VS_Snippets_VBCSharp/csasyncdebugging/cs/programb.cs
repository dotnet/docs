// Walkthrough: Using the Debugger with Async Methods
// 5adb2531-3f09-4b7e-8baa-29de80abee6e

//<Snippet3>
// Step Into and Step Over Example.
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        ProcessAsync().Wait();
    }

    static async Task ProcessAsync()
    {
        var result = await DoSomethingAsync();  // Step Into or Step Over from here

        int y = 0;
    }

    static async Task<int> DoSomethingAsync()
    {
        await Task.Delay(1000);
        return 5;
    }
}
//</Snippet3>

