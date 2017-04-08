
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Net;

    class HttpCookieRequestSessionChannel : 
        LayeredChannel<IRequestChannel>
        , IRequestSessionChannel
    {
        bool exchangeTerminateMessage;
        HttpCookieOutputSession session;         

        public HttpCookieRequestSessionChannel(HttpCookieSessionChannelFactory parent, 
            IRequestChannel innerChannel) 
            : base(parent, innerChannel)
        {
            this.exchangeTerminateMessage = parent.ExchangeTerminateMessage;
            this.session = new HttpCookieOutputSession();
        }

        // <Snippet0>
        public EndpointAddress RemoteAddress
        {
            get { return this.InnerChannel.RemoteAddress; }
        }
        // </Snippet0>

        public IOutputSession Session
        {
            get { return this.session; }
        }

        // <Snippet1>
        public Uri Via
        {
            get { return this.InnerChannel.Via; }
        }
        // </Snippet1>

        // <Snippet2>
        public IAsyncResult BeginRequest(Message message,
            AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginRequest(message,
                callback, state);
        }
        // </Snippet2>

        // <Snippet3>
        public IAsyncResult BeginRequest(Message message,
            TimeSpan timeout, AsyncCallback callback,
            object state)
        {
            return this.InnerChannel.BeginRequest(message,
                timeout, callback, state);
        }
        // </Snippet3>

        // <Snippet4>
        public Message EndRequest(IAsyncResult result)
        {
            return this.InnerChannel.EndRequest(result);
        }
        // </Snippet4>

        // <Snippet5>
        public Message Request(Message message)
        {
            return this.InnerChannel.Request(message);
        }
        // </Snippet5>

        // <Snippet6>
        public Message Request(Message message, TimeSpan timeout)
        {
            return this.InnerChannel.Request(message, timeout);
        }
        // </Snippet6>

        protected override IAsyncResult OnBeginClose(
            TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new ChainedAsyncResult(timeout, callback, state,
                BeginExchangeTerminateMessage, EndExchangeTerminateMessage,
                base.OnBeginClose, base.OnEndClose);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            ChainedAsyncResult.End(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            if (exchangeTerminateMessage)
            {
                Message terminateSessionResponse = InnerChannel.Request(
                    CreateTerminateSessionRequest(), 
                    timeoutHelper.RemainingTime());
                ValidateTerminateSessionResponse(terminateSessionResponse);
            }
            base.Close(timeoutHelper.RemainingTime()); 
        }

        IAsyncResult BeginExchangeTerminateMessage(
            TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new ExchangeTerminateMessageAsyncResult(this, timeout, callback, state);
        }

        void EndExchangeTerminateMessage(IAsyncResult result)
        {
            ExchangeTerminateMessageAsyncResult.End(result);
        }

        Message CreateTerminateSessionRequest()
        {
            return Message.CreateMessage(this.GetProperty<MessageVersion>(),
                HttpCookieSessionBindingElement.TerminateAction, "");
        }

        void ValidateTerminateSessionResponse(Message message)
        {
            // Check whether the response message contains the Ack header.
            if (message != null)
            {
                if (message.Headers.Action == HttpCookieSessionBindingElement.TerminateReplyAction)
                {
                    return; // success
                }

                // Sction does not exist, check for the custom header.
                if (message.Headers.FindHeader("TerminateAck",
                    HttpCookieSessionBindingElement.TerminateReplyAction) >= 0)
                {
                    return;
                }
            }

            throw new CommunicationException(
                "Did not received the expected response to our terminate-session request, so shutdown has failed.");
        }

        class ExchangeTerminateMessageAsyncResult : AsyncResult
        {
            HttpCookieRequestSessionChannel channel;

            public ExchangeTerminateMessageAsyncResult(HttpCookieRequestSessionChannel channel,
                TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                if (!channel.exchangeTerminateMessage)
                {
                    base.Complete(true);
                    return;
                }

                this.channel = channel;
                Message terminateSessionRequest = channel.CreateTerminateSessionRequest();
                IAsyncResult result = channel.InnerChannel.BeginRequest(
                    terminateSessionRequest, timeout, new AsyncCallback(OnSendRequest), null);

                if (!result.CompletedSynchronously)
                {
                    return;
                }

                OnSendRequestCore(result);
                base.Complete(true);
            }

            public static void End(IAsyncResult result)
            {
                AsyncResult.End<ExchangeTerminateMessageAsyncResult>(result);
            }

            void OnSendRequest(IAsyncResult result)
            {
                if (result.CompletedSynchronously)
                {
                    return;
                }

                Exception completionException = null;
                try
                {
                    OnSendRequestCore(result);
                }
                catch (Exception e)
                {
                    completionException = e;
                }

                base.Complete(false, completionException);
            }

            void OnSendRequestCore(IAsyncResult result)
            {
                Message terminateSessionResponse = this.channel.InnerChannel.EndRequest(result);
                channel.ValidateTerminateSessionResponse(terminateSessionResponse);
            }
        }

        class HttpCookieOutputSession : IOutputSession
        {
            string id;

            public HttpCookieOutputSession()
            {
                this.id = Guid.NewGuid().ToString();
            }

            public string Id
            {
                get { return this.id; }
            }
        }
    }
}
