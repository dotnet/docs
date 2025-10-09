using System;

namespace ca2012
{
    //<snippet1>
    public class NumberValueTask
    {
        public async ValueTask<int> GetNumberAsync()
        {
            await Task.Delay(100);
            return 123;
        }

        public async Task UseValueTaskIncorrectlyAsync()
        {
            // This code violates the rule,
            // because ValueTask is awaited multiple times
            ValueTask<int> numberValueTask = GetNumberAsync();

            int first = await numberValueTask;
            int second = await numberValueTask; // <- illegal reuse

            // ...
        }

        // This code satisfies the rule.
        public async Task UseValueTaskCorrectlyAsync()
        {
            int first = await GetNumberAsync();
            int second = await GetNumberAsync();

            // ..
        }

        public async Task UseValueTaskAsTaskAsync()
        {
            ValueTask<int> numberValueTask = GetNumberAsync();

            Task<int> numberTask = numberValueTask.AsTask();

            int first = await numberTask;
            int second = await numberTask;

            // ...
        }
    }
    //</snippet1>
}
