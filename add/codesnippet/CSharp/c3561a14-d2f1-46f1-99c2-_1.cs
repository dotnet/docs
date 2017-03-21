            public RequestContext EndReceiveRequest(IAsyncResult result)
            {
                return ReceiveRequestAsyncResult.End(result);
            }