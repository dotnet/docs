MainExample();
OperatorForm();
Scope();

void MainExample()
{
    // <MainExample>
    uint a = uint.MaxValue;

    unchecked
    {
        Console.WriteLine(a + 1);  // output: 0
    }

    try
    {
        checked
        {
            Console.WriteLine(a + 1);
        }
    }
    catch (OverflowException e)
    {
        Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
    }
    // </MainExample>
}

void OperatorForm()
{
    // <OperatorForm>
    double a = double.MaxValue;

    int b = unchecked((int)a);
    Console.WriteLine(b);  // output: -2147483648

    try
    {
        b = checked((int)a);
    }
    catch (OverflowException e)
    {
        Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
    }
    // </OperatorForm>
}

void Scope()
{
    // <ScopeExample>
    int Multiply(int a, int b) => a * b;

    int factor = 2;

    try
    {
        checked
        {
            Console.WriteLine(Multiply(factor, int.MaxValue));  // output: -2
        }
    }
    catch (OverflowException e)
    {
        Console.WriteLine(e.Message);
    }

    try
    {
        checked
        {
            Console.WriteLine(Multiply(factor, factor * int.MaxValue));
        }
    }
    catch (OverflowException e)
    {
        Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
    }
    // </ScopeExample>
}