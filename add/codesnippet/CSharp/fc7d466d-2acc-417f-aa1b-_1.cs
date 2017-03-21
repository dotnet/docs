            public bool EndWaitForRequest(IAsyncResult result)
            {
                return this.InnerChannel.EndWaitForRequest(result);
            }