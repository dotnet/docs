using System;
using ImportedTypes;

namespace WarningWaves;

public class WaveFive
{
    public class Src
    {
        public bool Select<T>(Func<int, T> selector) => true;
    }

    public class Src2
    {
        public int Select<T>(Func<int, T> selector) => 0;
    }

    public static void Examples()
    {
        var w = new WaveFive();

        w.M(w);

        QueryExpression();
        QueryExpressionNoWarn();

    }

    private static void QueryExpression()
    {
        //<QueryPrecedence>
        bool b = true;
        var source = new Src();
        b = true;
        source = new Src();
        var a = b && from c in source select c;
        Console.WriteLine(a);

        var indexes = new Src2();
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        var range = array[0..from c in indexes select c];
        //</QueryPrecedence>
    }

    private static void QueryExpressionNoWarn()
    {
        //<QueryPrecedenceNoWarn>
        bool b = true;
        var source = new Src();
        b = true;
        source = new Src();
        var a = b && (from c in source select c);
        Console.WriteLine(a);

        var indexes = new Src2();
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        var range = array[0..(from c in indexes select c)];
        //</QueryPrecedenceNoWarn>
    }
    // <StaticTypeAsIs>
    static class StaticClass
    {
        public static void Thing() { }
    }

    void M(object o)
    {
        // warning: cannot use a static type in 'is' or 'as'
        if (o is StaticClass)
        {
            Console.WriteLine("Can't happen");
        }
        else
        {
            Console.WriteLine("o is not an instance of a static class");
        }
    }
    // </StaticTypeAsIs>

    // <StructsArentNull>
    class Program
    {
        public static void M(S s)
        {
            if (s == null) { } // CS8073: The result of the expression is always 'false'
            if (s != null) { } // CS8073: The result of the expression is always 'true'
        }
    }

    struct S
    {
        public static bool operator ==(S s1, S s2) => s1.Equals(s2);
        public static bool operator !=(S s1, S s2) => !s1.Equals(s2);
        public override bool Equals(object? other)
        {
            // Implementation elided
            return false;
        }
        public override int GetHashCode() => 0;

        // Other details elided...
    }
    // </StructsArentNull>

    // <StaticTypeInInterface>
    public static class Utilities
    {
        // elided
    }

    public interface IUtility
    {
        // CS8897
        public void SetUtility(Utilities u);

        // CS8898
        public Utilities GetUtility();
    }
    // </StaticTypeInInterface>


    // <DefiniteAssignmentWarnings>
    public struct DefiniteAssignmentWarnings
    {
        // CS8880
        public Struct Property { get; }
        // CS8881
        private Struct field;

        // CS8882
        public void Method(out Struct s)
        {

        }

        public DefiniteAssignmentWarnings(int dummy)
        {
            // CS8883
            Struct v2 = Property;
            // CS8884
            Struct v3 = field;
            // CS8885:
            DefiniteAssignmentWarnings p2 = this;
        }

        public static void Method2(out Struct s1)
        {
            // CS8886
            var s2 = s1;
            s1 = default;
        }

        public static void UseLocalStruct()
        {
            Struct r1;
            var r2 = r1;
        }
    }
    // </DefiniteAssignmentWarnings>


    // <DefiniteAssignment>
    public struct DefiniteAssignmentNoWarnings
    {
        // CS8880
        public Struct Property { get; } = default;
        // CS8881
        private Struct field = default;

        // CS8882
        public void Method(out Struct s)
        {
            s = default;
        }

        public DefiniteAssignmentNoWarnings(int dummy)
        {
            // CS8883
            Struct v2 = Property;
            // CS8884
            Struct v3 = field;
            // CS8885:
            DefiniteAssignmentNoWarnings p2 = this;
        }

        public static void Method2(out Struct s1)
        {
            // CS8886
            s1 = default;
            var s2 = s1;
        }

        public static void UseLocalStruct()
        {
            Struct r1 = default;
            var r2 = r1;
        }
    }
    // </DefiniteAssignment>
}
