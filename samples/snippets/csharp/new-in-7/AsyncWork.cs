using System;
using System.Threading.Tasks;

namespace new_in_7
{
    public class AsyncWork
    {
        // <SnippetTaskExample>
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
        // </SnippetTaskExample>

        private async Task<string> SecondStep(Int32 index, String name)
        {
            await Task.Delay(50);
            return "This could be a format string";
        }

        private async Task<int> FirstWork(String address)
        {
            await Task.Delay(100);
            return 42;
        }

        #region 36_TaskLambdaExample
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
        #endregion

        // <SnippetUsingValueTask>
        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }
        // </SnippetUsingValueTask>
    }
}
