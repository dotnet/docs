        public IAsyncResult BeginRequest(Message message,
            TimeSpan timeout, AsyncCallback callback,
            object state)
        {
            return this.InnerChannel.BeginRequest(message,
                timeout, callback, state);
        }