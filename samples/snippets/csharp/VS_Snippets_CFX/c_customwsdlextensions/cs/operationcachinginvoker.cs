using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WCF.Documentation
{
    class OperationCachingInvoker : IOperationInvoker
    {
        string action;
        IOperationInvoker innerOperationInvoker;
        IOperationCache operationCache;

        public OperationCachingInvoker(string action, IOperationInvoker innerOperationInvoker)
        {
            this.action = action;
            this.innerOperationInvoker = innerOperationInvoker;
		}

		#region Properties

		string Action
        {
            get { return action; }
        }

        IOperationInvoker InnerOperationInvoker
        {
            get { return this.innerOperationInvoker; }
        }

        IOperationCache OperationCache
        {
            get
            {
                if (operationCache == null)
                {
                    operationCache = OperationContext.Current.Host.Extensions.Find<IOperationCache>();
                }
                return operationCache;
            }
		}

		#endregion

		#region Synchronous Invocation

		public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            if (OperationCache == null)
            {
                return InnerOperationInvoker.Invoke(instance, inputs, out outputs);
            }

            OperationCacheKey key = new OperationCacheKey(action, inputs);
            OperationCacheValue value = OperationCache.Lookup(key);

            // if it's not in the cache, invoke and then add to the cache.
            if (value == null)
            {
              Console.WriteLine("Not in the cache. Creating new and caching.");
                object returnValue = InnerOperationInvoker.Invoke(instance, inputs, out outputs);
                value = new OperationCacheValue(outputs, returnValue);
                OperationCache.Insert(key, value);
                return returnValue;
            }

            // otherwise, just return the data
            Console.WriteLine("In cache; returning cache instance.");
            outputs = value.Outputs;
            return value.ReturnValue;
        }

        public bool IsSynchronous
        {
            get { return InnerOperationInvoker.IsSynchronous; }
        }

		#endregion

		#region Asynchronous Invocation

		public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            if (OperationCache == null)
            {
                return InnerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
            }

            OperationCacheKey key = new OperationCacheKey(action, inputs);
            OperationCacheValue value = OperationCache.Lookup(key);

            // if it's not in the cache, let the async invoke and let the end handle caching
            if (value == null)
            {
                return new OperationCachingInvokerAsyncResult(instance, action, inputs, innerOperationInvoker, callback, state);
            }

            // otherwise, just pass all the data to the async result and let it complete synchronously
            return new OperationCachingInvokerAsyncResult(instance, action, inputs, value.ReturnValue, value.Outputs, callback, state);
        }

		public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
		{
			if (OperationCache == null)
			{
				return InnerOperationInvoker.InvokeEnd(instance, out outputs, result);
			}

			OperationCachingInvokerAsyncResult asyncResult = result as OperationCachingInvokerAsyncResult;
			if (asyncResult == null)
			{
				throw new ArgumentException("Invalid AsyncResult", "result");
			}
			OperationCachingInvokerAsyncResult.End(asyncResult);

			if (asyncResult.IsNewResult)
			{
				OperationCacheKey key = new OperationCacheKey(asyncResult.Action, asyncResult.Inputs);
				OperationCacheValue value = new OperationCacheValue(asyncResult.Outputs, asyncResult.ReturnValue);
				OperationCache.Insert(key, value);
			}

			outputs = asyncResult.Outputs;
			return asyncResult.ReturnValue;
		}

        public object[] AllocateInputs()
        {
            return InnerOperationInvoker.AllocateInputs();
        }

		#endregion
    }
}
