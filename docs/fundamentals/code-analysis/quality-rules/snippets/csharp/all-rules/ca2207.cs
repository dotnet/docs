namespace ca2207
{
    //<snippet1>
    // This struct violates the rule.
    struct BadStruct
    {
        private static readonly int s_first;
        private static readonly int s_second;

        static BadStruct()
        {
            s_first = 1;
            s_second = 2;
        }

        // ...
    }

    // This struct satisfies the rule.
    struct GoodStruct
    {
        private static readonly int s_first = 1;
        private static readonly int s_second = 2;

        // ...
    }
    //</snippet1>
}
