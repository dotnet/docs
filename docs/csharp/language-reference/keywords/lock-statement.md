---
title: "lock statement (C# Reference)"
description: "The lock keyword is used in threading "
ms.date: 07/20/2015
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
helpviewer_keywords: 
  - "lock keyword [C#]"
ms.assetid: 656da1a4-707e-4ef6-9c6e-6d13b646af42
---
# lock statement (C# Reference)

The `lock` keyword marks a statement block as a critical section by obtaining the mutual-exclusion lock for a given object, executing a statement, and then releasing the lock. The following example includes a `lock` statement.

```csharp
class Account
{
    decimal balance;
    private Object thisLock = new Object();

    public void Withdraw(decimal amount)
    {
        lock (thisLock)
        {
            if (amount > balance)
            {
                throw new Exception("Insufficient funds");
            }
            balance -= amount;
        }
    }
}
```

For more information, see [Thread Synchronization](../../programming-guide/concepts/threading/thread-synchronization.md).

## Remarks

The `lock` keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.

The section [Threading](../../programming-guide/concepts/threading/index.md) discusses threading.

The `lock` keyword calls <xref:System.Threading.Monitor.Enter%2A> at the start of the block and <xref:System.Threading.Monitor.Exit%2A> at the end of the block. A <xref:System.Threading.ThreadInterruptedException> is thrown if <xref:System.Threading.Thread.Interrupt%2A> interrupts a thread that is waiting to enter a `lock` statement.

In general, avoid locking on a `public` type, or instances beyond your code's control. The common constructs `lock (this)`, `lock (typeof (MyType))`, and `lock ("myLock")` violate this guideline:

- `lock (this)` is a problem if the instance can be accessed publicly.

- `lock (typeof (MyType))` is a problem if `MyType` is publicly accessible.

- `lock("myLock")` is a problem because any other code in the process using the same string, will share the same lock.

Best practice is to define a `private` object to lock on, or a `private static` object variable to protect data common to all instances.

You can't use the [await](await.md) keyword in the body of a `lock` statement.

## Example - Threads without locking

The following sample shows a simple use of threads without locking in C#:

[!code-csharp[csrefKeywordsFixedLock#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#5)]

## Example - Threads using locking

The following sample uses threads and `lock`. As long as the `lock` statement is present, the statement block is a critical section and `balance` will never become a negative number:

[!code-csharp[csrefKeywordsFixedLock#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#6)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Reflection.MethodImplAttributes>
- <xref:System.Threading.Mutex>
- <xref:System.Threading.Monitor>
- [C# Reference](../../language-reference/index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Threading](../../programming-guide/concepts/threading/index.md)
- [C# Keywords](index.md)
- [Statement Keywords](statement-keywords.md)
- [Interlocked Operations](../../../standard/threading/interlocked-operations.md)
- [AutoResetEvent](../../../standard/threading/autoresetevent.md)
- [Thread Synchronization](../../programming-guide/concepts/threading/thread-synchronization.md)