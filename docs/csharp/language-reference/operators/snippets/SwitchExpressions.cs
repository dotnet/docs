using System;
using System.Collections.Generic;
using System.Linq;

namespace operators
{

    // <SnippetBasicStructure>
    public static class SwitchExample
    {
        public enum Directions
        {
            Up,
            Down,
            Right,
            Left
        }

        public enum Orientation
        {
            North,
            South,
            East,
            West
        }
    
        public static void Main()
        {
            var direction = Directions.Right;
            Console.WriteLine($"Map view direction is {direction}");

            var orientation = direction switch
            {
                Directions.Up    => Orientation.North,
                Directions.Right => Orientation.East,
                Directions.Down  => Orientation.South,
                Directions.Left  => Orientation.West,
            };
            Console.WriteLine($"Cardinal orientation is {orientation}");
        }
    }
    // </SnippetBasicStructure>

    public static class SwitchExpressions
    {
        public static void Examples()
        {
            SwitchExample.Main();

            var collection = new int[]{1,2,3,4,5,6,7,8,9};
            TypeExample(collection);
            RecursiveExample(collection);
            RecursiveExample(collection[0..0]);
            RecursiveExample(collection[0..1]);
            RecursiveExample(collection[0..2]);
            CaseGuardExample(collection.AsEnumerable());
            CaseGuardExample(collection[0..0].AsEnumerable());
            CaseGuardExample(collection[0..1].AsEnumerable());
            CaseGuardExample(collection[0..2].AsEnumerable());
            try {
                ExhaustiveExample(default(List<int>));
            } catch (ArgumentNullException e)
            {
                Console.WriteLine($"Caught expected exception: {e.Message}");
            }

        }


        private static void TypeExample<T>(IEnumerable<T> sequence)
        {
            // <SnippetTypePattern>
            var third = sequence switch
            {
                System.Array array => array.GetValue(2),
                IList<T> list => list[2],
                IEnumerable<T> seq => seq.Skip(2).First(),
            };
            Console.WriteLine(third);
            // </SnippetTypePattern>
        }

        private static void RecursiveExample<T>(IEnumerable<T> sequence)
        {
            // <SnippetRecursivePattern>
            var third = sequence switch
            {
                System.Array { Length : 0}        => default,
                System.Array { Length : 1} array => array.GetValue(0),
                System.Array { Length : 2} array => array.GetValue(1),
                System.Array array               => array.GetValue(2),
                IList<T> list                    => list[2],
                IEnumerable<T> seq               => seq.Skip(2).First(),
            };
            Console.WriteLine(third);
            // </SnippetRecursivePattern>
        }

        private static void CaseGuardExample<T>(IEnumerable<T> sequence)
        {
            // <SnippetGuardCase>
            var third = sequence switch
            {
                System.Array { Length : 0}                => default,
                System.Array { Length : 1} array          => array.GetValue(0),
                System.Array { Length : 2} array          => array.GetValue(1),
                System.Array array                        => array.GetValue(2),
                IEnumerable<T> list when !list.Any()      => default,
                IEnumerable<T> list when list.Count() < 3 => list.Last(),
                IList<T> list                             => list[2],
                IEnumerable<T> seq                        => seq.Skip(2).First(),
            };
            Console.WriteLine(third);
            // </SnippetGuardCase>
        }

        private static void ExhaustiveExample<T>(IEnumerable<T> sequence)
        {
            // <SnippetExhaustive>
            var third = sequence switch
            {
                System.Array { Length : 0}       => default,
                System.Array { Length : 1} array => array.GetValue(0),
                System.Array { Length : 2} array => array.GetValue(1),
                System.Array array               => array.GetValue(2),
                IEnumerable<T> list 
                    when !list.Any()             => default,
                IEnumerable<T> list 
                    when list.Count() < 3        => list.Last(),
                IList<T> list                    => list[2],
                null                             => throw new ArgumentNullException(nameof(sequence)),
                _                                => sequence.Skip(2).First(),
            };
            Console.WriteLine(third);
            // </SnippetExhaustive>
        }

        
    }
}

