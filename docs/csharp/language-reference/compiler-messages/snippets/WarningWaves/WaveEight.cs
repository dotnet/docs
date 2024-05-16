namespace WarningWaves;

public class ProgramEight
{
    // <NoAmpersand>
    public static async Task LogValue()
    {
        int x = 1;
        unsafe {
            int* y = &x;
            Console.WriteLine(*y);
        }
        await Task.Delay(1000);
    }
    // </NoAmpersand>
}