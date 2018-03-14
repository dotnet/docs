---
title: "Interoperability with Enterprise Services and COM+ Transactions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d0fd0d26-fe86-443b-b208-4d57d39fa4aa
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Interoperability with Enterprise Services and COM+ Transactions
The <xref:System.Transactions> namespace supports interoperability between transaction objects created using this namespace and transactions created through COM+.  
  
 You can use the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration when you create a new <xref:System.Transactions.TransactionScope> instance to specify the level of interoperability with COM+.  
  
 By default, when your application code checks the static <xref:System.Transactions.Transaction.Current%2A> property, <xref:System.Transactions> attempts to look for a transaction that is otherwise current, or a <xref:System.Transactions.TransactionScope> object that dictates that <xref:System.Transactions.Transaction.Current%2A> is **null**. If it cannot find either one of these, <xref:System.Transactions> queries the COM+ context for a transaction. Note that even though <xref:System.Transactions> may find a transaction from the COM+ context, it still favors transactions that are native to <xref:System.Transactions>.  
  
## Interoperability levels  
 The <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration defines the following levels of interoperability—<xref:System.Transactions.EnterpriseServicesInteropOption.None>, <xref:System.Transactions.EnterpriseServicesInteropOption.Full> and <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>.  
  
 The <xref:System.Transactions.TransactionScope> class provides constructors that accept <xref:System.Transactions.EnterpriseServicesInteropOption> as a parameter.  
  
 <xref:System.Transactions.EnterpriseServicesInteropOption.None>, as the name implies, implies that there is no interoperability between <xref:System.EnterpriseServices> contexts and transaction scopes. After creating a <xref:System.Transactions.TransactionScope> object with <xref:System.Transactions.EnterpriseServicesInteropOption.None>, any changes to <xref:System.Transactions.Transaction.Current%2A> are not reflected in the COM+ context. Similarly, changes to the transaction in the COM+ context are not reflected in <xref:System.Transactions.Transaction.Current%2A>. This is the fastest mode of operation for <xref:System.Transactions> because there is no extra synchronization required. <xref:System.Transactions.EnterpriseServicesInteropOption.None> is the default value used by <xref:System.Transactions.TransactionScope> with all constructors that do not accept <xref:System.Transactions.EnterpriseServicesInteropOption> as a parameter.  
  
 If you do want to combine <xref:System.EnterpriseServices> transactions with your ambient transaction, you need to use either <xref:System.Transactions.EnterpriseServicesInteropOption.Full> or <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>. Both of these values rely on a feature called services without components, and therefore you should be running on Windows XP Service Pack 2 or Windows Server 2003 when using them.  
  
 <xref:System.Transactions.EnterpriseServicesInteropOption.Full> specifies that the ambient transactions for <xref:System.Transactions> and <xref:System.EnterpriseServices> are always the same. It results in creating a new <xref:System.EnterpriseServices> transactional context and applying the transaction that is current for the <xref:System.Transactions.TransactionScope> to be current for that context. As such, the transaction in <xref:System.Transactions.Transaction.Current%2A> is completely in synchronization with the transaction in <xref:System.EnterpriseServices.ContextUtil.Transaction%2A>. This value introduces a performance penalty because new COM+ contexts may need to be created.  
  
 <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic> specifies the following requirements:  
  
-   When <xref:System.Transactions.Transaction.Current%2A> is checked, <xref:System.Transactions> should support transactions in the COM+ context if it detects that it is running in a context other than the default context. Note that the default context cannot contain a transaction. Therefore, in the default context, even with <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>, the transaction stored in the thread local storage used by <xref:System.Transactions> is returned for <xref:System.Transactions.Transaction.Current%2A>.  
  
-   If a new <xref:System.Transactions.TransactionScope> object is created and the creation occurs in a context other than the default context, the transaction that is current for the <xref:System.Transactions.TransactionScope> object should be reflected in COM+. In this case, <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic> behaves like <xref:System.Transactions.EnterpriseServicesInteropOption.Full> in that it creates a new COM+ context.  
  
 In addition when <xref:System.Transactions.Transaction.Current%2A> is set in both <xref:System.Transactions.EnterpriseServicesInteropOption.Full> and <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>, both of these modes imply that <xref:System.Transactions.Transaction.Current%2A> cannot be set directly.  Any attempt to set <xref:System.Transactions.Transaction.Current%2A> directly other than creating a <xref:System.Transactions.TransactionScope> results in an <xref:System.InvalidOperationException>. The <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration value is inherited by new transaction scopes that do not explicitly specify which value to use. For example, if you create a new <xref:System.Transactions.TransactionScope> object with <xref:System.Transactions.EnterpriseServicesInteropOption.Full>, and then create a second <xref:System.Transactions.TransactionScope> object but do not specify an <xref:System.Transactions.EnterpriseServicesInteropOption> value, the second <xref:System.Transactions.TransactionScope> object also has a <xref:System.Transactions.EnterpriseServicesInteropOption.Full>.  
  
 In summary, the following rules apply when creating a new transaction scope:  
  
1.  <xref:System.Transactions.Transaction.Current%2A> is checked to see if there is a transaction. This check results in:  
  
    -   A check to see if there is a scope.  
  
    -   If there is a scope, the value of the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration passed in when the scope was initially created is checked.  
  
    -   If the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration is set to <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>, the COM+ transaction (<xref:System.EnterpriseServices> Transaction) takes precedence over the <xref:System.Transactions> transaction in managed thread local storage.  
  
         If the value is set to <xref:System.Transactions.EnterpriseServicesInteropOption.None>, the <xref:System.Transactions> transaction in managed thread local storage takes precedence.  
  
         If the value is <xref:System.Transactions.EnterpriseServicesInteropOption.Full>, there is only one transaction and it is a COM+ transaction.  
  
2.  The value of the <xref:System.Transactions.TransactionScopeOption> enumeration passed in by the <xref:System.Transactions.TransactionScope> constructor is checked. This determines if a new transaction must be created.  
  
3.  If a new transaction is to be created, the following values of <xref:System.Transactions.EnterpriseServicesInteropOption> result in:  
  
    -   <xref:System.Transactions.EnterpriseServicesInteropOption.Full>:  a transaction associated with a COM+ context is created.  
  
    -   <xref:System.Transactions.EnterpriseServicesInteropOption.None>: a <xref:System.Transactions> transaction is created.  
  
    -   <xref:System.Transactions.EnterpriseServicesInteropOption.Automatic>: if there is a COM+ context, a transaction is created and attached to the context.  
  
 The following table illustrates the Enterprise Services (ES) context and a transactional scope that requires a transaction using the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration.  
  
|ES Context|None|Automatic|Full|  
|----------------|----------|---------------|----------|  
|Default context|Default context|Default context|Create new <br />transactional context|  
|Non-default context|Maintain client's context|Create new transactional context|Create new transactional context|  
  
 The following table illustrates what the ambient transaction is, given a particular <xref:System.EnterpriseServices> context, and a transactional scope that requires a transaction using the <xref:System.Transactions.EnterpriseServicesInteropOption> enumeration.  
  
|ES Context|None|Automatic|Full|  
|----------------|----------|---------------|----------|  
|Default context|ST|ST|ES|  
|Non-default context|ST|ES|ES|  
  
 In the preceding table:  
  
-   ST means that the scope's ambient transaction is managed by <xref:System.Transactions>, separate from any <xref:System.EnterpriseServices> context's transaction that may be present.  
  
-   ES means that the scope's ambient transaction is same as the <xref:System.EnterpriseServices> context's transaction.
