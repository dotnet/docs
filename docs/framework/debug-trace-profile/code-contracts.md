---
title: "Code Contracts"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Code contracts"
ms.assetid: 84526045-496f-489d-8517-a258cf76f040
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Code Contracts
Code contracts provide a way to specify preconditions, postconditions, and object invariants in your code. Preconditions are requirements that must be met when entering a method or property. Postconditions describe expectations at the time the method or property code exits. Object invariants describe the expected state for a class that is in a good state.  
  
 Code contracts include classes for marking your code, a static analyzer for compile-time analysis, and a runtime analyzer. The classes for code contracts can be found in the <xref:System.Diagnostics.Contracts> namespace.  
  
 The benefits of code contracts include the following:  
  
-   Improved testing: Code contracts provide static contract verification, runtime checking, and documentation generation.  
  
-   Automatic testing tools: You can use code contracts to generate more meaningful unit tests by filtering out meaningless test arguments that do not satisfy preconditions.  
  
-   Static verification: The static checker can decide whether there are any contract violations without running the program. It checks for implicit contracts, such as null dereferences and array bounds, and explicit contracts.  
  
-   Reference documentation: The documentation generator augments existing XML documentation files with contract information. There are also style sheets that can be used with [Sandcastle](https://github.com/EWSoftware/SHFB) so that the generated documentation pages have contract sections.  
  
 All .NET Framework languages can immediately take advantage of contracts; you do not have to write a special parser or compiler. A Visual Studio add-in lets you specify the level of code contract analysis to be performed. The analyzers can confirm that the contracts are well-formed (type checking and name resolution) and can produce a compiled form of the contracts in Microsoft intermediate language (MSIL) format. Authoring contracts in Visual Studio lets you take advantage of the standard IntelliSense provided by the tool.  
  
 Most methods in the contract class are conditionally compiled; that is, the compiler emits calls to these methods only when  you define a special symbol, CONTRACTS_FULL, by using the `#define` directive. CONTRACTS_FULL lets you write contracts in your code without using `#ifdef` directives; you can produce different builds, some with contracts, and some without.  
  
 For tools and detailed instructions for using code contracts, see [Code Contracts](http://go.microsoft.com/fwlink/?LinkId=152461) on the MSDN DevLabs Web site.  
  
## Preconditions  
 You can express preconditions by using the <xref:System.Diagnostics.Contracts.Contract.Requires%2A?displayProperty=nameWithType> method. Preconditions specify state when a method is invoked. They are generally used to specify valid parameter values. All members that are mentioned in preconditions must be at least as accessible as the method itself; otherwise, the precondition might not be understood by all callers of a method. The condition must have no side-effects. The run-time behavior of failed preconditions is determined by the runtime analyzer.  
  
 For example, the following precondition expresses that parameter `x` must be non-null.  
  
 `Contract.Requires( x != null );`  
  
 If your code must throw a particular exception on failure of a precondition, you can use the generic overload of <xref:System.Diagnostics.Contracts.Contract.Requires%2A> as follows.  
  
 `Contract.Requires<ArgumentNullException>( x != null, "x" );`  
  
### Legacy Requires Statements  
 Most code contains some parameter validation in the form of `if`-`then`-`throw` code. The contract tools recognize these statements as preconditions in the following cases:  
  
-   The statements appear before any other statements in a method.  
  
-   The entire set of such statements is followed by an explicit <xref:System.Diagnostics.Contracts.Contract> method call, such as a call to the <xref:System.Diagnostics.Contracts.Contract.Requires%2A>, <xref:System.Diagnostics.Contracts.Contract.Ensures%2A>, <xref:System.Diagnostics.Contracts.Contract.EnsuresOnThrow%2A>, or <xref:System.Diagnostics.Contracts.Contract.EndContractBlock%2A> method.  
  
 When `if`-`then`-`throw` statements appear in this form, the tools recognize them as legacy `requires` statements. If no other contracts follow the `if`-`then`-`throw` sequence, end the code with the <xref:System.Diagnostics.Contracts.Contract.EndContractBlock%2A?displayProperty=nameWithType> method.  
  
```  
if ( x == null ) throw new ...  
Contract.EndContractBlock(); // All previous "if" checks are preconditions  
```  
  
 Note that the condition in the preceding test is a negated precondition. (The actual precondition would be `x != null`.) A negated precondition is highly restricted: It must be written as shown in the previous example; that is, it should contain no `else` clauses, and the body of the `then` clause must be a single `throw` statement. The `if` test is subject to both purity and visibility rules (see [Usage Guidelines](#usage_guidelines)), but the `throw` expression is subject only to purity rules. However, the type of the exception thrown must be as visible as the method in which the contract occurs.  
  
## Postconditions  
 Postconditions are contracts for the state of a method when it terminates. The postcondition is checked just before exiting a method. The run-time behavior of failed postconditions is determined by the runtime analyzer.  
  
 Unlike preconditions, postconditions may reference members with less visibility. A client may not be able to understand or make use of some of the information expressed by a postcondition using private state, but this does not affect the client's ability to use the method correctly.  
  
### Standard Postconditions  
 You can express standard postconditions by using the <xref:System.Diagnostics.Contracts.Contract.Ensures%2A> method. Postconditions express a condition that must be `true` upon normal termination of the method.  
  
 `Contract.Ensures( this.F > 0 );`  
  
### Exceptional Postconditions  
 Exceptional postconditions are postconditions that should be `true` when a particular exception is thrown by a method. You can specify these postconditions by using the <xref:System.Diagnostics.Contracts.Contract.EnsuresOnThrow%2A?displayProperty=nameWithType> method, as the following example shows.  
  
 `Contract.EnsuresOnThrow<T>( this.F > 0 );`  
  
 The argument is the condition that must be `true` whenever an exception that is a subtype of `T` is thrown.  
  
 There are some exception types that are difficult to use in an exceptional postcondition. For example, using the type <xref:System.Exception> for `T` requires the method to guarantee the condition regardless of the type of exception that is thrown, even if it is a stack overflow or other impossible-to-control exception. You should use exceptional postconditions only for specific exceptions that might be thrown when a member is called, for example, when an <xref:System.InvalidTimeZoneException> is thrown for a <xref:System.TimeZoneInfo> method call.  
  
### Special Postconditions  
 The following methods may be used only within postconditions:  
  
-   You can refer to method return values in postconditions by using the expression `Contract.Result<T>()`, where `T` is replaced by the return type of the method. When the compiler is unable to infer the type, you must explicitly provide it. For example, the C# compiler is unable to infer types for methods that do not take any arguments, so it requires the following postcondition: `Contract.Ensures(0 <Contract.Result<int>())` Methods with a return type of `void` cannot refer to `Contract.Result<T>()` in their postconditions.  
  
-   A prestate value in a postcondition refers to the value of an expression at the start of a method or property. It uses the expression `Contract.OldValue<T>(e)`, where `T` is the type of `e`. You can omit the generic type argument whenever the compiler is able to infer its type. (For example, the C# compiler always infers the type because it takes an argument.) There are several restrictions on what can occur in `e` and the contexts in which an old expression may appear. An old expression cannot contain another old expression. Most importantly, an old expression must refer to a value that existed in the method's precondition state. In other words, it must be an expression that can be evaluated as long as the method's precondition is `true`. Here are several instances of that rule.  
  
    -   The value must exist in the method's precondition state. In order to reference a field on an object, the preconditions must guarantee that that object is always non-null.  
  
    -   You cannot refer to the method's return value in an old expression:  
  
        ```  
        Contract.OldValue(Contract.Result<int>() + x) // ERROR  
        ```  
  
    -   You cannot refer to `out` parameters in an old expression.  
  
    -   An old expression cannot depend on the bound variable of a quantifier if the range of the quantifier depends on the return value of the method:  
  
        ```  
        Contract. ForAll (0,Contract. Result<int>(),  
        i => Contract.OldValue(xs[i]) > 3); // ERROR  
        ```  
  
    -   An old expression cannot refer to the parameter of the anonymous delegate in a <xref:System.Diagnostics.Contracts.Contract.ForAll%2A> or <xref:System.Diagnostics.Contracts.Contract.Exists%2A> call unless it is used as an indexer or argument to a method call:  
  
        ```  
        Contract. ForAll (0, xs .Length, i => Contract.OldValue(xs[i]) > 3); // OK  
        Contract. ForAll (0, xs .Length, i => Contract.OldValue(i) > 3); // ERROR  
        ```  
  
    -   An old expression cannot occur in the body of an anonymous delegate if the value of the old expression depends on any of the parameters of the anonymous delegate, unless the anonymous delegate is an argument to the <xref:System.Diagnostics.Contracts.Contract.ForAll%2A> or <xref:System.Diagnostics.Contracts.Contract.Exists%2A> method:  
  
        ```  
        Method( ... (T t) => Contract.OldValue(... t ...) ... ); // ERROR  
        ```  
  
    -   `Out` parameters present a problem because contracts appear before the body of the method, and most compilers do not allow references to `out` parameters in postconditions. To solve this problem, the <xref:System.Diagnostics.Contracts.Contract> class provides the <xref:System.Diagnostics.Contracts.Contract.ValueAtReturn%2A> method, which allows a postcondition based on an `out` parameter.  
  
        ```  
        public void OutParam(out int x) f  
        Contract.Ensures(Contract.ValueAtReturn(out x) == 3);  
        x = 3;  
        ```  
  
         As with the <xref:System.Diagnostics.Contracts.Contract.OldValue%2A> method, you can omit the generic type parameter whenever the compiler is able to infer its type. The contract rewriter replaces the method call with the value of the `out` parameter. The <xref:System.Diagnostics.Contracts.Contract.ValueAtReturn%2A> method may appear only in postconditions. The argument to the method must be an `out` parameter or a field of a structure `out` parameter. The latter is also useful when referring to fields in the postcondition of a structure constructor.  
  
        > [!NOTE]
        >  Currently, the code contract analysis tools do not check whether `out` parameters are initialized properly and disregard their mention in the postcondition. Therefore, in the previous example, if the line after the contract had used the value of `x` instead of assigning an integer to it, a compiler would not issue the correct error. However, on a build where the CONTRACTS_FULL preprocessor symbol is not defined (such asa release build), the compiler will issue an error.  
  
## Invariants  
 Object invariants are conditions that should be true for each instance of a class whenever that object is visible to a client. They express the conditions under which the object is considered to be correct.  
  
 The invariant methods are identified by being marked with the <xref:System.Diagnostics.Contracts.ContractInvariantMethodAttribute> attribute. The invariant methods must contain no code except for a sequence of calls to the <xref:System.Diagnostics.Contracts.Contract.Invariant%2A> method, each of which specifies an individual invariant, as shown in the following example.  
  
```  
[ContractInvariantMethod]  
protected void ObjectInvariant ()   
{  
Contract.Invariant(this.y >= 0);  
Contract.Invariant(this.x > this.y);  
...  
}  
```  
  
 Invariants are conditionally defined by the CONTRACTS_FULL preprocessor symbol. During run-time checking, invariants are checked at the end of each public method. If an invariant mentions a public method in the same class, the invariant check that would normally happen at the end of that public method is disabled. Instead, the check occurs only at the end of the outermost method call to that class. This also happens if the class is re-entered because of a call to a method on another class. Invariants are not checked for object finalizers or for any methods that implement the <xref:System.IDisposable.Dispose%2A> method.  
  
<a name="usage_guidelines"></a>   
## Usage Guidelines  
  
### Contract Ordering  
 The following table shows the order of elements you should use when you write method contracts.  
  
|`If-then-throw statements`|Backward-compatible public preconditions|  
|-|-|  
|<xref:System.Diagnostics.Contracts.Contract.Requires%2A>|All public preconditions.|  
|<xref:System.Diagnostics.Contracts.Contract.Ensures%2A>|All public (normal) postconditions.|  
|<xref:System.Diagnostics.Contracts.Contract.EnsuresOnThrow%2A>|All public exceptional postconditions.|  
|<xref:System.Diagnostics.Contracts.Contract.Ensures%2A>|All private/internal (normal) postconditions.|  
|<xref:System.Diagnostics.Contracts.Contract.EnsuresOnThrow%2A>|All private/internal exceptional postconditions.|  
|<xref:System.Diagnostics.Contracts.Contract.EndContractBlock%2A>|If using `if`-`then`-`throw` style preconditions without any other contracts, place a call to <xref:System.Diagnostics.Contracts.Contract.EndContractBlock%2A> to indicate that all previous if checks are preconditions.|  
  
<a name="purity"></a>   
### Purity  
 All methods that are called within a contract must be pure; that is, they must not update any preexisting state. A pure method is allowed to modify objects that have been created after entry into the pure method.  
  
 Code contract tools currently assume that the following code elements are pure:  
  
-   Methods that are marked with the <xref:System.Diagnostics.Contracts.PureAttribute>.  
  
-   Types that are marked with the <xref:System.Diagnostics.Contracts.PureAttribute> (the attribute applies to all the type's methods).  
  
-   Property get accessors.  
  
-   Operators (static methods whose names start with "op", and that have one or two parameters and a non-void return type).  
  
-   Any method whose fully qualified name begins with "System.Diagnostics.Contracts.Contract", "System.String", "System.IO.Path", or "System.Type".  
  
-   Any invoked delegate, provided that the delegate type itself is attributed with the <xref:System.Diagnostics.Contracts.PureAttribute>. The delegate types <xref:System.Predicate%601?displayProperty=nameWithType> and <xref:System.Comparison%601?displayProperty=nameWithType> are considered pure.  
  
<a name="visibility"></a>   
### Visibility  
 All members mentioned in a contract must be at least as visible as the method in which they appear. For example, a private field cannot be mentioned in a precondition for a public method; clients cannot validate such a contract before they call the method. However, if the field is marked with the <xref:System.Diagnostics.Contracts.ContractPublicPropertyNameAttribute>, it is exempt from these rules.  
  
## Example  
 The following example shows the use of code contracts.  
  
 [!code-csharp[ContractExample#1](../../../samples/snippets/csharp/VS_Snippets_CLR/contractexample/cs/program.cs#1)]
 [!code-vb[ContractExample#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/contractexample/vb/program.vb#1)]
