---
title: "lock Statement (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
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
manager: "wpickett"
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
  
 For more information, see [Thread Synchronization](../Topic/Thread%20Synchronization%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Remarks  
 The `lock` keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.  
  
 The section [Threading](../Topic/Threading%20\(C%23%20and%20Visual%20Basic\).md) discusses threading.  
  
 The `lock` keyword calls <xref:System.Threading.Monitor.Enter*> at the start of the block and <xref:System.Threading.Monitor.Exit*> at the end of the block. A <xref:System.Threading.ThreadInterruptedException> is thrown if <xref:System.Threading.Thread.Interrupt*> interrupts a thread that is waiting to enter a `lock` statement.  
  
 In general, avoid locking on a `public` type, or instances beyond your code's control. The common constructs `lock (this)`, `lock (typeof (MyType))`, and `lock ("myLock")` violate this guideline:  
  
-   `lock (this)` is a problem if the instance can be accessed publicly.  
  
-   `lock (typeof (MyType))` is a problem if `MyType` is publicly accessible.  
  
-   `lock("myLock")` is a problem because any other code in the process using the same string, will share the same lock.  
  
 Best practice is to define a `private` object to lock on, or a `private static` object variable to protect data common to all instances.  
  
 You can't use the [await](../keywords/await--csharp-reference-.md) keyword in the body of a `lock` statement.  
  
## Example  
 The following sample shows a simple use of threads without locking in C#.  
  
 [!code[csrefKeywordsFixedLock#5](../keywords/codesnippet/CSharp/lock-statement--csharp-reference-_1.cs)]  
  
## Example  
 The following sample uses threads and `lock`. As long as the `lock` statement is present, the statement block is a critical section and `balance` will never become a negative number.  
  
 [!code[csrefKeywordsFixedLock#6](../keywords/codesnippet/CSharp/lock-statement--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Reflection.MethodImplAttributes>   
 <xref:System.Threading.Mutex>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Threading](../Topic/Threading%20\(C%23%20and%20Visual%20Basic\).md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Statement Keywords](../keywords/statement-keywords--csharp-reference-.md)   
 [Monitors](../Topic/Monitors.md)   
 [Interlocked Operations](../Topic/Interlocked%20Operations.md)   
 [AutoResetEvent](../Topic/AutoResetEvent.md)   
 [Thread Synchronization](../Topic/Thread%20Synchronization%20\(C%23%20and%20Visual%20Basic\).md)