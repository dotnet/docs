using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

#pragma warning disable CS0612
public class Program
{
    public static void Main(string[] args)
    {
        var c = new MyClass();  // this should trigger a warning at compile time since MyClass has an Obsolete attribute

        // this code enumerates all the possible targets of an attributes
        // for purposes of compile time checking
        var targets = new List<AttributeTargets>
        {
            AttributeTargets.All,
            AttributeTargets.Assembly,
            AttributeTargets.Class,
            AttributeTargets.Constructor,
            AttributeTargets.Delegate,
            AttributeTargets.Enum,
            AttributeTargets.Event,
            AttributeTargets.Field,
            AttributeTargets.GenericParameter,
            AttributeTargets.Interface,
            AttributeTargets.Method,
            AttributeTargets.Module,
            AttributeTargets.Parameter,
            AttributeTargets.Property,
            AttributeTargets.ReturnValue,
            AttributeTargets.Struct
        };

        // <ReflectionExample1>
        TypeInfo typeInfo = typeof(MyClass).GetTypeInfo();
        Console.WriteLine("The assembly qualified name of MyClass is " + typeInfo.AssemblyQualifiedName);
        // </ReflectionExample1>

        // <ReflectionExample2>
        var attrs = typeInfo.GetCustomAttributes();
        foreach(var attr in attrs)
            Console.WriteLine("Attribute on MyClass: " + attr.GetType().Name);
        // </ReflectionExample2>
    }
}

// <ObsoleteExample1>
[Obsolete]
public class MyClass
{
}
// </ObsoleteExample1>

// <ObsoleteExample2>
[Obsolete("ThisClass is obsolete. Use ThisClass2 instead.")]
public class ThisClass
{
}
// </ObsoleteExample2>
#pragma warning restore CS0612
// <CreateAttributeExample1>
public class MySpecialAttribute : Attribute
{
}
// </CreateAttributeExample1>

// <CreateAttributeExample2>
[MySpecial]
public class SomeOtherClass
{
}
// </CreateAttributeExample2>

// <AttributeUsageExample1>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class MyAttributeForClassAndStructOnly : Attribute
{
}
// </AttributeUsageExample1>

// <AttributeUsageExample2>
public class Foo
{
    // if the below attribute was uncommented, it would cause a compiler error
    // [MyAttributeForClassAndStructOnly]
    public Foo()
    { }
}
// </AttributeUsageExample2>

// <CallerMemberName1>
public class MyUIClass : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void RaisePropertyChanged([CallerMemberName] string propertyName = default!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string? _name;
    public string? Name
    {
        get { return _name;}
        set
        {
            if (value != _name)
            {
                _name = value;
                RaisePropertyChanged();   // notice that "Name" is not needed here explicitly
            }
        }
    }
}
// </CallerMemberName1>

/*
// <AttributeGotcha1>
public class GotchaAttribute : Attribute
{
    public GotchaAttribute(Foo myClass, string str)
    {
    }
}
// </AttributeGotcha1>

// <AttributeGotcha2>
[Gotcha(new Foo(), "test")] // does not compile
public class AttributeFail
{
}
// </AttributeGotcha2>
*/
