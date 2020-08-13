using System;

namespace lambda_expressions
{
    // <SnippetVariableScope>
    public static class VariableScopeWithLambdas
    {
        public class VariableCaptureGame
        {
            internal Action<int> updateCapturedLocalVariable;
            internal Func<int, bool> isEqualToCapturedLocalVariable;

            public void Run(int input)
            {
                int j = 0;

                updateCapturedLocalVariable = x =>
                {
                    j = x;
                    bool result = j > input;
                    Console.WriteLine($"{j} is greater than {input}: {result}");
                };

                isEqualToCapturedLocalVariable = x => x == j;

                Console.WriteLine($"Local variable before lambda invocation: {j}");
                updateCapturedLocalVariable(10);
                Console.WriteLine($"Local variable after lambda invocation: {j}");
            }
        }

        public static void Main()
        {
            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
        }
        // Output:
        // Local variable before lambda invocation: 0
        // 10 is greater than 5: True
        // Local variable after lambda invocation: 10
        // Captured local variable is equal to 10: True
        // 3 is greater than 5: False
        // Another lambda observes a new value of captured variable: True
    }
    // </SnippetVariableScope>
}