            public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext requestContext)
            {
                return TryReceiveRequestAsyncResult.End(result, out requestContext);
            }