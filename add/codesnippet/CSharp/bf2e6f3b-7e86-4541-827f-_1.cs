        public IAsyncResult BeginRequest(Message message,
            AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginRequest(message,
                callback, state);
        }