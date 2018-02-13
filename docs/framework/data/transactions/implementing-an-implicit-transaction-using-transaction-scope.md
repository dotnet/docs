---
title: "Implementing an Implicit Transaction using Transaction Scope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 49d1706a-1e0c-4c85-9704-75c908372eb9
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Implementing an Implicit Transaction using Transaction Scope
The <xref:System.Transactions.TransactionScope> class provides a simple way to mark a block of code as participating in a transaction, without requiring you to interact with the transaction itself. A transaction scope can select and manage the ambient transaction automatically. Due to its ease of use and efficiency, it is recommended that you use the <xref:System.Transactions.TransactionScope> class when developing a transaction application.  
  
 In addition, you do not need to enlist resources explicitly with the transaction. Any <xref:System.Transactions> resource manager (such as SQL Server 2005) can detect the existence of an ambient transaction created by the scope and automatically enlist.  
  
## Creating a transaction scope  
 The following sample shows a simple usage of the <xref:System.Transactions.TransactionScope> class.  
  
 [!code-csharp[TransactionScope#1](../../../../samples/snippets/csharp/VS_Snippets_Remoting/TransactionScope/cs/ScopeWithSQL.cs#1)]
 [!code-vb[TransactionScope#1](../../../../samples/snippets/visualbasic/VS_Snippets_Remoting/TransactionScope/vb/ScopeWithSQL.vb#1)]  
  
 The transaction scope is started once you create a new <xref:System.Transactions.TransactionScope> object.  As illustrated in the code sample, it is recommended that you create scopes with a **using** statement. The **using** statement is available both in C# and in Visual Basic, and works like a **try...finally** block to ensure that the scope is disposed of properly.  
  
 When you instantiate <xref:System.Transactions.TransactionScope>, the transaction manager determines which transaction to participate in. Once determined, the scope always participates in that transaction. The decision is based on two factors: whether an ambient transaction is present and the value of the **TransactionScopeOption** parameter in the constructor. The ambient transaction is the transaction within which your code executes. You can obtain a reference to the ambient transaction by calling the static <xref:System.Transactions.Transaction.Current%2A?displayProperty=nameWithType> property of the <xref:System.Transactions.Transaction> class. For more information on how this parameter is used, see the [Managing transaction flow using TransactionScopeOption](#ManageTxFlow) section of this topic.  
  
## Completing a transaction scope  
 When your application completes all the work it wants to perform in a transaction, you should call the <xref:System.Transactions.TransactionScope.Complete%2A?displayProperty=nameWIthType> method only once to inform the transaction manager that it is acceptable to commit the transaction. It is very good practice to put the call to <xref:System.Transactions.TransactionScope.Complete%2A> as the last statement in the **using** block.  
  
 Failing to call this method aborts the transaction, because the transaction manager interprets this as a system failure, or equivalent to an exception thrown within the scope of the transaction. However, calling this method does not guarantee that the transaction wil be committed. It is merely a way of informing the transaction manager of your status. After calling the <xref:System.Transactions.TransactionScope.Complete%2A> method, you can no longer access the ambient transaction by using the <xref:System.Transactions.Transaction.Current%2A> property, and attempting to do so will result in an exception being thrown.  
  
 If the <xref:System.Transactions.TransactionScope> object created the transaction initially, the actual work of committing the transaction by the transaction manager occurs after the last line of code in the **using** block. If it did not create the transaction, the commit occurs whenever <xref:System.Transactions.CommittableTransaction.Commit%2A> is called by the owner of the <xref:System.Transactions.CommittableTransaction> object. At that point the transaction manager calls the resource managers and informs them to either commit or rollback, based on whether the <xref:System.Transactions.TransactionScope.Complete%2A> method was called on the <xref:System.Transactions.TransactionScope> object.  
  
 The **using** statement ensures that the <xref:System.Transactions.TransactionScope.Dispose%2A> method of the <xref:System.Transactions.TransactionScope> object is called even if an exception occurs. The <xref:System.Transactions.TransactionScope.Dispose%2A> method marks the end of the transaction scope. Exceptions that occur after calling this method may not affect the transaction. This method also restores the ambient transaction to it previous state.  
  
 A <xref:System.Transactions.TransactionAbortedException> is thrown if the scope creates the transaction, and the transaction is aborted. A <xref:System.Transactions.TransactionInDoubtException> is thrown if the transaction manager cannot reach a Commit decision. No exception is thrown if the transaction is committed.  
  
## Rolling back a transaction  
 If you want to rollback a transaction, you should not call the <xref:System.Transactions.TransactionScope.Complete%2A> method within the transaction scope. For example, you can throw an exception within the scope. The transaction in which it participates in will be rolled back.  
  
##  <a name="ManageTxFlow"></a> Managing transaction flow using TransactionScopeOption  
 Transaction scope can be nested by calling a method that uses a <xref:System.Transactions.TransactionScope> from within a method that uses its own scope, as is the case with the `RootMethod` method in the following example,  
  
```csharp  
void RootMethod()  
{  
     using(TransactionScope scope = new TransactionScope())  
     {  
          /* Perform transactional work here */  
          SomeMethod();  
          scope.Complete();  
     }  
}  
  
void SomeMethod()  
{  
     using(TransactionScope scope = new TransactionScope())  
     {  
          /* Perform transactional work here */  
          scope.Complete();  
     }  
}  
```  
  
 The top-most transaction scope is referred to as the root scope.  
  
 The <xref:System.Transactions.TransactionScope> class provides several overloaded constructors that accept an enumeration of the type <xref:System.Transactions.TransactionScopeOption>, which defines the transactional behavior of the scope.  
  
 A <xref:System.Transactions.TransactionScope> object has three options:  
  
-   Join the ambient transaction, or create a new one if one does not exist.  
  
-   Be a new root scope, that is, start a new transaction and have that transaction be the new ambient transaction inside its own scope.  
  
-   Not take part in a transaction at all. There is no ambient transaction as a result.  
  
 If the scope is instantiated with <xref:System.Transactions.TransactionScopeOption.Required>, and an ambient transaction is present, the scope joins that transaction. If, on the other hand, there is no ambient transaction, then the scope creates a new transaction, and become the root scope. This is the default value. When <xref:System.Transactions.TransactionScopeOption.Required> is used, the code inside the scope does not need to behave differently whether it is the root or just joining the ambient transaction. It should operate identically in both cases.  
  
 If the scope is instantiated with <xref:System.Transactions.TransactionScopeOption.RequiresNew>, it is always the root scope. It starts a new transaction, and its transaction becomes the new ambient transaction inside the scope.  
  
 If the scope is instantiated with <xref:System.Transactions.TransactionScopeOption.Suppress>, it never takes part in a transaction, regardless of whether an ambient transaction is present. A scope instantiated with this value always have **null** as its ambient transaction.  
  
 The above options are summarized in the following table.  
  
|TransactionScopeOption|Ambient Transaction|The scope takes part in|  
|----------------------------|-------------------------|-----------------------------|  
|Required|No|New Transaction (will be the root)|  
|Requires New|No|New Transaction (will be the root)|  
|Suppress|No|No Transaction|  
|Required|Yes|Ambient  Transaction|  
|Requires New|Yes|New Transaction (will be the root)|  
|Suppress|Yes|No Transaction|  
  
 When a <xref:System.Transactions.TransactionScope> object joins an existing ambient transaction, disposing of the scope object may not end the transaction, unless the scope aborts the transaction. If the ambient transaction was created by a root scope, only when the root scope is disposed of, does <xref:System.Transactions.CommittableTransaction.Commit%2A> get called on the transaction. If the transaction was created manually, the transaction ends when it is either aborted, or committed by its creator.  
  
 The following example shows a <xref:System.Transactions.TransactionScope> object that creates three nested scope objects, each instantiated with a different <xref:System.Transactions.TransactionScopeOption> value.  
  
```csharp  
using(TransactionScope scope1 = new TransactionScope())   
//Default is Required   
{   
     using(TransactionScope scope2 = new   
      TransactionScope(TransactionScopeOption.Required))   
     {  
     ...  
     }   
  
     using(TransactionScope scope3 = new TransactionScope(TransactionScopeOption.RequiresNew))   
     {  
     ...  
     }   
  
     using(TransactionScope scope4 = new   
        TransactionScope(TransactionScopeOption.Suppress))   
    {  
     ...  
    }   
}  
```  
  
 The example shows a code block without any ambient transaction creating a new scope (`scope1`) with <xref:System.Transactions.TransactionScopeOption.Required>. The scope `scope1` is a root scope as it creates a new transaction (Transaction A) and makes Transaction A the ambient transaction. `Scope1` then creates three more objects, each with a different <xref:System.Transactions.TransactionScopeOption> value. For example, `scope2` is created with <xref:System.Transactions.TransactionScopeOption.Required>, and since there is an ambient transaction, it joins the first transaction created by `scope1`. Note that `scope3` is the root scope of a new transaction, and that `scope4` has no ambient transaction.  
  
 Although the default and most commonly used value of <xref:System.Transactions.TransactionScopeOption> is <xref:System.Transactions.TransactionScopeOption.Required>, each of the other values has its unique purpose.  
  
 <xref:System.Transactions.TransactionScopeOption.Suppress> is useful when you want to preserve the operations performed by the code section, and do not want to abort the ambient transaction if the operations fail. For example, when you want to perform logging or audit operations, or when you want to publish events to subscribers regardless of whether your ambient transaction commits or aborts. This value allows you to have a non-transactional code section inside a transaction scope, as shown in the following example.  
  
```csharp  
using(TransactionScope scope1 = new TransactionScope())  
{  
     try  
     {  
          //Start of non-transactional section   
          using(TransactionScope scope2 = new  
             TransactionScope(TransactionScopeOption.Suppress))  
          {  
               //Do non-transactional work here  
          }  
          //Restores ambient transaction here  
   }  
     catch  
     {}  
   //Rest of scope1  
}  
```  
  
### Voting inside a nested scope  
 Although a nested scope can join the ambient transaction of the root scope, calling <xref:System.Transactions.TransactionScope.Complete%2A> in the nested scope has no affect on the root scope. Only if all the scopes from the root scope down to the last nested scope vote to commit the transaction, will the transaction be committed. Not calling <xref:System.Transactions.TransactionScope.Complete%2A> in a nested scope will affect the root scope as the ambient transaction will immediately be aborted.  
  
## Setting the TransactionScope timeout  
 Some of the overloaded constructors of <xref:System.Transactions.TransactionScope> accept a value of type <xref:System.TimeSpan>, which is used to control the timeout of the transaction. A timeout set to zero means an infinite timeout. Infinite timeout is useful mostly for debugging, when you want to isolate a problem in your business logic by stepping through your code, and you do not want the transaction you debug to time out while you attempt to locate the problem. Be extremely careful using the infinite timeout value in all other cases, because it overrides the safeguards against transaction deadlocks.  
  
 You typically set the <xref:System.Transactions.TransactionScope> timeout to values other than default in two cases. The first is during development, when you want to test the way your application handles aborted transactions. By setting the timeout to a small value (such as one millisecond), you cause your transaction to fail and can thus observe your error handling code. The second case in which you set the value to be less than the default timeout is when you believe that the scope is involved in resource contention, resulting in deadlocks. In that case, you want to abort the transaction as soon as possible and not wait for the default timeout to expire.  
  
 When a scope joins an ambient transaction but specifies a smaller timeout than the one the ambient transaction is set to, the new, shorter timeout is enforced on the <xref:System.Transactions.TransactionScope> object, and the scope must end within the nested time specified, or the transaction is automatically aborted. If the nested scope's timeout is more than that of the ambient transaction, it has no effect.  
  
## Setting the TransactionScope isolation level  
 Some of the overloaded constructors of <xref:System.Transactions.TransactionScope> accept a structure of type <xref:System.Transactions.TransactionOptions> to specify an isolation level, in addition to a timeout value. By default, the transaction executes with isolation level set to <xref:System.Transactions.IsolationLevel.Serializable>. Selecting an isolation level other than <xref:System.Transactions.IsolationLevel.Serializable> is commonly used for read-intensive systems. This requires a solid understanding of transaction processing theory and the semantics of the transaction itself, the concurrency issues involved, and the consequences for system consistency.  
  
 In addition, not all resource managers support all levels of isolation, and they may elect to take part in the transaction at a higher level than the one configured.  
  
 Every isolation level besides <xref:System.Transactions.IsolationLevel.Serializable> is susceptible to inconsistency resulting from other transactions accessing the same information. The difference between the different isolation levels is in the way read and write locks are used. A lock can be held only when the transaction accesses the data in the resource manager, or it can be held until the transaction is committed or aborted. The former is better for throughput, the latter for consistency. The two kinds of locks and the two kinds of operations (read/write) give four basic isolation levels. See <xref:System.Transactions.IsolationLevel> for more information.  
  
 When using nested <xref:System.Transactions.TransactionScope> objects, all nested scopes must be configured to use exactly the same isolation level if they want to join the ambient transaction. If a nested <xref:System.Transactions.TransactionScope> object tries to join the ambient transaction yet it specifies a different isolation level, an <xref:System.ArgumentException> is thrown.  
  
## Interop with COM+  
 When you create a new <xref:System.Transactions.TransactionScope> instance, you can use the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration in one of the constructors to specify how to interact with COM+. For more information on this, see [Interoperability with Enterprise Services and COM+ Transactions](../../../../docs/framework/data/transactions/interoperability-with-enterprise-services-and-com-transactions.md).  
  
## See Also  
 <xref:System.Transactions.Transaction.Clone%2A>  
 <xref:System.Transactions.TransactionScope>
