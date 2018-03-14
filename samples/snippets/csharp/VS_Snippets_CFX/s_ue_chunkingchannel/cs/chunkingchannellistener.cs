
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.Samples.ChannelHelpers;
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    internal class ChunkingChannelListener : ChannelListenerBase<IDuplexSessionChannel>
    {
        IChannelListener<IDuplexSessionChannel> innerListener;
        ICollection<string> operationParams;
        int maxBufferedChunks;

        public ChunkingChannelListener(IChannelListener<IDuplexSessionChannel> innerListener, ICollection<string> operationParams, int maxBufferedChunks)
            : base()
        {

            this.innerListener = innerListener;
            this.operationParams = operationParams;
            this.maxBufferedChunks = maxBufferedChunks;
        }

        public override Uri Uri
        {
            get { return innerListener.Uri; }
        }

        public override T GetProperty<T>()
        {
            return innerListener.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            innerListener.Open(timeout);
        }
        protected override void OnAbort()
        {
            innerListener.Abort();
        }
        protected override void OnClose(TimeSpan timeout)
        {
            innerListener.Close(timeout);
        }
        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerListener.BeginOpen(timeout, callback, state);
        }
        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerListener.BeginClose(timeout, callback, state);
        }
        protected override void OnEndClose(IAsyncResult result)
        {
            innerListener.EndClose(result);
        }
        protected override void OnEndOpen(IAsyncResult result)
        {
            innerListener.EndOpen(result);
        }

        protected override IDuplexSessionChannel OnAcceptChannel(TimeSpan timeout)
        {
            IDuplexSessionChannel innerChannel = innerListener.AcceptChannel();
            return WrapChannel(innerChannel);
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override IDuplexSessionChannel OnEndAcceptChannel(IAsyncResult result)
        {
            IDuplexSessionChannel innerChannel = innerListener.EndAcceptChannel(result);
            return WrapChannel(innerChannel);
        }

        IDuplexSessionChannel WrapChannel(IDuplexSessionChannel innerChannel)
        {
            if (innerChannel == null)
            {
                return null;
            }
            else
            {
                return new ChunkingDuplexSessionChannel(this, innerChannel, operationParams, maxBufferedChunks);
            }
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return innerListener.BeginWaitForChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            return innerListener.EndWaitForChannel(result);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            return innerListener.WaitForChannel(timeout);
        }
    }
}
