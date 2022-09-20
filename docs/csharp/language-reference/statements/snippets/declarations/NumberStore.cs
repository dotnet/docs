﻿namespace RefReturns
{

    // <Snippet1>
    using System;

    class NumberStore
    {
        int[] numbers = { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 };

        public ref int FindNumber(int target)
        {
            for (int ctr = 0; ctr < numbers.Length; ctr++)
            {
                if (numbers[ctr] >= target)
                    return ref numbers[ctr];
            }
            return ref numbers[0];
        }

        public override string ToString() => string.Join(" ", numbers);
    }
    // </Snippet1>

    public static class FirstExample
    {
        public static void Tests()
        {
            // <Snippet2>
            var store = new NumberStore();
            Console.WriteLine($"Original sequence: {store.ToString()}");
            int number = 16;
            ref var value = ref store.FindNumber(number);
            value *= 2;
            Console.WriteLine($"New sequence:      {store.ToString()}");
            // The example displays the following output:
            //       Original sequence: 1 3 7 15 31 63 127 255 511 1023
            //       New sequence:      1 3 7 15 62 63 127 255 511 1023
            // </Snippet2>
        }
    }
}
