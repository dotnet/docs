
static void Using()
{
    // <Using>
    var numbers = new List<int>();
    using (StreamReader reader = File.OpenText("numbers.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) is not null)
        {
            if (int.TryParse(line, out int number))
            {
                numbers.Add(number);
            }
        }
    }
    // </Using>
}

static async void AwaitUsing()
{
    // <AwaitUsing>
    await using (var resource = new AsyncDisposableExample())
    {
        // Use the resource
    }
    // </AwaitUsing>
}

// <UsingDeclaration>
static IEnumerable<int> LoadNumbers(string filePath)
{
    using StreamReader reader = File.OpenText(filePath);
    
    var numbers = new List<int>();
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
    return numbers;
}
// </UsingDeclaration>

static void MultipleResources()
{
    // <MultipleResources>
    using (StreamReader numbersFile = File.OpenText("numbers.txt"), wordsFile = File.OpenText("words.txt"))
    {
        // Process both files
    }
    // </MultipleResources>
}

static IEnumerable<int> UsingWithExpression(string filePath)
{
    var result = new List<int>();
    // <UsingWithExpression>
    StreamReader reader = File.OpenText(filePath);
    
    using (reader)
    {
        // Process file content
    }
    // </UsingWithExpression>
    return result;
}
