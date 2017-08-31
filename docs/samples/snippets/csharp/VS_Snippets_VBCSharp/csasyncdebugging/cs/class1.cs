// Walkthrough: Using the Debugger with Async Methods
// 5adb2531-3f09-4b7e-8baa-29de80abee6e

using System.Threading.Tasks;

namespace AsyncDebuggingCS
{
    class Class1
    {
        private async void Other()
        {
            //<Snippet2>
            var theTask = DoSomethingAsync();
            var result = await theTask;
            //</Snippet2>
        }

        static async Task<int> DoSomethingAsync()
        {
            await Task.Delay(1000);
            return 5;
        }

    }
}
