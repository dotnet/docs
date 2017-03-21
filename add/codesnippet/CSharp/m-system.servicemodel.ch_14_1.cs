            public bool WaitForRequest(TimeSpan timeout)
            {
                return this.InnerChannel.WaitForRequest(timeout);
            }