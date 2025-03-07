PageOne();
PageTwo();
PageThree();
PageFour();
PageFive();
PageSix();
Challenge();

void PageOne()
{
    // <HelloWorld>
    Console.WriteLine("Hello, World!");
    // </HelloWorld>
}

void PageTwo()
{
    // <Variables>
    string aFriend = "Bill";
    Console.WriteLine(aFriend);
    // </Variables>

    // <Assignment>
    aFriend = "Maira";
    Console.WriteLine(aFriend);
    // </Assignment>

    // <ConcatMessage>
    Console.WriteLine("Hello " + aFriend);
    // </ConcatMessage>

    // <Interpolation>
    Console.WriteLine($"Hello {aFriend}");
    // </Interpolation>
}

void PageThree()
{
    // <WorkWithStrings>
    string firstFriend = "Maria";
    string secondFriend = "Sage";
    Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
    // </WorkWithStrings>

    // <Properties>
    Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
    Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");
    // </Properties>
}

void PageFour()
{
    // <Trim>
    string greeting = "      Hello World!       ";
    Console.WriteLine($"[{greeting}]");

    string trimmedGreeting = greeting.TrimStart();
    Console.WriteLine($"[{trimmedGreeting}]");

    trimmedGreeting = greeting.TrimEnd();
    Console.WriteLine($"[{trimmedGreeting}]");

    trimmedGreeting = greeting.Trim();
    Console.WriteLine($"[{trimmedGreeting}]");
    // </Trim>
}

void PageFive()
{
    // <Replace>
    string sayHello = "Hello World!";
    Console.WriteLine(sayHello);
    sayHello = sayHello.Replace("Hello", "Greetings");
    Console.WriteLine(sayHello);
    // </Replace>

    // <UpperLower>
    Console.WriteLine(sayHello.ToUpper());
    Console.WriteLine(sayHello.ToLower());
    // </UpperLower>
}

void PageSix()
{
    // <SearchStrings>
    string songLyrics = "You say goodbye, and I say hello";
    Console.WriteLine(songLyrics.Contains("goodbye"));
    Console.WriteLine(songLyrics.Contains("greetings"));
    // </SearchStrings>
}

void Challenge()
{
    // <Challenge>
    string songLyrics = "You say goodbye, and I say hello";
    Console.WriteLine(songLyrics.StartsWith("You"));
    Console.WriteLine(songLyrics.StartsWith("goodbye"));

    Console.WriteLine(songLyrics.EndsWith("hello"));
    Console.WriteLine(songLyrics.EndsWith("goodbye"));
    // </Challenge>
}
