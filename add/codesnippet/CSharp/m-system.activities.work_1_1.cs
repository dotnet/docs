    public sealed class LongRunningDiceRoll : Activity
    {
        public OutArgument<int> D1 { get; set; }
        public OutArgument<int> D2 { get; set; }

        public LongRunningDiceRoll()
        {
            this.Implementation = () => new Sequence
            {
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Rolling the dice for 5 seconds."
                    },
                    new Delay
                    {
                        Duration = TimeSpan.FromSeconds(5)
                    },
                    new DiceRoll
                    {
                        D1 = new OutArgument<int>(env => this.D1.Get(env)),
                        D2 = new OutArgument<int>(env => this.D2.Get(env))
                    }
                }
            };
        }
    }