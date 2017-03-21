        public bool WaitForMessage(TimeSpan timeout)
        {
            return this.InnerChannel.WaitForMessage(timeout);
        }