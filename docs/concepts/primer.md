# .NET Primer

By [Rich Lander](https://github.com/richlander), [Zlatko Knezevic](https://github.com/blackdwarf)

.NET is a general purpose development platform. It can be used for any kind of app type or workload where general purpose solutions are used. It has several key features that are attractive to many developers, including automatic memory management and modern programming languages, that make it easier to efficiently build high-quality applications. .NET enables a high-level programming environment with many convenience features, while providing low-level access to native memory and APIs.

Multiple implementations of .NET are available, based on open [.NET Standards](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) that specify the fundamentals of the platform. They are separately optimized for different application types (e.g. desktop, mobile, gaming, cloud) and support many chips (e.g. x86/x64, ARM) and operating systems (e.g. Windows, Linux, iOS, Android, OS X). Open source is also an important part of the .NET ecosystem, with multiple .NET implementations and many libraries available under OSI-approved licenses.

You can take a look at the [Overview of .NET implementations](editions-overview.md) document to figure out all of the different editions of the .NET Framework that are available, both Microsoft's and others.

This Primer will help you understand some of the key concepts in the .NET Platform and point you to more resources 
for each given topic. By the end of it, you should have enough information to be able to recognize significant terms and 
concepts in the .NET Platform and to know how to further your knowledge about them. 

## Key .NET Concepts

There is a certain number of concepts that are very important to understand if you are new to the .NET Platform. These concepts are the cornerstone of the entire platform, and understanding them at the outset is important for general understanding of how .NET works.

Most of these concepts are defined in the **What is .NET?** article. 


## A stroll through .NET

As any mature and advanced application development framework, .NET has many powerful features that make the developer's job easier and aim to make writing code more powerful and expressive. This section will outline the basics of the most salient features and provide pointers to more detailed discussions where needed. After finishing this stroll, you should have enough information to be able to read the samples on our GitHub repos as well as other code and understand what is going on.

*   [Programming languages](#programming-languages)
*   [Automatic memory management](#automatic-memory-management)
*   [Type safety](#type-safety)
*   [Delegates and lambdas](#delegates-and-lambdas)
*   [Generic Types (Generics)](#generic-types-generics)
*   [Language Integrated Query (LINQ)](#language-integrated-query-linq)
*   [Async Programming](#async-programming)
*   [Native interoperability](#native-interoperability)
*   [Unsafe Code](#unsafe-code)

## Programming languages

As a developer, you can choose any programming language that supports .NET to create your application. Because .NET provides language independence and interoperability, you can interact with other .NET applications and components regardless of the language with which they were developed.

Languages that allow you to develop applications for the .NET Platform adhere to the [Common Language Infrastructure (CLI) specification](https://www.visualstudio.com/en-us/mt639507).

Microsoft languages that .NET supports include C#, F#, and Visual Basic. 

* C# is simple, powerful, type-safe, and object-oriented while retaining the expressiveness and elegance of C-style languages. Anyone familiar with C and similar languages will find few problems in adapting to C#.

* F# is a cross-platform, functional-first programming language that also supports traditional object-oriented and imperative programming.

* Visual Basic is an easy language to learn that you can use to build a variety of applications that run on .NET.

> **Note**
> 
> In the RC2 release of .NET Core, only C# is fully supported.
>  

### Automatic memory management

Garbage collection is the most well-known of .NET features. Developers do not need to actively manage memory, although there are mechanisms to provide more information to the garbage collector (GC). C# includes the `new` keyword to allocate memory in terms of a particular type, and the `using` keyword to provide scope for the usage of the object. The GC operates on a lazy approach to memory management, preferring application throughput to the immediate collection of memory.

The following two lines both allocate memory:

```cs
var title = ".NET Primer";
var list = new List<string>;

```

There is no analogous keyword to de-allocate memory, as de-allocation happens automatically when the garbage collector reclaims the memory through its scheduled running.

Method variables normally go out of scope once a method completes, at which point they can be collected. However, you can indicate to the GC that a particular object is out of scope sooner than method exit using the `using` statement.

```cs
using(FileStream stream = GetFileStream(context))
{
    //operations on the stream
}

```

Once the `using` block completes, the GC will know that the `stream` object in the example above is free to be collected and its memory reclaimed.

One of the less obvious but quite far-reaching features that a garbage collector enables is memory safety. The invariant of memory safety is very simple: a program is memory safe if it accesses only memory that has been allocated (and not freed). Dangling pointers are always bugs, and tracking them down is often quite difficult.

The .NET runtime provides additional services, to complete the promise of memory safety, not naturally offered by a GC. It ensures that programs do not index off the end of an array or accessing a phantom field off the end of an object.

The following example will throw an exception as a result of memory safety.

```cs
int[] numbers = new int[42];
int number = numbers[42]; // will throw (indexes are 0-based)

```

### Type Safety

Objects are allocated in terms of types. The only operations allowed for a given object, and the memory it consumes, are those of its type. A `Dog` type may have `Jump` and `WagTail` methods, but not likely a `SumTotal` method. A program can only call the declared methods of a given type. All other calls will result either in a compile-time error or a run-time exception (in case of using dynamic features or `object`).

.NET languages are object-oriented, with hierarchies of base and derived classes. The .NET runtime will only allow object casts and calls that align with the object hierarchy. Remember that every type defined in any .NET language derives from the base `object` type.

```cs
Dog dog = Dog.AdoptDog(); // Returns a Dog type
Pet pet = (Pet)dog; // Dog derives from Pet
pet.ActCute();
Car car = (Car)dog; // will throw - no relationship between Car and Dog
object temp = (object)dog; // legal - a Dog is an object
car = (Car)temp; // will throw - the runtime isn't fooled
car.Accelerate() // the dog won't like this, nor will the program get this far

```

Type safety is also used to help enforce encapsulation by guaranteeing the fidelity of the accessor keywords. Accessor keywords are artifacts which control access to members of a given type by other code. These are usually used for various kinds of data within a type that are used to manage its behavior.

```cs
Dog dog = Dog._nextDogToBeAdopted; // will throw - this is a private field

```

Some .NET languages support **type inference**. Type inference means that the compiler will deduce the type of the expression on the left-hand side from the expression on the right-hand side. This doesn't mean that the type safety is broken or avoided. The resulting type **has** a strong type with everything that implies. Let's rewrite the first two lines of the previous example to introduce type inference. You will note that the rest of the example is completely the same.

```cs
  var dog = Dog.AdoptDog();
  var pet = (Pet)dog;
  pet.ActCute();
  Car car = (Car)dog; // will throw - no relationship between Car and Dog
  object temp = (object)dog; // legal - a Dog is an object
  car = (Car)temp; // will throw - the runtime isn't fooled
  car.Accelerate() // the dog won't like this, nor will the program get this far

```

### Delegates and Lambdas

Delegates are like C++ function pointers, with a big difference that they are type safe. They are a kind of disconnected method within the CLR type system. Regular methods are attached to a class and only directly callable through static or instance calling conventions.

Delegates are used in various APIs and places in the .NET world, especially through lambda expressions, which are a cornerstone of LINQ.

Read more about it in the [Delegates and lambdas](delegates-lambdas.md) document.

### Generic Types (Generics)

Generic types, also commonly called "generics" are a feature that was added in .NET Framework 2.0. In short, generics allow the programmer to introduce a "type parameter" when designing their classes, that will allow the client code (the users of the type) to specify the exact type to use in place of the type parameter.

Generics were added in order to help programmers implement generic data structures. Before their arrival, in order for a, say, _List_ type to be generic, it would have to work with elements that were of type _object_. This would have various performance as well as semantic problems, not to mention possible subtle runtime errors. The most notorious of the latter is when a data structure contains, for instance, both integers and strings, and an _InvalidCastException_ is thrown on working with the list's members.

The below sample shows a basic program running using an instance of _List<T>_ types.

```cs
using System;
using System.Collections.Generic;

namespace GenericsSampleShort {
    public static void Main(string[] args){
        // List<string> is the client way of specifying the actual type for the type parameter T
        List<string> listOfStrings = new List<string> { "First", "Second", "Third" };

        // listOfStrings can accept only strings, both on read and write.
        listOfStrings.Add("Fourth");

        // Below will throw a compile-time error, since the type parameter
        // specifies this list as containing only strings.
        listOfStrings.Add(1);

    }
}

```

Read more about it in the [Generic Types (Generics) Overview](generics.md) document.

### Async Programming

Async programming is a first-class concept within .NET, with async support in the runtime, the framework libraries, and .NET language constructs. Internally, they are based off of objects (such as `Task`) which take advantage of the operating system to perform I/O-bound jobs as efficiently as possible.

To learn more about async programming in .NET, start with the [Async Overview](../async/async-overview.md).

### Language Integrated Query (LINQ)

LINQ is a powerful set of features for C# and VB that allow you to write simple, declarative code for operating on data. The data can be in many forms (such as in-memory objects, in a SQL database, or an XML document), but the LINQ code you write typically won't look different for each data source!

To learn more and see some samples, check out [LINQ (Language Integrated Query)](linq.md).

### Native Interoperability

Every operating system in current use provides a lot of platform support for various programming tasks. .NET provides several ways to tap into those APIs. Collectively, this support is called "native interoperability" and in this section we will take a look at how to access native APIs from managed, .NET code.

The main way to do native interoperability is via "platform invoke" or P/Invoke for short. This support in .NET Core is available across Linux and Windows platforms. Another, Windows-only way of doing native interoperability is known as "COM interop" which is used to work with [COM components](https://msdn.microsoft.com/library/bwa2bx93.aspx) in managed code. It is built on top of P/Invoke infrastructure, but it works in subtly different ways.

Most of Mono's (and thus Xamarin's) interoperability support for Java and Objective-C are built similarly, that is, they use the same principles.

Read more about it in the [Native interoperability](native-interop.md) document.

### Unsafe Code

The CLR enables the ability to access native memory and do pointer arithmetic via `unsafe` code. These operations are needed for certain algorithms and system interoperability. Although powerful, use of unsafe code is discouraged unless it is necessary to interop with system APIs or implement the most efficient algorithm. Unsafe code may not execute the same way in different environments, and also loses the benefits of a garbage collector and type safety. It's recommended to confine and centralize unsafe code as much as possible, and test that code thoroughly.

The `ToString()` method from the [StringBuilder class](https://github.com/dotnet/coreclr/blob/master/src/mscorlib/src/System/Text/StringBuilder.cs#L327) illustrates how using `unsafe` code can efficiently implement an algorithm by moving around chunks of memory directly:

```cs
public override String ToString() {
          Contract.Ensures(Contract.Result<String>() != null);

          VerifyClassInvariant();

          if (Length == 0)
              return String.Empty;

          string ret = string.FastAllocateString(Length);
          StringBuilder chunk = this;
          unsafe {
              fixed (char* destinationPtr = ret)
              {
                  do
                  {
                      if (chunk.m_ChunkLength > 0)
                      {
                          // Copy these into local variables so that they are stable even in the presence of ----s (hackers might do this)
                          char[] sourceArray = chunk.m_ChunkChars;
                          int chunkOffset = chunk.m_ChunkOffset;
                          int chunkLength = chunk.m_ChunkLength;

                          // Check that we will not overrun our boundaries.
                          if ((uint)(chunkLength + chunkOffset) <= ret.Length && (uint)chunkLength <= (uint)sourceArray.Length)
                          {
                              fixed (char* sourcePtr = sourceArray)
                                  string.wstrcpy(destinationPtr + chunkOffset, sourcePtr, chunkLength);
                          }
                          else
                          {
                              throw new ArgumentOutOfRangeException("chunkLength", Environment.GetResourceString("ArgumentOutOfRange_Index"));
                          }
                      }
                      chunk = chunk.m_ChunkPrevious;
                  } while (chunk != null);
              }
          }
          return ret;
      }

```

## Notes

The term ".NET runtime" is used throughout the document to accommodate for the multiple implementations of .NET, such as CLR, Mono, IL2CPP and others. The more specific names are only used if needed.

This document is not intended to be historical in nature, but describe the .NET platform as it is now. It isn't important whether a .NET feature has always been available or was only recently introduced, only that it is important enough to highlight and discuss.
