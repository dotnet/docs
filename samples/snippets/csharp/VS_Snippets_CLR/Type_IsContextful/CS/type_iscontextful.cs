// <Snippet1>
using System;
using System.Runtime.Remoting.Contexts;

public class ContextBoundClass: ContextBoundObject
{
    public string Value = "The Value property.";
}

public class Example
{
    public static void Main()
    {
         // Determine whether the types can be hosted in a Context.
         Console.WriteLine("The IsContextful property for the {0} type is {1}.",
                           typeof(Example).Name, typeof(Example).IsContextful);
         Console.WriteLine("The IsContextful property for the {0} type is {1}.",
                           typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsContextful);

         // Determine whether the types are marshalled by reference.
         Console.WriteLine("The IsMarshalByRef property of {0} is {1}.",
                           typeof(Example).Name, typeof(Example).IsMarshalByRef);
         Console.WriteLine("The IsMarshalByRef property of {0} is {1}.",
                           typeof(ContextBoundClass).Name, typeof(ContextBoundClass).IsMarshalByRef);
         
         // Determine whether the types are primitive datatypes.
         Console.WriteLine("{0} is a primitive data type: {1}.",
                           typeof(int).Name, typeof(int).IsPrimitive);
         Console.WriteLine("{0} is a primitive data type: {1}.",
                           typeof(string).Name, typeof(string).IsPrimitive);
    }
}
// The example displays the following output:
//    The IsContextful property for the Example type is False.
//    The IsContextful property for the ContextBoundClass type is True.
//    The IsMarshalByRef property of Example is False.
//    The IsMarshalByRef property of ContextBoundClass is True.
//    Int32 is a primitive data type: True.
//    String is a primitive data type: False.
// </Snippet1>
