    // Define a custom parameter attribute that takes a single message argument.
    [AttributeUsage( AttributeTargets.Parameter )]
    public class ArgumentUsageAttribute : Attribute
    {
        // This is the attribute constructor.
        public ArgumentUsageAttribute( string UsageMsg )
        {
            this.usageMsg = UsageMsg;
        }

        // usageMsg is storage for the attribute message.
        protected string usageMsg;

        // This is the Message property for the attribute.
        public string Message
        {
            get { return usageMsg; }
            set { usageMsg = value; }
        }
    }