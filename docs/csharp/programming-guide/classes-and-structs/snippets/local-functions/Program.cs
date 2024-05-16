using System.Diagnostics.CodeAnalysis;

namespace local_functions;

class Program
{
    static void Main(string[] args)
    { }

    //<Basic>
    private static string GetText(string path, string filename)
    {
         var reader = File.OpenText($"{AppendPathSeparator(path)}{filename}");
         var text = reader.ReadToEnd();
         return text;

         string AppendPathSeparator(string filepath)
         {
            return filepath.EndsWith(@"\") ? filepath : filepath + @"\";
         }
    }
    //</Basic>

    //<WithAttributes>
    #nullable enable
    private static void Process(string?[] lines, string mark)
    {
        foreach (var line in lines)
        {
            if (IsValid(line))
            {
                // Processing logic...
            }
        }

        bool IsValid([NotNullWhen(true)] string? line)
        {
            return !string.IsNullOrEmpty(line) && line.Length >= mark.Length;
        }
    }
    //</WithAttributes>
    #nullable disable

    //<FactorialWithLocal>
    public static int LocalFunctionFactorial(int n)
    {
        return nthFactorial(n);

        int nthFactorial(int number) => number < 2 
            ? 1 
            : number * nthFactorial(number - 1);
    }
    //</FactorialWithLocal>

    //<FactorialWithLambda>
    public static int LambdaFactorial(int n)
    {
        Func<int, int> nthFactorial = default(Func<int, int>);

        nthFactorial = number => number < 2
            ? 1
            : number * nthFactorial(number - 1);

        return nthFactorial(n);
    }
    //</FactorialWithLambda>

    //<AsyncWithLambda>
    public async Task<string> PerformLongRunningWorkLambda(string address, int index, string name)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException(message: "An address is required", paramName: nameof(address));
        if (index < 0)
            throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

        Func<Task<string>> longRunningWorkImplementation = async () =>
        {
            var interimResult = await FirstWork(address);
            var secondResult = await SecondStep(index, name);
            return $"The results are {interimResult} and {secondResult}. Enjoy.";
        };

        return await longRunningWorkImplementation();
    }
    //</AsyncWithLambda>

    //<AsyncWithLocal>
    public async Task<string> PerformLongRunningWork(string address, int index, string name)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException(message: "An address is required", paramName: nameof(address));
        if (index < 0)
            throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

        return await longRunningWorkImplementation();

        async Task<string> longRunningWorkImplementation()
        {
            var interimResult = await FirstWork(address);
            var secondResult = await SecondStep(index, name);
            return $"The results are {interimResult} and {secondResult}. Enjoy.";
        }
    }
    //</AsyncWithLocal>

    private async Task<int> FirstWork(string address)
    {
        await Task.Delay(100);
        return 10;
    }

    private async Task<int> SecondStep(int index, string name)
    {
        await Task.Delay(100);
        return 9;
    }

    //<YieldReturn>
    public IEnumerable<string> SequenceToLowercase(IEnumerable<string> input)
    {
        if (!input.Any())
        {
            throw new ArgumentException("There are no items to convert to lowercase.");
        }
        
        return LowercaseIterator();
        
        IEnumerable<string> LowercaseIterator()
        {
            foreach (var output in input.Select(item => item.ToLower()))
            {
                yield return output;
            }
        }
    }
    //</YieldReturn>
}
