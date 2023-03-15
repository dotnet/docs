
namespace GenericsExamples;

//<CustomAttribute>
class CustomAttribute : Attribute
{
    public object? info;
}
//</CustomAttribute>

//<GenericClassAsAttribute>
public class GenericClass1<T> { }

[CustomAttribute(info = typeof(GenericClass1<>))]
class ClassA { }
//</GenericClassAsAttribute>

//<TypeParameters>
public class GenericClass2<T, U> { }

[CustomAttribute(info = typeof(GenericClass2<,>))]
class ClassB { }
//</TypeParameters>

//<ClosedGeneric>
public class GenericClass3<T, U, V> { }

[CustomAttribute(info = typeof(GenericClass3<int, double, string>))]
class ClassC { }
//</ClosedGeneric>

//<GenericAttribute>
public class CustomGenericAttribute<T> : Attribute { }  //Requires C# 11
//</GenericAttribute>
