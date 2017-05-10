---
title: "lock Statement (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "lock_CSharpKeyword"
  - "lock"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "lock keyword [C#]"
ms.assetid: 656da1a4-707e-4ef6-9c6e-6d13b646af42
caps.latest.revision: 43
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# lock Statement (C# Reference)
The `lock` keyword marks a statement block as a critical section by obtaining the mutual-exclusion lock for a given object, executing a statement, and then releasing the lock. The following example includes a `lock` statement.  
  
```  
  
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
  
 For more information, see [Thread Synchronization](http://msdn.microsoft.com/library/413e1f28-a2c5-4eec-8338-aa43e7982ff4).  
  
## Remarks  
 The `lock` keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.  
  
 The section [Threading](http://msdn.microsoft.com/library/552f6c68-dbdb-4327-ae36-32cf9063d88c) discusses threading.  
  
 The `lock` keyword calls <xref:System.Threading.Monitor.Enter%2A> at the start of the block and <xref:System.Threading.Monitor.Exit%2A> at the end of the block. A <xref:System.Threading.ThreadInterruptedException> is thrown if <xref:System.Threading.Thread.Interrupt%2A> interrupts a thread that is waiting to enter a `lock` statement.  
  
 In general, avoid locking on a `public` type, or instances beyond your code's control. The common constructs `lock (this)`, `lock (typeof (MyType))`, and `lock ("myLock")` violate this guideline:  
  
-   `lock (this)` is a problem if the instance can be accessed publicly.  
  
-   `lock (typeof (MyType))` is a problem if `MyType` is publicly accessible.  
  
-   `lock("myLock")` is a problem because any other code in the process using the same string, will share the same lock.  
  
 Best practice is to define a `private` object to lock on, or a `private static` object variable to protect data common to all instances.  
  
 You can't use the [await](../../../csharp/language-reference/keywords/await.md) keyword in the body of a `lock` statement.  
  
## Example  
 The following sample shows a simple use of threads without locking in C#.  
  
 [!code-cs[csrefKeywordsFixedLock#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/lock-statement_1.cs)]  
  
## Example  
 The following sample uses threads and `lock`. As long as the `lock` statement is present, the statement block is a critical section and `balance` will never become a negative number.  
  
 [!code-cs[csrefKeywordsFixedLock#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/lock-statement_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Reflection.MethodImplAttributes>   
 <xref:System.Threading.Mutex>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Threading](http://msdn.microsoft.com/library/552f6c68-dbdb-4327-ae36-32cf9063d88c)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Statement Keywords](../../../csharp/language-reference/keywords/statement-keywords.md)   
 @System.Threading.Monitor   
 [Interlocked Operations](../../../standard/threading/interlocked-operations.md)   
 [AutoResetEvent](../../../standard/threading/autoresetevent.md)   
 [Thread Synchronization](http://msdn.microsoft.com/library/413e1f28-a2c5-4eec-8338-aa43e7982ff4)