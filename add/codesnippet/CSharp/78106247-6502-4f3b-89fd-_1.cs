        public Message Request(Message message, TimeSpan timeout)
        {
            return this.InnerChannel.Request(message, timeout);
        }