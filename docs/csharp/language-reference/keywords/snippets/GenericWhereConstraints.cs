using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Keywords
{
    // <Snippet1>
    public class AGenericClass<T> where T : IComparable<T> { }
    // </Snippet1>

    // <SNippet2>
    public class UsingEnum<T> where T : System.Enum { }

    public class UsingDelegate<T> where T : System.Delegate { }

    public class Multicaster<T> where T : System.MulticastDelegate { }
    // </Snippet2>

    // <Snippet3>
    class MyClass<T, U>
        where T : class
        where U : struct
    { }
    // </Snippet3>

    // <Snippet4>
    class UnManagedWrapper<T>
        where T : unmanaged
    { }
    // </Snippet4>

    // <SnippetNotNull>
#nullable enable
    class NotNullContainer<T>
        where T : notnull
    {
    }
#nullable restore
    // </SnippetNotNull>

    // <Snippet5>
    public class MyGenericClass<T> where T : IComparable<T>, new()
    {
        // The following line is not possible without new() constraint:
        T item = new T();
    }
    // </Snippet5>

    // <SnippetRefStruct>
    public class GenericRefStruct<T> where T : allows ref struct
    {
        // Scoped is allowed because T might be a ref struct
        public void M(scoped T parm)
        {

        }
    }
    // </SnippetRefStruct>

    // <Snippet6>
    public interface IMyInterface { }

    namespace CodeExample
    {
        class Dictionary<TKey, TVal>
            where TKey : IComparable<TKey>
            where TVal : IMyInterface
        {
            public void Add(TKey key, TVal val) { }
        }
    }
    // </Snippet6>
    public class Container
    {
        // <Snippet7>
        public void MyMethod<T>(T t) where T : IMyInterface { }
        // </Snippet7>

        // <Snippet8>
        delegate T MyDelegate<T>() where T : new();
        // </Snippet8>
    }


    public interface IEmployee
    {
    }

    // <BaseClass>
    public abstract class B
    {
        public void M<T>(T? item) where T : struct { }
        public abstract void M<T>(T? item);

    }
    // </BaseClass>

    // <DerivedClass>
    public class D : B
    {
        // Without the "default" constraint, the compiler tries to override the first method in B
        public override void M<T>(T? item) where T : default { }
    }
    // </DerivedClass>
}
