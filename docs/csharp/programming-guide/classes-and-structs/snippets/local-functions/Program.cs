using System;
using System.Threading.Tasks;

namespace local_functions
{
    class Program
    {
        static async Task Main(string[] args)
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
        public Task<string> PerformLongRunningWorkLambda(string address, int index, string name)
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

            return longRunningWorkImplementation();
        }
        //</AsyncWithLambda>

        //<AsyncWithLocal>
        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

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
    }
}
