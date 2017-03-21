        public Message EndRequest(IAsyncResult result)
        {
            return this.InnerChannel.EndRequest(result);
        }