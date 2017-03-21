            public RequestContext ReceiveRequest(TimeSpan timeout)
            {
                RequestContext requestContext;
                while (true)
                {
                    requestContext = this.InnerChannel.ReceiveRequest(timeout);
                    if (ProcessRequestContext(ref requestContext))
                    {
                        break;
                    }
                }

                return requestContext;
            }