using System.Collections.Concurrent;
using System.Drawing;
using System.Net;
using System.Threading.Tasks.Dataflow;

// Stub types/methods used throughout examples
static class Stubs
{
    public static Task<string> DownloadStringTaskAsync(string url, CancellationToken ct = default) => Task.FromResult("");
    public static Task<byte[]> DownloadDataAsync(string url, CancellationToken ct = default) => Task.FromResult(Array.Empty<byte>());
    public static Task SaveToDiskAsync(string path, byte[] data, CancellationToken ct) => Task.CompletedTask;
    public static Task SendMailAsync(string addr, CancellationToken ct = default) => Task.CompletedTask;
    public static Task<bool> GetBuyRecommendation1Async(string symbol, CancellationToken ct = default) => Task.FromResult(true);
    public static Task<bool> GetBuyRecommendation2Async(string symbol, CancellationToken ct = default) => Task.FromResult(true);
    public static Task<bool> GetBuyRecommendation3Async(string symbol, CancellationToken ct = default) => Task.FromResult(true);
    public static Task<double> GetCurrentPriceFromServer1Async(string symbol, CancellationToken ct) => Task.FromResult(100.0);
    public static Task<double> GetCurrentPriceFromServer2Async(string symbol, CancellationToken ct) => Task.FromResult(100.0);
    public static Task<double> GetCurrentPriceFromServer3Async(string symbol, CancellationToken ct) => Task.FromResult(100.0);
    public static Task<Bitmap> GetBitmapAsync(string url, CancellationToken ct = default) => Task.FromResult(new Bitmap(1, 1));
    public static Bitmap ConvertImage(Bitmap bmp) => bmp;
    public static Bitmap Mashup(Bitmap b1, Bitmap b2) => b1;
    public static Task<Bitmap> DownloadFirstImageAsync() => Task.FromResult(new Bitmap(1, 1));
    public static Task<Bitmap> DownloadSecondImageAsync() => Task.FromResult(new Bitmap(1, 1));
    public static void BuyStock(string symbol) { }
    public static void Log(object? o) { }
    public static void ProcessNextItem(int item) { }
    public static bool TryGetCachedValue(out int value) { value = 0; return false; }
    public static string[] addrs = Array.Empty<string>();
    public static string[] urls = Array.Empty<string>();
}

static class Examples
{
    // ---- Yield example ----
    // <YieldLoop>
    public static async Task YieldLoopExample()
    {
        await Task.Run(async delegate
        {
            for (int i = 0; i < 1000000; i++)
            {
                await Task.Yield(); // fork the continuation into a separate work item
            }
        });
    }
    // </YieldLoop>

    // ---- Task.Run examples ----
    // <TaskRunBasic>
    public static async Task TaskRunBasicExample()
    {
        int answer = 42;
        string result = await Task.Run(() =>
        {
            // … do compute-bound work here
            return answer.ToString();
        });
        Console.WriteLine(result);
    }
    // </TaskRunBasic>

    // <TaskRunAsync>
    public static async Task TaskRunAsyncExample()
    {
        Bitmap image = await Task.Run(async () =>
        {
            using Bitmap bmp1 = await Stubs.DownloadFirstImageAsync();
            using Bitmap bmp2 = await Stubs.DownloadSecondImageAsync();
            return Stubs.Mashup(bmp1, bmp2);
        });
    }
    // </TaskRunAsync>

    // ---- Task.FromResult ----
    // <TaskFromResult>
    public static Task<int> GetValueAsync(string key)
    {
        int cachedValue;
        return Stubs.TryGetCachedValue(out cachedValue) ?
            Task.FromResult(cachedValue) :
            GetValueAsyncInternal(key);
    }

    static async Task<int> GetValueAsyncInternal(string key)
    {
        await Task.Delay(1);
        return 0;
    }
    // </TaskFromResult>

    // ---- Task.WhenAll ----
    // <WhenAllBasic>
    public static async Task WhenAllBasic()
    {
        IEnumerable<Task> asyncOps = from addr in Stubs.addrs select Stubs.SendMailAsync(addr);
        await Task.WhenAll(asyncOps);
    }
    // </WhenAllBasic>

    // <WhenAllWithCatch>
    public static async Task WhenAllWithCatch()
    {
        IEnumerable<Task> asyncOps = from addr in Stubs.addrs select Stubs.SendMailAsync(addr);
        try
        {
            await Task.WhenAll(asyncOps);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
        }
    }
    // </WhenAllWithCatch>

    // <WhenAllExamineExceptions>
    public static async Task WhenAllExamineExceptions()
    {
        Task[] asyncOps = (from addr in Stubs.addrs select Stubs.SendMailAsync(addr)).ToArray();
        try
        {
            await Task.WhenAll(asyncOps);
        }
        catch (Exception exc)
        {
            foreach (Task faulted in asyncOps.Where(t => t.IsFaulted))
            {
                Console.WriteLine($"Faulted: {faulted.Exception}");
            }
        }
    }
    // </WhenAllExamineExceptions>

    // <WhenAllDownloadPages>
    public static async Task WhenAllDownloadPages()
    {
        string[] pages = await Task.WhenAll(
            from url in Stubs.urls select Stubs.DownloadStringTaskAsync(url));
        Console.WriteLine(pages.Length);
    }
    // </WhenAllDownloadPages>

    // <WhenAllDownloadPagesExceptions>
    public static async Task WhenAllDownloadPagesExceptions()
    {
        Task<string>[] asyncOps =
            (from url in Stubs.urls select Stubs.DownloadStringTaskAsync(url)).ToArray();
        try
        {
            string[] pages = await Task.WhenAll(asyncOps);
            Console.WriteLine(pages.Length);
        }
        catch (Exception exc)
        {
            foreach (Task<string> faulted in asyncOps.Where(t => t.IsFaulted))
            {
                Console.WriteLine($"Faulted: {faulted.Exception}");
            }
        }
    }
    // </WhenAllDownloadPagesExceptions>

    // ---- Task.WhenAny ----
    // <WhenAnyRedundancy>
    public static async Task WhenAnyRedundancy(string symbol)
    {
        var recommendations = new List<Task<bool>>()
        {
            Stubs.GetBuyRecommendation1Async(symbol),
            Stubs.GetBuyRecommendation2Async(symbol),
            Stubs.GetBuyRecommendation3Async(symbol)
        };
        Task<bool> recommendation = await Task.WhenAny(recommendations);
        if (await recommendation) Stubs.BuyStock(symbol);
    }
    // </WhenAnyRedundancy>

    // <WhenAnyRetryOnException>
    public static async Task WhenAnyRetryOnException(string symbol)
    {
        Task<bool>[] allRecommendations = new Task<bool>[]
        {
            Stubs.GetBuyRecommendation1Async(symbol),
            Stubs.GetBuyRecommendation2Async(symbol),
            Stubs.GetBuyRecommendation3Async(symbol)
        };
        var remaining = allRecommendations.ToList();
        while (remaining.Count > 0)
        {
            Task<bool> recommendation = await Task.WhenAny(remaining);
            try
            {
                if (await recommendation) Stubs.BuyStock(symbol);
                break;
            }
            catch (WebException)
            {
                remaining.Remove(recommendation);
            }
        }
    }
    // </WhenAnyRetryOnException>

    // <WhenAnyCancelRemainder>
    public static async Task WhenAnyCancelRemainder(string symbol)
    {
        var cts = new CancellationTokenSource();
        var recommendations = new List<Task<bool>>()
        {
            Stubs.GetBuyRecommendation1Async(symbol, cts.Token),
            Stubs.GetBuyRecommendation2Async(symbol, cts.Token),
            Stubs.GetBuyRecommendation3Async(symbol, cts.Token)
        };

        Task<bool> recommendation = await Task.WhenAny(recommendations);
        cts.Cancel();
        if (await recommendation) Stubs.BuyStock(symbol);
    }
    // </WhenAnyCancelRemainder>

    // <WhenAnyInterleaving>
    public static async Task WhenAnyInterleaving(string[] imageUrls)
    {
        List<Task<Bitmap>> imageTasks =
            (from imageUrl in imageUrls select Stubs.GetBitmapAsync(imageUrl)).ToList();
        while (imageTasks.Count > 0)
        {
            try
            {
                Task<Bitmap> imageTask = await Task.WhenAny(imageTasks);
                imageTasks.Remove(imageTask);

                Bitmap image = await imageTask;
                Console.WriteLine($"Got image: {image.Width}x{image.Height}");
            }
            catch { }
        }
    }
    // </WhenAnyInterleaving>

    // <WhenAnyInterleavingWithProcessing>
    public static async Task WhenAnyInterleavingWithProcessing(string[] imageUrls)
    {
        List<Task<Bitmap>> imageTasks =
            (from imageUrl in imageUrls
             select Stubs.GetBitmapAsync(imageUrl)
                 .ContinueWith(t => Stubs.ConvertImage(t.Result))).ToList();
        while (imageTasks.Count > 0)
        {
            try
            {
                Task<Bitmap> imageTask = await Task.WhenAny(imageTasks);
                imageTasks.Remove(imageTask);

                Bitmap image = await imageTask;
                Console.WriteLine($"Got image: {image.Width}x{image.Height}");
            }
            catch { }
        }
    }
    // </WhenAnyInterleavingWithProcessing>

    // <WhenAnyThrottling>
    public static async Task WhenAnyThrottling(Uri[] uriList)
    {
        const int CONCURRENCY_LEVEL = 15;
        int nextIndex = 0;
        var imageTasks = new List<Task<Bitmap>>();
        while (nextIndex < CONCURRENCY_LEVEL && nextIndex < uriList.Length)
        {
            imageTasks.Add(Stubs.GetBitmapAsync(uriList[nextIndex].ToString()));
            nextIndex++;
        }

        while (imageTasks.Count > 0)
        {
            try
            {
                Task<Bitmap> imageTask = await Task.WhenAny(imageTasks);
                imageTasks.Remove(imageTask);

                Bitmap image = await imageTask;
                Console.WriteLine($"Got image: {image.Width}x{image.Height}");
            }
            catch (Exception exc) { Stubs.Log(exc); }

            if (nextIndex < uriList.Length)
            {
                imageTasks.Add(Stubs.GetBitmapAsync(uriList[nextIndex].ToString()));
                nextIndex++;
            }
        }
    }
    // </WhenAnyThrottling>

    // <EarlyBailout>
    public static async Task<Task> UntilCompletionOrCancellation(
        Task asyncOp, CancellationToken ct)
    {
        var tcs = new TaskCompletionSource<bool>();
        using (ct.Register(() => tcs.TrySetResult(true)))
            await Task.WhenAny(asyncOp, tcs.Task);
        return asyncOp;
    }
    // </EarlyBailout>

    // ---- LogCompletionIfFailed ----
    // <LogCompletionIfFailed>
    private static async void LogCompletionIfFailed(IEnumerable<Task> tasks)
    {
        foreach (var task in tasks)
        {
            try { await task; }
            catch (Exception exc) { Stubs.Log(exc); }
        }
    }
    // </LogCompletionIfFailed>

    // <DelayTimeout>
    public static async Task<Bitmap?> DownloadWithTimeout(string url)
    {
        Task<Bitmap> download = Stubs.GetBitmapAsync(url);
        if (download == await Task.WhenAny(download, Task.Delay(3000)))
        {
            return await download;
        }
        else
        {
            var ignored = download.ContinueWith(
                t => Trace($"Task finally completed: {t.Status}"));
            return null;
        }
    }

    static void Trace(string message) => Console.WriteLine(message);
    // </DelayTimeout>

    // <DelayTimeoutMultiple>
    public static async Task<Bitmap[]?> DownloadMultipleWithTimeout(string[] imageUrls)
    {
        Task<Bitmap[]> downloads =
            Task.WhenAll(from url in imageUrls select Stubs.GetBitmapAsync(url));
        if (downloads == await Task.WhenAny(downloads, Task.Delay(3000)))
        {
            return downloads.Result;
        }
        else
        {
            downloads.ContinueWith(t => Stubs.Log(t));
            return null;
        }
    }
    // </DelayTimeoutMultiple>

    // ---- Combinators ----
    // <RetryOnFaultSync>
    public static T RetryOnFault<T>(Func<T> function, int maxTries)
    {
        for (int i = 0; i < maxTries; i++)
        {
            try { return function(); }
            catch { if (i == maxTries - 1) throw; }
        }
        return default(T)!;
    }
    // </RetryOnFaultSync>

    // <RetryOnFaultAsync>
    public static async Task<T> RetryOnFault<T>(Func<Task<T>> function, int maxTries)
    {
        for (int i = 0; i < maxTries; i++)
        {
            try { return await function().ConfigureAwait(false); }
            catch { if (i == maxTries - 1) throw; }
        }
        return default(T)!;
    }
    // </RetryOnFaultAsync>

    // <RetryOnFaultWithDelay>
    public static async Task<T> RetryOnFaultWithDelay<T>(
        Func<Task<T>> function, int maxTries, Func<Task> retryWhen)
    {
        for (int i = 0; i < maxTries; i++)
        {
            try { return await function().ConfigureAwait(false); }
            catch { if (i == maxTries - 1) throw; }
            await retryWhen().ConfigureAwait(false);
        }
        return default(T)!;
    }
    // </RetryOnFaultWithDelay>

    // <NeedOnlyOne>
    public static async Task<T> NeedOnlyOne<T>(
        params Func<CancellationToken, Task<T>>[] functions)
    {
        var cts = new CancellationTokenSource();
        var tasks = (from function in functions
                     select function(cts.Token)).ToArray();
        var completed = await Task.WhenAny(tasks).ConfigureAwait(false);
        cts.Cancel();
        foreach (var task in tasks)
        {
            var ignored = task.ContinueWith(
                t => Stubs.Log(t), TaskContinuationOptions.OnlyOnFaulted);
        }
        return await completed;
    }
    // </NeedOnlyOne>

    // <Interleaved>
    public static IEnumerable<Task<T>> Interleaved<T>(IEnumerable<Task<T>> tasks)
    {
        var inputTasks = tasks.ToList();
        var sources = (from _ in Enumerable.Range(0, inputTasks.Count)
                       select new TaskCompletionSource<T>()).ToList();
        int nextTaskIndex = -1;
        foreach (var inputTask in inputTasks)
        {
            inputTask.ContinueWith(completed =>
            {
                var source = sources[Interlocked.Increment(ref nextTaskIndex)];
                if (completed.IsFaulted)
                    source.TrySetException(completed.Exception!.InnerExceptions);
                else if (completed.IsCanceled)
                    source.TrySetCanceled();
                else
                    source.TrySetResult(completed.Result);
            }, CancellationToken.None,
               TaskContinuationOptions.ExecuteSynchronously,
               TaskScheduler.Default);
        }
        return from source in sources
               select source.Task;
    }
    // </Interleaved>

    // <WhenAllOrFirstException>
    public static Task<T[]> WhenAllOrFirstException<T>(IEnumerable<Task<T>> tasks)
    {
        var inputs = tasks.ToList();
        var ce = new CountdownEvent(inputs.Count);
        var tcs = new TaskCompletionSource<T[]>();

        Action<Task> onCompleted = (Task completed) =>
        {
            if (completed.IsFaulted)
                tcs.TrySetException(completed.Exception!.InnerExceptions);
            if (ce.Signal() && !tcs.Task.IsCompleted)
                tcs.TrySetResult(inputs.Select(t => ((Task<T>)t).Result).ToArray());
        };

        foreach (var t in inputs) t.ContinueWith(onCompleted);
        return tcs.Task;
    }
    // </WhenAllOrFirstException>

    // ---- AsyncCache usage ----
    // <AsyncCacheUsage>
    static AsyncCache<string, string> m_webPages =
        new AsyncCache<string, string>(url => Stubs.DownloadStringTaskAsync(url));

    public static async Task UseWebPageCache(string url)
    {
        string contents = await m_webPages[url];
        Console.WriteLine(contents.Length);
    }
    // </AsyncCacheUsage>

    // ---- AsyncProducerConsumerCollection usage ----
    // <AsyncProducerConsumerUsage>
    static AsyncProducerConsumerCollection<int> m_data = new();

    public static async Task ConsumerAsync()
    {
        while (true)
        {
            int nextItem = await m_data.Take();
            Stubs.ProcessNextItem(nextItem);
        }
    }

    public static void Produce(int data)
    {
        m_data.Add(data);
    }
    // </AsyncProducerConsumerUsage>

    // <BufferBlockUsage>
    static BufferBlock<int> m_dataBlock = new();

    public static async Task ConsumerAsyncBlock()
    {
        while (true)
        {
            int nextItem = await m_dataBlock.ReceiveAsync();
            Stubs.ProcessNextItem(nextItem);
        }
    }

    public static void ProduceBlock(int data)
    {
        m_dataBlock.Post(data);
    }
    // </BufferBlockUsage>

    // ---- Cancellation examples ----
    // <CancelSingleDownload>
    public static async Task CancelSingleDownload(string url)
    {
        var cts = new CancellationTokenSource();
        string result = await Stubs.DownloadStringTaskAsync(url, cts.Token);
        // at some point later, potentially on another thread
        cts.Cancel();
        Console.WriteLine(result);
    }
    // </CancelSingleDownload>

    // <CancelMultipleDownloads>
    public static async Task CancelMultipleDownloads(string[] urlList)
    {
        var cts = new CancellationTokenSource();
        IList<string> results = await Task.WhenAll(
            from url in urlList select Stubs.DownloadStringTaskAsync(url, cts.Token));
        // at some point later, potentially on another thread
        cts.Cancel();
        Console.WriteLine(results.Count);
    }
    // </CancelMultipleDownloads>

    // <CancelSubsetDownloads>
    public static async Task CancelSubsetDownloads(string url, string outputPath)
    {
        var cts = new CancellationTokenSource();
        byte[] data = await Stubs.DownloadDataAsync(url, cts.Token);
        await Stubs.SaveToDiskAsync(outputPath, data, CancellationToken.None);
        // at some point later, potentially on another thread
        cts.Cancel();
    }
    // </CancelSubsetDownloads>
}

// ---- AsyncCache ----
// <AsyncCache>
public class AsyncCache<TKey, TValue> where TKey : notnull
{
    private readonly Func<TKey, Task<TValue>> _valueFactory;
    private readonly ConcurrentDictionary<TKey, Lazy<Task<TValue>>> _map;

    public AsyncCache(Func<TKey, Task<TValue>> valueFactory)
    {
        if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));
        _valueFactory = valueFactory;
        _map = new ConcurrentDictionary<TKey, Lazy<Task<TValue>>>();
    }

    public Task<TValue> this[TKey key]
    {
        get
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return _map.GetOrAdd(key, toAdd =>
                new Lazy<Task<TValue>>(() => _valueFactory(toAdd))).Value;
        }
    }
}
// </AsyncCache>

// ---- AsyncProducerConsumerCollection ----
// <AsyncProducerConsumerCollection>
public class AsyncProducerConsumerCollection<T>
{
    private readonly Queue<T> m_collection = new Queue<T>();
    private readonly Queue<TaskCompletionSource<T>> m_waiting =
        new Queue<TaskCompletionSource<T>>();

    public void Add(T item)
    {
        TaskCompletionSource<T>? tcs = null;
        lock (m_collection)
        {
            if (m_waiting.Count > 0) tcs = m_waiting.Dequeue();
            else m_collection.Enqueue(item);
        }
        if (tcs != null) tcs.TrySetResult(item);
    }

    public Task<T> Take()
    {
        lock (m_collection)
        {
            if (m_collection.Count > 0)
            {
                return Task.FromResult(m_collection.Dequeue());
            }
            else
            {
                var tcs = new TaskCompletionSource<T>();
                m_waiting.Enqueue(tcs);
                return tcs.Task;
            }
        }
    }
}
// </AsyncProducerConsumerCollection>

// <EarlyBailoutUI>
class EarlyBailoutUI
{
    private CancellationTokenSource? m_cts;

    public void btnCancel_Click(object sender, EventArgs e)
    {
        if (m_cts != null) m_cts.Cancel();
    }

    public async void btnRun_Click(object sender, EventArgs e)
    {
        m_cts = new CancellationTokenSource();
        try
        {
            Task<Bitmap> imageDownload = Stubs.GetBitmapAsync("url");
            await Examples.UntilCompletionOrCancellation(imageDownload, m_cts.Token);
            if (imageDownload.IsCompleted)
            {
                Bitmap image = await imageDownload;
                Stubs.Log(image);
            }
            else imageDownload.ContinueWith(t => Stubs.Log(t));
        }
        finally { }
    }
}
// </EarlyBailoutUI>

// <EarlyBailoutWithTokenUI>
class EarlyBailoutWithTokenUI
{
    private CancellationTokenSource? m_cts;

    public async void btnRun_Click(object sender, EventArgs e)
    {
        m_cts = new CancellationTokenSource();
        try
        {
            Task<Bitmap> imageDownload = Stubs.GetBitmapAsync("url", m_cts.Token);
            await Examples.UntilCompletionOrCancellation(imageDownload, m_cts.Token);
            Bitmap image = await imageDownload;
            Stubs.Log(image);
        }
        catch (OperationCanceledException) { }
        finally { }
    }
}
// </EarlyBailoutWithTokenUI>

public static class Program
{
    public static async Task Main()
    {
        await Examples.WhenAllBasic();
        Console.WriteLine("Done.");
    }
}


