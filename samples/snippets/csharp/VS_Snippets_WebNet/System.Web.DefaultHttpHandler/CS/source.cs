using System;
using System.Web;
using System.Threading;

// <Snippet1>
public class AsyncDefaultHttpHandler : DefaultHttpHandler
{
    private HttpContext _context;

    public override IAsyncResult BeginProcessRequest(
      HttpContext context, AsyncCallback callback, object state)
    {
        AsyncResultSample ar = new AsyncResultSample(callback, state);
        _context = context;

        return ar;
    }

    public override void EndProcessRequest(IAsyncResult result)
    {
        _context.Response.Write("EndProcessRequest called.");
    }

    // This method should not be called asynchronously.
    public override void ProcessRequest(HttpContext context)
    {
        throw new InvalidOperationException(
                  "Asynchronous processing failed.");
    }

    // Enables pooling when set to true
    public override bool IsReusable
    {
        get { return true; }
    }
}

// Tracks state between the begin and end calls.
class AsyncResultSample : IAsyncResult
{
    private AsyncCallback callback = null;
    private Object asyncState;
    private Boolean isCompleted;

    internal AsyncResultSample(AsyncCallback cb, Object state)
    {
        this.callback = cb;
        asyncState = state;
        isCompleted = false;
    }

    public object AsyncState
    {
        get
        {
            return asyncState;
        }
    }

    public bool CompletedSynchronously
    {
        get
        {
            return false;
        }
    }

    public WaitHandle AsyncWaitHandle
    {
        get
        {
            throw new InvalidOperationException(
                      "ASP.NET should not use this property .");
        }
    }

    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }
    }

    internal void SetCompleted()
    {
        isCompleted = true;
        if (callback != null)
        {
            callback(this);
        }
    }

}
// </Snippet1>

