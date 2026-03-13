Console.WriteLine(Utilities.MidPoint(12, 24));

// <TestRepeat>
var str = new RepeatSequence();

for (int i = 0; i < 10; i++)
    Console.WriteLine(str++);
// </TestRepeat>

// <TestDescribe>
static void PrintDescription<T>() where T : IDescribable<T>
{
    Console.WriteLine(T.Describe());
}

PrintDescription<Widget>();
PrintDescription<Gadget>();
// </TestDescribe>

// <TestAddition>
var pt = new Point<int>(3, 4);

var translate = new Translation<int>(5, 10);

var final = pt + translate;

Console.WriteLine(pt);
Console.WriteLine(translate);
Console.WriteLine(final);
// </TestAddition>
