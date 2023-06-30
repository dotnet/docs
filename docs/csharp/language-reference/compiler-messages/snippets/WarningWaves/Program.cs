// See https://aka.ms/new-console-template for more information

namespace WarningWaves;

public static class Program
{
    // <MultipleEntryPoints>
    public static void Main()
    {
        RunProgram();
    }

    // CS8892
    public static async Task Main(string[] args)
    {
        await RunProgramAsync();
    }
    // </MultipleEntryPoints>

    private static void RunProgram()
    {
        WaveFive.Examples();
    }

    private static async Task RunProgramAsync()
    {
        RunProgram();
        await Task.Yield();
    }
}

