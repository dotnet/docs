using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
    class OperationCachingInvokerAsyncResult : AsyncResult
    {
        string action;
        IOperationInvoker innerOperationInvoker;
        object[] inputs;
        object instance;
        bool isNewResult;
        object[] outputs;
        object returnValue;

        public OperationCachingInvokerAsyncResult(object instance, string action, object[] inputs, IOperationInvoker innerOperationInvoker, AsyncCallback callback, object state)
            : base(callback, state)
        {
            this.instance = instance;
            this.action = action;
            this.inputs = inputs;
            this.innerOperationInvoker = innerOperationInvoker;
            this.isNewResult = true;

            innerOperationInvoker.InvokeBegin(instance, inputs, new AsyncCallback(HandleCallback), null);
        }

        public OperationCachingInvokerAsyncResult(object instance, string action, object[] inputs, object returnValue, object[] outputs, AsyncCallback callback, object state)
            : base(callback, state)
        {
            this.instance = instance;
            this.action = action;
            this.inputs = inputs;
            this.returnValue = returnValue;
            this.outputs = outputs;
            this.isNewResult = false;
            Complete(true);
        }

        public string Action
        {
            get { return action; }
        }

        public object[] Inputs
        {
            get { return Inputs; }
        }

        public bool IsNewResult
        {
            get { return isNewResult; }
        }

        public object ReturnValue
        {
            get { return returnValue; }
        }

        public object[] Outputs
        {
            get { return outputs; }
        }

        void HandleCallback(IAsyncResult asyncResult)
        {
            try
            {
                innerOperationInvoker.InvokeEnd(instance, out outputs, asyncResult);
                Complete(false);
            }
            catch (Exception e)
            {
                Complete(false, e);
            }
        }

        public static void End(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
            {
                throw new ArgumentNullException("result");
            }

            OperationCachingInvokerAsyncResult outputResult = asyncResult as OperationCachingInvokerAsyncResult;
            if (outputResult == null)
            {
                throw new ArgumentException("Invalid AsyncResult", "result");
            }
            AsyncResult.End(outputResult);
        }
    }

	abstract class AsyncResult : IAsyncResult
	{
		AsyncCallback callback;
		bool completedSynchronously;
		bool endCalled;
		Exception exception;
		bool isCompleted;
		ManualResetEvent manualResetEvent;
		object asyncState;

		protected AsyncResult(AsyncCallback callback, object state)
		{
			this.callback = callback;
			this.asyncState = state;
		}

		public object AsyncState
		{
			get { return asyncState; }
		}

		public WaitHandle AsyncWaitHandle
		{
			get
			{
				if (manualResetEvent != null)
				{
					return manualResetEvent;
				}

				lock (this)
				{
					if (manualResetEvent == null)
					{
						manualResetEvent = new ManualResetEvent(isCompleted);
					}
				}

				return manualResetEvent;
			}
		}

		public bool CompletedSynchronously
		{
			get { return completedSynchronously; }
		}

		public bool IsCompleted
		{
			get { return isCompleted; }
		}

		protected void Complete(bool completedSynchronously)
		{
			if (isCompleted)
			{
				throw new InvalidOperationException("AsyncResults can only be completed once.");
			}

			ManualResetEvent manualResetEvent = null;
			this.completedSynchronously = completedSynchronously;

			if (completedSynchronously)
			{
				// If we completedSynchronously, then there's no chance that the 
				// manualResetEvent was created so we don't need to worry about a race
				this.isCompleted = true;
				if (this.manualResetEvent != null)
				{
					throw new InvalidOperationException("No ManualResetEvent should be created for a synchronous AsyncResult.");
				}
			}
			else
			{
				lock (this)
				{
					this.isCompleted = true;
					manualResetEvent = this.manualResetEvent;
				}
			}

			if (callback != null)
			{
				callback(this);
			}

			if (manualResetEvent != null)
			{
				manualResetEvent.Set();
			}
		}

		protected void Complete(bool completedSynchronously, Exception exception)
		{
			this.exception = exception;
			Complete(completedSynchronously);
		}

		protected static void End(AsyncResult asyncResult)
		{
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}

			if (asyncResult.endCalled)
			{
				throw new InvalidOperationException("Async object already ended.");
			}

			asyncResult.endCalled = true;

			if (!asyncResult.isCompleted)
			{
				using (WaitHandle waitHandle = asyncResult.AsyncWaitHandle)
				{
					waitHandle.WaitOne();
				}
			}

			if (asyncResult.exception != null)
			{
				throw asyncResult.exception;
			}
		}
	}
}
