            Console.Write("Enter a dividend: ");
            var dividend = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a divisor: ");
            var divisor = Convert.ToInt32(Console.ReadLine());

            // If the divisor is 0, the second clause in the following condition
            // causes a run-time error. The && operator short circuits when the
            // first expression is false. That is, it does not evaluate the
            // second expression. The & operator evaluates both, and causes 
            // a run-time error when divisor is 0.
            if ((divisor != 0) && (dividend / divisor > 0))
            {
                Console.WriteLine("Quotient: {0}", dividend / divisor);
            }
            else
            {
                Console.WriteLine("Attempted division by 0 ends up here.");
            }