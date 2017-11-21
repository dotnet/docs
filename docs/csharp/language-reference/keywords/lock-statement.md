---
title: "lock Statement (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
helpviewer_keywords: 
  - "lock keyword [C#]"
ms.assetid: 656da1a4-707e-4ef6-9c6e-6d13b646af42
caps.latest.revision: 43
author: "BillWagner"
ms.author: "wiwagn"
---
# lock Statement (C# Reference)
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
  
-   `lock (this)` is a problem if the instance can be accessed publicly.  
  
-   `lock (typeof (MyType))` is a problem if `MyType` is publicly accessible.  
  
-   `lock("myLock")` is a problem because any other code in the process using the same string, will share the same lock.  
  
 Best practice is to define a `private` object to lock on, or a `private static` object variable to protect data common to all instances.  
  
 You can't use the [await](../../../csharp/language-reference/keywords/await.md) keyword in the body of a `lock` statement.  
  
## Example  
 The following sample shows a simple use of threads without locking in C#.  
  
 [!code-csharp[csrefKeywordsFixedLock#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/lock-statement_1.cs)]  
  
## Example  
 The following sample uses threads and `lock`. As long as the `lock` statement is present, the statement block is a critical section and `balance` will never become a negative number.  
  
 [!code-csharp[csrefKeywordsFixedLock#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/lock-statement_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Reflection.MethodImplAttributes>  
 <xref:System.Threading.Mutex>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Threading](../../programming-guide/concepts/threading/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Statement Keywords](../../../csharp/language-reference/keywords/statement-keywords.md)  
 <xref:System.Threading.Monitor>  
 [Interlocked Operations](../../../standard/threading/interlocked-operations.md)  
 [AutoResetEvent](../../../standard/threading/autoresetevent.md)  
 [Thread Synchronization](../../programming-guide/concepts/threading/thread-synchronization.md)
