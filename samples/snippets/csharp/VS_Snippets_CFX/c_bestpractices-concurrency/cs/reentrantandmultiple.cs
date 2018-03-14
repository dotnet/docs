// <snippet1>
using System;
using System.ServiceModel;

[ServiceContract]
public interface IHttpFetcher
{
  [OperationContract]
  string GetWebPage(string address);
}

//<snippet6>
// These classes have the invariant that:
//     this.slow.GetWebPage(this.cachedAddress) == this.cachedWebPage.
// When you read cached values you can assume they are valid. When
// you write the cached values, you must guarantee that they are valid.
//</snippet6>
// <snippet2>
// With ConcurrencyMode.Single, WCF does not call again into the object
// so long as the method is running. After the operation returns the object
// can be called again, so you must make sure state is consistent before
// returning.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
class SingleCachingHttpFetcher : IHttpFetcher
{
    string cachedWebPage;
    string cachedAddress;
    readonly IHttpFetcher slow;

    public string GetWebPage(string address)
    {
        // <-- Can assume cache is valid.
        if (this.cachedAddress == address)
        {
            return this.cachedWebPage;
        }

        // <-- Cache is no longer valid because we are changing
        // one of the values.
        this.cachedAddress = address;
        string webPage = slow.GetWebPage(address);
        this.cachedWebPage = webPage;
        // <-- Cache is valid again here.

        return this.cachedWebPage;
        // <-- Must guarantee that the cache is valid because we are returning.
    }
}
// </snippet2>

// <snippet3>
// With ConcurrencyMode.Reentrant, WCF makes sure that only one
// thread runs in your code at a time. However, when you call out on a
// channel, the operation can get called again on another thread. Therefore 
// you must confirm that state is consistent both before channel calls and
// before you return.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
class ReentrantCachingHttpFetcher : IHttpFetcher
{
  string cachedWebPage;
  string cachedAddress;
  readonly SlowHttpFetcher slow;

  public ReentrantCachingHttpFetcher()
  {
    this.slow = new SlowHttpFetcher();
  }

  public string GetWebPage(string address)
  {
    // <-- Can assume that cache is valid.
    if (this.cachedAddress == address)
    {
        return this.cachedWebPage;
    }

    // <-- Must guarantee that the cache is valid, because 
    // the operation can be called again before we return.
    string webPage = slow.GetWebPage(address);
    // <-- Can assume cache is valid.

    // <-- Cache is no longer valid because we are changing
    // one of the values.
    this.cachedAddress = address;
    this.cachedWebPage = webPage;
    // <-- Cache is valid again here.

    return this.cachedWebPage;
    // <-- Must guarantee that cache is valid because we are returning.
  }
}
// </snippet3>

// <snippet4>
// With ConcurrencyMode.Multiple, threads can call an operation at any time.  
// It is your responsibility to guard your state with locks. If
// you always guarantee you leave state consistent when you leave
// the lock, you can assume it is valid when you enter the lock.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
class MultipleCachingHttpFetcher : IHttpFetcher
{
  string cachedWebPage;
  string cachedAddress;
  readonly SlowHttpFetcher slow;
  readonly object ThisLock = new object();

  public MultipleCachingHttpFetcher()
  {
    this.slow = new SlowHttpFetcher();
  }

  public string GetWebPage(string address)
  {
    lock (this.ThisLock)
    {
      // <-- Can assume cache is valid.
      if (this.cachedAddress == address)
      {
          return this.cachedWebPage;
          // <-- Must guarantee that cache is valid because 
          // the operation returns and releases the lock.
      }
      // <-- Must guarantee that cache is valid here because
      // the operation releases the lock.
    }

    string webPage = slow.GetWebPage(address);

    lock (this.ThisLock)
    {
      // <-- Can assume cache is valid.

      // <-- Cache is no longer valid because the operation 
      // changes one of the values.
      this.cachedAddress = address;
      this.cachedWebPage = webPage;
      // <-- Cache is valid again here.

      // <-- Must guarantee that cache is valid because
      // the operation releases the lock.
    }

    return webPage;
  }
}
// </snippet4>
// </snippet1>

//<snippet5>
// This class has the invariant that:
//     this.slow.GetWebPage(this.cachedAddress) == this.cachedWebPage.
// When you read cached values you can assume they are valid. When
// you write the cached values, you must guarantee that they are valid.
//</snippet5>

public class SlowHttpFetcher
{
  public string GetWebPage(string address)
  {
    return "The return value.";
  }
  
}