using System;
//<Snippet20>
using System.Collections;
using System.Collections.Generic;
//</Snippet20>


// Iterators (C# and Visual Basic)
// f45331db-d595-46ec-9142-551d3d1eb1a7

class Example21
{
    public static void Run() { Main(); }

    //<Snippet21>
    static void Main()
    {
        foreach (int number in SomeNumbers())
        {
            Console.Write(number.ToString() + " ");
        }
        // Output: 3 5 8
        Console.ReadKey();
    }

    public static System.Collections.IEnumerable SomeNumbers()
    {
        yield return 3;
        yield return 5;
        yield return 8;
    }
    //</Snippet21>
}


class Example22
{
    public static void Run() { Main(); }

    //<Snippet22>
    static void Main()
    {
        foreach (int number in EvenSequence(5, 18))
        {
            Console.Write(number.ToString() + " ");
        }
        // Output: 6 8 10 12 14 16 18
        Console.ReadKey();
    }

    public static System.Collections.Generic.IEnumerable<int>
        EvenSequence(int firstNumber, int lastNumber)
    {
        // Yield even numbers in the range.
        for (int number = firstNumber; number <= lastNumber; number++)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }
    //</Snippet22>
}


class Example23
{
    public static void Run() { Main(); }

    //<Snippet23>
    static void Main()
    {
        DaysOfTheWeek days = new DaysOfTheWeek();

        foreach (string day in days)
        {
            Console.Write(day + " ");
        }
        // Output: Sun Mon Tue Wed Thu Fri Sat
        Console.ReadKey();
    }

    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week.
                yield return days[index];
            }
        }
    }
    //</Snippet23>
}



class Example24
{
    public static void Run() { Main(); }

    //<Snippet24>
    static void Main()
    {
        Zoo theZoo = new Zoo();

        theZoo.AddMammal("Whale");
        theZoo.AddMammal("Rhinoceros");
        theZoo.AddBird("Penguin");
        theZoo.AddBird("Warbler");

        foreach (string name in theZoo)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
        // Output: Whale Rhinoceros Penguin Warbler

        foreach (string name in theZoo.Birds)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
        // Output: Penguin Warbler

        foreach (string name in theZoo.Mammals)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
        // Output: Whale Rhinoceros

        Console.ReadKey();
    }

    public class Zoo : IEnumerable
    {
        // Private members.
        private List<Animal> animals = new List<Animal>();

        // Public methods.
        public void AddMammal(string name)
        {
            animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Mammal });
        }

        public void AddBird(string name)
        {
            animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Bird });
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Animal theAnimal in animals)
            {
                yield return theAnimal.Name;
            }
        }

        // Public members.
        public IEnumerable Mammals
        {
            get { return AnimalsForType(Animal.TypeEnum.Mammal); }
        }

        public IEnumerable Birds
        {
            get { return AnimalsForType(Animal.TypeEnum.Bird); }
        }

        // Private methods.
        private IEnumerable AnimalsForType(Animal.TypeEnum type)
        {
            foreach (Animal theAnimal in animals)
            {
                if (theAnimal.Type == type)
                {
                    yield return theAnimal.Name;
                }
            }
        }

        // Private class.
        private class Animal
        {
            public enum TypeEnum { Bird, Mammal }

            public string Name { get; set; }
            public TypeEnum Type { get; set; }
        }
    }
    //</Snippet24>
}


// Snippets 25, 26, and 27 do not apply in C#.


class Example28
{
    public static void Run() { Main(); }

    //<Snippet28>
    static void Main()
    {
        Stack<int> theStack = new Stack<int>();

        //  Add items to the stack.
        for (int number = 0; number <= 9; number++)
        {
            theStack.Push(number);
        }

        // Retrieve items from the stack.
        // foreach is allowed because theStack implements
        // IEnumerable<int>.
        foreach (int number in theStack)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
        // Output: 9 8 7 6 5 4 3 2 1 0

        // foreach is allowed, because theStack.TopToBottom
        // returns IEnumerable(Of Integer).
        foreach (int number in theStack.TopToBottom)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
        // Output: 9 8 7 6 5 4 3 2 1 0

        foreach (int number in theStack.BottomToTop)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
        // Output: 0 1 2 3 4 5 6 7 8 9

        foreach (int number in theStack.TopN(7))
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
        // Output: 9 8 7 6 5 4 3

        Console.ReadKey();
    }

    public class Stack<T> : IEnumerable<T>
    {
        private T[] values = new T[100];
        private int top = 0;

        public void Push(T t)
        {
            values[top] = t;
            top++;
        }
        public T Pop()
        {
            top--;
            return values[top];
        }

        // This method implements the GetEnumerator method. It allows
        // an instance of the class to be used in a foreach statement.
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = top - 1; index >= 0; index--)
            {
                yield return values[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> TopToBottom
        {
            get { return this; }
        }

        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int index = 0; index <= top - 1; index++)
                {
                    yield return values[index];
                }
            }
        }

        public IEnumerable<T> TopN(int itemsFromTop)
        {
            // Return less than itemsFromTop if necessary.
            int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

            for (int index = top - 1; index >= startIndex; index--)
            {
                yield return values[index];
            }
        }

    }
    //</Snippet28>
}



