using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operators;
public class SimplifiedNullParameterCheck
{

    // <BangBangExample>
    void Method(string name!!)
    {
        // ...
    }
    // </BangBangExample>

    // <MultipleParameters>
    void Method(string firstName!!, string lastName!!, string? nickName, string message)
    {
        // ...
    }
    // </MultipleParameters>
}

public class NullParameterCheck
{

    // <HandCodedExample>
    void Method(string name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        // ...
    }
    // </HandCodedExample>

    // <HandCodedMultipleParms>
    void Method(string firstName, string lastName, string nickName, string message)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName));
        }
        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName));
        }
        // ...
    }
    // </HandCodedMultipleParms>
}

// <NoAbstractMethods>
public abstract class AbstractClass
{
    // Simplified null parameter check not allowed:
    public abstract void Method(string name);

    // Simplified null check not allowed for "defaultName"
    // It could be added on a method or lambda that matches this 
    // delegate type:
    public delegate void SetDefaultString(string defaultName);
}

public interface IInterfaceMethods
{
    private static string defaultName = string.Empty;

    // Simplified null parameter check not allowed:
    void Method(string name);

    // !! allowed because an implementation is suppolied:
    public static void SetDefaultName(string name!!)
    {
        defaultName = name;
    }
}
// </NoAbstractMethods>


public class Container
{
    void M(string? name!!) { }
}
