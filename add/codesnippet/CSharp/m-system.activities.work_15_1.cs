    public sealed class DiceRoll : CodeActivity
    {
        public OutArgument<int> D1 { get; set; }
        public OutArgument<int> D2 { get; set; }

        static Random r = new Random();

        protected override void Execute(CodeActivityContext context)
        {
            D1.Set(context, r.Next(1, 7));
            D2.Set(context, r.Next(1, 7));
        }
    }