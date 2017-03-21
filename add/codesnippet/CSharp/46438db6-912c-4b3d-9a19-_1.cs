            public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
            {
                ReceiveRequestAsyncResult result = new ReceiveRequestAsyncResult(this, timeout, callback, state);
                result.Begin();
                return result;
            }