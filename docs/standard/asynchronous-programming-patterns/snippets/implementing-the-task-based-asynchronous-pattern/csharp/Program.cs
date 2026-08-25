using System.Drawing;

// <ManualTapImplementation>
static class StreamExtensions
{
    public static Task<int> ReadTask(this Stream stream, byte[] buffer, int offset, int count, object? state)
    {
        var tcs = new TaskCompletionSource<int>();
        stream.BeginRead(buffer, offset, count, ar =>
        {
            try { tcs.SetResult(stream.EndRead(ar)); }
            catch (Exception exc) { tcs.SetException(exc); }
        }, state);
        return tcs.Task;
    }
}
// </ManualTapImplementation>

// <HybridApproach>
class Calculator
{
    private int value = 0;

    public Task<int> MethodAsync(string input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        return MethodAsyncInternal(input);
    }

    private async Task<int> MethodAsyncInternal(string input)
    {
        // code that uses await goes here
        await Task.Delay(1);
        return value;
    }
}
// </HybridApproach>

internal class ImageData
{
    public int Width { get; set; } = 1;
    public int Height { get; set; } = 1;
}

static class ImageRenderer
{
    // <ComputeBoundTask>
    internal static Task<Bitmap> RenderAsync(ImageData data, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var bmp = new Bitmap(data.Width, data.Height);
            for (int y = 0; y < data.Height; y++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                for (int x = 0; x < data.Width; x++)
                {
                    // render pixel [x,y] into bmp
                }
            }
            return bmp;
        }, cancellationToken);
    }
    // </ComputeBoundTask>

    // <MixedBoundTask>
    public static async Task<Bitmap> DownloadDataAndRenderImageAsync(CancellationToken cancellationToken)
    {
        var imageData = await DownloadImageDataAsync(cancellationToken);
        return await RenderAsync(imageData, cancellationToken);
    }
    // </MixedBoundTask>

    private static Task<ImageData> DownloadImageDataAsync(CancellationToken ct)
    {
        return Task.FromResult(new ImageData());
    }
}

static class TimerExamples
{
    // <DelayWithTimer>
    public static Task<DateTimeOffset> Delay(int millisecondsTimeout)
    {
        TaskCompletionSource<DateTimeOffset>? tcs = null;
        Timer? timer = null;

        timer = new Timer(delegate
        {
            timer!.Dispose();
            tcs!.TrySetResult(DateTimeOffset.UtcNow);
        }, null, Timeout.Infinite, Timeout.Infinite);

        tcs = new TaskCompletionSource<DateTimeOffset>(timer);
        timer.Change(millisecondsTimeout, Timeout.Infinite);
        return tcs.Task;
    }
    // </DelayWithTimer>

    // <DelayBoolResult>
    public static Task<bool> DelaySimple(int millisecondsTimeout)
    {
        TaskCompletionSource<bool>? tcs = null;
        Timer? timer = null;

        timer = new Timer(delegate
        {
            timer!.Dispose();
            tcs!.TrySetResult(true);
        }, null, Timeout.Infinite, Timeout.Infinite);

        tcs = new TaskCompletionSource<bool>(timer);
        timer.Change(millisecondsTimeout, Timeout.Infinite);
        return tcs.Task;
    }
    // </DelayBoolResult>

    // <PollingLoop>
    public static async Task Poll(Uri url, CancellationToken cancellationToken, IProgress<bool> progress)
    {
        while (true)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            bool success = false;
            try
            {
                await DownloadStringAsync(url);
                success = true;
            }
            catch { /* ignore errors */ }
            progress.Report(success);
        }
    }
    // </PollingLoop>

    private static Task<string> DownloadStringAsync(Uri url) => Task.FromResult(string.Empty);
}

static class Program
{
    static async Task Main()
    {
        var bmp = await ImageRenderer.DownloadDataAndRenderImageAsync(CancellationToken.None);
        Console.WriteLine($"Rendered {bmp.Width}x{bmp.Height} image.");
    }
}
