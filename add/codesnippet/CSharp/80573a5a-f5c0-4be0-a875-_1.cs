            public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return this.InnerChannel.BeginWaitForRequest(timeout, callback, state);
            }