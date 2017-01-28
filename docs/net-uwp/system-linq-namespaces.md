---
title: "System.Linq namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ee5b5c7b-19f1-4826-ae18-50a9dec7503e
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Linq namespaces1
The `System.Linq` and `System.Linq.Expressions` namespaces contain types that support queries that use Language-Integrated Query (LINQ).  
  
 This topic displays the types in the `System.Linq` and `System.Linq.Expressions` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Linq namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Linq.Enumerable>|Provides a set of static methods for querying objects that implement IEnumerable\<T>.|  
|<xref:System.Linq.EnumerableExecutor>|Represents an expression tree and provides functionality to execute the expression tree after rewriting it.|  
|<xref:System.Linq.EnumerableExecutor%601>|Represents an expression tree and provides functionality to execute the expression tree after rewriting it.|  
|<xref:System.Linq.EnumerableQuery>|Represents an IEnumerable as an EnumerableQuery data source.|  
|<xref:System.Linq.EnumerableQuery%601>|Represents an IEnumerable\<T> collection as an IQueryable\<T> data source.|  
|<xref:System.Linq.IGrouping%602>|Represents a collection of objects that have a common key.|  
|<xref:System.Linq.ILookup%602>|Defines an indexer, size property, and Boolean search method for data structures that map keys to IEnumerable\<T> sequences of values.|  
|<xref:System.Linq.IOrderedEnumerable%601>|Represents a sorted sequence.|  
|<xref:System.Linq.IOrderedQueryable>|Represents the result of a sorting operation.|  
|<xref:System.Linq.IOrderedQueryable%601>|Represents the result of a sorting operation.|  
|<xref:System.Linq.IQueryable>|Provides functionality to evaluate queries against a specific data source wherein the type of the data is not specified.|  
|<xref:System.Linq.IQueryable%601>|Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.|  
|<xref:System.Linq.IQueryProvider>|Defines methods to create and execute queries that are described by an IQueryable object.|  
|<xref:System.Linq.Lookup%602>|Represents a collection of keys each mapped to one or more values.|  
|<xref:System.Linq.OrderedParallelQuery%601>|Represents a sorted, parallel sequence.|  
|<xref:System.Linq.ParallelEnumerable>|Provides a set of methods for querying objects that implement ParallelQuery{TSource}. This is the parallel equivalent of Enumerable.|  
|<xref:System.Linq.ParallelExecutionMode>|The query execution mode is a hint that specifies how the system should handle performance trade-offs when parallelizing queries.|  
|<xref:System.Linq.ParallelMergeOptions>|Specifies the preferred type of output merge to use in a query. In other words, it indicates how PLINQ should merge the results from the various partitions back into a single result sequence. This is a hint only, and may not be respected by the system when parallelizing all queries.|  
|<xref:System.Linq.ParallelQuery>|Represents a parallel sequence.|  
|<xref:System.Linq.ParallelQuery%601>|Represents a parallel sequence.|  
|<xref:System.Linq.Queryable>|Provides a set of static methods for querying data structures that implement IQueryable\<T>.|  
  
## System.Linq.Expressions namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Linq.Expressions.BinaryExpression>|Represents an expression that has a binary operator.|  
|<xref:System.Linq.Expressions.BlockExpression>|Represents a block that contains a sequence of expressions where variables can be defined.|  
|<xref:System.Linq.Expressions.CatchBlock>|Represents a catch statement in a try block.|  
|<xref:System.Linq.Expressions.ConditionalExpression>|Represents an expression that has a conditional operator.|  
|<xref:System.Linq.Expressions.ConstantExpression>|Represents an expression that has a constant value.|  
|<xref:System.Linq.Expressions.DebugInfoExpression>|Emits or clears a sequence point for debug information. This allows the debugger to highlight the correct source code when debugging.|  
|<xref:System.Linq.Expressions.DefaultExpression>|Represents the default value of a type or an empty expression.|  
|<xref:System.Linq.Expressions.DynamicExpression>|Represents a dynamic operation.|  
|<xref:System.Linq.Expressions.DynamicExpressionVisitor>|Represents a visitor or rewriter for dynamic expression trees.|  
|<xref:System.Linq.Expressions.ElementInit>|Represents an initializer for a single element of an IEnumerable collection.|  
|<xref:System.Linq.Expressions.Expression>|Provides the base class from which the classes that represent expression tree nodes are derived. It also contains static factory methods to create the various node types. This is an abstract class.|  
|<xref:System.Linq.Expressions.Expression%601>|Represents a strongly typed lambda expression as a data structure in the form of an expression tree. This class cannot be inherited.|  
|<xref:System.Linq.Expressions.ExpressionType>|Describes the node types for the nodes of an expression tree.|  
|<xref:System.Linq.Expressions.ExpressionVisitor>|Represents a visitor or rewriter for expression trees.|  
|<xref:System.Linq.Expressions.GotoExpression>|Represents an unconditional jump. This includes return statements, break and continue statements, and other jumps.|  
|<xref:System.Linq.Expressions.GotoExpressionKind>|Specifies what kind of jump this GotoExpression represents.|  
|<xref:System.Linq.Expressions.IndexExpression>|Represents indexing a property or array.|  
|<xref:System.Linq.Expressions.InvocationExpression>|Represents an expression that applies a delegate or lambda expression to a list of argument expressions.|  
|<xref:System.Linq.Expressions.LabelExpression>|Represents a label, which can be put in any Expression context. If it is jumped to, it will get the value provided by the corresponding GotoExpression. Otherwise, it receives the value in DefaultValue. If the Type equals Void, no value should be provided.|  
|<xref:System.Linq.Expressions.LabelTarget>|Represents the target of a GotoExpression.|  
|<xref:System.Linq.Expressions.LambdaExpression>|Describes a lambda expression. This captures a block of code that is similar to a .NET method body.|  
|<xref:System.Linq.Expressions.ListInitExpression>|Represents a constructor call that has a collection initializer.|  
|<xref:System.Linq.Expressions.LoopExpression>|Represents an infinite loop. It can be exited with "break".|  
|<xref:System.Linq.Expressions.MemberAssignment>|Represents assignment operation for a field or property of an object.|  
|<xref:System.Linq.Expressions.MemberBinding>|Provides the base class from which the classes that represent bindings that are used to initialize members of a newly created object derive.|  
|<xref:System.Linq.Expressions.MemberBindingType>|Describes the binding types that are used in MemberInitExpression objects.|  
|<xref:System.Linq.Expressions.MemberExpression>|Represents accessing a field or property.|  
|<xref:System.Linq.Expressions.MemberInitExpression>|Represents calling a constructor and initializing one or more members of the new object.|  
|<xref:System.Linq.Expressions.MemberListBinding>|Represents initializing the elements of a collection member of a newly created object.|  
|<xref:System.Linq.Expressions.MemberMemberBinding>|Represents initializing members of a member of a newly created object.|  
|<xref:System.Linq.Expressions.MethodCallExpression>|Represents a call to either static or an instance method.|  
|<xref:System.Linq.Expressions.NewArrayExpression>|Represents creating a new array and possibly initializing the elements of the new array.|  
|<xref:System.Linq.Expressions.NewExpression>|Represents a constructor call.|  
|<xref:System.Linq.Expressions.ParameterExpression>|Represents a named parameter expression.|  
|<xref:System.Linq.Expressions.RuntimeVariablesExpression>|Represents an expression that provides runtime read/write permission for variables.|  
|<xref:System.Linq.Expressions.SwitchCase>|Represents one case of a SwitchExpression.|  
|<xref:System.Linq.Expressions.SwitchExpression>|Represents a control expression that handles multiple selections by passing control to SwitchCase.|  
|<xref:System.Linq.Expressions.SymbolDocumentInfo>|Stores information necessary to emit debugging symbol information for a source file, in particular the file name and unique language identifier.|  
|<xref:System.Linq.Expressions.TryExpression>|Represents a try/catch/finally/fault block.|  
|<xref:System.Linq.Expressions.TypeBinaryExpression>|Represents an operation between an expression and a type.|  
|<xref:System.Linq.Expressions.UnaryExpression>|Represents an expression that has a unary operator.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)