namespace AsyncExamples
{
    public static class Program
    {
        static async Task Main()
        {
            await FirstExample.ShowTodaysInfoAsync();
            await SecondExample.ShowTodaysInfoAsync();
            await ExampleTask.DisplayCurrentInfoAsync();
            await AwaitTaskExample.DisplayCurrentInfoAsync();
            await AsyncVoidExample.MultipleEventHandlersAsync();
            await AsyncStreamExample.ReadWordsAsync();
        }
    }
}
