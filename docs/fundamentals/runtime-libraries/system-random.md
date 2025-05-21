---
title: System.Random class
description: Learn about the System.Random class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Random class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Random> class represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.

Pseudo-random numbers are chosen with equal probability from a finite set of numbers. The chosen numbers are not completely random because a mathematical algorithm is used to select them, but they are sufficiently random for practical purposes. The implementation of the <xref:System.Random> class is based on a modified version of Donald E. Knuth's subtractive random number generator algorithm. For more information, see D. E. Knuth. *The Art of Computer Programming, Volume 2: Seminumerical Algorithms*. Addison-Wesley, Reading, MA, third edition, 1997.

To generate a cryptographically secure random number, such as one that's suitable for creating a random password, use one of the static methods in the <xref:System.Security.Cryptography.RandomNumberGenerator?displayProperty=nameWithType> class.

## Instantiate the random number generator

You instantiate the random number generator by providing a seed value (a starting value for the pseudo-random number generation algorithm) to a <xref:System.Random.%23ctor%2A> class constructor. You can supply the seed value either explicitly or implicitly:

- The <xref:System.Random.%23ctor%28System.Int32%29> constructor uses an explicit seed value that you supply.
- The <xref:System.Random.%23ctor> constructor uses the default seed value. This is the most common way of instantiating the random number generator.

In .NET Framework, the default seed value is time-dependent. In .NET Core, the default seed value is produced by the thread-static, pseudo-random number generator.

If the same seed is used for separate <xref:System.Random> objects, they will generate the same series of random numbers. This can be useful for creating a test suite that processes random values, or for replaying games that derive their data from random numbers. However, note that <xref:System.Random> objects in processes running under different versions of .NET Framework might return differentseries of random numbers even if they're instantiated with identical seed values.

To produce different sequences of random numbers, you can make the seed value time-dependent, thereby producing a different series with each new instance of <xref:System.Random>. The parameterized <xref:System.Random.%23ctor%28System.Int32%29> constructor can take an <xref:System.Int32> value based on the number of ticks in the current time, whereas the parameterless <xref:System.Random.%23ctor> constructor uses the system clock to generate its seed value. However, on .NET Framework only, because the clock has finite resolution, using the parameterless constructor to create different <xref:System.Random> objects in close succession creates random number generators that produce identical sequences of random numbers. The following example illustrates how two <xref:System.Random> objects that are instantiated in close succession in a .NET Framework application generate an identical series of random numbers. On most Windows systems, <xref:System.Random> objects created within 15 milliseconds of one another are likely to have identical seed values.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/Random1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/Random1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/Random1.vb" id="Snippet1":::

To avoid this problem, create a single <xref:System.Random> object instead of multiple objects. Note that the `Random` class in .NET Core does not have this limitation.

## Avoid multiple instantiations

On .NET Framework, initializing two random number generators in a tight loop or in rapid succession creates two random number generators that can produce identical sequences of random numbers. In most cases, this is not the developer's intent and can lead to performance issues, because instantiating and initializing a random number generator is a relatively expensive process.

Both to improve performance and to avoid inadvertently creating separate random number generators that generate identical numeric sequences, we recommend that you create one <xref:System.Random> object to generate many random numbers over time, instead of creating new <xref:System.Random> objects to generate one random number.

However, the <xref:System.Random> class isn't thread safe. If you call <xref:System.Random> methods from multiple threads, follow the guidelines discussed in the next section.

## Thread safety

Instead of instantiating individual <xref:System.Random> objects, we recommend that you create a single <xref:System.Random> instance to generate all the random numbers needed by your app. However, <xref:System.Random> objects are not thread safe. If your app calls <xref:System.Random> methods from multiple threads, you must use a synchronization object to ensure that only one thread can access the random number generator at a time. If you don't ensure that the <xref:System.Random> object is accessed in a thread-safe way, calls to methods that return random numbers return 0.

The following example uses the C# [lock Statement](/dotnet/csharp/language-reference/keywords/lock-statement), the F# [lock function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#lock) and the Visual Basic [SyncLock statement](../../visual-basic/language-reference/statements/synclock-statement.md) to ensure that a single random number generator is accessed by 11 threads in a thread-safe manner. Each thread generates 2 million random numbers, counts the number of random numbers generated and calculates their sum, and then updates the totals for all threads when it finishes executing.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/threadsafeex1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/threadsafeex1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/threadsafeex1.vb" id="Snippet3":::

The example ensures thread-safety in the following ways:

- The <xref:System.ThreadStaticAttribute> attribute is used to define thread-local variables that track the total number of random numbers generated and their sum for each thread.
- A lock (the `lock` statement in C#, the `lock` function in F# and the `SyncLock` statement in Visual Basic) protects access to the variables for the total count and sum of all random numbers generated on all threads.
- A semaphore (the <xref:System.Threading.CountdownEvent> object) is used to ensure that the main thread blocks until all other threads complete execution.
- The example checks whether the random number generator has become corrupted by determining whether two consecutive calls to random number generation methods return 0. If corruption is detected, the example uses the <xref:System.Threading.CancellationTokenSource> object to signal that all threads should be canceled.
- Before generating each random number, each thread checks the state of the <xref:System.Threading.CancellationToken> object. If cancellation is requested, the example calls the <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A?displayProperty=nameWithType> method to cancel the thread.

The following example is identical to the first, except that it uses a <xref:System.Threading.Tasks.Task> object and a lambda expression instead of <xref:System.Threading.Thread> objects.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/threadsafeex2.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/threadsafeex2.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/threadsafeex2.vb" id="Snippet4":::

It differs from the first example in the following ways:

- The variables to keep track of the number of random numbers generated and their sum in each task are local to the task, so there is no need to use the <xref:System.ThreadStaticAttribute> attribute.
- The static <xref:System.Threading.Tasks.Task.WaitAll%2A?displayProperty=nameWithType> method is used to ensure that the main thread doesn't complete before all tasks have finished. There is no need for the <xref:System.Threading.CountdownEvent> object.
- The exception that results from task cancellation is surfaced in the <xref:System.Threading.Tasks.Task.WaitAll%2A?displayProperty=nameWithType> method. In the previous example, it is handled by each thread.

## Generate different types of random numbers

The random number generator provides methods that let you generate the following kinds of random numbers:

- A series of <xref:System.Byte> values. You determine the number of byte values by passing an array initialized to the number of elements you want the method to return to the <xref:System.Random.NextBytes%2A> method. The following example generates 20 bytes.

  :::code language="csharp" source="./snippets/System/Random/Overview/csharp/nextbytes1.cs" interactive="try-dotnet-method" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/nextbytes1.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Random/Overview/vb/nextbytes1.vb" id="Snippet5":::

- A single integer. You can choose whether you want an integer from 0 to a maximum value (<xref:System.Int32.MaxValue?displayProperty=nameWithType> - 1) by calling the <xref:System.Random.Next> method, an integer between 0 and a specific value by calling the <xref:System.Random.Next%28System.Int32%29> method, or an integer within a range of values by calling the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method. In the parameterized overloads, the specified maximum value is exclusive; that is, the actual maximum number generated is one less than the specified value.

  The following example calls the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method to generate 10 random numbers between -10 and 10. Note that the second argument to the method specifies the exclusive upper bound of the range of random values returned by the method. In other words, the largest integer that the method can return is one less than this value.

  :::code language="csharp" source="./snippets/System/Random/Overview/csharp/nextex1.cs" interactive="try-dotnet-method" id="Snippet6":::
  :::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/nextex1.fs" id="Snippet6":::
  :::code language="vb" source="./snippets/System/Random/Overview/vb/nextex1.vb" id="Snippet6":::

- A single floating-point value from 0.0 to less than 1.0 by calling the <xref:System.Random.NextDouble%2A> method. The exclusive upper bound of the random number returned by the method is 1, so its actual upper bound is 0.99999999999999978. The following example generates 10 random floating-point numbers.

  :::code language="csharp" source="./snippets/System/Random/Overview/csharp/nextdoubleex1.cs" interactive="try-dotnet-method" id="Snippet7":::
  :::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/nextdoubleex1.fs" id="Snippet7":::
  :::code language="vb" source="./snippets/System/Random/Overview/vb/nextdoubleex1.vb" id="Snippet7":::

> [!IMPORTANT]
> The <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method allows you to specify the range of the returned random number. However, the `maxValue` parameter, which specifies the upper range returned number, is an exclusive, not an inclusive, value. This means that the method call `Next(0, 100)` returns a value between 0 and 99, and not between 0 and 100.

You can also use the <xref:System.Random> class for such tasks as generating [random Boolean values](#generate-random-boolean-values), generating [random floating-point values in a specified range](#retrieve-floating-point-values-in-a-specified-range), generating [Generate random 64-bit integers](#generate-random-64-bit-integers), and [retrieving a unique element from an array or collection](#retrieve-a-unique-element-from-an-array-or-collection).

## Substitute your own algorithm

You can implement your own random number generator by inheriting from the <xref:System.Random> class and supplying your random number generation algorithm. To supply your own algorithm, you must override the <xref:System.Random.Sample%2A> method, which implements the random number generation algorithm. You should also override the <xref:System.Random.Next>, <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29>, and <xref:System.Random.NextBytes%2A> methods to ensure that they call your overridden <xref:System.Random.Sample%2A> method. You don't have to override the <xref:System.Random.Next%28System.Int32%29> and <xref:System.Random.NextDouble%2A> methods.

For an example that derives from the <xref:System.Random> class and modifies its default pseudo-random number generator, see the <xref:System.Random.Sample%2A> reference page.

## Retrieve the same sequence of random values

Sometimes you want to generate the same sequence of random numbers in software test scenarios and in game playing. Testing with the same sequence of random numbers allows you to detect regressions and confirm bug fixes. Using the same sequence of random number in games allows you to replay previous games.

You can generate the same sequence of random numbers by providing the same seed value to the <xref:System.Random.%23ctor%28System.Int32%29> constructor. The seed value provides a starting value for the pseudo-random number generation algorithm. The following example uses 100100 as an arbitrary seed value to instantiate the <xref:System.Random> object, displays 20 random floating-point values, and persists the seed value. It then restores the seed value, instantiates a new random number generator, and displays the same 20 random floating-point values. Note that the example may produce different sequences of random numbers if run on different versions of .NET.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/same1.cs" interactive="try-dotnet" id="Snippet12":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/same1.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/same1.vb" id="Snippet12":::

## Retrieve unique sequences of random numbers

Providing different seed values to instances of the <xref:System.Random> class causes each random number generator to produce a different sequence of values. You can provide a seed value either explicitly by calling the <xref:System.Random.%23ctor%28System.Int32%29> constructor, or implicitly by calling the <xref:System.Random.%23ctor> constructor. Most developers call the parameterless constructor, which uses the system clock. The following example uses this approach to instantiate two <xref:System.Random> instances. Each instance displays a series of 10 random integers.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/unique.cs" interactive="try-dotnet" id="Snippet13":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/unique.fs" id="Snippet13":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/unique.vb" id="Snippet13":::

However, because of its finite resolution, the system clock doesn't detect time differences that are less than approximately 15 milliseconds. Therefore, if your code calls the <xref:System.Random.%23ctor> overload on .NET Framework to instantiate two <xref:System.Random> objects in succession, you might inadvertently be providing the objects with identical seed values. (The <xref:System.Random> class in .NET Core does not have this limitation.) To see this in the previous example, comment out the <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> method call, and compile and run the example again.

To prevent this from happening, we recommend that you instantiate a single <xref:System.Random> object rather than multiple ones. However, since <xref:System.Random> isn't thread safe, you must use some synchronization device if you access a <xref:System.Random> instance from multiple threads; for more information, see the [Thread safety](#thread-safety) section. Alternately, you can use a delay mechanism, such as the <xref:System.Threading.Thread.Sleep%2A> method used in the previous example, to ensure that the instantiations occur more than 15 millisecond apart.

## Retrieve integers in a specified range

You can retrieve integers in a specified range by calling the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method, which lets you specify both the lower and the upper bound of the numbers you'd like the random number generator to return. The upper bound is an exclusive, not an inclusive, value. That is, it isn't included in the range of values returned by the method. The following example uses this method to generate random integers between -10 and 10. Note that it specifies 11, which is one greater than the desired value, as the value of the `maxValue` argument in the method call.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/range1.cs" interactive="try-dotnet-method" id="Snippet15":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/range1.fs" id="Snippet15":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/range1.vb" id="Snippet15":::

## Retrieve integers with a specified number of digits

You can call the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method to retrieve numbers with a specified number of digits. For example, to retrieve numbers with four digits (that is, numbers that range from 1000 to 9999), you call the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method with a `minValue` value of 1000 and a `maxValue` value of 10000, as the following example shows.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/range2.cs" interactive="try-dotnet-method" id="Snippet16":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/range2.fs" id="Snippet16":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/range2.vb" id="Snippet16":::

## Retrieve floating-point values in a specified range

The <xref:System.Random.NextDouble%2A> method returns random floating-point values that range from 0 to less than 1. However, you'll often want to generate random values in some other range.

If the interval between the minimum and maximum desired values is 1, you can add the difference between the desired starting interval and 0 to the number returned by the <xref:System.Random.NextDouble%2A> method. The following example does this to generate 10 random numbers between -1 and 0.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/doublerange2.cs" interactive="try-dotnet-method" id="Snippet17":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/doublerange2.fs" id="Snippet17":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/doublerange2.vb" id="Snippet17":::

To generate random floating-point numbers whose lower bound is 0 but upper bound is greater than 1 (or, in the case of negative numbers, whose lower bound is less than -1 and upper bound is 0), multiply the random number by the non-zero bound. The following example does this to generate 20 million random floating-point numbers that range from 0 to <xref:System.Int64.MaxValue?displayProperty=nameWithType>. In also displays the distribution of the random values generated by the method.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/doublerange1.cs" interactive="try-dotnet-method" id="Snippet18":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/doublerange1.fs" id="Snippet18":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/doublerange1.vb" id="Snippet18":::

To generate random floating-point numbers between two arbitrary values, like the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method does for integers, use the following formula:

```csharp
Random.NextDouble() * (maxValue - minValue) + minValue
```

The following example generates 1 million random numbers that range from 10.0 to 11.0, and displays their distribution.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/doublerange3.cs" interactive="try-dotnet-method" id="Snippet19":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/doublerange3.fs" id="Snippet19":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/doublerange3.vb" id="Snippet19":::

## Generate random Boolean values

The <xref:System.Random> class doesn't provide methods that generate <xref:System.Boolean> values. However, you can define your own class or method to do that. The following example defines a class, `BooleanGenerator`, with a single method, `NextBoolean`. The `BooleanGenerator` class stores a <xref:System.Random> object as a private variable. The `NextBoolean` method calls the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29?displayProperty=nameWithType> method and passes the result to the <xref:System.Convert.ToBoolean%28System.Int32%29?displayProperty=nameWithType> method. Note that 2 is used as the argument to specify the upper bound of the random number. Since this is an exclusive value, the method call returns either 0 or 1.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/booleans1.cs" interactive="try-dotnet" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/booleans1.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/booleans1.vb" id="Snippet8":::

Instead of creating a separate class to generate random <xref:System.Boolean> values, the example could simply have defined a single method. In that case, however, the <xref:System.Random> object should have been defined as a class-level variable to avoid instantiating a new <xref:System.Random> instance in each method call. In Visual Basic, the Random instance can be defined as a [Static](../../visual-basic/language-reference/modifiers/static.md) variable in the `NextBoolean` method. The following example provides an implementation.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/booleans2.cs" interactive="try-dotnet-method" id="Snippet20":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/booleans2.fs" id="Snippet20":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/booleans2.vb" id="Snippet20":::

## Generate random 64-bit integers

The overloads of the <xref:System.Random.Next%2A> method return 32-bit integers. However, in some cases, you might want to work with 64-bit integers. You can do this as follows:

1. Call the <xref:System.Random.NextDouble%2A> method to retrieve a double-precision floating point value.

2. Multiply that value by <xref:System.Int64.MaxValue?displayProperty=nameWithType>.

The following example uses this technique to generate 20 million random long integers and categorizes them in 10 equal groups. It then evaluates the distribution of the random numbers by counting the number in each group from 0 to <xref:System.Int64.MaxValue?displayProperty=nameWithType>. As the output from the example shows, the numbers are distributed more or less equally through the range of a long integer.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/long1.cs" interactive="try-dotnet-method" id="Snippet14":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/long1.fs" id="Snippet14":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/long1.vb" id="Snippet14":::

An alternative technique that uses bit manipulation does not generate truly random numbers. This technique calls <xref:System.Random.Next> to generate two integers, left-shifts one by 32 bits, and ORs them together. This technique has two limitations:

1. Because bit 31 is the sign bit, the value in bit 31 of the resulting long integer is always 0. This can be addressed by generating a random 0 or 1, left-shifting it 31 bits, and ORing it with the original random long integer.

2. More seriously, because the probability that the value returned by <xref:System.Random.Next> will be 0, there will be few if any random numbers in the range 0x0-0x00000000FFFFFFFF.

## Retrieve bytes in a specified range

The overloads of the <xref:System.Random.Next%2A> method allow you to specify the range of random numbers, but the <xref:System.Random.NextBytes%2A> method does not. The following example implements a `NextBytes` method that lets you specify the range of the returned bytes. It defines a `Random2` class that derives from <xref:System.Random> and overloads its `NextBytes` method.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/bytes1.cs" interactive="try-dotnet" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/bytes1.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/bytes1.vb" id="Snippet9":::

The `NextBytes(Byte[], Byte, Byte)` method wraps a call to the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method and specifies the minimum value and one greater than the maximum value (in this case, 0 and 101) that we want returned in the byte array. Because we are sure that the integer values returned by the <xref:System.Random.Next%2A> method are within the range of the <xref:System.Byte> data type, we can safely cast them (in C# and F#) or convert them (in Visual Basic) from integers to bytes.

## Retrieve an element from an array or collection at random

Random numbers often serve as indexes to retrieve values from arrays or collections. To retrieve a random index value, you can call the <xref:System.Random.Next%28System.Int32%2CSystem.Int32%29> method, and use the lower bound of the array as the value of its `minValue` argument and one greater than the upper bound of the array as the value of its `maxValue` argument. For a zero-based array, this is equivalent to its <xref:System.Array.Length> property, or one greater than the value returned by the <xref:System.Array.GetUpperBound%2A?displayProperty=nameWithType> method. The following example randomly retrieves the name of a city in the United States from an array of cities.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/array1.cs" interactive="try-dotnet-method" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/array1.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/array1.vb" id="Snippet10":::

## Retrieve a unique element from an array or collection

A random number generator can always return duplicate values. As the range of numbers becomes smaller or the number of values generated becomes larger, the probability of duplicates grows. If random values must be unique, more numbers are generated to compensate for duplicates, resulting in increasingly poor performance.

There are a number of techniques to handle this scenario. One common solution is to create an array or collection that contains the values to be retrieved, and a parallel array that contains random floating-point numbers. The second array is populated with random numbers at the time the first array is created, and the <xref:System.Array.Sort%28System.Array%2CSystem.Array%29?displayProperty=nameWithType> method is used to sort the first array by using the values in the parallel array.

For example, if you're developing a Solitaire game, you want to ensure that each card is used only once. Instead of generating random numbers to retrieve a card and tracking whether that card has already been dealt, you can create a parallel array of random numbers that can be used to sort the deck. Once the deck is sorted, your app can maintain a pointer to indicate the index of the next card on the deck.

The following example illustrates this approach. It defines a `Card` class that represents a playing card and a `Dealer` class that deals a deck of shuffled cards. The `Dealer` class constructor populates two arrays: a `deck` array that has class scope and that represents all the cards in the deck; and a local `order` array that has the same number of elements as the `deck` array and is populated with randomly generated <xref:System.Double> values. The <xref:System.Array.Sort%28System.Array%2CSystem.Array%29?displayProperty=nameWithType> method is then called to sort the `deck` array based on the values in the `order` array.

:::code language="csharp" source="./snippets/System/Random/Overview/csharp/uniquearray1.cs" interactive="try-dotnet" id="Snippet11":::
:::code language="fsharp" source="./snippets/System/Random/Overview/fsharp/uniquearray1.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System/Random/Overview/vb/uniquearray1.vb" id="Snippet11":::
