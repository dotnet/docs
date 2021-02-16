using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public static class DeclarationAndTypePattern
    {
        public static void Examples()
        {
            IsExpression();
            SwitchExpression();
        }

        private static void IsExpression()
        {
            // <IsExpression>
            int? xNullable = 7;
            int y = 23;
            object yBoxed = y;
            if (xNullable is int a && yBoxed is int b)
            {
                Console.WriteLine(a + b);  // output: 30
            }
            // </IsExpression>
        }

        private static void SwitchExpression()
        {
            // <SwitchExpression>
            var numbers = new int[] { 10, 20, 30 };
            Console.WriteLine(GetCount(numbers));  // output: 3

            var letters = new List<char> { 'a', 'b', 'c', 'd' };
            Console.WriteLine(GetCount(letters));  // output: 4

            static int GetCount<T>(IEnumerable<T> source) => source switch
            {
                Array a => a.Length,
                ICollection<T> c => c.Count,
                _ => source.Count(),
            };
            // </SwitchExpression>
        }
    }

    namespace Vehicles
    {
        // <DiscardVariable>
        public abstract class Vehicle {}
        public class Car : Vehicle {}
        public class Truck : Vehicle {}

        public static class TollCalculator
        {
            public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
            {
                Car _ => 2.00m,
                Truck _ => 7.50m,
                null => throw new ArgumentNullException(nameof(vehicle)),
                _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
            };
        }
        // </DiscardVariable>

        public static class TollCalculatorWithTypePattern
        {
            // <TypePattern>
            public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
            {
                Car => 2.00m,
                Truck => 7.50m,
                null => throw new ArgumentNullException(nameof(vehicle)),
                _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
            };
            // </TypePattern>
        }
    }
}