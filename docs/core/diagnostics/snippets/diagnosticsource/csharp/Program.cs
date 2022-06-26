// <WholeProgram>
using System.Diagnostics;
MyListener TheListener = new MyListener();
TheListener.Listening();
HTTPClient Client = new HTTPClient();
Client.SendWebRequest("https://docs.microsoft.com/dotnet/core/diagnostics/");

// <snippit4>
class HTTPClient
{
    // <snippit1>
    private static DiagnosticSource httpLogger = new DiagnosticListener("System.Net.Http");
    // </snippit1>
    public byte[] SendWebRequest(string url)
    {
        // <snippit3>
        if (httpLogger.IsEnabled("RequestStart"))
        {
            httpLogger.Write("RequestStart", new { Url = url });
        }
        // </snippit3>
        //Pretend this sends an HTTP request to the url and gets back a reply.
        byte[] reply = new byte[] { };
        return reply;
    }
}
// </snippit4>
// <snippit5>
class Observer<T> : IObserver<T>
{
    public Observer(Action<T> onNext, Action onCompleted)
    {
        _onNext = onNext ?? new Action<T>(_ => { });
        _onCompleted = onCompleted ?? new Action(() => { });
    }
    public void OnCompleted() { _onCompleted(); }
    public void OnError(Exception error) { }
    public void OnNext(T value) { _onNext(value); }
    private Action<T> _onNext;
    private Action _onCompleted;
}
class MyListener
{
    // <snippit6>
    IDisposable networkSubscription;
    IDisposable listenerSubscription;
    private readonly object allListeners = new();
    public void Listening()
    {
        Action<KeyValuePair<string, object>> whenHeard = delegate (KeyValuePair<string, object> data)
        {
            Console.WriteLine($"Data received: {data.Key}: {data.Value}");
        };
        Action<DiagnosticListener> onNewListener = delegate (DiagnosticListener listener)
        {
            Console.WriteLine($"New Listener discovered: {listener.Name}");
            //Suscribe to the specific DiagnosticListener of interest.
            if (listener.Name == "System.Net.Http")
            {
                //Use lock to ensure the callback code is thread safe.
                lock (allListeners)
                {
                    if (networkSubscription != null)
                    {
                        networkSubscription.Dispose();
                    }
                    IObserver<KeyValuePair<string, object>> iobserver = new Observer<KeyValuePair<string, object>>(whenHeard, null);
                    networkSubscription = listener.Subscribe(iobserver);
                }

            }
        };
        //Subscribe to discover all DiagnosticListeners
        IObserver<DiagnosticListener> observer = new Observer<DiagnosticListener>(onNewListener, null);
        //When a listener is created, invoke the onNext function which calls the delegate.
        listenerSubscription = DiagnosticListener.AllListeners.Subscribe(observer);
    }
    // </snippit6>
    // Typically you leave the listenerSubscription subscription active forever.
    // However when you no longer want your callback to be called, you can
    // call listenerSubscription.Dispose() to cancel your subscription to the IObservable.
}
// </snippit5>
// </WholeProgram>
