using System;

namespace ca2200
{
    //<snippet1>
    class TestsRethrow
    {
        static void Main2200()
        {
            TestsRethrow testRethrow = new TestsRethrow();
            testRethrow.CatchException();
        }

        void CatchException()
        {
            try
            {
                CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine($"Explicitly specified:{Environment.NewLine}{e.StackTrace}");
            }

            try
            {
                CatchAndRethrowImplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine($"{Environment.NewLine}Implicitly specified:{Environment.NewLine}{e.StackTrace}");
            }
        }

        void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException e)
            {
                // Violates the rule.
                throw e;
            }
        }

        void CatchAndRethrowImplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException)
            {
                // Satisfies the rule.
                throw;
            }
        }

        void ThrowException()
        {
            throw new ArithmeticException("illegal expression");
        }
    }
    //</snippet1>
}
