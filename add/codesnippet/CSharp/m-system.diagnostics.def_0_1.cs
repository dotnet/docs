            // Compute the next binomial coefficient and handle all exceptions.
            try
            {
                result = CalcBinomial(possibilities, iter);
            }
            catch(Exception ex)
            {
                string failMessage = String.Format("An exception was raised when " +
                    "calculating Binomial( {0}, {1} ).", possibilities, iter);
                defaultListener.Fail(failMessage, ex.Message);
                if (!defaultListener.AssertUiEnabled)
                {
                    Console.WriteLine(failMessage+ "\n" +ex.Message);
                }
                return;
            }