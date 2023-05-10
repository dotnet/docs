namespace Declarations;

public static class Declaration
{
    public static void Examples()
    {
        {
            // <Declare>
            string greeting;
            int a, b, c;
            List<double> xs;
            // </Declare>
        }

        {
            // <DeclareAndInit>
            string greeting = "Hello";
            int a = 3, b = 2, c = a + b;
            List<double> xs = new();
            // </DeclareAndInit>
        }

        {
            // <LocalConstant>
            const string Greeting = "Hello";
            const double MinLimit = -10.0, MaxLimit = -MinLimit;
            // </LocalConstant>
        }
    }
}