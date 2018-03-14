
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    class InterceptingInputChannel<TChannel>
        : InterceptingChannelBase<TChannel>, IInputChannel
        where TChannel : class, IInputChannel
    {
        public InterceptingInputChannel(
            ChannelManagerBase manager, ChannelMessageInterceptor interceptor, TChannel innerChannel)
            : base(manager, interceptor, innerChannel)
        {
            // empty
        }

        // <Snippet12>
        public EndpointAddress LocalAddress
        {
            get
            {
                return this.InnerChannel.LocalAddress;
            }
        }
        // </Snippet12>

        bool ProcessReceivedMessage(ref Message message)
        {
            Message originalMessage = message;
            this.OnReceive(ref message);
            return (message != null || originalMessage == null);
        }

        // <Snippet13>
        public Message Receive()
        {
            return Receive(DefaultReceiveTimeout);
        }
        // </Snippet13>

        // <Snippet14>
        public Message Receive(TimeSpan timeout)
        {
            Message message;
            while (true)
            {
                message = this.InnerChannel.Receive(timeout);
                if (ProcessReceivedMessage(ref message))
                {
                    break;
                }
            }

            return message;
        }
        // </Snippet14>

        // <Snippet15>
        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return BeginReceive(DefaultReceiveTimeout, callback, state);
        }
        // </Snippet15>

        // <Snippet16>
        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            ReceiveAsyncResult<TChannel> result = new ReceiveAsyncResult<TChannel>(this, timeout, callback, state);
            result.Begin();
            return result;
        }
        // </Snippet16>

        // <Snippet17>
        public Message EndReceive(IAsyncResult result)
        {
            return ReceiveAsyncResult<TChannel>.End(result);
        }
        // </Snippet17>

        // <Snippet18>
        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            bool result;
            while (true)
            {
                result = this.InnerChannel.TryReceive(timeout, out message);
                if (ProcessReceivedMessage(ref message))
                {
                    break;
                }
            }

            return result;
        }
        // </Snippet18>

        // <Snippet19>
        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            TryReceiveAsyncResult<TChannel> result = new TryReceiveAsyncResult<TChannel>(this, timeout, callback, state);
            result.Begin();
            return result;
        }
        // </Snippet19>

        // <Snippet20>
        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            return TryReceiveAsyncResult<TChannel>.End(result, out message);
        }
        // </Snippet20>

        // <Snippet21>
        public bool WaitForMessage(TimeSpan timeout)
        {
            return this.InnerChannel.WaitForMessage(timeout);
        }
        // </Snippet21>

        // <Snippet22>
        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginWaitForMessage(timeout, callback, state);
        }
        // </Snippet22>

        // <Snippet23>
        public bool EndWaitForMessage(IAsyncResult result)
        {
            return this.InnerChannel.EndWaitForMessage(result);
        }
        // </Snippet23>

        abstract class ReceiveAsyncResultBase<TInputChannel> : AsyncResult
            where TInputChannel : class, IInputChannel
        {
            Message message;
            InterceptingInputChannel<TInputChannel> channel;
            AsyncCallback onReceive;

            protected ReceiveAsyncResultBase(InterceptingInputChannel<TInputChannel> channel,
                AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.channel = channel;
                this.onReceive = new AsyncCallback(OnReceive);
            }

            protected Message Message
            {
                get { return this.message; }
            }

            public void Begin()
            {
                IAsyncResult result = BeginReceive(onReceive, null);
                if (result.CompletedSynchronously)
                {
                    if (HandleReceiveComplete(result))
                    {
                        base.Complete(true);
                    }
                }
            }

            protected abstract IAsyncResult BeginReceive(AsyncCallback callback, object state);
            protected abstract Message EndReceive(IAsyncResult result);

            bool HandleReceiveComplete(IAsyncResult result)
            {
                while (true)
                {
                    this.message = EndReceive(result);
                    if (channel.ProcessReceivedMessage(ref message))
                    {
                        return true;
                    }

                    // try again
                    result = BeginReceive(onReceive, null);
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

        class TryReceiveAsyncResult<TInputChannel> : ReceiveAsyncResultBase<TInputChannel>
            where TInputChannel : class, IInputChannel
        {
            TInputChannel innerChannel;
            TimeSpan timeout;
            bool returnValue;

            public TryReceiveAsyncResult(InterceptingInputChannel<TInputChannel> channel, TimeSpan timeout,
                AsyncCallback callback, object state)
                : base(channel, callback, state)
            {
                this.innerChannel = channel.InnerChannel;
                this.timeout = timeout;
            }

            protected override IAsyncResult BeginReceive(AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginTryReceive(this.timeout, callback, state);
            }

            protected override Message EndReceive(IAsyncResult result)
            {
                Message message;
                this.returnValue = this.innerChannel.EndTryReceive(result, out message);
                return message;
            }

            public static bool End(IAsyncResult result, out Message message)
            {
                TryReceiveAsyncResult<TInputChannel> thisPtr = AsyncResult.End<TryReceiveAsyncResult<TInputChannel>>(result);
                message = thisPtr.Message;
                return thisPtr.returnValue;
            }
        }

        class ReceiveAsyncResult<TInputChannel> : ReceiveAsyncResultBase<TInputChannel>
           where TInputChannel : class, IInputChannel
        {
            TInputChannel innerChannel;
            TimeSpan timeout;

            public ReceiveAsyncResult(InterceptingInputChannel<TInputChannel> channel, TimeSpan timeout,
                AsyncCallback callback, object state)
                : base(channel, callback, state)
            {
                this.innerChannel = channel.InnerChannel;
                this.timeout = timeout;
            }

            protected override IAsyncResult BeginReceive(AsyncCallback callback, object state)
            {
                return this.innerChannel.BeginReceive(this.timeout, callback, state);
            }

            protected override Message EndReceive(IAsyncResult result)
            {
                return this.innerChannel.EndReceive(result);
            }

            public static Message End(IAsyncResult result)
            {
                ReceiveAsyncResult<TInputChannel> thisPtr = AsyncResult.End<ReceiveAsyncResult<TInputChannel>>(result);
                return thisPtr.Message;
            }
        }
    }

    class InterceptingDuplexChannel
        : InterceptingInputChannel<IDuplexChannel>, IDuplexChannel
    {
        public InterceptingDuplexChannel(
            ChannelManagerBase manager, ChannelMessageInterceptor interceptor, IDuplexChannel innerChannel)
            : base(manager, interceptor, innerChannel)
        {
            // empty
        }

        public EndpointAddress RemoteAddress
        {
            get
            {
                return this.InnerChannel.RemoteAddress;
            }
        }

        public Uri Via
        {
            get
            {
                return this.InnerChannel.Via;
            }
        }

        public void Send(Message message)
        {
            Send(message, DefaultSendTimeout);
        }

        public void Send(Message message, TimeSpan timeout)
        {
            this.OnSend(ref message);
            this.InnerChannel.Send(message, timeout);
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            return BeginSend(message, DefaultSendTimeout, callback, state);
        }

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.OnSend(ref message);
            return this.InnerChannel.BeginSend(message, timeout, callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            this.InnerChannel.EndSend(result);
        }
    }


    class InterceptingDuplexSessionChannel : InterceptingDuplexChannel, IDuplexSessionChannel
    {
        IDuplexSessionChannel innerSessionChannel;

        public InterceptingDuplexSessionChannel(
            ChannelManagerBase manager, ChannelMessageInterceptor interceptor, IDuplexSessionChannel innerChannel)
            : base(manager, interceptor, innerChannel)
        {
            this.innerSessionChannel = innerChannel;
        }

        public IDuplexSession Session
        {
            get
            {
                return this.innerSessionChannel.Session;
            }
        }
    }
}
