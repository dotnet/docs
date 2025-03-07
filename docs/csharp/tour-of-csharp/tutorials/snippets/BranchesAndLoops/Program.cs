
PageOne();
PageTwo();
MorePageTwo();
ComplexPageTwo();
PageThree();
PageThreeDo();
PageFour();
PageFive();
Challenge();

void PageOne()
{
    // <FirstIf>
    int a = 5;
    int b = 6;
    if (a + b > 10)
        Console.WriteLine("The answer is greater than 10.");
    // </FirstIf>
}

void PageTwo()
{
    // <IfAndElse>
    int a = 5;
    int b = 3;
    if (a + b > 10)
        Console.WriteLine("The answer is greater than 10");
    else
        Console.WriteLine("The answer is not greater than 10");
    // </IfAndElse>
}

void MorePageTwo()
{
    // <IncludeBraces>
    int a = 5;
    int b = 3;
    if (a + b > 10)
    {
        Console.WriteLine("The answer is greater than 10");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
    }
    // </IncludeBraces>
}

void ComplexPageTwo()
{
    // <ComplexConditions>
    int a = 5;
    int b = 3;
    int c = 4;
    if ((a + b + c > 10) && (a == b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("And the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("Or the first number is not equal to the second");
    }
    // </ComplexConditions>

    // <UseOr>
    if ((a + b + c > 10) || (a == b))
    // </UseOr>
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("Or the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("And the first number is not equal to the second");
    }
}

void PageThree()
{
    // <WhileLoop>
    int counter = 0;
    while (counter < 10)
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
    }
    // </WhileLoop>
}

void PageThreeDo()
{
    // <DoLoop>
    int counter = 0;
    do
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
    } while (counter < 10);
    // </DoLoop>
}

void PageFour()
{
    // <ForLoop>
    for (int counter = 0; counter < 10; counter++)
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
    }
    // </ForLoop>
}

void PageFive()
{
    // <Rows>
    for (int row = 1; row < 11; row++)
    {
        Console.WriteLine($"The row is {row}");
    }
    // </Rows>

    // <Columns>
    for (char column = 'a'; column < 'k'; column++)
    {
        Console.WriteLine($"The column is {column}");
    }
    // </Columns>

    // <Nested>
    for (int row = 1; row < 11; row++)
    {
        for (char column = 'a'; column < 'k'; column++)
        {
            Console.WriteLine($"The cell is ({row}, {column})");
        }
    }
    // </Nested>
}

void Challenge()
{
    // <Challenge>
    int sum = 0;
    for (int number = 1; number < 21; number++)
    {
        if (number % 3 == 0)
        {
            sum = sum + number;
        }
    }
    Console.WriteLine($"The sum is {sum}");
    // </Challenge>
}
