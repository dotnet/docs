namespace ReferenceReturns
{
    // <ReferenceReturns>
    using System;

    public class NumberStore
    {
        private readonly int[] numbers = [1, 30, 7, 1557, 381, 63, 1027, 2550, 511, 1023];

        public ref int GetReferenceToMax()
        {
            ref int max = ref numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = ref numbers[i];
                }
            }
            return ref max;
        }

        public override string ToString() => string.Join(" ", numbers);
    }

    public static class ReferenceReturnExample
    {
        public static void Run()
        {
            var store = new NumberStore();
            Console.WriteLine($"Original sequence: {store.ToString()}");
            
            ref int max = ref store.GetReferenceToMax();
            max = 0;
            Console.WriteLine($"Updated sequence:  {store.ToString()}");
            // Output:
            // Original sequence: 1 30 7 1557 381 63 1027 2550 511 1023
            // Updated sequence:  1 30 7 1557 381 63 1027 0 511 1023
        }
    }
    // </ReferenceReturns>
}
