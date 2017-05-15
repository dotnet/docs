
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Collections.Generic;
    using System.Threading;

    class HttpCookieReplySessionChannel 
        : ChannelBase, IReplySessionChannel
    {
        EndpointAddress localAddress;
        HttpCookieReplySessionChannelListener parent;
        InputQueue<RequestContext> requestQueue;
        HttpCookieReplySession session;
        TimeSpan sessionTimeout;

        public HttpCookieReplySessionChannel(HttpCookieReplySessionChannelListener parent, EndpointAddress localAddress) 
            : base(parent)
        {
            this.parent = parent;
            this.localAddress = localAddress;
            this.sessionTimeout = parent.SessionTimeout;
            this.session = new HttpCookieReplySession();
            this.requestQueue = new InputQueue<RequestContext>();
        }

        public EndpointAddress LocalAddress
        {
            get { return localAddress; }
        }

        public IInputSession Session
        {
            get { return this.session; }
        }

        protected override void OnAbort()
        {
            this.requestQueue.Close();
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.requestQueue.Close();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.requestQueue.Close();
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
        {
            return BeginReceiveRequest(this.DefaultReceiveTimeout, callback, state);
        }
        
        public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            ValidateTimeSpan(timeout);
            return new ReceiveRequestAsyncResult(this, timeout, callback, state);
        }

        public RequestContext EndReceiveRequest(IAsyncResult result)
        {
            return ReceiveRequestAsyncResult.End(result);
        }

        public IAsyncResult BeginTryReceiveRequest(
            TimeSpan timeout, AsyncCallback callback, 
            object state)
        {
            ValidateTimeSpan(timeout);
            return this.requestQueue.BeginDequeue(timeout, callback, state);
        }

        public bool EndTryReceiveRequest(IAsyncResult result,
            out RequestContext context)
        {
            return this.requestQueue.EndDequeue(result, out context);
        }

        public RequestContext ReceiveRequest()
        {
            return ReceiveRequest(DefaultReceiveTimeout);
        }

        public RequestContext ReceiveRequest(TimeSpan timeout)
        {
            ValidateTimeSpan(timeout);
            return this.requestQueue.Dequeue(timeout);
        }

        public bool TryReceiveRequest(TimeSpan timeout, 
            out RequestContext context)
        {
            ValidateTimeSpan(timeout);
            return this.requestQueue.Dequeue(timeout, out context);
        }

        public IAsyncResult BeginWaitForRequest(
            TimeSpan timeout, AsyncCallback callback,
            object state)
        {
            return this.requestQueue.BeginWaitForItem(timeout, callback, state);
        }

        public bool EndWaitForRequest(IAsyncResult result)
        {
            return this.requestQueue.EndWaitForItem(result);
        }

        public bool WaitForRequest(TimeSpan timeout)
        {
            return this.requestQueue.WaitForItem(timeout);
        }

        public void Enqueue(RequestContext item, ItemDequeuedCallback dequeuedCallback)
        {
            this.requestQueue.EnqueueAndDispatch(item, dequeuedCallback);
        }

        static void ValidateTimeSpan(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("timeout", timeout,
                    "Timeout must be greater than or equal to TimeSpan.Zero. To disable timeout, specify TimeSpan.MaxValue.");
            }
        }

        class ReceiveRequestAsyncResult : AsyncResult
        {
            IReplyChannel channel;
            TimeSpan timeout;
            static AsyncCallback onReceiveRequest = new AsyncCallback(OnReceiveRequest);
            RequestContext requestContext;

            public ReceiveRequestAsyncResult(IReplyChannel channel, TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.channel = channel;
                this.timeout = timeout;
                IAsyncResult result = channel.BeginTryReceiveRequest(timeout, onReceiveRequest, this);

                if (!result.CompletedSynchronously)
                {
                    return;
                }

                OnReceiveRequestCore(result);
                base.Complete(true);
            }

            public static RequestContext End(IAsyncResult result)
            {
                ReceiveRequestAsyncResult thisPtr = AsyncResult.End<ReceiveRequestAsyncResult>(result);
                return thisPtr.requestContext;
            }

            void OnReceiveRequestCore(IAsyncResult result)
            {
                if (!this.channel.EndTryReceiveRequest(result, out this.requestContext))
                {
                    throw new TimeoutException(string.Format("Receive request timed out after {0}.", timeout));
                }
            }

            static void OnReceiveRequest(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                ReceiveRequestAsyncResult thisPtr = (ReceiveRequestAsyncResult)result.AsyncState;
                Exception completionException = null;
                try
                {
                    thisPtr.OnReceiveRequestCore(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                }

                thisPtr.Complete(false, completionException);
            }
        }
    }
}
