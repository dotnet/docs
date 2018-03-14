// REDMOND\glennha
//<Snippet1>
using namespace System;
using namespace System::Reflection;

generic<typename T, typename U> public ref class Base {};

generic<typename T> public ref class G {};

generic<typename V> public ref class Derived : Base<String^, V>
{
public: 
    G<Derived<V>^>^ F;

    ref class Nested {};
};

void DisplayGenericType(Type^ t, String^ caption)
{
    Console::WriteLine("\n{0}", caption);
    Console::WriteLine("    Type: {0}", t);

    Console::WriteLine("\t            IsGenericType: {0}", 
        t->IsGenericType);
    Console::WriteLine("\t  IsGenericTypeDefinition: {0}", 
        t->IsGenericTypeDefinition);
    Console::WriteLine("\tContainsGenericParameters: {0}", 
        t->ContainsGenericParameters);
    Console::WriteLine("\t       IsGenericParameter: {0}", 
        t->IsGenericParameter);
}

void main()
{
    // Get the generic type definition for Derived, and the base
    // type for Derived.
    //
    Type^ tDerived = Derived::typeid;
    Type^ tDerivedBase = tDerived->BaseType;

    // Declare an array of Derived<int>, and get its type.
    //
    array<Derived<int>^>^ d = gcnew array<Derived<int>^>(0);
    Type^ tDerivedArray = d->GetType();

    // Get a generic type parameter, the type of a field, and a
    // type that is nested in Derived. Notice that in order to
    // get the nested type it is necessary to either (1) specify
    // the generic type definition Derived::typeid, as shown here,
    // or (2) specify a type parameter for Derived.
    //
    Type^ tT = Base::typeid->GetGenericArguments()[0];
    Type^ tF = tDerived->GetField("F")->FieldType;
    Type^ tNested = Derived::Nested::typeid;

    DisplayGenericType(tDerived, "generic<V> Derived");
    DisplayGenericType(tDerivedBase, "Base type of generic<V> Derived");
    DisplayGenericType(tDerivedArray, "Array of Derived<int>");
    DisplayGenericType(tT, "Type parameter T from generic<T> Base");
    DisplayGenericType(tF, "Field type, G<Derived<V>^>^");
    DisplayGenericType(tNested, "Nested type in generic<V> Derived");
}

/* This code example produces the following output:

generic<V> Derived
    Type: Derived`1[V]
                    IsGenericType: True
          IsGenericTypeDefinition: True
        ContainsGenericParameters: True
               IsGenericParameter: False

Base type of generic<V> Derived
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

Type parameter T from generic<T> Base
    Type: T
                    IsGenericType: False
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: True

Field type, G<Derived<V>^>^
    Type: G`1[Derived`1[V]]
                    IsGenericType: True
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: False

Nested type in generic<V> Derived
    Type: Derived`1+Nested[V]
                    IsGenericType: True
          IsGenericTypeDefinition: True
        ContainsGenericParameters: True
               IsGenericParameter: False
 */
//</Snippet1>



