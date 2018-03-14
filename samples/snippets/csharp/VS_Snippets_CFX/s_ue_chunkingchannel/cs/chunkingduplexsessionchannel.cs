
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Microsoft.Samples.ChannelHelpers;
using System.Xml;
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    public class ChunkingDuplexSessionChannel : ChannelBase, IDuplexSessionChannel
    {
        #region member variables
        //used by both send and receive
        IDuplexSessionChannel innerChannel;
        ICollection<string> operationParams;

        //used by receive
        int maxBufferedChunks; //max number of input chunks to be buffered
        bool stopReceive = false; //whether chunks receive loop should stop
        ChunkingMessage currentInputMessage; //current message that's being chunked in
        ManualResetEvent receiveStopped = new ManualResetEvent(true); //indicates chunk receive loop has stopped
        ManualResetEvent currentMessageCompleted = new ManualResetEvent(true); //indicates current message completed and chunk receive loop stopped

        //used by send
        ManualResetEvent sendingDone = new ManualResetEvent(true);

        #endregion

        #region Constructor
        internal ChunkingDuplexSessionChannel(ChannelManagerBase channelManager, 
            IDuplexSessionChannel innerChannel, ICollection<string> operationParams,
            int maxBufferedChunks)
            : base(channelManager)
        {
            this.Initialize(channelManager, innerChannel, operationParams, maxBufferedChunks);
        }
        void Initialize(ChannelManagerBase channelManager, 
            IDuplexSessionChannel innerChannel, ICollection<string> operationParams,
            int maxBufferedChunks)
        {
            this.innerChannel = innerChannel;
            this.operationParams = operationParams;
            this.maxBufferedChunks = maxBufferedChunks;
        }
        #endregion

        #region CommunicationObject overrides
        protected override void OnOpen(TimeSpan timeout)
        {
            innerChannel.Open(timeout);
        }
        protected override void OnClose(TimeSpan timeout)
        {
            this.stopReceive=true;
            //wait for receive to stop so we can have a clean shutdown
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            if (this.receiveStopped.WaitOne(TimeoutHelper.ToMilliseconds(timeoutHelper.RemainingTime()), false))
            {
                innerChannel.Close(timeoutHelper.RemainingTime());
            }
            else
            {
                throw new TimeoutException("Close timeout exceeded");
            }
            
            //we don't call base.OnClose because it does nothing
        }
        protected override void OnAbort()
        {
            innerChannel.Abort();
            //we don't call base.OnAbort because it does nothing
        }
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerChannel.BeginOpen(timeout, callback, state);
        }
        protected override void OnEndOpen(IAsyncResult result)
        {
            innerChannel.EndOpen(result);
        }
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            // TO DO should stop the receive loop asynchronously            
            return innerChannel.BeginClose(timeout, callback, state);
        }
        protected override void OnEndClose(IAsyncResult result)
        {
            innerChannel.EndClose(result);
        }

        public override T GetProperty<T>()
        {
            return innerChannel.GetProperty<T>();
        }

        #endregion

        #region Receive chunks loop
        void ReceiveChunkLoop(object state)
        {
            TimeoutHelper timeouthelper = (TimeoutHelper)state;
            //receive loop on a worker thread
            Message message = null;
            do
            {
                //don't pass default timeout so that we can react to stopReceive
                //which will be set from Close
                message = innerChannel.Receive(timeouthelper.RemainingTime());
                if (message == null)
                {
                    //a null message should not have been chunked to begin with
                    throw new CommunicationException("A null chunk message was received. Null message indicates the end of a session so a null chunk should never be received");
                }

                //add this chunk to current message
                //this can throw a TimeoutException if 
                ProcessReceivedChunk(message);

                if (IsLastChunk(message))
                {
                    //we're done with the current message
                    this.currentMessageCompleted.Set();
                    this.currentInputMessage = null;
                    //stop this chunk receive loop
                    //will start again when above layer calls Receive and a new message is received
                    this.stopReceive = true;
                }
            //stopReceive is Set if stopClose is called or if we received the endChunk message
            //also stop if we received a null message indicating the session was closed
            } while (!stopReceive &&  message != null); 
            receiveStopped.Set();
        }
        #endregion

        #region Handling received messages
        ChunkingMessage GetNewChunkingMessage(Message receivedMessage, TimeoutHelper timeoutHelper)
        {
            if (receivedMessage == null)
            {
                //end of session
                return null;
            }
            Guid messageId = GetMessageId(receivedMessage);
            if (this.currentInputMessage != null && messageId == this.currentInputMessage.MessageId)
            {
                throw new InvalidOperationException("A new ChunkingMessage was requested but the received message's id matches the current message id. The received message is a chunk of the current message");
            }
            ChunkingReader reader = new ChunkingReader(receivedMessage, this.maxBufferedChunks,timeoutHelper);

            string originalAction = receivedMessage.Headers.GetHeader<string>(
                            ChunkingUtils.OriginalAction,
                            ChunkingUtils.ChunkNs);
            ChunkingMessage dechunkedMessage = new ChunkingMessage(receivedMessage.Version, originalAction, reader, messageId);

            string addressingNs = ChunkingUtils.GetAddressingNamespace(receivedMessage.Version);
            //read original headers from body of startingChunk and add them to headers of dechunkedMessage
            for (int i = 0; i < receivedMessage.Headers.Count; i++)
            {
                MessageHeaderInfo headerInfo = receivedMessage.Headers[i];
                if (headerInfo.Namespace != ChunkingUtils.ChunkNs &&
                    !(headerInfo.Name == "Action" && headerInfo.Namespace == addressingNs))
                {
                    //not a chunking header and not the chunking wsa:Action header
                    //copy it to dechunkedMessage
                    dechunkedMessage.Headers.CopyHeaderFrom(
                        receivedMessage.Headers, i);
                }
            }
            return dechunkedMessage;
        }
        private bool IsNewMessage(Message receivedMessage)
        {
            if (receivedMessage == null)
            {
                //invalid
                throw new ArgumentException("IsNewMessage should not be passed a null message", "receivedMessage");
            }
            Guid messageId = GetMessageId(receivedMessage);
            return (this.currentInputMessage == null || this.currentInputMessage.MessageId != messageId);
        }
        private bool IsLastChunk(Message receivedMessage)
        {
            if (receivedMessage == null)
            {
                //invalid
                throw new ArgumentException("IsLastChunk should not be passed a null message", "receivedMessage");
            }
            return (receivedMessage.Headers.FindHeader(ChunkingUtils.ChunkingEndHeader, ChunkingUtils.ChunkNs) > -1);

        }
        private bool IsChunkInCurrentMessage(Message receivedMessage)
        {
            if (receivedMessage == null)
            {
                //invalid
                throw new ArgumentException("IsChunkInCurrentMessage should not be passed a null message", "receivedMessage");
            }
            return (!IsNewMessage(receivedMessage));
        }
        private Guid GetMessageId(Message receivedMessage)
        {
            if (receivedMessage == null)
            {
                //invalid
                throw new ArgumentException("GetMessageId should not be passed a null message", "receivedMessage");
            }
            return receivedMessage.Headers.GetHeader<Guid>(ChunkingUtils.MessageIdHeader, ChunkingUtils.ChunkNs);

        }
        private void ProcessReceivedChunk(Message receivedMessage)
        {
            if (receivedMessage == null)
            {
                //invalid
                throw new ArgumentException("ProcessReceivedChunk should not be passed a null message", "receivedMessage");
            }

            if (IsChunkInCurrentMessage(receivedMessage))
            {
                //just another chunk in current message
                this.currentInputMessage.UnderlyingReader.AddMessage(receivedMessage);
            }
            else
            {
                throw new InvalidOperationException("ProcessReceivedChunk was passed a chunk that doesn't belong to the current message");
            }
        }
        #endregion

        #region IInputChannel Members
        public Message Receive(TimeSpan timeout)
        {
            ThrowIfDisposedOrNotOpen();

            //if we're receiving chunks, wait till that's done
            TimeoutHelper helper = new TimeoutHelper(timeout);

            if (!this.currentMessageCompleted.WaitOne(TimeoutHelper.ToMilliseconds(timeout),false))
            {
                throw new TimeoutException("Receive timed out waiting for previous message receive to complete");
            }

            //call receive on inner channel
            Message message = innerChannel.Receive(helper.RemainingTime());
            if (message != null && message.Headers.Action == ChunkingUtils.ChunkAction)
            {
                this.currentInputMessage = GetNewChunkingMessage(message, helper);
                //start receiving chunks again
                this.currentMessageCompleted.Reset();
                this.stopReceive = false;
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReceiveChunkLoop),helper);
                return currentInputMessage;

            }
            else
            {
                return message;
            }

        }
        public Message Receive()
        {
            return this.Receive(base.DefaultReceiveTimeout);
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {

             ThrowIfDisposedOrNotOpen();
             message = null;
             bool timedout = false;
             try
             {
                 message = this.Receive(timeout);
             }
             catch (TimeoutException)
             {
                 timedout = true;
             }
             return (!timedout);

        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            return innerChannel.WaitForMessage(timeout);
        }

        #endregion

        #region IOutputChannel Members

        public void Send(Message message)
        {
            Send(message, this.DefaultSendTimeout);
        }
        public void Send(Message message, TimeSpan timeout)
        {
            ThrowIfDisposedOrNotOpen();

            if (!this.sendingDone.WaitOne(TimeoutHelper.ToMilliseconds(timeout), false))
            {
                throw new TimeoutException("Send timed out waiting for the previous message send to complete");
            }
            lock (base.ThisLock) // synchronized state transitions are not allowed while sending
            {
                ThrowIfDisposedOrNotOpen();

                if (this.operationParams.Contains(message.Headers.Action))
                {
                    TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
                    this.sendingDone.Reset();
                    ChunkingWriter writer = new ChunkingWriter(message,timeoutHelper,innerChannel);
                    message.WriteBodyContents(writer);
                    this.sendingDone.Set();

                }
                else
                {
                    //passthrough
                    innerChannel.Send(message, timeout);
                }
            }
        }
        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void EndSend(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EndpointAddress RemoteAddress
        {
            get { return innerChannel.RemoteAddress; }
        }

        public Uri Via
        {
            get { return innerChannel.Via; }
        }

        #endregion

        #region ISessionChannel<IDuplexSession> Members

        public IDuplexSession Session
        {
            get { return innerChannel.Session; }
        }

        
        #endregion

        #region IInputChannel advanced members
        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Message EndReceive(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EndpointAddress LocalAddress
        {
            get { return innerChannel.LocalAddress; }
        }
        #endregion
    }
    internal class StartChunkState
    {
        internal string OperationName;
        internal string OperationNs;
        internal string ParamName;
        internal string ParamNs;
    }

    internal class ChunkState
    {
        internal ChunkState()
        {
            this.Buffer = new byte[ChunkingUtils.ChunkSize];
            this.Count = 0;
        }
        internal int AppendBytes(byte[] buffer, int index, int count)
        {
            int bytesToCopy = Math.Min(count, this.Buffer.Length - this.Count);
            Array.Copy(buffer, index, this.Buffer, this.Count, bytesToCopy);
            this.Count += bytesToCopy;
            return count - bytesToCopy;
        }
        internal byte[] Buffer;
        internal int Count;
    }
}
