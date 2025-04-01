using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace specialNamespaceForOneMethodSignature
{
    using System;
    class Task<TResult>
    {
        public TResult TValue;
    }
    class Dummy <TResult>
    {
            // <snippet01>
            public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(
                Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, //BeginRead
                 Func<IAsyncResult, TResult> endMethod, //EndRead
                 TArg1 arg1, // the byte[] buffer
                 TArg2 arg2, // the offset in arg1 at which to start writing data
                 TArg3 arg3, // the maximum number of bytes to read
                 object state // optional state information
                )
                //</snippet01>
        { return new Task<TResult>(); }
    }
}

namespace APM_Task
{
    class TestFileStreamNaive
    {
        //<snippet02>
        public string GetFileData(string path)
        {
            FileInfo fi = new FileInfo(path);
            byte[] data = new byte[fi.Length];
            FileStream fs;

            // a using statement is ok here because we Wait before returning
            // and will be done with the filestream.
            using (fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, true))
            {
                //Task<int> returns the number of bytes read
                Task<int> task = Task<int>.Factory.FromAsync(
                        fs.BeginRead, fs.EndRead, data, 0, data.Length, null);

                task.Wait();
                return new UTF8Encoding().GetString(data);
            }
        }
        //</snippet02>
        static void Main()
        {
            TestFileStreamNaive instance = new TestFileStreamNaive();
            string s = instance.GetFileData("testfile.txt");
        }
    }

    class AsyncResult : IAsyncResult
    {

        public AsyncResult() { }
        public object AsyncState
        {
            get { return "Hello from a parallel universe."; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get { throw new NotImplementedException(); }
        }

        static IAsyncResult DoSomethingAsynchronously()
        {
            return new AsyncResult();
        }

        //<snippet07>
        static Task<String> ReturnTaskFromAsyncResult()
        {
            IAsyncResult ar = DoSomethingAsynchronously();
            Task<String> t = Task<string>.Factory.FromAsync(ar, _ =>
                {
                    return (string)ar.AsyncState;
                });

            return t;
        }
        //</snippet07>
    }

    //<snippet08>
    class WebDataDownloader
    {

        static void Main()
        {
            WebDataDownloader downloader = new WebDataDownloader();
            string[] addresses = { "http://www.msnbc.com", "http://www.yahoo.com",
                                     "http://www.nytimes.com", "http://www.washingtonpost.com",
                                     "http://www.latimes.com", "http://www.newsday.com" };
            CancellationTokenSource cts = new CancellationTokenSource();

            // Create a UI thread from which to cancel the entire operation
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Press c to cancel");
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
            });

            // Using a neutral search term that is sure to get some hits.
            Task<string[]> webTask = downloader.GetWordCounts(addresses, "the", cts.Token);

            // Do some other work here unless the method has already completed.
            if (!webTask.IsCompleted)
            {
                // Simulate some work.
                Thread.SpinWait(5000000);
            }

            string[] results = null;
            try
            {
                results = webTask.Result;
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    OperationCanceledException oce = ex as OperationCanceledException;
                    if (oce != null)
                    {
                        if (oce.CancellationToken == cts.Token)
                        {
                            Console.WriteLine("Operation canceled by user.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            finally
            {
                cts.Dispose();
            }
            if (results != null)
            {
                foreach (var item in results)
                    Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        Task<string[]> GetWordCounts(string[] urls, string name, CancellationToken token)
        {
            TaskCompletionSource<string[]> tcs = new TaskCompletionSource<string[]>();
            WebClient[] webClients = new WebClient[urls.Length];

            // If the user cancels the CancellationToken, then we can use the
            // WebClient's ability to cancel its own async operations.
            token.Register(() =>
                {
                    foreach (var wc in webClients)
                    {
                        if (wc != null)
                            wc.CancelAsync();
                    }
                });

            object m_lock = new object();
            int count = 0;
            List<string> results = new List<string>();
            for (int i = 0; i < urls.Length; i++)
            {
                webClients[i] = new WebClient();

                #region callback
                // Specify the callback for the DownloadStringCompleted
                // event that will be raised by this WebClient instance.
                webClients[i].DownloadStringCompleted += (obj, args) =>
                 {
                     if (args.Cancelled == true)
                     {
                         tcs.TrySetCanceled();
                         return;
                     }
                     else if (args.Error != null)
                     {
                         // Pass through to the underlying Task
                         // any exceptions thrown by the WebClient
                         // during the asynchronous operation.
                         tcs.TrySetException(args.Error);
                         return;
                     }
                     else
                     {
                         // Split the string into an array of words,
                         // then count the number of elements that match
                         // the search term.
                         string[] words = null;
                         words = args.Result.Split(' ');
                         string NAME = name.ToUpper();
                         int nameCount = (from word in words.AsParallel()
                                          where word.ToUpper().Contains(NAME)
                                          select word)
                                         .Count();

                         // Associate the results with the url, and add new string to the array that
                         // the underlying Task object will return in its Result property.
                         results.Add(String.Format("{0} has {1} instances of {2}", args.UserState, nameCount, name));
                     }

                     // If this is the last async operation to complete,
                     // then set the Result property on the underlying Task.
                     lock (m_lock)
                     {
                         count++;
                         if (count == urls.Length)
                         {
                             tcs.TrySetResult(results.ToArray());
                         }
                     }
                 };
                #endregion

                // Call DownloadStringAsync for each URL.
                Uri address = null;
                try
                {
                    address = new Uri(urls[i]);
                    // Pass the address, and also use it for the userToken
                    // to identify the page when the delegate is invoked.
                    webClients[i].DownloadStringAsync(address, address);
                }

                catch (UriFormatException ex)
                {
                    // Abandon the entire operation if one url is malformed.
                    // Other actions are possible here.
                    tcs.TrySetException(ex);
                    return tcs.Task;
                }
            }

            // Return the underlying Task. The client code
            // waits on the Result property, and handles exceptions
            // in the try-catch block there.
            return tcs.Task;
        }
        //</snippet08>
    }

    #region snippet09
    class Calculator
    {
        public IAsyncResult BeginCalculate(int decimalPlaces, AsyncCallback ac, object state)
        {
            Console.WriteLine($"Calling BeginCalculate on thread {Thread.CurrentThread.ManagedThreadId}");
            Task<string> f = Task<string>.Factory.StartNew(_ => Compute(decimalPlaces), state);
            if (ac != null) f.ContinueWith((res) => ac(f));
            return f;
        }

        public string Compute(int numPlaces)
        {
            Console.WriteLine($"Calling compute on thread {Thread.CurrentThread.ManagedThreadId}");

            // Simulating some heavy work.
            Thread.SpinWait(500000000);

            // Actual implementation left as exercise for the reader.
            // Several examples are available on the Web.
            return "3.14159265358979323846264338327950288";
        }

        public string EndCalculate(IAsyncResult ar)
        {
            Console.WriteLine($"Calling EndCalculate on thread {Thread.CurrentThread.ManagedThreadId}");
            return ((Task<string>)ar).Result;
        }
    }

    public class CalculatorClient
    {
        static int decimalPlaces = 12;
        public static void Main()
        {
            Calculator calc = new Calculator();
            int places = 35;

            AsyncCallback callBack = new AsyncCallback(PrintResult);
            IAsyncResult ar = calc.BeginCalculate(places, callBack, calc);

            // Do some work on this thread while the calculator is busy.
            Console.WriteLine("Working...");
            Thread.SpinWait(500000);
            Console.ReadLine();
        }

        public static void PrintResult(IAsyncResult result)
        {
            Calculator c = (Calculator)result.AsyncState;
            string piString = c.EndCalculate(result);
            Console.WriteLine($"Calling PrintResult on thread {Thread.CurrentThread.ManagedThreadId}; result = {piString}");
        }
    }
    #endregion
} //end APM_Task namespace

class FileStreamDemo
{
    static void Main()
    {
        FileStreamDemo fsd = new FileStreamDemo();
        //  var task = fsd.GetMultiFileData(new string[1]);
         fsd.ShowCallingFromAsync();
       // fsd.ShowCallingFromAsyncFileData();
        //  fsd.ProcessFilesAsync();
        //  task.Wait();
        //  Console.WriteLine(task.Result);

        Console.WriteLine("press any key");
        Console.ReadLine();
    }
    //<snippet03>
    const int MAX_FILE_SIZE = 14000000;
    public static Task<string> GetFileStringAsync(string path)
    {
        FileInfo fi = new FileInfo(path);
        byte[] data = null;
        data = new byte[fi.Length];

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, true);

        //Task<int> returns the number of bytes read
        Task<int> task = Task<int>.Factory.FromAsync(
                fs.BeginRead, fs.EndRead, data, 0, data.Length, null);

        // It is possible to do other work here while waiting
        // for the antecedent task to complete.
        // ...

        // Add the continuation, which returns a Task<string>.
        return task.ContinueWith((antecedent) =>
        {
            fs.Close();

            // Result = "number of bytes read" (if we need it.)
            if (antecedent.Result < 100)
            {
                return "Data is too small to bother with.";
            }
            else
            {
                // If we did not receive the entire file, the end of the
                // data buffer will contain garbage.
                if (antecedent.Result < data.Length)
                    Array.Resize(ref data, antecedent.Result);

                // Will be returned in the Result property of the Task<string>
                // at some future point after the asynchronous file I/O operation completes.
                return new UTF8Encoding().GetString(data);
            }
        });
    }
    //</snippet03>

        void ShowCallingFromAsync()
        {
            string path = @"\\docbuild2\public\Main\Logs\DllDiffReport\DllDiffReport_BetweenInBuildAndInProduct.html";
            //<snippet04>

            Task<string> t = GetFileStringAsync(path);

            // Do some other work:
            // ...

            try
            {
                 Console.WriteLine(t.Result.Substring(0, 500));
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.InnerException.Message);
            }
            //</snippet04>

            Console.ReadLine();
        }

        //not used???
        //<snippet12>
        public static Task<int> GetFileDataAsync(string path, ref byte[] data)
        {
            // Error handling omitted for brevity...

            FileInfo fi = new FileInfo(path);
            data = new byte[fi.Length];
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, true);

            // Task<int> returns the number of bytes read
            // Pass FileStream in AsyncState parameter in order to close it from the call site.
            return Task<int>.Factory.FromAsync(
                    fs.BeginRead, fs.EndRead, data, 0, data.Length, fs);
        }
        //</snippet12>

        void ShowCallingFromAsyncFileData()
        {
            //<snippet13>
            string path = @"\\remoteComputer\filename.txt";

            byte[] buffer = null;
            Task<int> t = GetFileDataAsync(path, ref buffer);

            // Can do some other work here:
            // ...
            for(int i = 0; i < 10; i++)
                Console.Write("Working... ");

            var result =
            t.ContinueWith((antecedent) =>
            {
                // Error handling omitted...

                return new UTF8Encoding().GetString(buffer);
            });

            // Can also do some other work here:
            // ...
            for (int i = 0; i < 10; i++)
                Console.Write("Working more... ");
            try
            {
                t.Wait();
                Console.WriteLine(result.Result.Substring(0, 50));
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.InnerException.Message);
            }
            //</snippet13>

            Console.ReadLine();
        }
        // nested dummy class for snippet0 5 below
        class MyCustomState
        {
            public string StateData { get; set; }
            public MyCustomState() { StateData = "Hello"; }
        }
        private MyCustomState GetCustomState()
        {
            return new MyCustomState();
        }

        //<snippet05>
        public Task<string> GetFileStringAsync2(string path)
        {
            FileInfo fi = new FileInfo(path);
            byte[] data = new byte[fi.Length];
            MyCustomState state = GetCustomState();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, true);
            // We still pass null for the last parameter because
            // the state variable is visible to the continuation delegate.
            Task<int> task = Task<int>.Factory.FromAsync(
                    fs.BeginRead, fs.EndRead, data, 0, data.Length, null);

            return task.ContinueWith((antecedent) =>
            {
                // It is safe to close the filestream now.
                fs.Close();

                // Capture custom state data directly in the user delegate.
                // No need to pass it through the FromAsync method.
                if (state.StateData.Contains("New York, New York"))
                {
                    return "Start spreading the news!";
                }
                else
                {
                    // If we did not receive the entire file, the end of the
                    // data buffer will contain garbage.
                    if (antecedent.Result < data.Length)
                        Array.Resize(ref data, antecedent.Result);

                    // Will be returned in the Result property of the Task<string>
                    // at some future point after the asynchronous file I/O operation completes.
                    return new UTF8Encoding().GetString(data);
                }
            });
        }
        //</snippet05>

        string[] GetFilesToRead()
        {
            return new string[3] { "test.txt", "test1.txt", "test2.txt" };
        }
        //<snippet06>
        public Task<string> GetMultiFileData(string[] filesToRead)
        {
            FileStream fs;
            Task<string>[] tasks = new Task<string>[filesToRead.Length];
            byte[] fileData = null;
            for (int i = 0; i < filesToRead.Length; i++)
            {
                fileData = new byte[0x1000];
                fs = new FileStream(filesToRead[i], FileMode.Open, FileAccess.Read, FileShare.Read, fileData.Length, true);

                // By adding the continuation here, the
                // Result of each task will be a string.
                tasks[i] = Task<int>.Factory.FromAsync(
                         fs.BeginRead, fs.EndRead, fileData, 0, fileData.Length, null)
                         .ContinueWith((antecedent) =>
                             {
                                 fs.Close();

                                 // If we did not receive the entire file, the end of the
                                 // data buffer will contain garbage.
                                 if (antecedent.Result < fileData.Length)
                                     Array.Resize(ref fileData, antecedent.Result);

                                 // Will be returned in the Result property of the Task<string>
                                 // at some future point after the asynchronous file I/O operation completes.
                                 return new UTF8Encoding().GetString(fileData);
                             });
            }

            // Wait for all tasks to complete.
            return Task<string>.Factory.ContinueWhenAll(tasks, (data) =>
            {
                // Propagate all exceptions and mark all faulted tasks as observed.
                Task.WaitAll(data);

                // Combine the results from all tasks.
                StringBuilder sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.Result);
                }
                // Final result to be returned eventually on the calling thread.
                return sb.ToString();
            });
        }
        //</snippet06>
        public string ProcessData(Task[] arr)
        {
            return "processed";
        }

        //<snippet11>
        void ProcessFilesAsync()
        {
            string[] files = Directory.GetFiles(@"\\remoteComputer\folderName\", "*.*", SearchOption.AllDirectories);
            CancellationTokenSource cts = new CancellationTokenSource();

            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var file in files)
            {
                Task<string> t = null;
                try
                {
                    t = GetFileStringAsync3(file, cts.Token);
                }
                catch
                {
                    Console.WriteLine($"Argument exception on {file}");
                    continue;
                }
                t.ContinueWith((antecedent) => ProcessFileData(antecedent.Result));
                tasks.Add(t);
            }
            Console.WriteLine("All tasks have been added.");
            // Do some work here.

            try
            {
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("All tasks have completed.");
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
            finally
            {
                cts.Dispose();
            }

            // If needed, perform a final step after all tasks have completed.
            Task.Factory.ContinueWhenAll(tasks.ToArray(), (arr) =>
                {
                    foreach (var t in arr)
                    {
                        CompareFileData(t.Result);
                    }
                });
        }

        public Task<string> GetFileStringAsync3(string path, CancellationToken token)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(String.Format("Could not find {0}", path));
            }
            FileInfo fi = new FileInfo(path);
            byte[] data = null;

            if (fi.Length < MAX_FILE_SIZE && fi.Length > 0)
        {
            data = new byte[fi.Length];
        }
        else
            {
                throw new ArgumentException(String.Format("{0} is too big to load!", path));
            }

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, true);

            // We still pass null for the last parameter because
            // the state variable is visible to the continuation delegate.
            Task<int> task = Task<int>.Factory.FromAsync(
                    fs.BeginRead, fs.EndRead, data, 0, data.Length, null);

            return task.ContinueWith((antecedent) =>
            {
                fs.Close();

                // If we did not receive the entire file, the end of the
                // data buffer will contain garbage.
                if (antecedent.Result < data.Length)
                    Array.Resize(ref data, antecedent.Result);

                // Will be returned in the Result property of the Task<string>
                // at some future point after the asynchronous file I/O operation completes.
                return new UTF8Encoding().GetString(data);
            });
        }

        string ProcessFileData(string data)
        {

            string s = data.Substring(0, 80);
            Console.WriteLine(s);
            return s;
        }

        string CompareFileData(string s)
        {
            return "compare results";
        }
        //</snippet11>
    }
