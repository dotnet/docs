namespace main_arguments;

// <AsyncMain>
class Program
{
    static async Task<int> Main(string[] args)
    {
        return await AsyncConsoleWork();
    }

    private static async Task<int> AsyncConsoleWork()
    {
        // main body here 
        return 0;
    }
}
// </AsyncMain>
