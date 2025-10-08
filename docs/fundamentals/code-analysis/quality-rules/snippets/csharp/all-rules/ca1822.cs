using System;
using System.Collections.Generic;

namespace ca1822
{
    public class Printer
    {
        private readonly List<char> _items = [
            'H', 'e', 'l', 'l', 'o',
        ];

        public void PrintHello()
        {
            BadPrintHelloInternal();
            GoodPrintHelloInternal();
            GoodPrintHelloStaticInternal();
        }

        // This method violates the rule.
        private void BadPrintHelloInternal()
        {
            Console.WriteLine("Hello");
        }

        // This methods satisfies the rule.
        private void GoodPrintHelloInternal()
        {
            Console.WriteLine(string.Join(string.Empty, this._items));
        }

        private static void GoodPrintHelloStaticInternal()
        {
            Console.WriteLine("Hello");
        }
    }
}
