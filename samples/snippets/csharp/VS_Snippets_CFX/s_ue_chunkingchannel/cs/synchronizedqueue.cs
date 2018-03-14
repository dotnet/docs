
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
namespace Microsoft.Samples.ChannelHelpers
{
    public class SynchronizedQueue<TItem> where TItem : class
    {
        Queue<TItem> queue;
        object lockObject;
        ManualResetEvent itemAvailableEvent;
        ManualResetEvent spaceAvailableEvent;

        int maxLength;
        public SynchronizedQueue(int maxLength)
        {
            this.lockObject = new object();
            this.queue = new Queue<TItem>();
            this.itemAvailableEvent = new ManualResetEvent(false);
            this.spaceAvailableEvent = new ManualResetEvent(true);
            this.maxLength = maxLength;
        }
        public virtual bool TryDequeue(TimeoutHelper timeout, out TItem item)
        {
            item = null;
            if (this.ItemAvailableEvent.WaitOne(TimeoutHelper.ToMilliseconds(timeout.RemainingTime()), false))
            {
                item = this.Dequeue();
                return (item != null);
            }
            else
            {
                return false;
            }
        }

        public virtual TItem Dequeue()
        {
            TItem item;
            lock (lockObject)
            {
                item = queue.Dequeue();
                if (this.Count == 0)
                {
                    this.itemAvailableEvent.Reset();
                }
                this.spaceAvailableEvent.Set();
            }

            return item;
        }
        public virtual bool TryEnqueue(TimeoutHelper timeout, TItem item)
        {
            if (this.SpaceAvailableEvent.WaitOne(TimeoutHelper.ToMilliseconds(timeout.RemainingTime()), false))
            {
                this.Enqueue(item);
                return true;
            }
            else
            {
                return false;
            }
            

        }
        public virtual void Enqueue(TItem item)
        {
            lock (lockObject)
            {
                queue.Enqueue(item);
                this.itemAvailableEvent.Set();
                if (this.MaxLengthReached)
                {
                    this.SpaceAvailableEvent.Reset();
                }
            }
        }
        public virtual int MaxLength
        {
            get { return this.maxLength; }
        }
        public virtual int Count
        {
            get { return queue.Count; }
        }
        public virtual ManualResetEvent ItemAvailableEvent
        {
            get { return this.itemAvailableEvent; }
        }
        public virtual ManualResetEvent SpaceAvailableEvent
        {
            get { return this.spaceAvailableEvent; }
        }
        public virtual bool MaxLengthReached
        {
            get { return Count >= maxLength; }
        }
    }
}
