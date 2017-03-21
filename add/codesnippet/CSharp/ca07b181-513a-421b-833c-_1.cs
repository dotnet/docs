    public sealed class Divide : CodeActivity
    {
        [RequiredArgument]
        public InArgument<int> Dividend { get; set; }

        [RequiredArgument]
        public InArgument<int> Divisor { get; set; }

        public OutArgument<int> Remainder { get; set; }
        public OutArgument<int> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int quotient = Dividend.Get(context) / Divisor.Get(context);
            int remainder = Dividend.Get(context) % Divisor.Get(context);

            Result.Set(context, quotient);
            Remainder.Set(context, remainder);
        }
    }