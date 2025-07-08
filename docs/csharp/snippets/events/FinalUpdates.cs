
namespace FinalUpdates;

// <StructEventArgs>
internal struct SearchDirectoryArgs
{
    internal string CurrentSearchDirectory { get; }
    internal int TotalDirs { get; }
    internal int CompletedDirs { get; }

    internal SearchDirectoryArgs(string dir, int totalDirs, int completedDirs) : this()
    {
        CurrentSearchDirectory = dir;
        TotalDirs = totalDirs;
        CompletedDirs = completedDirs;
    }
}
// </StructEventArgs>

public class W
{
    public event EventHandler StartWorking = null!;
}

public class Unused
{
    private static void Example()
    {
        var worker = new W();

        // <AsyncEvent>
        worker.StartWorking += async (sender, eventArgs) =>
        {
            try
            {
                await DoWorkAsync();
            }
            catch (Exception e)
            {
                //Some form of logging.
                Console.WriteLine($"Async task failure: {e.ToString()}");
                // Consider gracefully, and quickly exiting.
            }
        };
        // </AsyncEvent>

    }

    private static async Task DoWorkAsync() => await Task.Yield();

}
