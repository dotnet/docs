            public bool TryReceiveRequest(TimeSpan timeout, out RequestContext requestContext)
            {
                bool result;

                while (true)
                {
                    result = this.InnerChannel.TryReceiveRequest(timeout, out requestContext);
                    if (!result || ProcessRequestContext(ref requestContext))
                    {
                        break;
                    }
                }

                return result;
            }