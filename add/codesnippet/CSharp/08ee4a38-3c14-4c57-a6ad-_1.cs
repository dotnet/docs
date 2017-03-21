            public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                TryReceiveRequestAsyncResult result = new TryReceiveRequestAsyncResult(this, timeout, callback, state);
                result.Begin();
                return result;
            }