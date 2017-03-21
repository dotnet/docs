            Single zero = 0;

            // This condition will return false.
            if ((0 / zero) == Single.NaN)
            {
                Console.WriteLine("0 / 0 can be tested with Single.NaN.");
            }
            else
            {
                Console.WriteLine("0 / 0 cannot be tested with Single.NaN; use Single.IsNan() instead.");
            }