---
title: "Mixed Declarative Code-Imperative Code Bugs (LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f12b1ab4-bb92-4b92-a648-0525e45b3ce7
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Mixed Declarative Code/Imperative Code Bugs (LINQ to XML) (Visual Basic)
[!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] contains various methods that allow you to modify an XML tree directly. You can add elements, delete elements, change the contents of an element, add attributes, and so on. This programming interface is described in [Modifying XML Trees (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/modifying-xml-trees-linq-to-xml.md). If you are iterating through one of the axes, such as <xref:System.Xml.Linq.XContainer.Elements%2A>, and you are modifying the XML tree as you iterate through the axis, you can end up with some strange bugs.  
  
 This problem is sometimes known as "The Halloween Problem".  
  
## Definition of the Problem  
 When you write some code using LINQ that iterates through a collection, you are writing code in a declarative style. It is more akin to describing *what* you want, rather that *how* you want to get it done. If you write code that 1) gets the first element, 2) tests it for some condition, 3) modifies it, and 4) puts it back into the list, then this would be imperative code. You are telling the computer *how* to do what you want done.  
  
 Mixing these styles of code in the same operation is what leads to problems. Consider the following:  
  
 Suppose you have a linked list with three items in it (a, b, and c):  
  
 `a -> b -> c`  
  
 Now, suppose that you want to move through the linked list, adding three new items (a', b', and c'). You want the resulting linked list to look like this:  
  
 `a -> a' -> b -> b' -> c -> c'`  
  
 So you write code that iterates through the list, and for every item, adds a new item right after it. What happens is that your code will first see the `a` element, and insert `a'` after it. Now, your code will move to the next node in the list, which is now `a'`! It happily adds a new item to the list, `a''`.  
  
 How would you solve this in the real world? Well, you might make a copy of the original linked list, and create a completely new list. Or if you are writing purely imperative code, you might find the first item, add the new item, and then advance twice in the linked list, advancing over the element that you just added.  
  
## Adding While Iterating  
 For example, suppose you want to write some code that for every element in a tree, you want to create a duplicate element:  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
For Each e As XElement In root.Elements()  
    root.Add(New XElement(e.Name, e.Value))  
Next  
```  
  
 This code goes into an infinite loop. The `foreach` statement iterates through the `Elements()` axis, adding new elements to the `doc` element. It ends up iterating also through the elements it just added. And because it allocates new objects with every iteration of the loop, it will eventually consume all available memory.  
  
 You can fix this problem by pulling the collection into memory using the <xref:System.Linq.Enumerable.ToList%2A> standard query operator, as follows:  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
For Each e As XElement In root.Elements().ToList()  
    root.Add(New XElement(e.Name, e.Value))  
Next  
Console.WriteLine(root)  
```  
  
 Now the code works. The resulting XML tree is the following:  
  
```xml  
<Root>  
  <A>1</A>  
  <B>2</B>  
  <C>3</C>  
  <A>1</A>  
  <B>2</B>  
  <C>3</C>  
</Root>  
```  
  
## Deleting While Iterating  
 If you want to delete all nodes at a certain level, you might be tempted to write code like the following:  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
For Each e As XElement In root.Elements()  
    e.Remove()  
Next  
Console.WriteLine(root)  
```  
  
 However, this does not do what you want. In this situation, after you have removed the first element, A, it is removed from the XML tree contained in root, and the code in the Elements method that is doing the iterating cannot find the next element.  
  
 The preceding code produces the following output:  
  
```xml  
<Root>  
  <B>2</B>  
  <C>3</C>  
</Root>  
```  
  
 The solution again is to call <xref:System.Linq.Enumerable.ToList%2A> to materialize the collection, as follows:  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
For Each e As XElement In root.Elements().ToList()  
    e.Remove()  
Next  
Console.WriteLine(root)  
```  
  
 This produces the following output:  
  
```xml  
<Root />  
```  
  
 Alternatively, you can eliminate the iteration altogether by calling <xref:System.Xml.Linq.XElement.RemoveAll%2A> on the parent element:  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
root.RemoveAll()  
Console.WriteLine(root)  
```  
  
## Why Can't LINQ Automatically Handle This?  
 One approach would be to always bring everything into memory instead of doing lazy evaluation. However, it would be very expensive in terms of performance and memory use. In fact, if LINQ and (LINQ to XML) were to take this approach, it would fail in real-world situations.  
  
 Another possible approach would be to put in some sort of transaction syntax into LINQ, and have the compiler attempt to analyze the code and determine if any particular collection needed to be materialized. However, attempting to determine all code that has side-effects is incredibly complex. Consider the following code:  
  
```vb  
Dim z = _  
    From e In root.Elements() _  
    Where (TestSomeCondition(e)) _  
    Select DoMyProjection(e)  
```  
  
 Such analysis code would need to analyze the methods TestSomeCondition and DoMyProjection, and all methods that those methods called, to determine if any code had side-effects. But the analysis code could not just look for any code that had side-effects. It would need to select for just the code that had side-effects on the child elements of `root` in this situation.  
  
 LINQ to XML does not attempt to do any such analysis.  
  
 It is up to you to avoid these problems.  
  
## Guidance  
 First, do not mix declarative and imperative code.  
  
 Even if you know exactly the semantics of your collections and the semantics of the methods that modify the XML tree, if you write some clever code that avoids these categories of problems, your code will need to be maintained by other developers in the future, and they may not be as clear on the issues. If you mix declarative and imperative coding styles, your code will be more brittle.  
  
 If you write code that materializes a collection so that these problems are avoided, note it with comments as appropriate in your code, so that maintenance programmers will understand the issue.  
  
 Second, if performance and other considerations allow, use only declarative code. Don't modify your existing XML tree. Generate a new one.  
  
```vb  
Dim root As XElement = _  
    <Root>  
        <A>1</A>  
        <B>2</B>  
        <C>3</C>  
    </Root>  
Dim newRoot As XElement = New XElement("Root", _  
    root.Elements(), root.Elements())  
Console.WriteLine(newRoot)  
```  
  
## See Also  
 [Advanced LINQ to XML Programming (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/advanced-linq-to-xml-programming.md)
