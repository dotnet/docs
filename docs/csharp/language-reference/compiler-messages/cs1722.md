---
title: "Compiler Error CS1722"
ms.date: 07/20/2015
f1_keywords: 
  - "CS1722"
helpviewer_keywords: 
  - "CS1722"
ms.assetid: cf698a80-e4c9-46e2-96a0-8b8b5a08fc37
---
# Compiler Error CS1722
Base class 'class' must come before any interfaces  
  
 When specifying a class to inherit from and interfaces to implement, the class name must be specified first.  
  
## Example  
 The following sample generates CS1722.  
  
```csharp  
// CS1722.cs  
// compile with: /target:library  
public class A {}  
interface I {}  
  
public class MyClass : I, A {}   // CS1722  
public class MyClass2 : A, I {}   // OK  
```
