using System;
using System.Collections.Generic;


public class Class3
{
    // Collections (C# and Visual Basic)
    // e76533a9-5033-4a0b-b003-9c2be60d185b

    public void Process()
    {
        ListCars();
        Console.WriteLine();
        ListColors();
        Console.WriteLine();
        ListEvenNumbers();
        Console.WriteLine();
    }

    //<Snippet31>
    private static void ListCars()
    {
        var cars = new List<Car>
        {
            { new Car() { Name = "car1", Color = "blue", Speed = 20}},
            { new Car() { Name = "car2", Color = "red", Speed = 50}},
            { new Car() { Name = "car3", Color = "green", Speed = 10}},
            { new Car() { Name = "car4", Color = "blue", Speed = 50}},
            { new Car() { Name = "car5", Color = "blue", Speed = 30}},
            { new Car() { Name = "car6", Color = "red", Speed = 60}},
            { new Car() { Name = "car7", Color = "green", Speed = 50}}
        };

        // Sort the cars by color alphabetically, and then by speed
        // in descending order.
        cars.Sort();

        // View all of the cars.
        foreach (Car thisCar in cars)
        {
            Console.Write(thisCar.Color.PadRight(5) + " ");
            Console.Write(thisCar.Speed.ToString() + " ");
            Console.Write(thisCar.Name);
            Console.WriteLine();
        }

        // Output:
        //  blue  50 car4
        //  blue  30 car5
        //  blue  20 car1
        //  green 50 car7
        //  green 10 car3
        //  red   60 car6
        //  red   50 car2
    }

    public class Car : IComparable<Car>
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        public int CompareTo(Car other)
        {
            // A call to this method makes a single comparison that is
            // used for sorting.

            // Determine the relative order of the objects being compared.
            // Sort by color alphabetically, and then by speed in
            // descending order.

            // Compare the colors.
            int compare;
            compare = String.Compare(this.Color, other.Color, true);

            // If the colors are the same, compare the speeds.
            if (compare == 0)
            {
                compare = this.Speed.CompareTo(other.Speed);

                // Use descending order for speed.
                compare = -compare;
            }

            return compare;
        }
    }
    //</Snippet31>


    //<Snippet32>
    private static void ListColors()
    {
        var colors = new AllColors();

        foreach (Color theColor in colors)
        {
            Console.Write(theColor.Name + " ");
        }
        Console.WriteLine();
        // Output: red blue green
    }


    // Collection class.
    public class AllColors : System.Collections.IEnumerable
    {
        Color[] _colors =
        {
            new Color() { Name = "red" },
            new Color() { Name = "blue" },
            new Color() { Name = "green" }
        };

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(_colors);

            // Instead of creating a custom enumerator, you could
            // use the GetEnumerator of the array.
            //return _colors.GetEnumerator();
        }

        // Custom enumerator.
        private class ColorEnumerator : System.Collections.IEnumerator
        {
            private Color[] _colors;
            private int _position = -1;

            public ColorEnumerator(Color[] colors)
            {
                _colors = colors;
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return _colors[_position];
                }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _position++;
                return (_position < _colors.Length);
            }

            void System.Collections.IEnumerator.Reset()
            {
                _position = -1;
            }
        }
    }

    // Element class.
    public class Color
    {
        public string Name { get; set; }
    }
    //</Snippet32>


    //<Snippet33>
    private static void ListEvenNumbers()
    {
        foreach (int number in EvenSequence(5, 18))
        {
            Console.Write(number.ToString() + " ");
        }
        Console.WriteLine();
        // Output: 6 8 10 12 14 16 18
    }

    private static IEnumerable<int> EvenSequence(
        int firstNumber, int lastNumber)
    {
        // Yield even numbers in the range.
        for (var number = firstNumber; number <= lastNumber; number++)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }
    //</Snippet33>

}