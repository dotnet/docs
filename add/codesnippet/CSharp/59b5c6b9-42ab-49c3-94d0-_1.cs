        public bool EndWaitForMessage(IAsyncResult result)
        {
            return this.InnerChannel.EndWaitForMessage(result);
        }