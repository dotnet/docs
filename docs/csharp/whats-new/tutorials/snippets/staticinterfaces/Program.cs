// See https://aka.ms/new-console-template for more information

Console.WriteLine(Utilities.MidPoint(12, 24));

// <TestRepeat>
var str = new RepeatSequence();

for (int i = 0; i < 10; i++)
    Console.WriteLine(str++);
// </TestRepeat>

// <TestUniqueInstance>
var instance = UniqueInstance.Instance;
instance.PrintMessage();
// </TestUniqueInstance>

// <TestAddition>
var pt = new Point<int>(3, 4);

var translate = new Translation<int>(5, 10);

var final = pt + translate;

Console.WriteLine(pt);
Console.WriteLine(translate);
Console.WriteLine(final);
// </TestAddition>
