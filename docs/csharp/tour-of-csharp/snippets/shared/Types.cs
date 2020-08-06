using System;
using System.Reflection;

namespace DeclareTypes
{
    // <PointStruct>
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y) => (X, Y) = (x, y);
    }
    // </PointStruct>
}
namespace TourOfCsharp
{
    // <PointClass>
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    // </PointClass>

    // <DefinePairClass>
    public class Pair<TFirst, TSecond>
    {
        public TFirst First;
        public TSecond Second;
    }
    // </DefinePairClass>

    // <Create3DPoint>
    public class Point3D : Point
    {
        public int z;
        public Point3D(int x, int y, int z) :
            base(x, y)
        {
            this.z = z;
        }
    }
    // </Create3DPoint>

    // <FirstInterfaces>
    interface IControl
    {
        void Paint();
    }
    interface ITextBox : IControl
    {
        void SetText(string text);
    }
    interface IListBox : IControl
    {
        void SetItems(string[] items);
    }
    interface IComboBox : ITextBox, IListBox { }
    // </FirstInterfaces>

    // <ImplementInterfaces>
    interface IDataBound
    {
        void Bind(Binder b);
    }
    public class EditBox : IControl, IDataBound
    {
        public void Paint() { }
        public void Bind(Binder b) { }
    }
    // </ImplementInterfaces>

    // <EnumDeclaration>
    // A traditional enumeration of some root vegetables.
    public enum SomeRootVegetables
    {
        HorseRadish,
        Radish,
        Turnip
    }
    // </EnumDeclaration>

    // <FlagsEnumDeclaration>
    // A bit field or flag enumeration of harvesting seasons.
    [Flags]
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 4,
        Spring = 8,
        All = Summer | Autumn | Winter | Spring
    }
    // </FlagsEnumDeclaration>


    public static class Types
    {
        public static void Examples()
        {
            // <CreatePoints>
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 20);
            // </CreatePoints>

            // <CreatePairObject>
            Pair<int, string> pair = new Pair<int, string> { First = 1, Second = "two" };
            int i = pair.First;     // TFirst is int
            string s = pair.Second; // TSecond is string
                                    // </CreatePairObject>

            // <ImplicitCastToBase>
            Point a = new Point(10, 20);
            Point b = new Point3D(10, 20, 30);
            // </ImplicitCastToBase>

            // <UseInterfaces>
            EditBox editBox = new EditBox();
            IControl control = editBox;
            IDataBound dataBound = editBox;
            // </UseInterfaces>

            // <UsingEnums>
            var turnip = SomeRootVegetables.Turnip;

            var spring = Seasons.Spring;
            var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
            var theYear = Seasons.All;
            // </UsingEnums>

            // <DeclareNullable>
            int? optionalInt = default; 
            optionalInt = 5;
            string? optionalText = default;
            optionalText = "Hello World.";
            // </DeclareNullable>

            // <DeclareTuples>
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
            // Output:
            // Sum of 3 elements is 4.5.
            // </DeclareTuples>
        }
    }
}
