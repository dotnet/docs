---
title: "Memory<T> and Span<T> usage guidelines"
ms.date: "10/01/2018"
helpviewer_keywords: 
  - "Memory&lt;T&gt; and Span&lt;T&gt; best practices"
  - "using Memory&lt;T&gt; and Span&lt;T&gt;"
---
# Memory\<T> and Span\<T> usage guidelines

.NET Core includes a number of types that represent an arbitrary contiguous region of memory. .NET Core 2.0 introduced <xref:System.Span%601> and <xref:System.ReadOnlySpan%601>, which are lightweight memory buffers that can be backed by managed or unmanaged memory. Because these types can only be stored on the stack, they are unsuitable for a number of scenarios, including asynchronous method calls. .NET Core 2.1 adds a number of additional types, including <xref:System.Memory%601>, <xref:System.ReadOnlyMemory%601>, <xref:System.Buffers.IMemoryOwner%601>, and <xref:System.Buffers.MemoryPool%601>. Like <xref:System.Span%601>, <xref:System.Memory%601> and its related types can be backed by both managed and unmanaged memory. Unlike <xref:System.Span%601>, <xref:System.Memory%601> can be stored on the managed heap.

Both <xref:System.Span%601> and <xref:System.Memory%601> are buffers of structured data that can be used in pipelines. That is, they are designed so that some or all of the data can be efficiently passed to components in the pipeline, which can process them and optionally modify the buffer. Because <xref:System.Memory%601> and its related types can be accessed by multiple components or by multiple threads, it's important that developers follow some standard usage guidelines to produce robust code.

## Owners, consumers, and lifetime management

Since buffers can be passed around between APIs, and since buffers can sometimes be accessed from multiple threads, it's important to consider lifetime management. There are three core concepts:

- **Ownership**. The owner of a buffer instance is responsible for lifetime management, including destroying the buffer when it's no longer in use. All buffers have a single owner. Generally the owner is the component that created the buffer or that received the buffer from a factory. Ownership can also be transferred; **Component-A** can relinquish control of the buffer to **Component-B**, at which point **Component-A** may no longer use the buffer, and **Component-B** becomes responsible for destroying the buffer when it's no longer in use.

- **Consumption**. The consumer of a buffer instance is allowed to use the buffer instance by reading from it and possibly writing to it. Buffers can have one consumer at a time unless some external synchronization mechanism is provided. Note that the active consumer of a buffer isn't necessarily the buffer's owner.

- **Lease**. The lease is the length of time that a particular component is allowed to be the consumer of the buffer.

The following pseudo-code example illustrates these three concepts. It includes a `Main` method that instantiates a <xref:System.Memory%601> buffer of type <xref:System.Char>, calls the `WriteInt32ToBuffer` method to write the string representation of an integer to the buffer, and then calls the `DisplayBufferToConsole` method to display the value of the buffer.

```csharp
using System;

class Program
{
    // Write 'value' as a human-readable string to the output buffer.
    void WriteInt32ToBuffer(int value, Buffer buffer);

    // Display the contents of the buffer to the console.
    void DisplayBufferToConsole(Buffer buffer);

    // Application code
    static void Main()
    {
        var buffer = CreateBuffer();
        try
        {
            int value = Int32.Parse(Console.ReadLine());
            WriteInt32ToBuffer(value, buffer);
            DisplayBufferToConsole(buffer);
        }
        finally
        {
            buffer.Destroy();
        }
    }
}
```

The `Main` method creates the buffer (in this case an <xref:System.Span%601> instance) and so is its owner. Therefore, `Main` is responsible for destroying the buffer when it's no longer in use. It does this by calling the buffer's <xref:System.Span%601.Clear?displayProperty=nameWithType> method. (The <xref:System.Span%601.Clear> method here actually clears the buffer's memory; the <xref:System.Span%601> structure doesn't actually have a method that destroys the buffer.)

The buffer has two consumers, `WriteInt32ToBuffer` and `DisplayBufferToConsole`. There is only one consumer at a time (first `WriteInt32ToBuffer`, then `DisplayBufferToConsole`), and neither of the consumers owns the buffer. Note also that "consumer" in this context doesn't imply a read-only view of the buffer; consumers can modify the buffer's contents, as `WriteInt32ToBuffer` does, if given a read/write view of the buffer.

The `WriteInt32ToBuffer` method has a lease on (can consume) the buffer between the start of the method call and the time the method returns. Similarly, `DisplayBufferToConsole` has a lease on the buffer while it's executing, and the lease is released when the method unwinds. (There is no API for lease management; a "lease" is a conceptual matter.)

## Memory\<T> and the owner/consumer model

As the [Owners, consumers, and lifetime management](#owners-consumers-and-lifetime-management) section notes, a buffer always has an owner. .NET Core supports two ownership models:

- A model that supports single ownership. A buffer has a single owner for its entire lifetime.

- A model that supports ownership transfer. Ownership of a buffer can be transferred from its original owner (its creator) to another component, which then becomes responsible for the buffer's lifetime management. That owner can in turn transfer ownership to another component, and so on.

You use the <xref:System.Buffers.IMemoryOwner%601?displayProperty=nameWithType> interface to explicitly manage the ownership of a buffer. <xref:System.Buffers.IMemoryOwner%601> supports both ownership models. The component that has an <xref:System.Buffers.IMemoryOwner%601> reference owns the buffer. The following example uses an <xref:System.Buffers.IMemoryOwner%601?> instance to reflect the ownership of an <xref:System.Memory%601> buffer.

[!code-csharp[ownership](~/samples/snippets/standard/buffers/memory-t/owner/owner.cs)]

We can also write this example with the [`using`](../../csharp/language-reference/keywords/using-statement.md):

[!code-csharp[ownership-using](~/samples/snippets/standard/buffers/memory-t/owner-using/owner-using.cs)]

In this code:

- The `Main` method holds the reference to the <xref:System.Buffers.IMemoryOwner%601> instance, so the `Main` method is the owner of the buffer.

- The `WriteInt32ToBuffer` and `DisplayBufferToConsole` methods accept <xref:System.Memory%601> as a public API. Therefore, they are consumers of the buffer. And they only consume it one at a time.

Although the `WriteInt32ToBuffer` method is intended to write a value to the buffer, the `DisplayBufferToConsole` method isn't. To reflect this, it could have accepted an argument of type <xref:System.ReadOnlyMemory%601>. For additional information on <xref:System.ReadOnlyMemory%601>, see [Rule #2: Use ReadOnlySpan\<T> or ReadOnlyMemory\<T> if the buffer should be read-only](#rule-2).

### "Ownerless" Memory\<T> instances

You can create a <xref:System.Memory%601> instance without using <xref:System.Buffers.IMemoryOwner%601>. In this case, ownership of the buffer is implicit rather than explicit, and only the single-owner model is supported. You can do this by:

- Calling one of the  <xref:System.Memory%601> constructors directly, passing in a `T[]`, as the following example does.

- Calling the [String.AsMemory](xref:System.MemoryExtensions.AsMemory(System.String)) extension method to produce a `ReadOnlyMemory<char>` instance.

[!code-csharp[ownerless-memory](~/samples/snippets/standard/buffers/memory-t/ownerless/ownerless.cs)]

The method that initially creates the <xref:System.Memory%601> instance is the implicit owner of the buffer. Ownership cannot be transferred to any other component because there is no <xref:System.Buffers.IMemoryOwner%601> instance to facilitate the transfer. (As an alternative, you can also imagine that the runtime's garbage collector owns the buffer, and all methods just consume the buffer.)

## Usage guidelines

Because a memory block is owned but is intended to be passed to multiple components, some of which may operate upon a particular memory block simultaneously, it is important to establish guidelines for using both <xref:System.Memory%601> and <xref:System.Span%601>.  Guidelines are necessary because:

- It is possible for a component to retain a reference to a memory block after its owner has released it.

- It is possible for a component to operate on a buffer at the same time that another component is operating on it, in the process corrupting the data in the buffer.

- While the stack-allocated nature of <xref:System.Span%601> optimizes performance and makes <xref:System.Span%601> the preferred type for operating on a memory block, it also subjects <xref:System.Span%601> to some major restrictions. It is important to know when to use a <xref:System.Span%601> and when to use <xref:System.Memory%601>.

The following are our recommendations for successfully using <xref:System.Memory%601> and its related types. Note that guidance that applies to <xref:System.Memory%601> and <xref:System.Span%601> also applies to <xref:System.ReadOnlyMemory%601> and <xref:System.ReadOnlySpan%601> unless we explicitly note otherwise.

**Rule #1: For a synchronous API, use Span\<T> instead of Memory\<T> as a parameter if possible.**

<xref:System.Span%601> is more versatile than <xref:System.Memory%601> and can represent a wider variety of contiguous memory buffers. <xref:System.Span%601> also offers better performance than <xref:System.Memory%601>. Finally, you can use the <xref:System.Memory%601.Span?displayProperty=nameWithType> property to convert a <xref:System.Memory%601> instance to a <xref:System.Span%601>, although Span\<T>-to-Memory\<T> conversion isn't possible. So if your callers happen to have a <xref:System.Memory%601> instance, they'll be able to call your methods with <xref:System.Span%601> parameters anyway.

Using a parameter of type <xref:System.Span%601> instead of type <xref:System.Memory%601> also helps you write a correct consuming method implementation. You'll automatically get compile-time checks to ensure that you're not attempting to access the buffer beyond your method's lease (more on this later).

Sometimes, you'll have to use a <xref:System.Memory%601> parameter instead of a <xref:System.Span%601> parameter, even if you're fully synchronous. Perhaps an API that you depend accepts only <xref:System.Memory%601> arguments. This is fine, but be aware of the tradeoffs involved when using <xref:System.Memory%601> synchronously.

<a name="rule-2" />

**Rule #2: Use ReadOnlySpan\<T> or ReadOnlyMemory\<T> if the buffer should be read-only.**

In the earlier examples, the `DisplayBufferToConsole` method only reads from the buffer; it doesn't modify the contents of the buffer. The method signature should be changed to the following.

```csharp
void DisplayBufferToConsole(ReadOnlyMemory<char> buffer);
```

In fact, if we combine this rule and Rule #1, we can do even better and rewrite the method signature as follows:

```csharp
void DisplayBufferToConsole(ReadOnlySpan<char> buffer);
```

The `DisplayBufferToConsole` method now works with virtually every buffer type imaginable: `T[]`, storage allocated with [stackalloc](../../csharp/language-reference/operators/stackalloc.md), and so on. You can even pass a <xref:System.String> directly into it!

**Rule #3: If your method accepts Memory\<T> and returns `void`, you must not use the Memory\<T> instance after your method returns.**

This relates to the "lease" concept mentioned earlier. A void-returning method's lease on the <xref:System.Memory%601> instance begins when the method is entered, and it ends when the method exits. Consider the following example, which calls `Log` in a loop based on input from the console.

[!code-csharp[void-returning](~/samples/snippets/standard/buffers/memory-t/void-returning/void-returning.cs#1)]

If `Log` is a fully synchronous method, this code will behave as expected because there is only one active consumer of the memory instance at any given time.
But imagine instead that `Log` has this implementation.

```csharp
// !!! INCORRECT IMPLEMENTATION !!!
static void Log(ReadOnlyMemory<char> message)
{
    // Run in background so that we don't block the main thread while performing IO.
    Task.Run(() =>
    {
        StreamWriter sw = File.AppendText(@".\input-numbers.dat");
        sw.WriteLine(message);
    });
}
```

In this implementation, `Log` violates its lease because it still attempts to use the <xref:System.Memory%601> instance in the background after the original method has returned. The `Main` method could mutate the buffer while `Log` attempts to read from it, which could result in data corruption.

There are several ways to resolve this:

- The `Log` method can return a <xref:System.Threading.Tasks.Task> instead of `void`, as the following implementation of the `Log` method does.

   [!code-csharp[task-returning](~/samples/snippets/standard/buffers/memory-t/task-returning2/task-returning2.cs#1)]

- `Log` can instead be implemented as follows:

   [!code-csharp[defensive-copy](~/samples/snippets/standard/buffers/memory-t/task-returning/task-returning.cs#1)]

**Rule #4: If your method accepts a Memory\<T> and returns a Task, you must not use the Memory\<T> instance after the Task transitions to a terminal state.**

This is just the async variant of Rule #3. The `Log` method from the earlier example can be written as follows to comply with this rule:

[!code-csharp[task-returning-async](~/samples/snippets/standard/buffers/memory-t/void-returning-async/void-returning-async.cs#1)]

Here, "terminal state" means that the task transitions to a completed, faulted, or canceled state. In other words, "terminal state" means "anything that would cause await to throw or to continue execution."

This guidance applies to methods that return <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.ValueTask%601>, or any similar type.

**Rule #5: If your constructor accepts Memory\<T> as a parameter, instance methods on the constructed object are assumed to be consumers of the Memory\<T> instance.**

Consider the following example:

```csharp
class OddValueExtractor
{
    public OddValueExtractor(ReadOnlyMemory<int> input);
    public bool TryReadNextOddValue(out int value);
}

void PrintAllOddValues(ReadOnlyMemory<int> input)
{
    var extractor = new OddValueExtractor(input);
    while (extractor.TryReadNextOddValue(out int value))
    {
      Console.WriteLine(value);
    }
}
```

Here, the `OddValueExtractor` constructor accepts a `ReadOnlyMemory<int>` as a constructor parameter, so the constructor itself is a consumer of the `ReadOnlyMemory<int>` instance, and all instance methods on the returned value are also consumers of the original `ReadOnlyMemory<int>` instance. This means that `TryReadNextOddValue` consumes the `ReadOnlyMemory<int>` instance, even though the instance isn't passed directly to the `TryReadNextOddValue` method.

**Rule #6: If you have a settable Memory\<T>-typed property (or an equivalent instance method) on your type, instance methods on that object are assumed to be consumers of the Memory\<T> instance.**

This is really just a variant of Rule #5. This rule exists because property setters or equivalent methods are assumed to capture and persist their inputs, so instance methods on the same object may utilize the captured state.

The following example triggers this rule:

```csharp
class Person
{
    // Settable property.
    public Memory<char> FirstName { get; set; }

    // alternatively, equivalent "setter" method
    public SetFirstName(Memory<char> value);

    // alternatively, a public settable field
    public Memory<char> FirstName;
}
```

**Rule #7: If you have an IMemoryOwner\<T> reference, you must at some point dispose of it or transfer its ownership (but not both).**

Since a <xref:System.Memory%601> instance may be backed by either managed or unmanaged memory, the owner must call <xref:System.Buffers.MemoryPool%601.Dispose%2A?displayProperty=nameWithType> when work performed on the <xref:System.Memory%601> instance is complete. Alternatively, the owner may transfer ownership of the <xref:System.Buffers.IMemoryOwner%601> instance to a different component, at which point the acquiring component becomes responsible for calling <xref:System.Buffers.MemoryPool%601.Dispose%2A?displayProperty=nameWithType> at the appropriate time (more on this later).

Failure to call the <xref:System.Buffers.MemoryPool%601.Dispose%2A> method may lead to unmanaged memory leaks or other performance degradation.

This rule also applies to code that calls factory methods like <xref:System.Buffers.MemoryPool%601.Rent%2A?displayProperty=nameWithType>. The caller becomes the owner of the returned <xref:System.Buffers.IMemoryOwner%601> and is responsible for disposing of the instance when finished.

**Rule #8: If you have an IMemoryOwner\<T> parameter in your API surface, you are accepting ownership of that instance.**

Accepting an instance of this type signals that your component intends to take ownership of this instance. Your component becomes responsible for proper disposal according to Rule #7.

Any component that transfers ownership of the <xref:System.Buffers.IMemoryOwner%601> instance to a different component should no longer use that instance after the method call completes.

> [!IMPORTANT]
> If your constructor accepts <xref:System.Buffers.IMemoryOwner%601> as a parameter, its type should implement <xref:System.IDisposable>, and your <xref:System.IDisposable.Dispose%2A> method should call <xref:System.Buffers.MemoryPool%601.Dispose%2A?displayProperty=nameWithType>.

**Rule #9: If you're wrapping a synchronous p/invoke method, your API should accept Span\<T> as a parameter.**

According to Rule #1, <xref:System.Span%601> is generally the correct type to use for synchronous APIs. You can pin <xref:System.Span%601> instances via the [`fixed`](../../csharp/language-reference/keywords/fixed-statement.md) keyword, as in the following example.

```csharp
using System.Runtime.InteropServices;

[DllImport(...)]
private static extern unsafe int ExportedMethod(byte* pbData, int cbData);

public unsafe int ManagedWrapper(Span<byte> data)
{
    fixed (byte* pbData = &MemoryMarshal.GetReference(data))
    {
        int retVal = ExportedMethod(pbData, data.Length);

        /* error checking retVal goes here */

        return retVal;
    }
}
```

In the previous example, `pbData` can be null if, for example, the input span is empty. If the exported method absolutely requires that `pbData` be non-null, even if `cbData` is 0, the method can be implemented as follows:

```csharp
public unsafe int ManagedWrapper(Span<byte> data)
{
    fixed (byte* pbData = &MemoryMarshal.GetReference(data))
    {
        byte dummy = 0;
        int retVal = ExportedMethod((pbData != null) ? pbData : &dummy, data.Length);

        /* error checking retVal goes here */

        return retVal;
    }
}
```

**Rule #10: If you're wrapping an asynchronous p/invoke method, your API should accept Memory\<T> as a parameter.**

Since you cannot use the [`fixed`](../../csharp/language-reference/keywords/fixed-statement.md) keyword across asynchronous operations, you use the <xref:System.Memory%601.Pin%2A?displayProperty=nameWithType> method to pin <xref:System.Memory%601> instances, regardless of the kind of contiguous memory the instance represents. The following example shows how to use this API to perform an asynchronous p/invoke call.

```csharp
using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(...)]
private delegate void OnCompletedCallback(IntPtr state, int result);

[DllImport(...)]
private static extern unsafe int ExportedAsyncMethod(byte* pbData, int cbData, IntPtr pState, IntPtr lpfnOnCompletedCallback);

private static readonly IntPtr _callbackPtr = GetCompletionCallbackPointer();

public unsafe Task<int> ManagedWrapperAsync(Memory<byte> data)
{
    // setup
    var tcs = new TaskCompletionSource<int>();
    var state = new MyCompletedCallbackState
    {
        Tcs = tcs
    };
    var pState = (IntPtr)GCHandle.Alloc(state);

    var memoryHandle = data.Pin();
    state.MemoryHandle = memoryHandle;

    // make the call
    int result;
    try
    {
        result = ExportedAsyncMethod((byte*)memoryHandle.Pointer, data.Length, pState, _callbackPtr);
    }
    catch
    {
        ((GCHandle)pState).Free(); // cleanup since callback won't be invoked
        memoryHandle.Dispose();
        throw;
    }

    if (result != PENDING)
    {
        // Operation completed synchronously; invoke callback manually
        // for result processing and cleanup.
        MyCompletedCallbackImplementation(pState, result);
    }

    return tcs.Task;
}

private static void MyCompletedCallbackImplementation(IntPtr state, int result)
{
    GCHandle handle = (GCHandle)state;
    var actualState = (MyCompletedCallbackState)state;
    handle.Free();
    actualState.MemoryHandle.Dispose();

    /* error checking result goes here */

    if (error)
    {
        actualState.Tcs.SetException(...);
    }
    else
    {
        actualState.Tcs.SetResult(result);
    }
}

private static IntPtr GetCompletionCallbackPointer()
{
    OnCompletedCallback callback = MyCompletedCallbackImplementation;
    GCHandle.Alloc(callback); // keep alive for lifetime of application
    return Marshal.GetFunctionPointerForDelegate(callback);
}

private class MyCompletedCallbackState
{
    public TaskCompletionSource<int> Tcs;
    public MemoryHandle MemoryHandle;
}
```

## See also

- <xref:System.Memory%601?displayProperty=nameWithType>
- <xref:System.Buffers.IMemoryOwner%601?displayProperty=nameWithType>
- <xref:System.Span%601?displayProperty=nameWithType>
