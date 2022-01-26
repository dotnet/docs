using System.Reflection;

namespace DeclareTypes
{
    //<PointStruct>
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        
        public Point(double x, double y) => (X, Y) = (x, y);
    }
    //</PointStruct>
}
namespace TourOfCsharp
{
    //<PointClass>
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        
        public Point(int x, int y) => (X, Y) = (x, y);
    }
    //</PointClass>

    //<DefinePairClass>
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        
        public Pair(TFirst first, TSecond second) => 
            (First, Second) = (first, second);
    }
    //</DefinePairClass>

    //<Create3DPoint>
    public class Point3D : Point
    {
        public int Z { get; set; }
        
        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }
    //</Create3DPoint>

    //<FirstInterfaces>
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
    //</FirstInterfaces>

    //<ImplementInterfaces>
    interface IDataBound
    {
        void Bind(Binder b);
    }
    
    public class EditBox : IControl, IDataBound
    {
        public void Paint() { }
        public void Bind(Binder b) { }
    }
    //</ImplementInterfaces>

    //<EnumDeclaration>
    public enum SomeRootVegetable
    {
        HorseRadish,
        Radish,
        Turnip
    }
    //</EnumDeclaration>

    //<FlagsEnumDeclaration>
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
    //</FlagsEnumDeclaration>


    public static class Types
    {
        public static void Examples()
        {
            //<CreatePoints>
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 20);
            //</CreatePoints>

            //<CreatePairObject>
            var pair = new Pair<int, string>(1, "two");
            int i = pair.First;     //TFirst int
            string s = pair.Second; //TSecond string
            //</CreatePairObject>

            //<ImplicitCastToBase>
            Point a = new(10, 20);
            Point b = new Point3D(10, 20, 30);
            //</ImplicitCastToBase>

            //<UseInterfaces>
            EditBox editBox = new();
            IControl control = editBox;
            IDataBound dataBound = editBox;
            //</UseInterfaces>

            //<UsingEnums>
            var turnip = SomeRootVegetable.Turnip;

            var spring = Seasons.Spring;
            var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
            var theYear = Seasons.All;
            //</UsingEnums>

            //<DeclareNullable>
            int? optionalInt = default; 
            optionalInt = 5;
            string? optionalText = default;
            optionalText = "Hello World.";
            //</DeclareNullable>

            //<DeclareTuples>
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
            //Output:
            //Sum of 3 elements is 4.5.
            //</DeclareTuples>
        }
    }
}
