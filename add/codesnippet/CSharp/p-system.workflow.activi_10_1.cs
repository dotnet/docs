        static public void ApplyContext(SendActivity activity, IDictionary<string, string> context)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                activity.Context = context;
            }
        }