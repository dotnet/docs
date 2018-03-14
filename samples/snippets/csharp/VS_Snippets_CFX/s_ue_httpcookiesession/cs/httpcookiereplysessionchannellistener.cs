
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Collections.Generic;
    using System.Collections;
    using System.Net;
    using System.Threading;

    class HttpCookieReplySessionChannelListener : 
        ChannelListenerBase<IReplySessionChannel>
    {
        // Tracks mapping session ID->Channel.
        Dictionary<string, HttpCookieReplySessionChannel> channelMapping;

        // Channels that have been created but not accepted.
        InputQueue<IReplySessionChannel> channelQueue;

        bool exchangeTerminateMessage;
        IReplyChannel innerChannel;
        IChannelListener<IReplyChannel> innerChannelListener;
        TimeSpan sessionTimeout;
        AsyncCallback onReceiveRequest;
        EventHandler onInnerChannelClosed;
        ItemDequeuedCallback onItemDequeued;
        WaitCallback completeReceiveCallback;

        public HttpCookieReplySessionChannelListener(
            HttpCookieSessionBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            this.innerChannelListener = context.BuildInnerChannelListener<IReplyChannel>(); ;
            this.sessionTimeout = bindingElement.SessionTimeout;
            this.exchangeTerminateMessage = bindingElement.ExchangeTerminateMessage;
            this.channelMapping = new Dictionary<string, HttpCookieReplySessionChannel>();
            this.channelQueue = new InputQueue<IReplySessionChannel>();
            this.onReceiveRequest = new AsyncCallback(OnReceiveRequest);
            this.onInnerChannelClosed = new EventHandler(OnInnerChannelClosed);
            this.onItemDequeued = new ItemDequeuedCallback(OnItemDequeued);
        }

        internal TimeSpan SessionTimeout
        {
            get { return this.sessionTimeout; }
        }

        public override Uri Uri
        {
            get { return this.innerChannelListener.Uri; }
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

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new OpenAsyncResult(this, timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            OpenAsyncResult.End(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            // Because the inner listener is a Datagram (singleton) listener, we 
            // accept the singleton channel and then dispose of the listener because
            // the lifetimes are decoupled.
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            this.innerChannelListener.Open(timeoutHelper.RemainingTime());
            this.innerChannel = this.innerChannelListener.AcceptChannel(timeoutHelper.RemainingTime());
            this.innerChannel.Open(timeoutHelper.RemainingTime());
            this.innerChannelListener.Close(timeoutHelper.RemainingTime());
        }

        protected override void OnOpened()
        {
            base.OnOpened();
            this.StartReceiving();
        }

        protected override void OnAbort()
        {
            bool abortInnerChannel = false;
            lock (this.channelMapping)
            {
                // If all the accepted channels have been released, abort the inner channel.
                if (this.innerChannel != null && this.channelMapping.Count == 0)
                {
                    abortInnerChannel = true;
                }
            }

            if (abortInnerChannel)
            {
                this.innerChannel.Abort();
            }

            IChannelListener innerChannelListenerSnapshot = this.innerChannelListener;
            if (innerChannelListenerSnapshot != null)
            {
                innerChannelListenerSnapshot.Abort();
            }
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.channelQueue.BeginDequeue(timeout, callback, state);
        }

        protected override IReplySessionChannel OnEndAcceptChannel(IAsyncResult result)
        {
            return this.channelQueue.EndDequeue(result);
        }

        protected override IReplySessionChannel OnAcceptChannel(TimeSpan timeout)
        {
            return this.channelQueue.Dequeue(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CloseAsyncResult(this, timeout, callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            CloseAsyncResult.End(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            bool closeInnerChannel = false;
            lock (this.channelMapping)
            {
                // If all the accepted channels have been released, abort the inner channel.
                if (this.channelMapping.Count == 0)
                {
                    closeInnerChannel = true;
                }
            }

            if (closeInnerChannel)
            {
                this.innerChannel.Close(timeout);
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            this.channelQueue.Dispose();
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.channelQueue.BeginWaitForItem(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            return this.channelQueue.EndWaitForItem(result);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            return this.channelQueue.WaitForItem(timeout);
        }

        void OnInnerChannelClosed(object sender, EventArgs e)
        {
            // Reduce the quota and start an accept.
            IReplySessionChannel channel = (IReplySessionChannel)sender;
            channel.Closed -= this.onInnerChannelClosed;

            bool abortInnerChannel = false;
            lock (channelMapping)
            {
                channelMapping.Remove(channel.Session.Id);
                if (channelMapping.Count == 0 && this.State != CommunicationState.Opened)
                {
                    abortInnerChannel = true;
                }
            }

            if (abortInnerChannel)
            {
                this.innerChannel.Abort();
            }
        }

        // Start the receive loop.
        void StartReceiving()
        {
            IAsyncResult result = BeginInnerReceiveRequest();
            if (result != null && result.CompletedSynchronously)
            {
                // Do not block the user thread.
                if (this.completeReceiveCallback == null)
                {
                    this.completeReceiveCallback = new WaitCallback(CompleteReceiveCallback);
                }
                ThreadPool.QueueUserWorkItem(this.completeReceiveCallback, result);
            }
        }

        void OnItemDequeued()
        {
            StartReceiving();
        }

        // Add some resiliency around expected exceptions that we can handle.
        IAsyncResult BeginInnerReceiveRequest()
        {
            while (true)
            {
                if (this.State != CommunicationState.Opened)
                {
                    return null;
                }

                try
                {
                    return this.innerChannel.BeginTryReceiveRequest(TimeSpan.MaxValue, onReceiveRequest, null);
                }
                catch (CommunicationException)
                {
                    // Production code traces here.
                }
                catch (TimeoutException)
                {
                    // Production code traces here.
                }
            }
        }

        void CompleteReceiveCallback(object state)
        {
            Exception unhandledException = null;
            try
            {
                OnReceiveRequestCore((IAsyncResult)state);
            }
            catch (Exception e)
            {
                unhandledException = e;
            }

            if (unhandledException != null)
            {
                // Propagate the exception to the user asynchronously.
                this.channelQueue.EnqueueAndDispatch(unhandledException, onItemDequeued, true);
            }
        }

        void OnReceiveRequest(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
            {
                return;
            }

            Exception unhandledException = null;
            try
            {
                OnReceiveRequestCore(result);
            }
            catch (Exception e)
            {
                unhandledException = e;
            }

            if (unhandledException != null)
            {
                // Propagate the exception to the user asynchronously.
                this.channelQueue.EnqueueAndDispatch(unhandledException, onItemDequeued, true);
            }
        }

        void OnReceiveRequestCore(IAsyncResult result)
        {
            RequestContext requestContext = null;

            bool continueReceiving = false;
            bool isRequestAvailable = false;

            while (result != null) 
            {
                Exception exceptionToEnqueue = null;
                try
                {
                    if (!this.innerChannel.EndTryReceiveRequest(result, out requestContext))
                    {
                        continueReceiving = (this.innerChannel.State == CommunicationState.Opened);
                    }
                    else
                    {
                        isRequestAvailable = true;
                        continueReceiving = false;
                    }
                }
                catch (CommunicationException)
                {
                    continueReceiving = (this.innerChannel.State == CommunicationState.Opened);
                }
                catch (TimeoutException)
                {
                    continueReceiving = (this.innerChannel.State == CommunicationState.Opened);
                }
                catch (Exception e)
                {
                    exceptionToEnqueue = e;
                }

                result = null;
                if (exceptionToEnqueue != null)
                {
                    this.channelQueue.EnqueueAndDispatch(exceptionToEnqueue, onItemDequeued, true);
                }
                else if (isRequestAvailable)
                {
                    continueReceiving = ProcessRequest(requestContext);
                }

                if (continueReceiving)
                {
                    result = BeginInnerReceiveRequest();
                }
            }
        }

        string GetHttpSessionId(RequestContext requestContext)
        {
            object httpRequestProperty;

            if (!requestContext.RequestMessage.Properties.TryGetValue(
                HttpRequestMessageProperty.Name, out httpRequestProperty))
            {
                requestContext.Abort();
                throw new CommunicationException("Message received without an HttpRequestMessageProperty. HttpCookieReplySession requires a conformant Http transport to function properly.");
            }

            return ((HttpRequestMessageProperty)httpRequestProperty).Headers[HttpRequestHeader.Cookie];
        }

        // Return true if the receive loop should continue.
        bool ProcessRequest(RequestContext requestContext)
        {
            if (requestContext == null) 
            {
                // This is EOF, signal EOF to all the channels.
                HttpCookieReplySessionChannel[] channels;
                lock (this.channelMapping)
                {
                    channels = new HttpCookieReplySessionChannel[this.channelMapping.Values.Count];
                    this.channelMapping.Values.CopyTo(channels, 0);
                    this.channelMapping.Clear();
                }

                for (int i = 0; i < channels.Length; i++)
                {
                    channels[i].Enqueue((RequestContext)null, null);
                }
                return false;
            }

            // Try to read the cookie value from HTTP request headers collection.
            Message requestMessage = requestContext.RequestMessage;
            string sessionID = GetHttpSessionId(requestContext);

            HttpCookieReplySessionChannel replySessionChannel = null;
            bool newChannel = false;
            lock (channelMapping)
            {
                // See if there is an existing channel for this session.
                if (sessionID == null ||
                    !channelMapping.TryGetValue(sessionID, out replySessionChannel))
                {
                    // Otherwise create one.
                    if (State != CommunicationState.Opened)
                    {
                        return false;
                    }

                    replySessionChannel = new HttpCookieReplySessionChannel(this, innerChannel.LocalAddress);
                    replySessionChannel.Closed += this.onInnerChannelClosed;
                    channelMapping.Add(replySessionChannel.Session.Id, replySessionChannel);
                    newChannel = true;
                }
            }

            if (newChannel)
            {
                // Enqueue the new channel so that threads waiting
                // in the AcceptChannel method can pick them up.
                this.channelQueue.EnqueueAndDispatch(replySessionChannel);
            }
            else if (exchangeTerminateMessage &&
                requestMessage.Headers.Action == HttpCookieSessionBindingElement.TerminateAction)
            {
                // If both ends are WCF ends, this channel is capable 
                // of exchanging a message, when the client closes the request 
                // channel. Consequently the server is able to clean up the 
                // session channel in real-time fashion.
                // Send the terminate acknowledgment to the client.
                Message terminateResponse = Message.CreateMessage(requestMessage.Version,
                   HttpCookieSessionBindingElement.TerminateReplyAction, "");

                // For AddressingVersion.None, add a custom header because the response action is stripped.
                if (requestMessage.Version.Addressing == AddressingVersion.None)
                {
                    MessageHeader ackHeader = MessageHeader.CreateHeader("TerminateAck",
                        HttpCookieSessionBindingElement.TerminateReplyAction, "", true);

                    terminateResponse.Headers.Add(ackHeader);
                }

                requestContext.Reply(terminateResponse);
                replySessionChannel.Abort();

                return true;
            }

            HttpCookieSessionRequestContext httpRequestContext =
                new HttpCookieSessionRequestContext(requestContext, replySessionChannel.Session.Id, newChannel);

            // Enqueue the request to the session channel's message queue.
            replySessionChannel.Enqueue(httpRequestContext, onItemDequeued);

            return false;
        }

        class CloseAsyncResult : AsyncResult
        {
            IReplyChannel innerChannel;

            public CloseAsyncResult(HttpCookieReplySessionChannelListener listener, TimeSpan timeout,
                AsyncCallback callback, object state)
                : base(callback, state)
            {
                lock (listener.channelMapping)
                {
                    // If all the accepted channels have been released, abort the inner channel.
                    if (listener.innerChannel != null && listener.channelMapping.Count == 0)
                    {
                        this.innerChannel = listener.innerChannel;
                    }
                }

                if (this.innerChannel != null)
                {
                    IAsyncResult result = this.innerChannel.BeginClose(
                        timeout, new AsyncCallback(OnInnerChannelClose), null);

                    if (!result.CompletedSynchronously)
                    {
                        return;
                    }

                    this.innerChannel.EndClose(result);
                }

                base.Complete(true);
            }

            public static void End(IAsyncResult result)
            {
                AsyncResult.End<CloseAsyncResult>(result);
            }

            void OnInnerChannelClose(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                Exception completionException = null;
                try
                {
                    this.innerChannel.EndClose(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                }

                base.Complete(false, completionException);
            }
        }

        class OpenAsyncResult : AsyncResult
        {
            HttpCookieReplySessionChannelListener parent;
            TimeoutHelper timeoutHelper;

            public OpenAsyncResult(HttpCookieReplySessionChannelListener parent, TimeSpan timeout,
                AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.parent = parent;
                this.timeoutHelper = new TimeoutHelper(timeout);
                IAsyncResult result = parent.innerChannelListener.BeginOpen(timeoutHelper.RemainingTime(),
                    new AsyncCallback(OnInnerChannelListenerOpen), null);
                
                if (!result.CompletedSynchronously)
                {
                    return;
                }

                if (OnInnerChannelListenerOpenCore(result))
                {
                    base.Complete(true);
                }
            }

            public static void End(IAsyncResult result)
            {
                AsyncResult.End<OpenAsyncResult>(result);
            }

            void OnInnerChannelListenerOpen(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                Exception completionException = null;
                bool completeSelf = false;
                try
                {
                    completeSelf = OnInnerChannelListenerOpenCore(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                    completeSelf = true;
                }

                if (completeSelf)
                {
                    base.Complete(false, completionException);
                }
            }

            bool OnInnerChannelListenerOpenCore(IAsyncResult result)
            {
                parent.innerChannelListener.EndOpen(result);

                // We can call the sync overload because it is a datagram listener and we can 
                // get our singleton channel immediately.
                parent.innerChannel = parent.innerChannelListener.AcceptChannel(timeoutHelper.RemainingTime());
                IAsyncResult openChannelResult =
                    parent.innerChannel.BeginOpen(timeoutHelper.RemainingTime(), new AsyncCallback(OnInnerChannelOpen), null);
                if (!openChannelResult.CompletedSynchronously)
                {
                    return false;
                }

                return OnInnerChannelOpenCore(openChannelResult);
            }

            void OnInnerChannelOpen(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                Exception completionException = null;
                bool completeSelf = false;
                try
                {
                    completeSelf = OnInnerChannelOpenCore(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                    completeSelf = true;
                }

                if (completeSelf)
                {
                    base.Complete(false, completionException);
                }
            }

            bool OnInnerChannelOpenCore(IAsyncResult result)
            {
                parent.innerChannel.EndOpen(result);
                IAsyncResult channelCloseResult = parent.innerChannelListener.BeginClose(timeoutHelper.RemainingTime(),
                    new AsyncCallback(OnInnerChannelListenerClose), null);
                if (!channelCloseResult.CompletedSynchronously)
                {
                    return false;
                }

                return OnInnerChannelListenerCloseCore(result);
            }

            void OnInnerChannelListenerClose(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                Exception completionException = null;
                bool completeSelf = false;
                try
                {
                    completeSelf = OnInnerChannelListenerCloseCore(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                    completeSelf = true;
                }

                if (completeSelf)
                {
                    base.Complete(false, completionException);
                }
            }

            bool OnInnerChannelListenerCloseCore(IAsyncResult result)
            {
                parent.innerChannelListener.EndClose(result);
                return true;
            }
        }
    }
}
