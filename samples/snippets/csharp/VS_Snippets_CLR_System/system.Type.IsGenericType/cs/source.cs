// REDMOND\glennha
//<Snippet1>
using System;
using System.Reflection;

public class Base<T, U> {}

public class Derived<V> : Base<string, V>
{
    public G<Derived <V>> F;

    public class Nested {}
}

public class G<T> {}

class Example
{
    public static void Main()
    {
        // Get the generic type definition for Derived, and the base
        // type for Derived.
        //
        Type tDerived = typeof(Derived<>);
        Type tDerivedBase = tDerived.BaseType;

        // Declare an array of Derived<int>, and get its type.
        //
        Derived<int>[] d = new Derived<int>[0];
        Type tDerivedArray = d.GetType();

        // Get a generic type parameter, the type of a field, and a
        // type that is nested in Derived. Notice that in order to
        // get the nested type it is necessary to either (1) specify
        // the generic type definition Derived<>, as shown here,
        // or (2) specify a type parameter for Derived.
        //
        Type tT = typeof(Base<,>).GetGenericArguments()[0];
        Type tF = tDerived.GetField("F").FieldType;
        Type tNested = typeof(Derived<>.Nested);

        DisplayGenericType(tDerived, "Derived<V>");
        DisplayGenericType(tDerivedBase, "Base type of Derived<V>");
        DisplayGenericType(tDerivedArray, "Array of Derived<int>");
        DisplayGenericType(tT, "Type parameter T from Base<T>");
        DisplayGenericType(tF, "Field type, G<Derived<V>>");
        DisplayGenericType(tNested, "Nested type in Derived<V>");
    }

    public static void DisplayGenericType(Type t, string caption)
    {
        Console.WriteLine("\n{0}", caption);
        Console.WriteLine("    Type: {0}", t);

        Console.WriteLine("\t            IsGenericType: {0}", 
            t.IsGenericType);
        Console.WriteLine("\t  IsGenericTypeDefinition: {0}", 
            t.IsGenericTypeDefinition);
        Console.WriteLine("\tContainsGenericParameters: {0}", 
            t.ContainsGenericParameters);
        Console.WriteLine("\t       IsGenericParameter: {0}", 
            t.IsGenericParameter);
    }
}

/* This code example produces the following output:

Derived<V>
    Type: Derived`1[V]
                    IsGenericType: True
          IsGenericTypeDefinition: True
        ContainsGenericParameters: True
               IsGenericParameter: False

Base type of Derived<V>
    Type: Base`2[System.String,V]
                    IsGenericType: True
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: False

Array of Derived<int>
    Type: Derived`1[System.Int32][]
                    IsGenericType: False
          IsGenericTypeDefinition: False
        ContainsGenericParameters: False
               IsGenericParameter: False

Type parameter T from Base<T>
    Type: T
                    IsGenericType: False
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: True

Field type, G<Derived<V>>
    Type: G`1[Derived`1[V]]
                    IsGenericType: True
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: False

Nested type in Derived<V>
    Type: Derived`1+Nested[V]
                    IsGenericType: True
          IsGenericTypeDefinition: True
        ContainsGenericParameters: True
               IsGenericParameter: False
 */
//</Snippet1>



