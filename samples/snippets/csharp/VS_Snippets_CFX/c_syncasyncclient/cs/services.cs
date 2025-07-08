// <snippet1>
// <snippet2>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
  [ServiceContractAttribute(Namespace="http://microsoft.wcf.documentation")]
  public interface ISampleService{

    [OperationContractAttribute]
    string SampleMethod(string msg);

    [OperationContractAttribute(AsyncPattern = true)]
    IAsyncResult BeginSampleMethod(string msg, AsyncCallback callback, object asyncState);

    //Note: There is no OperationContractAttribute for the end method.
    string EndSampleMethod(IAsyncResult result);

    // <snippet6>
    [OperationContractAttribute(AsyncPattern=true)]
    IAsyncResult BeginServiceAsyncMethod(string msg, AsyncCallback callback, object asyncState);

    // Note: There is no OperationContractAttribute for the end method.
    string EndServiceAsyncMethod(IAsyncResult result);
  }
  // </snippet6>
  // </snippet2>

  public class SampleService : ISampleService
  {
    #region ISampleService Members

    public string  SampleMethod(string msg)
    {
      Console.WriteLine($"Called synchronous sample method with \"{msg}\"");
 	    return "The synchronous service greets you: " + msg;
    }

    // This asynchronously implemented operation is never called because
    // there is a synchronous version of the same method.
    public IAsyncResult BeginSampleMethod(string msg, AsyncCallback callback, object asyncState)
    {
      Console.WriteLine("BeginSampleMethod called with: " + msg);
      return new CompletedAsyncResult<string>(msg);
    }

    public string EndSampleMethod(IAsyncResult r)
    {
      CompletedAsyncResult<string> result = r as CompletedAsyncResult<string>;
      Console.WriteLine("EndSampleMethod called with: " + result.Data);
      return result.Data;
    }

    // <snippet3>
    public IAsyncResult BeginServiceAsyncMethod(string msg, AsyncCallback callback, object asyncState)
    {
      Console.WriteLine($"BeginServiceAsyncMethod called with: \"{msg}\"");
      return new CompletedAsyncResult<string>(msg);
    }

    public string EndServiceAsyncMethod(IAsyncResult r)
    {
      CompletedAsyncResult<string> result = r as CompletedAsyncResult<string>;
      Console.WriteLine($"EndServiceAsyncMethod called with: \"{result.Data}\"");
      return result.Data;
    }
    // </snippet3>
    #endregion
  }

  // Simple async result implementation.
  class CompletedAsyncResult<T> : IAsyncResult
  {
    T data;

    public CompletedAsyncResult(T data)
    { this.data = data; }

    public T Data
    { get { return data; } }

    #region IAsyncResult Members
    public object AsyncState
    { get { return (object)data; } }

    public WaitHandle AsyncWaitHandle
    { get { throw new Exception("The method or operation is not implemented."); } }

    public bool CompletedSynchronously
    { get { return true; } }

    public bool IsCompleted
    { get { return true; } }
    #endregion
  }
}
// </snippet1>
