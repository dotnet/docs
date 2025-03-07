
ListOfStrings();
ListOfNumbers();
ChallengeAnswer();

void ListOfStrings()
{
    // <BasicList>
    List<string> names = ["<name>", "Ana", "Felipe"];
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
    // </BasicList>

    // <ModifyList>
    Console.WriteLine();
    names.Add("Maria");
    names.Add("Bill");
    names.Remove("Ana");
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
    // </ModifyList>

    // <Indexers>
    Console.WriteLine($"My name is {names[0]}.");
    Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
    // </Indexers>

    // <Property>
    Console.WriteLine($"The list has {names.Count} people in it");
    // </Property>

    // <Search>
    var index = names.IndexOf("Felipe");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    }
    else
    {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }

    index = names.IndexOf("Not Found");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    }
    else
    {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }
    // </Search>

    // <Sort>
    names.Sort();
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
    // </Sort>
}

void ListOfNumbers()
{
    // <CreateList>
    List<int> fibonacciNumbers = [1, 1];
    // </CreateList>

    // <Fibonacci>
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

    fibonacciNumbers.Add(previous + previous2);

    foreach (var item in fibonacciNumbers)
    {
        Console.WriteLine(item);
    }
    // </Fibonacci>
}

void ChallengeAnswer()
{
    // <Answer>
    List<int> fibonacciNumbers = [1, 1];

    while (fibonacciNumbers.Count < 20)
    {
        var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

        fibonacciNumbers.Add(previous + previous2);
    }
    foreach (var item in fibonacciNumbers)
    {
        Console.WriteLine(item);
    }
    // </Answer>
}
