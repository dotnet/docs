using System.Threading.Tasks;

namespace AsyncExamples
{
    public static class Program
    {
        static async Task Main()
        {
            await FirstExample.ShowTodaysInfo();
            await SecondExample.ShowTodaysInfo();
            await ExampleTask.DisplayCurrentInfo();
            await AwaitTaskExample.DisplayCurrentInfo();
            await AsyncVoidExample.Main();
            await AsyncStreamExample.Examples();
        }
    }
}
