    class Program
    {
        static void Main(string[] args)
        {
            int switchExpression = 3;
            switch (switchExpression)
            {
                // A switch section can have more than one case label.
                case 0:
                case 1:
                    Console.WriteLine("Case 0 or 1");
                    // Most switch sections contain a jump statement, such as
                    // a break, goto, or return. The end of the statement list
                    // must be unreachable.
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                    // The following line causes a warning.
                    Console.WriteLine("Unreachable code");
                // 7 - 4 in the following line evaluates to 3.
                case 7 - 4:
                    Console.WriteLine("Case 3");
                    break;
                // If the value of switchExpression is not 0, 1, 2, or 3, the
                // default case is executed.
                default:
                    Console.WriteLine("Default case (optional)");
                    // You cannot "fall through" any switch section, including
                    // the last one.
                    break;
            }
        }
    }