    public sealed class AppendString : Activity<string>
    {
        // Input argument.
        [RequiredArgument]
        public InArgument<string> Name { get; set; }

        public AppendString()
        {
            // Define the implementation of this activity.
            this.Implementation = () => new Assign<string>
            {
                Value = new LambdaValue<string>(ctx => Name.Get(ctx) + " says hello world"),
                To = new LambdaReference<string>(ctx => Result.Get(ctx)),
            };
        }
    }