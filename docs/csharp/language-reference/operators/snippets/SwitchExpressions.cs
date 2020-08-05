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
            var item = TypeExample(collection);
            Console.WriteLine(item);
            item = RecursiveExample(collection);
            Console.WriteLine(item);

            item = RecursiveExample(collection[0..0]);
            Console.WriteLine(item);
            item = RecursiveExample(collection[0..1]);
            Console.WriteLine(item);
            item = RecursiveExample(collection[0..2]);
            Console.WriteLine(item);

            item = CaseGuardExample(collection.AsEnumerable());
            Console.WriteLine(item);
            item = CaseGuardExample(collection[0..0].AsEnumerable());
            Console.WriteLine(item);
            item = CaseGuardExample(collection[0..1].AsEnumerable());
            Console.WriteLine(item);
            item = CaseGuardExample(collection[0..2].AsEnumerable());
            try {
                item = ExhaustiveExample(default(List<int>));
                Console.WriteLine(item);
            } catch (ArgumentNullException e)
            {
                Console.WriteLine($"Caught expected exception: {e.Message}");
            }

        }

        // <SnippetTypePattern>
        public static T TypeExample<T>(IEnumerable<T> sequence) =>
            sequence switch
            {
                System.Array array => (T)array.GetValue(2),
                IList<T> list      => list[2],
                IEnumerable<T> seq => seq.Skip(2).First(),
            };
        // </SnippetTypePattern>

        // <SnippetRecursivePattern>
        public static T RecursiveExample<T>(IEnumerable<T> sequence) =>
            sequence switch
            {
                System.Array { Length : 0}       => default(T),
                System.Array { Length : 1} array => (T)array.GetValue(0),
                System.Array { Length : 2} array => (T)array.GetValue(1),
                System.Array array               => (T)array.GetValue(2),
                IList<T> list                    => list[2],
                IEnumerable<T> seq               => seq.Skip(2).First(),
            };
        // </SnippetRecursivePattern>

        // <SnippetGuardCase>
        public static T CaseGuardExample<T>(IEnumerable<T> sequence) =>
            sequence switch
            {
                System.Array { Length : 0}                => default(T),
                System.Array { Length : 1} array          => (T)array.GetValue(0),
                System.Array { Length : 2} array          => (T)array.GetValue(1),
                System.Array array                        => (T)array.GetValue(2),
                IEnumerable<T> list when !list.Any()      => default(T),
                IEnumerable<T> list when list.Count() < 3 => list.Last(),
                IList<T> list                             => list[2],
                IEnumerable<T> seq                        => seq.Skip(2).First(),
            };
        // </SnippetGuardCase>

        // <SnippetExhaustive>
        public static T ExhaustiveExample<T>(IEnumerable<T> sequence) =>
            sequence switch
            {
                System.Array { Length : 0}       => default(T),
                System.Array { Length : 1} array => (T)array.GetValue(0),
                System.Array { Length : 2} array => (T)array.GetValue(1),
                System.Array array               => (T)array.GetValue(2),
                IEnumerable<T> list
                    when !list.Any()             => default(T),
                IEnumerable<T> list
                    when list.Count() < 3        => list.Last(),
                IList<T> list                    => list[2],
                null                             => throw new ArgumentNullException(nameof(sequence)),
                _                                => sequence.Skip(2).First(),
            };
        // </SnippetExhaustive>
    }
}

