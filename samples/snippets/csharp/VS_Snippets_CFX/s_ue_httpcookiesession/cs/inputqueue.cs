//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Diagnostics;

    using System.Threading;

    // ItemDequeuedCallback is called as an item is dequeued from the InputQueue.  The 
    // InputQueue lock is not held during the callback.  However, the user code is
    // not notified of the item being available until the callback returns.  If you
    // are not sure if the callback blocks for a long time, then first call 
    // IOThreadScheduler.ScheduleCallback to get to a "safe" thread.
    delegate void ItemDequeuedCallback();

    /// <summary>
    /// Handles asynchronous interactions between producers and consumers. 
    /// Producers can dispatch available data to the input queue, 
    /// where it is dispatched to a waiting consumer or stored until a
    /// consumer becomes available. Consumers can synchronously or asynchronously
    /// request data from the queue, which is returned when data becomes
    /// available.
    /// </summary>
    /// <typeparam name="T">The concrete type of the consumer objects that are waiting for data.</typeparam>
    class InputQueue<T> : IDisposable where T : class
    {
        //Stores items that are waiting to be consumed.
        ItemQueue itemQueue;

        //Each IQueueReader represents some consumer that is waiting for
        //items to appear in the queue. The readerQueue stores them
        //in an ordered list so consumers get serviced in a FIFO manner.
        Queue<IQueueReader> readerQueue;

        //Each IQueueWaiter represents some waiter that is waiting for
        //items to appear in the queue.  When any item appears, all
        //waiters are signalled.
        List<IQueueWaiter> waiterList;

        static WaitCallback onInvokeDequeuedCallback;
        static WaitCallback onDispatchCallback;
        static WaitCallback completeOutstandingReadersCallback;
        static WaitCallback completeWaitersFalseCallback;
        static WaitCallback completeWaitersTrueCallback;

        //Represents the current state of the InputQueue.
        //as it transitions through its lifecycle.
        QueueState queueState;
        enum QueueState
        {
            Open,
            Shutdown,
            Closed
        }

        public InputQueue()
        {
            this.itemQueue = new ItemQueue();
            this.readerQueue = new Queue<IQueueReader>();
            this.waiterList = new List<IQueueWaiter>();
            this.queueState = QueueState.Open;
        }

        public int PendingCount
        {
            get
            {
                lock (ThisLock)
                {                    
                    return itemQueue.ItemCount;
                }
            }
        }

        object ThisLock
        {
            get { return itemQueue; }
        }

        public IAsyncResult BeginDequeue(TimeSpan timeout, AsyncCallback callback, object state)
        {
            Item item = default(Item);

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else
                    {
                        AsyncQueueReader reader = new AsyncQueueReader(this, timeout, callback, state);
                        readerQueue.Enqueue(reader);
                        return reader;
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        AsyncQueueReader reader = new AsyncQueueReader(this, timeout, callback, state);
                        readerQueue.Enqueue(reader);
                        return reader;
                    }
                }
            }

            InvokeDequeuedCallback(item.DequeuedCallback);
            return new TypedCompletedAsyncResult<T>(item.GetValue(), callback, state);
        }

        public IAsyncResult BeginWaitForItem(TimeSpan timeout, AsyncCallback callback, object state)
        {
            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (!itemQueue.HasAvailableItem)
                    {
                        AsyncQueueWaiter waiter = new AsyncQueueWaiter(timeout, callback, state);
                        waiterList.Add(waiter);
                        return waiter;
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (!itemQueue.HasAvailableItem && itemQueue.HasAnyItem)
                    {
                        AsyncQueueWaiter waiter = new AsyncQueueWaiter(timeout, callback, state);
                        waiterList.Add(waiter);
                        return waiter;
                    }
                }
            }

            return new TypedCompletedAsyncResult<bool>(true, callback, state);
        }

        static void CompleteOutstandingReadersCallback(object state)
        {
            IQueueReader[] outstandingReaders = (IQueueReader[])state;

            for (int i = 0; i < outstandingReaders.Length; i++)
            {
                outstandingReaders[i].Set(default(Item));
            }
        }

        static void CompleteWaitersFalseCallback(object state)
        {
            CompleteWaiters(false, (IQueueWaiter[])state);
        }

        static void CompleteWaitersTrueCallback(object state)
        {
            CompleteWaiters(true, (IQueueWaiter[])state);
        }

        static void CompleteWaiters(bool itemAvailable, IQueueWaiter[] waiters)
        {
            for (int i=0; i<waiters.Length; i++)
            {
                waiters[i].Set(itemAvailable);
            }
        }

        static void CompleteWaitersLater(bool itemAvailable, IQueueWaiter[] waiters)
        {
            if (itemAvailable)
            {
                if (completeWaitersTrueCallback == null)
                    completeWaitersTrueCallback = new WaitCallback(CompleteWaitersTrueCallback);

                ThreadPool.QueueUserWorkItem(completeWaitersTrueCallback, waiters);
            }
            else
            {
                if (completeWaitersFalseCallback == null)
                    completeWaitersFalseCallback = new WaitCallback(CompleteWaitersFalseCallback);

                ThreadPool.QueueUserWorkItem(completeWaitersFalseCallback, waiters);
            }
        }

        void GetWaiters(out IQueueWaiter[] waiters)
        {
            if (waiterList.Count > 0)
            {
                waiters = waiterList.ToArray();
                waiterList.Clear();
            }
            else
            {
                waiters = null;
            }
        }

        public void Close()
        {
            ((IDisposable)this).Dispose();
        }

        public void Shutdown()
        {
            IQueueReader[] outstandingReaders = null;
            lock (ThisLock)
            {
                if (queueState == QueueState.Shutdown)
                    return;

                if (queueState == QueueState.Closed)
                    return;

                this.queueState = QueueState.Shutdown;

                if (readerQueue.Count > 0 && this.itemQueue.ItemCount == 0)
                {
                    outstandingReaders = new IQueueReader[readerQueue.Count];
                    readerQueue.CopyTo(outstandingReaders, 0);
                    readerQueue.Clear();
                }
            }

            if (outstandingReaders != null)
            {
                for (int i = 0; i < outstandingReaders.Length; i++)
                {
                    outstandingReaders[i].Set(new Item((Exception)null, null));
                }
            }
        }

        public T Dequeue(TimeSpan timeout)
        {
            T value;

            if (!this.Dequeue(timeout, out value))
            {
                throw new TimeoutException(string.Format("Dequeue timed out in {0}.", timeout));
            }

            return value;
        }

        public bool Dequeue(TimeSpan timeout, out T value)
        {
            WaitQueueReader reader = null;
            Item item = new Item();

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else
                    {
                        reader = new WaitQueueReader(this);
                        readerQueue.Enqueue(reader);
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        reader = new WaitQueueReader(this);
                        readerQueue.Enqueue(reader);
                    }
                    else
                    {
                        value = default(T);
                        return true;
                    }
                }
                else // queueState == QueueState.Closed
                {
                    value = default(T);
                    return true;
                }
            }

            if (reader != null)
            {
                return reader.Wait(timeout, out value);
            }
            else
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                value = item.GetValue();
                return true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool dispose = false;

                lock (ThisLock)
                {
                    if (queueState != QueueState.Closed)
                    {
                        queueState = QueueState.Closed;
                        dispose = true;
                    }
                }

                if (dispose)
                {
                    while (readerQueue.Count > 0)
                    {
                        IQueueReader reader = readerQueue.Dequeue();
                        reader.Set(default(Item));
                    }

                    while (itemQueue.HasAnyItem)
                    {
                        Item item = itemQueue.DequeueAnyItem();
                        item.Dispose();
                        InvokeDequeuedCallback(item.DequeuedCallback);
                    }
                }
            }
        }

        public void Dispatch()
        {
            IQueueReader reader = null;
            Item item = new Item();
            IQueueReader[] outstandingReaders = null;
            IQueueWaiter[] waiters = null;
            bool itemAvailable = true;

            lock (ThisLock)
            {
                itemAvailable = !((queueState == QueueState.Closed) || (queueState == QueueState.Shutdown));
                this.GetWaiters(out waiters);

                if (queueState != QueueState.Closed)
                {
                    itemQueue.MakePendingItemAvailable();

                    if (readerQueue.Count > 0)
                    {
                        item = itemQueue.DequeueAvailableItem();
                        reader = readerQueue.Dequeue();

                        if (queueState == QueueState.Shutdown && readerQueue.Count > 0 && itemQueue.ItemCount == 0)
                        {
                            outstandingReaders = new IQueueReader[readerQueue.Count];
                            readerQueue.CopyTo(outstandingReaders, 0);
                            readerQueue.Clear();

                            itemAvailable = false;
                        }
                    }
                }
            }

            if (outstandingReaders != null)
            {
                if (completeOutstandingReadersCallback == null)
                    completeOutstandingReadersCallback = new WaitCallback(CompleteOutstandingReadersCallback);

                ThreadPool.QueueUserWorkItem(completeOutstandingReadersCallback, outstandingReaders);
            }

            if (waiters != null)
            {
                CompleteWaitersLater(itemAvailable, waiters);
            }

            if (reader != null)
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                reader.Set(item);
            }
        }

        //Ends an asynchronous Dequeue operation.
        public T EndDequeue(IAsyncResult result)
        {
            T value;

            if (!this.EndDequeue(result, out value))
            {
                throw new TimeoutException("Asynchronous Dequeue operation timed out.");
            }

            return value;
        }

        public bool EndDequeue(IAsyncResult result, out T value)
        {
            TypedCompletedAsyncResult<T> typedResult = result as TypedCompletedAsyncResult<T>;

            if (typedResult != null)
            {
                value = TypedCompletedAsyncResult<T>.End(result);
                return true;
            }

            return AsyncQueueReader.End(result, out value);
        }

        public bool EndWaitForItem(IAsyncResult result)
        {
            TypedCompletedAsyncResult<bool> typedResult = result as TypedCompletedAsyncResult<bool>;
            if (typedResult != null)
            {
                return TypedCompletedAsyncResult<bool>.End(result);
            }

            return AsyncQueueWaiter.End(result);
        }

        public void EnqueueAndDispatch(T item)
        {
            EnqueueAndDispatch(item, null);
        }

        public void EnqueueAndDispatch(T item, ItemDequeuedCallback dequeuedCallback)
        {
            EnqueueAndDispatch(item, dequeuedCallback, true);
        }

        public void EnqueueAndDispatch(Exception exception, ItemDequeuedCallback dequeuedCallback, bool canDispatchOnThisThread)
        {
            Debug.Assert(exception != null, "exception parameter should not be null");
            EnqueueAndDispatch(new Item(exception, dequeuedCallback), canDispatchOnThisThread);
        }

        public void EnqueueAndDispatch(T item, ItemDequeuedCallback dequeuedCallback, bool canDispatchOnThisThread)
        {
            Debug.Assert(item != null, "item parameter should not be null");
            EnqueueAndDispatch(new Item(item, dequeuedCallback), canDispatchOnThisThread);
        }

        void EnqueueAndDispatch(Item item, bool canDispatchOnThisThread)
        {
            bool disposeItem = false;
            IQueueReader reader = null;
            bool dispatchLater = false;
            IQueueWaiter[] waiters = null;
            bool itemAvailable = true;

            lock (ThisLock)
            {
                itemAvailable = !((queueState == QueueState.Closed) || (queueState == QueueState.Shutdown));
                this.GetWaiters(out waiters);

                if (queueState == QueueState.Open)
                {
                    if (canDispatchOnThisThread)
                    {
                        if (readerQueue.Count == 0)
                        {
                            itemQueue.EnqueueAvailableItem(item);
                        }
                        else
                        {
                            reader = readerQueue.Dequeue();
                        }
                    }
                    else
                    {
                        if (readerQueue.Count == 0)
                        {
                            itemQueue.EnqueueAvailableItem(item);
                        }
                        else
                        {
                            itemQueue.EnqueuePendingItem(item);
                            dispatchLater = true;
                        }
                    }
                }
                else // queueState == QueueState.Closed || queueState == QueueState.Shutdown
                {
                    disposeItem = true;
                }
            }

            if (waiters != null)
            {
                if (canDispatchOnThisThread)
                {
                    CompleteWaiters(itemAvailable, waiters);
                }
                else
                {
                    CompleteWaitersLater(itemAvailable, waiters);
                }
            }

            if (reader != null)
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                reader.Set(item);
            }

            if (dispatchLater)
            {
                if (onDispatchCallback == null)
                {
                    onDispatchCallback = new WaitCallback(OnDispatchCallback);
                }

                ThreadPool.QueueUserWorkItem(onDispatchCallback, this);
            }
            else if (disposeItem)
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                item.Dispose();
            }
        }

        public bool EnqueueWithoutDispatch(T item, ItemDequeuedCallback dequeuedCallback)
        {
            Debug.Assert(item != null, "EnqueueWithoutDispatch: item parameter should not be null");
            return EnqueueWithoutDispatch(new Item(item, dequeuedCallback));
        }

        public bool EnqueueWithoutDispatch(Exception exception, ItemDequeuedCallback dequeuedCallback)
        {
            Debug.Assert(exception != null, "EnqueueWithoutDispatch: exception parameter should not be null");
            return EnqueueWithoutDispatch(new Item(exception, dequeuedCallback));
        }

        // This does not block, however Dispatch() must be called later if this function
        // returns true.
        bool EnqueueWithoutDispatch(Item item)
        {
            lock (ThisLock)
            {
                // Open
                if (queueState != QueueState.Closed && queueState != QueueState.Shutdown)
                {
                    if (readerQueue.Count == 0)
                    {
                        itemQueue.EnqueueAvailableItem(item);
                        return false;
                    }
                    else
                    {
                        itemQueue.EnqueuePendingItem(item);
                        return true;
                    }
                }
            }

            item.Dispose();
            InvokeDequeuedCallbackLater(item.DequeuedCallback);
            return false;
        }

        static void OnDispatchCallback(object state)
        {
            ((InputQueue<T>)state).Dispatch();
        }

        static void InvokeDequeuedCallbackLater(ItemDequeuedCallback dequeuedCallback)
        {
            if (dequeuedCallback != null)
            {
                if (onInvokeDequeuedCallback == null)
                {
                    onInvokeDequeuedCallback = OnInvokeDequeuedCallback;
                }

                ThreadPool.QueueUserWorkItem(onInvokeDequeuedCallback, dequeuedCallback);
            }
        }

        static void InvokeDequeuedCallback(ItemDequeuedCallback dequeuedCallback)
        {
            if (dequeuedCallback != null)
            {
                dequeuedCallback();
            }
        }

        static void OnInvokeDequeuedCallback(object state)
        {
            ItemDequeuedCallback dequeuedCallback = (ItemDequeuedCallback)state;
            dequeuedCallback();
        }

        bool RemoveReader(IQueueReader reader)
        {
            lock (ThisLock)
            {
                if (queueState == QueueState.Open || queueState == QueueState.Shutdown)
                {
                    bool removed = false;

                    for (int i = readerQueue.Count; i > 0; i--)
                    {
                        IQueueReader temp = readerQueue.Dequeue();
                        if (Object.ReferenceEquals(temp, reader))
                        {
                            removed = true;
                        }
                        else
                        {
                            readerQueue.Enqueue(temp);
                        }
                    }

                    return removed;
                }
            }

            return false;
        }

        public bool WaitForItem(TimeSpan timeout)
        {
            WaitQueueWaiter waiter = null;
            bool itemAvailable = false;

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else
                    {
                        waiter = new WaitQueueWaiter();
                        waiterList.Add(waiter);
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        waiter = new WaitQueueWaiter();
                        waiterList.Add(waiter);
                    }
                    else
                    {
                        return false;
                    }
                }
                else // queueState == QueueState.Closed
                {
                    return true;
                }
            }

            if (waiter != null)
            {
                return waiter.Wait(timeout);
            }
            else
            {
                return itemAvailable;
            }
        }

        interface IQueueReader
        {
            void Set(Item item);
        }

        interface IQueueWaiter
        {
            void Set(bool itemAvailable);
        }

        class WaitQueueReader : IQueueReader
        {
            Exception exception;
            InputQueue<T> inputQueue;
            T item;
            ManualResetEvent waitEvent;
            object thisLock = new object();

            public WaitQueueReader(InputQueue<T> inputQueue)
            {
                this.inputQueue = inputQueue;
                waitEvent = new ManualResetEvent(false);
            }

            object ThisLock
            {
                get
                {
                    return this.thisLock;
                }
            }

            public void Set(Item item)
            {
                lock (ThisLock)
                {
                    Debug.Assert(this.item == null, "InputQueue.WaitQueueReader.Set: (this.item == null)");
                    Debug.Assert(this.exception == null, "InputQueue.WaitQueueReader.Set: (this.exception == null)");

                    this.exception = item.Exception;
                    this.item = item.Value;
                    waitEvent.Set();
                }
            }

            public bool Wait(TimeSpan timeout, out T value)
            {
                bool isSafeToClose = false;
                try
                {
                    if (timeout == TimeSpan.MaxValue)
                    {
                        waitEvent.WaitOne();
                    }
                    else if (!waitEvent.WaitOne(timeout, false))
                    {
                        if (this.inputQueue.RemoveReader(this))
                        {
                            value = default(T);
                            isSafeToClose = true;
                            return false;
                        }
                        else
                        {
                            waitEvent.WaitOne();
                        }
                    }

                    isSafeToClose = true;
                }
                finally
                {
                    if (isSafeToClose)
                    {
                        waitEvent.Close();
                    }
                }

                value = item;
                return true;
            }
        }

        class AsyncQueueReader : AsyncResult, IQueueReader
        {
            static TimerCallback timerCallback = new TimerCallback(AsyncQueueReader.TimerCallback);

            bool expired;
            InputQueue<T> inputQueue;
            T item;
            Timer timer;

            public AsyncQueueReader(InputQueue<T> inputQueue, TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.inputQueue = inputQueue;
                if (timeout != TimeSpan.MaxValue)
                {
                    this.timer = new Timer(timerCallback, this, timeout, TimeSpan.FromMilliseconds(-1));
                }
            }

            public static bool End(IAsyncResult result, out T value)
            {
                AsyncQueueReader readerResult = AsyncResult.End<AsyncQueueReader>(result);

                if (readerResult.expired)
                {
                    value = default(T);
                    return false;
                }
                else
                {
                    value = readerResult.item;
                    return true;
                }
            }

            static void TimerCallback(object state)
            {
                AsyncQueueReader thisPtr = (AsyncQueueReader)state;
                if (thisPtr.inputQueue.RemoveReader(thisPtr))
                {
                    thisPtr.expired = true;
                    thisPtr.Complete(false);
                }
            }

            public void Set(Item item)
            {
                this.item = item.Value;
                if (this.timer != null)
                {
                    this.timer.Change(-1, -1);
                }
                Complete(false, item.Exception);
            }
        }

        struct Item
        {
            T value;
            Exception exception;
            ItemDequeuedCallback dequeuedCallback;

            public Item(T value, ItemDequeuedCallback dequeuedCallback)
                : this(value, null, dequeuedCallback)
            {
            }

            public Item(Exception exception, ItemDequeuedCallback dequeuedCallback)
                : this(null, exception, dequeuedCallback)
            {
            }

            Item(T value, Exception exception, ItemDequeuedCallback dequeuedCallback)
            {
                this.value = value;
                this.exception = exception;
                this.dequeuedCallback = dequeuedCallback;
            }

            public Exception Exception
            {
                get { return this.exception; }
            }

            public T Value
            {
                get { return value; }
            }

            public ItemDequeuedCallback DequeuedCallback
            {
                get { return dequeuedCallback; }
            }

            public void Dispose()
            {
                if (value != null)
                {
                    if (value is IDisposable)
                    {
                        ((IDisposable)value).Dispose();
                    }
                    else if (value is ICommunicationObject)
                    {
                        ((ICommunicationObject)value).Abort();
                    }
                }
            }

            public T GetValue()
            {
                if (this.exception != null)
                {
                    throw this.exception;
                }

                return this.value;
            }
        }

        class WaitQueueWaiter : IQueueWaiter
        {
            bool itemAvailable;
            ManualResetEvent waitEvent;
            object thisLock = new object();

            public WaitQueueWaiter()
            {
                waitEvent = new ManualResetEvent(false);
            }

            object ThisLock
            {
                get
                {
                    return this.thisLock;
                }
            }

            public void Set(bool itemAvailable)
            {
                lock (ThisLock)
                {
                    this.itemAvailable = itemAvailable;
                    waitEvent.Set();
                }
            }

            public bool Wait(TimeSpan timeout)
            {
                if (timeout == TimeSpan.MaxValue)
                {
                    waitEvent.WaitOne();
                }
                else if (!waitEvent.WaitOne(timeout, false))
                {
                    return false;
                }

                return this.itemAvailable;
            }
        }

        class AsyncQueueWaiter : AsyncResult, IQueueWaiter
        {
            static TimerCallback timerCallback = new TimerCallback(AsyncQueueWaiter.TimerCallback);
            Timer timer;
            bool itemAvailable;
            object thisLock = new object();

            public AsyncQueueWaiter(TimeSpan timeout, AsyncCallback callback, object state) : base(callback, state)
            {
                if (timeout != TimeSpan.MaxValue)
                {
                    this.timer = new Timer(timerCallback, this, timeout, TimeSpan.FromMilliseconds(-1));
                }
            }

            object ThisLock
            {
                get
                {
                    return this.thisLock;
                }
            }

            public static bool End(IAsyncResult result)
            {
                AsyncQueueWaiter waiterResult = AsyncResult.End<AsyncQueueWaiter>(result);
                return waiterResult.itemAvailable;
            }

            static void TimerCallback(object state)
            {
                AsyncQueueWaiter thisPtr = (AsyncQueueWaiter)state;
                thisPtr.Complete(false);
            }

            public void Set(bool itemAvailable)
            {
                bool timely;

                lock (ThisLock)
                {
                    timely = (this.timer == null) || this.timer.Change(-1, -1);
                    this.itemAvailable = itemAvailable;
                }

                if (timely)
                {
                    Complete(false);
                }
            }
        }

        class ItemQueue
        {
            Item[] items;
            int head;
            int pendingCount;
            int totalCount;

            public ItemQueue()
            {
                items = new Item[1];
            }

            public Item DequeueAvailableItem()
            {
                if (totalCount == pendingCount)
                {
                    Debug.Assert(false, "ItemQueue does not contain any available items");
                    throw new Exception("Internal Error");
                }
                return DequeueItemCore();
            }

            public Item DequeueAnyItem()
            {
                if (pendingCount == totalCount)
                    pendingCount--;
                return DequeueItemCore();
            }

            void EnqueueItemCore(Item item)
            {
                if (totalCount == items.Length)
                {
                    Item[] newItems = new Item[items.Length * 2];
                    for (int i = 0; i < totalCount; i++)
                        newItems[i] = items[(head + i) % items.Length];
                    head = 0;
                    items = newItems;
                }
                int tail = (head + totalCount) % items.Length;
                items[tail] = item;
                totalCount++;
            }

            Item DequeueItemCore()
            {
                if (totalCount == 0)
                {
                    Debug.Assert(false, "ItemQueue does not contain any items");
                    throw new Exception("Internal Error");
                }
                Item item = items[head];
                items[head] = new Item();
                totalCount--;
                head = (head + 1) % items.Length;
                return item;
            }

            public void EnqueuePendingItem(Item item)
            {
                EnqueueItemCore(item);
                pendingCount++;
            }

            public void EnqueueAvailableItem(Item item)
            {
                EnqueueItemCore(item);
            }

            public void MakePendingItemAvailable()
            {
                if (pendingCount == 0)
                {
                    Debug.Assert(false, "ItemQueue does not contain any pending items");
                    throw new Exception("Internal Error");
                }
                pendingCount--;
            }
            
            public bool HasAvailableItem
            {
                get { return totalCount > pendingCount; }
            }

            public bool HasAnyItem
            {
                get { return totalCount > 0; }
            }

            public int ItemCount
            {
                get { return totalCount; }
            }
        }
    }
}
