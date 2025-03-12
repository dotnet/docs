
PageOne();
PageTwo();
MorePageTwo();
PageThree();
PageFour();
PageFive();

// Bonus calculation:
// <ChangeDoubleValues>
double a = 19;
double b = 23;
double c = 8;
double d = (a + b) / c;
Console.WriteLine(d);
// </ChangeDoubleValues>


void PageOne()
{
    // <Addition>
    int a = 18;
    int b = 6;
    int c = a + b;
    Console.WriteLine(c);
    // </Addition>
}

void PageTwo()
{
    // <Precedence>
    int a = 5;
    int b = 4;
    int c = 2;
    int d = a + b * c;
    Console.WriteLine(d);
    // </Precedence>

    // <Parentheses>
    d = (a + b) * c;
    Console.WriteLine(d);
    // </Parentheses>

    // <CompoundExpression>
    d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
    Console.WriteLine(d);
    // </CompoundExpression>
}

void MorePageTwo()
{
    // <Truncation>
    int a = 7;
    int b = 4;
    int c = 3;
    int d = (a + b) / c;
    Console.WriteLine(d);
    // </Truncation>
}

void PageThree()
{
    // <QuotientAndRemainder>
    int a = 7;
    int b = 4;
    int c = 3;
    int d = (a + b) / c;
    int e = (a + b) % c;
    Console.WriteLine($"quotient: {d}");
    Console.WriteLine($"remainder: {e}");
    // </QuotientAndRemainder>

    // <MinAndMax>
    int max = int.MaxValue;
    int min = int.MinValue;
    Console.WriteLine($"The range of integers is {min} to {max}");
    // </MinAndMax>

    // <Overflow>
    int what = max + 3;
    Console.WriteLine($"An example of overflow: {what}");
    // </Overflow>

}

void PageFour()
{
    // <FloatingPoint>
    double a = 5;
    double b = 4;
    double c = 2;
    double d = (a + b) / c;
    Console.WriteLine(d);
    // </FloatingPoint>

    // <MinMax>
    double max = double.MaxValue;
    double min = double.MinValue;
    Console.WriteLine($"The range of double is {min} to {max}");
    // </MinMax>

    // <RoundingError>
    double third = 1.0 / 3.0;
    Console.WriteLine(third);
    // </RoundingError>
}

void PageFive()
{
    // <Decimal>
    decimal min = decimal.MinValue;
    decimal max = decimal.MaxValue;
    Console.WriteLine($"The range of the decimal type is {min} to {max}");
    // </Decimal>

    // <Precision>
    double a = 1.0;
    double b = 3.0;
    Console.WriteLine(a / b);

    decimal c = 1.0M;
    decimal d = 3.0M;
    Console.WriteLine(c / d);
    // </Precision>

    // <Challenge>
    double radius = 2.50;
    double area = Math.PI * radius * radius;
    Console.WriteLine(area);
    // </Challenge>
}
