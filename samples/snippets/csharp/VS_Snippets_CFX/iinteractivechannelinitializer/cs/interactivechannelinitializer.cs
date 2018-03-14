// <snippet9>
using System;
using System.Collections.Generic;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Microsoft.WCF.Documentation
{
  // <snippet8>
  public class InteractiveChannelInitializer : IInteractiveChannelInitializer
  {
    #region IInteractiveChannelInitializer Members
    /*
      To implement IInteractiveChannelInitializer, perform the following steps 
      in IInteractiveChannelInitializer.BeginDisplayInitializationUI:

      1. Prompt the user and obtain an appropriate System.Net.NetworkCredential. 
      2. Add a custom channel parameter object to the collection returned by the 
          IChannel.GetProperty method on the IClientChannel object with a type 
          parameter of System.ServiceModel.Channels.ChannelParameterCollection. 
          This channel parameter object is used by the custom 
          System.ServiceModel.ClientCredentialsSecurityTokenManager to establish 
         the security tokens for the channel.
      3. Return. 

    */
    public IAsyncResult BeginDisplayInitializationUI(System.ServiceModel.IClientChannel channel, AsyncCallback callback, object state)
    {
      // This implementation merely displays a message to the user and performs no behavior.
      MessageBox.Show("IInteractiveChannelInitializer called. Click OK to continue...");
      return new DisplayCompletedAsyncResult<string>("The initialization asyncresult.");
    }

    public void EndDisplayInitializationUI(IAsyncResult result)
    {
      DisplayCompletedAsyncResult<string> realResult = result as DisplayCompletedAsyncResult<string>;
      Console.WriteLine("EndDisplayInitializationUI called, returning:" + realResult.Data);
    }
    #endregion
  }
  // </snippet8>


  class DisplayCompletedAsyncResult<T> : IAsyncResult
  {
    T data;

    public DisplayCompletedAsyncResult(T data)
    {
      this.data = data;
    }

    public T Data
    {
      get { return data; }
    }

    #region IAsyncResult Members

    public object AsyncState
    {
      get { return (object)data; }
    }

    public WaitHandle AsyncWaitHandle
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    public bool CompletedSynchronously
    {
      get { return true; }
    }

    public bool IsCompleted
    {
      get { return true; }
    }

    #endregion
  }
}
// </snippet9>
