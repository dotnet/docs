        static public void ApplyEndpointAddress(SendActivity activity, EndpointAddress epr)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                if (epr.Uri != null)
                {
                    activity.CustomAddress = epr.Uri.ToString();
                }
                if (epr.Headers != null && epr.Headers.Count > 0)
                {
                    AddressHeader contextHeader = epr.Headers.FindHeader(contextHeaderName, contextHeaderNamespace);
                    IDictionary<string, string> context = contextHeader.GetValue<Dictionary<string, string>>();
                    activity.Context = context;
                }
            }
        }