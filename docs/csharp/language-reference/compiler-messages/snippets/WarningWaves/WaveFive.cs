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


    // <UninitializedAutoProp>
    public struct UninitializedProperty
    {
        public Struct Property { get; }

        // CS8880
        public UninitializedProperty(int dummy)
        {
        }
    }
    // </UninitializedAutoProp>

    // <UninitializedField>
    public struct UninitializedField
    {
        private Struct field;

        // CS8881
        public UninitializedField(int dummy)
        {
        }
    }
    // </UninitializedField>

    // <UninitializedOutParam>
    // CS8882
    public void Method(out Struct s)
    {

    }
    // </UninitializedOutParam>

    // <UseBeforeAssignment>
    public struct ClientStruct
    {
        public Struct Property { get; }
        ClientStruct(int dummy)
        {
            // CS8883
            Struct v2 = Property;
            Property = default;
        }
    }
    // </UseBeforeAssignment>

    // <AccessFieldBeforeAssignment>
    public struct AccessField
    {
        public Struct Field;
        AccessField(int dummy)
        {
            // CS8884
            Struct v2 = Field;
            Field = default;
        }
    }
    // </AccessFieldBeforeAssignment>

    // <AccessThisBeforeAssignment>
    public struct AccessThis
    {
        public Struct Field;
        AccessThis(int dummy)
        {
            // CS8885:
            AccessThis p2 = this;
            this.Field = default;
        }
    }
    // </AccessThisBeforeAssignment>


    // <UseOutBeforeAssignment>
    public static void Method2(out Struct s1)
    {
        // CS8886
        var s2 = s1;
        s1 = default;
    }
    // </UseOutBeforeAssignment>

    // <UseLocalStruct>
    public static void UseLocalStruct()
    {
        Struct r1;
        var r2 = r1;
    }
    // </UseLocalStruct>

}
