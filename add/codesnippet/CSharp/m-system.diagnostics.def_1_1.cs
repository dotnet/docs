            // Compute the next binomial coefficient.  
            // If an exception is thrown, quit.
            decimal result = CalcBinomial(possibilities, iter);
            if (result==0) {return;}

            // Format the trace and console output.
            string binomial = String.Format("Binomial( {0}, {1} ) = ", possibilities, iter);
            defaultListener.Write(binomial);
            defaultListener.WriteLine(result.ToString());
            Console.WriteLine("{0} {1}", binomial, result);