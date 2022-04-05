using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    void Method(string firstName, string lastName, string? nickName, string? message)
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

// <HandCodedConstruction>
public class B
{
    public B()
    {
        Console.WriteLine("In B constructor");
    }
}

public class D : B
{
    private string identity = CreateNextIdentityString();
    private string data;

    public D()
    {
        Console.WriteLine("Parameterless D constructor");
    }
    public D(string arg) : this()
    {
        if (arg is null) throw new ArgumentNullException(nameof(arg));
        data = arg;
    }

    private static string CreateNextIdentityString()
    {
        Console.WriteLine("Creating identity string");
        return DateTime.Now.Ticks.ToString();
    }
}
// </HandCodedConstruction>

public class Simplified
{
    public class D : B
    {
        private string identity = CreateNextIdentityString();
        private string data;

        public D()
        {
            Console.WriteLine("Parameterless D constructor");
        }

        // <SimplifiedConstructorCheck>
        public D(string arg!!) : this()
        {
            data = arg;
        }
        // </SimplifiedConstructorCheck>

        private static string CreateNextIdentityString()
        {
            Console.WriteLine("Creating identity string");
            return DateTime.Now.Ticks.ToString();
        }
    }

    public class Characterizer
    {
        // <IteratorMethodSimplified>
        public IEnumerable<int> CharsIn(string data!!)
        {
            foreach (var ch in data)
            {
                yield return ch;
            }
        }
        // </IteratorMethodSimplified>

        // async

        public async Task<int> SumCharsIn(string data!!)
        {
            await Task.Delay(500);
            int sum = data.Sum(x => x);
            return sum;
        }

        // async enumerable
        public async IAsyncEnumerable<int> CharsInAsync(string data!!)
        {
            foreach (var ch in data)
            {
                if (ch % 5 == 0)
                    await Task.Delay(500);
                yield return ch;
            }
        }
    }

}

public class Characterizer
{
    // <IteratorMethod>
    public IEnumerable<int> CharsIn(string data)
    {
        if (data is null) throw new ArgumentNullException(nameof(data));

        foreach (var ch in data)
        {
            yield return ch;
        }
    }
    // </IteratorMethod>

    // async
    // <AsyncMethod>
    public async Task<int> SumCharsIn(string data)
    {
        if (data is null) throw new ArgumentNullException(nameof(data));

        await Task.Delay(500);
        int sum = data.Sum(x => x);
        return sum;
    }
    // </AsyncMethod>

    // async enumerable
    // <AsyncIteratorMethod>
    public async IAsyncEnumerable<int> CharsInAsync(string data)
    {
        if (data is null) throw new ArgumentNullException(nameof(data));

        foreach (var ch in data)
        {
            if (ch % 5 == 0)
                await Task.Delay(500);
            yield return ch;
        }
    }
    // </AsyncIteratorMethod>
}

public static class NullChecks
{
    public static async Task Examples()
    {
        try
        {
            Console.WriteLine("Hand coded null check");
            _ = new D(null!);
        } catch (ArgumentNullException)
        {
            Console.WriteLine();
        }
        try
        {
            Console.WriteLine("Simplified null check");
            _ = new Simplified.D(null!);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine();
        }


        var characters = new Characterizer();
        try
        {
            // <Enumerate>
            Console.WriteLine("Call iterator");
            var sequence = characters.CharsIn(null!);
            Console.WriteLine("Enumerate values");
            foreach (var c in sequence)
                Console.WriteLine(c);
            // </Enumerate>
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }

        try 
        { 
            Console.WriteLine("Create task");
            var sumTask = characters.SumCharsIn(null!);
            Console.WriteLine("await task");
            Console.WriteLine(await sumTask);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }

        try
        { 
            Console.WriteLine("Call async iterator");
            var sequenceAsync = characters.CharsInAsync(null!);
            Console.WriteLine("Enumerate values");
            await foreach (var c in sequenceAsync)
                Console.WriteLine(c);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }

        var characters2 = new Simplified.Characterizer();
        try
        {
            Console.WriteLine("Call iterator");
            var sequence = characters2.CharsIn(null!);
            Console.WriteLine("Enumerate values");
            foreach (var c in sequence)
                Console.WriteLine(c);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }

        try
        {
            Console.WriteLine("Create task");
            var sumTask = characters2.SumCharsIn(null!);
            Console.WriteLine("await task");
            Console.WriteLine(await sumTask);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }

        try
        {
            Console.WriteLine("Call async iterator");
            var sequenceAsync = characters2.CharsInAsync(null!);
            Console.WriteLine("Enumerate values");
            await foreach (var c in sequenceAsync)
                Console.WriteLine(c);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine();
        }
    }
}
