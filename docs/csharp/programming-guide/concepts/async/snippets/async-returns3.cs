using System;
using System.Threading.Tasks;

public class NaiveButton
{
    public event EventHandler Clicked;

    public void Click()
    {
        Console.WriteLine("Somebody has clicked a button. Let's raise the event...");
        Clicked?.Invoke(this, EventArgs.Empty);
        Console.WriteLine("All listeners are notified.");
    }
}

public class AsyncVoidExample
{
    static TaskCompletionSource<bool> tcs;

    static async Task Main()
    {
        tcs = new TaskCompletionSource<bool>();
        var secondHandlerFinished = tcs.Task;

        var button = new NaiveButton();
        button.Clicked += Button_Clicked_1;
        button.Clicked += Button_Clicked_2_Async;
        button.Clicked += Button_Clicked_3;

        Console.WriteLine("About to click a button...");
        button.Click();
        Console.WriteLine("Button's Click method returned.");

        await secondHandlerFinished;
    }

    private static void Button_Clicked_1(object sender, EventArgs e)
    {
        Console.WriteLine("   Handler 1 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 1 is done.");
    }

    private static async void Button_Clicked_2_Async(object sender, EventArgs e)
    {
        Console.WriteLine("   Handler 2 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 2 is about to go async...");
        await Task.Delay(500);
        Console.WriteLine("   Handler 2 is done.");
        tcs.SetResult(true);
    }

    private static void Button_Clicked_3(object sender, EventArgs e)
    {
        Console.WriteLine("   Handler 3 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 3 is done.");
    }
}

// Expected output:
// About to click a button...
// Somebody has clicked a button. Let's raise the event...
//    Handler 1 is starting...
//    Handler 1 is done.
//    Handler 2 is starting...
//    Handler 2 is about to go async...
//    Handler 3 is starting...
//    Handler 3 is done.
// All listeners are notified.
// Button's Click method returned.
//    Handler 2 is done.
