
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Permissions;

namespace Microsoft.ServiceModel.Samples
{
    class InterceptingChannelListener<TChannel> 
        : ChannelListenerBase<TChannel>
        where TChannel : class, IChannel
    {
        ChannelMessageInterceptor interceptor;
        IChannelListener<TChannel> innerChannelListener;

        public InterceptingChannelListener(ChannelMessageInterceptor interceptor, BindingContext context)
        {
            this.interceptor = interceptor;
            this.innerChannelListener = context.BuildInnerChannelListener<TChannel>();
            if (this.innerChannelListener == null)
            {
                throw new InvalidOperationException(
                    "InterceptingChannelListener requires an inner IChannelListener.");
            }
        }

        public ChannelMessageInterceptor Interceptor
        {
            get { return this.interceptor; }
        }

        public override Uri Uri
        {
            get
            {
                return this.innerChannelListener.Uri;
            }
        }

        public override T GetProperty<T>()
        {
            T baseProperty = base.GetProperty<T>();
            if (baseProperty != null)
            {
                return baseProperty;
            }

            return this.innerChannelListener.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelListener.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannelListener.EndOpen(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.innerChannelListener.Close(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginClose(timeout, callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.innerChannelListener.EndClose(result);
        }

        protected override void OnAbort()
        {
            this.innerChannelListener.Abort();
        }

        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            TChannel innerChannel = this.innerChannelListener.AcceptChannel(timeout);
            return WrapChannel(innerChannel);
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            TChannel innerChannel = this.innerChannelListener.EndAcceptChannel(result);
            return WrapChannel(innerChannel);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            return this.innerChannelListener.WaitForChannel(timeout);
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelListener.BeginWaitForChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            return this.innerChannelListener.EndWaitForChannel(result);
        }

        TChannel WrapChannel(TChannel innerChannel)
        {
            if (innerChannel == null)
            {
                return null;
            }

            if (typeof(TChannel) == typeof(IInputChannel))
            {
                return (TChannel)(object)new InterceptingInputChannel<IInputChannel>(this, this.Interceptor, (IInputChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IReplyChannel))
            {
                return (TChannel)(object)new InterceptingReplyChannel(this, (IReplyChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexChannel))
            {
                return (TChannel)(object)new InterceptingDuplexChannel(this, Interceptor, (IDuplexChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IInputSessionChannel))
            {
                return (TChannel)(object)new InterceptingInputSessionChannel(this,
                    (IInputSessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IReplySessionChannel))
            {
                return (TChannel)(object)new InterceptingReplySessionChannel(this,
                    (IReplySessionChannel)innerChannel);
            }
            else if (typeof(TChannel) == typeof(IDuplexSessionChannel))
            {
                return (TChannel)(object)new InterceptingDuplexSessionChannel(this, Interceptor, 
                    (IDuplexSessionChannel)innerChannel);
            }

            // Cannot wrap this channel.
            return innerChannel;
        }

        class InterceptingReplyChannel : InterceptingChannelBase<IReplyChannel>, IReplyChannel
        {
            public InterceptingReplyChannel(
                InterceptingChannelListener<TChannel> listener, IReplyChannel innerChannel)
                : base(listener, listener.Interceptor, innerChannel)
            {
                // empty
            }

            // <Snippet0>
            public EndpointAddress LocalAddress
            {
                get
                {
                    return this.InnerChannel.LocalAddress;
                }
            }
            // </Snippet0>

            // <Snippet7>
            public RequestContext ReceiveRequest()
            {
                return ReceiveRequest(DefaultReceiveTimeout);
            }
            // </Snippet7>

            // <Snippet8>
            public RequestContext ReceiveRequest(TimeSpan timeout)
            {
                RequestContext requestContext;
                while (true)
                {
                    requestContext = this.InnerChannel.ReceiveRequest(timeout);
                    if (ProcessRequestContext(ref requestContext))
                    {
                        break;
                    }
                }

                return requestContext;
            }
            // </Snippet8>

            // <Snippet1>
            public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
            {
                return BeginReceiveRequest(DefaultReceiveTimeout, callback, state);
            }
            // </Snippet1>

            // <Snippet2>
            public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                ReceiveRequestAsyncResult result = new ReceiveRequestAsyncResult(this, timeout, callback, state);
                result.Begin();
                return result;
            }
            // </Snippet2>

            // <Snippet3>
            public RequestContext EndReceiveRequest(IAsyncResult result)
            {
                return ReceiveRequestAsyncResult.End(result);
            }
            // </Snippet3>

            // <Snippet4>
            public bool TryReceiveRequest(TimeSpan timeout, out RequestContext requestContext)
            {
                bool result;

                while (true)
                {
                    result = this.InnerChannel.TryReceiveRequest(timeout, out requestContext);
                    if (!result || ProcessRequestContext(ref requestContext))
                    {
                        break;
                    }
                }

                return result;
            }
            // </Snippet4>

            // <Snippet5>
            public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                TryReceiveRequestAsyncResult result = new TryReceiveRequestAsyncResult(this, timeout, callback, state);
                result.Begin();
                return result;
            }
            // </Snippet5>

            // <Snippet6>
            public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext requestContext)
            {
                return TryReceiveRequestAsyncResult.End(result, out requestContext);
            }
            // </Snippet6>

            // <Snippet9>
            public bool WaitForRequest(TimeSpan timeout)
            {
                return this.InnerChannel.WaitForRequest(timeout);
            }
            // </Snippet9>

            // <Snippet10>
            public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginWaitForRequest(timeout, callback, state);
            }
            // </Snippet10>

            // <Snippet11>
            public bool EndWaitForRequest(IAsyncResult result)
            {
                return this.InnerChannel.EndWaitForRequest(result);
            }
            // </Snippet11>

            bool ProcessRequestContext(ref RequestContext requestContext)
            {
                if (requestContext == null)
                {
                    return true;
                }

                Message m = requestContext.RequestMessage;
                Message originalMessage = m;
                
                this.OnReceive(ref m);
                if (m != null || originalMessage == null)
                {
                    requestContext = new InterceptingRequestContext(this, requestContext);
                }
                else
                {
                    requestContext.Abort();
                    requestContext = null;
                }
                
                return requestContext != null;
            }

            abstract class ReceiveRequestAsyncResultBase : AsyncResult
            {
                RequestContext requestContext;
                InterceptingReplyChannel channel;
                AsyncCallback onReceive;

                protected ReceiveRequestAsyncResultBase(InterceptingReplyChannel channel,
                    AsyncCallback callback, object state)
                    : base(callback, state)
                {
                    this.channel = channel;
                    this.onReceive = new AsyncCallback(OnReceive);
                }

                protected RequestContext RequestContext
                {
                    get { return this.requestContext; }
                }

                public void Begin()
                {
                    IAsyncResult result = BeginReceiveRequest(onReceive, null);
                    if (result.CompletedSynchronously)
                    {
                        if (HandleReceiveComplete(result))
                        {
                            base.Complete(true);
                        }
                    }
                }

                protected abstract IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state);
                protected abstract RequestContext EndReceiveRequest(IAsyncResult result);

                bool HandleReceiveComplete(IAsyncResult result)
                {
                    while (true)
                    {
                        this.requestContext = EndReceiveRequest(result);
                        if (channel.ProcessRequestContext(ref requestContext))
                        {
                            return true;
                        }

                        // try again
                        result = BeginReceiveRequest(onReceive, null);
                        if (!result.CompletedSynchronously)
                        {
                            return false;
                        }
                    }
                }

                void OnReceive(IAsyncResult result)
                {
                    if (result.CompletedSynchronously)
                    {
                        return;
                    }

                    bool completeSelf = false;
                    Exception completeException = null;
                    try
                    {
                        completeSelf = HandleReceiveComplete(result);
                    }
                    catch (Exception e)
                    {
                        completeException = e;
                        completeSelf = true;
                    }

                    if (completeSelf)
                    {
                        base.Complete(false, completeException);
                    }
                }
            }

            class TryReceiveRequestAsyncResult : ReceiveRequestAsyncResultBase
            {
                IReplyChannel innerChannel;
                TimeSpan timeout;
                bool returnValue;

                public TryReceiveRequestAsyncResult(InterceptingReplyChannel channel, TimeSpan timeout,
                    AsyncCallback callback, object state)
                    : base(channel, callback, state)
                {
                    this.innerChannel = channel.InnerChannel;
                    this.timeout = timeout;
                }

                protected override IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
                {
                    return this.innerChannel.BeginTryReceiveRequest(this.timeout, callback, state);
                }

                protected override RequestContext EndReceiveRequest(IAsyncResult result)
                {
                    RequestContext requestContext;
                    this.returnValue = this.innerChannel.EndTryReceiveRequest(result, out requestContext);
                    return requestContext;
                }

                public static bool End(IAsyncResult result, out RequestContext requestContext)
                {
                    TryReceiveRequestAsyncResult thisPtr = AsyncResult.End<TryReceiveRequestAsyncResult>(result);
                    requestContext = thisPtr.RequestContext;
                    return thisPtr.returnValue;
                }
            }

            class ReceiveRequestAsyncResult : ReceiveRequestAsyncResultBase
            {
                IReplyChannel  innerChannel;
                TimeSpan timeout;

                public ReceiveRequestAsyncResult(InterceptingReplyChannel channel, TimeSpan timeout, AsyncCallback callback, object state)
                    : base(channel, callback, state)
                {
                    this.innerChannel = channel.InnerChannel;
                    this.timeout = timeout;
                }

                protected override IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
                {
                    return this.innerChannel.BeginReceiveRequest(this.timeout, callback, state);
                }

                protected override RequestContext EndReceiveRequest(IAsyncResult result)
                {
                    return this.innerChannel.EndReceiveRequest(result);
                }

                public static RequestContext End(IAsyncResult result)
                {
                    ReceiveRequestAsyncResult thisPtr = AsyncResult.End<ReceiveRequestAsyncResult>(result);
                    return thisPtr.RequestContext;
                }
            }


            class InterceptingRequestContext : RequestContext
            {
                InterceptingReplyChannel channel;
                RequestContext innerContext;

                public InterceptingRequestContext(InterceptingReplyChannel channel, RequestContext innerContext)
                {
                    this.channel = channel;
                    this.innerContext = innerContext;
                }

                public override Message RequestMessage
                {
                    get
                    {
                        return this.innerContext.RequestMessage;
                    }
                }

                public override void Abort()
                {
                    this.innerContext.Abort();
                }

                public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
                {
                    return BeginReply(message, channel.DefaultSendTimeout, callback, state);
                }

                public override IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
                {
                    Message m = message;
                    this.OnSend(ref m);
                    return this.innerContext.BeginReply(m, timeout, callback, state);
                }

                public override void Close()
                {
                    this.innerContext.Close();
                }

                public override void Close(TimeSpan timeout)
                {
                    this.innerContext.Close(timeout);
                }

                protected override void Dispose(bool disposing)
                {
                    try
                    {
                        if(disposing)
                             ((IDisposable)this.innerContext).Dispose();
                    }
                    finally
                    {
                        base.Dispose(disposing);
                    }
                }

                public override void EndReply(IAsyncResult result)
                {
                    this.innerContext.EndReply(result);
                }

                void OnSend(ref Message message)
                {
                    this.channel.OnSend(ref message);
                }

                public override void Reply(Message message)
                {
                    Reply(message, channel.DefaultSendTimeout);
                }

                public override void Reply(Message message, TimeSpan timeout)
                {
                    Message m = message;
                    this.OnSend(ref m);
                    this.innerContext.Reply(m, timeout);
                }
            }
        }

        class InterceptingInputSessionChannel : InterceptingInputChannel<IInputSessionChannel>, IInputSessionChannel
        {
            IInputSessionChannel innerSessionChannel;

            public InterceptingInputSessionChannel(
                InterceptingChannelListener<TChannel> listener, IInputSessionChannel innerChannel)
                : base(listener, listener.Interceptor, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IInputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }

        class InterceptingReplySessionChannel : InterceptingReplyChannel, IReplySessionChannel
        {
            IReplySessionChannel innerSessionChannel;

            public InterceptingReplySessionChannel(
                InterceptingChannelListener<TChannel> listener, IReplySessionChannel innerChannel)
                : base(listener, innerChannel)
            {
                this.innerSessionChannel = innerChannel;
            }

            public IInputSession Session
            {
                get
                {
                    return this.innerSessionChannel.Session;
                }
            }
        }
    }
}
