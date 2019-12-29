---
title: "Compiler Error CS0249"
ms.date: 07/20/2015
f1_keywords: 
  - "CS0249"
helpviewer_keywords: 
  - "CS0249"
ms.assetid: 8bc3572f-d949-4867-b119-6527fb924a4a
---
# Compiler Error CS0249
Do not override object.Finalize. Instead, provide a destructor.  
  
 Use destructor syntax to specify instructions to execute when your object is destroyed.  

 The following sample generates CS0249:  
  
```csharp  
// CS0249.cs  
class MyClass  
{  
   protected override void Finalize()   // CS0249  
   // try the following line instead  
   // ~MyClass()  
   {  
   }  
  
   public static void Main()  
   {  
   }  
}  
```
