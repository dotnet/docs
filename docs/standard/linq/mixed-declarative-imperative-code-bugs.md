---
title: Mixed declarative/imperative code bugs - LINQ to XML
description: Learn how to recognize and avoid problems that can occur when code iterates along an axis making changes.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: fada62d0-0680-4e73-945a-2b00d7a507af
ms.topic: article
---

# Mixed declarative/imperative code bugs (LINQ to XML)

LINQ to XML contains various methods that allow you to modify an XML tree directly. You can add elements, delete elements, change the contents of an element, add attributes, and so on. This programming interface is described in [Modify XML trees](in-memory-xml-tree-modification-vs-functional-construction.md). If you're iterating through one of the axes, such as <xref:System.Xml.Linq.XContainer.Elements%2A>, and you're modifying the XML tree as you iterate through the axis, you can end up with some strange bugs.

This problem is sometimes known as "The Halloween Problem".

When you write some code using LINQ that iterates through a collection, you're writing code in a declarative style. It's more akin to describing *what* you want, rather that *how* you want to get it done. If you write code that 1) gets the first element, 2) tests it for some condition, 3) modifies it, and 4) puts it back into the list, then this would be imperative code. You're telling the computer *how* to do what you want done.

Mixing these styles of code in the same operation is what leads to problems. Consider the following:

Suppose you have a linked list with three items in it (a, b, and c):

> a -> b -> c

Now, suppose that you want to move through the linked list, adding three new items (a', b', and c'). You want the resulting linked list to look like this:

 > a -> a' -> b -> b' -> c -> c'

So you write code that iterates through the list, and for every item, adds a new item right after it. What happens is that your code will first see the `a` element, and insert `a'` after it. Now, your code will move to the next node in the list, which is now `a'`, so it adds a new item between a' and b to the list!

How would you solve this? Well, you might make a copy of the original linked list, and create a completely new list. Or if you're writing purely imperative code, you might find the first item, add the new item, and then advance twice in the linked list, advancing over the element that you just added.

## Example: Adding while iterating

For example, suppose you want to write code to create a duplicate of every element in a tree:

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
foreach (XElement e in root.Elements())
    root.Add(new XElement(e.Name, (string)e));
```

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

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
foreach (XElement e in root.Elements().ToList())
    root.Add(new XElement(e.Name, (string)e));
Console.WriteLine(root);
```

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

## Example: Deleting while iterating

If you want to delete all nodes at a certain level, you might be tempted to write code like the following:

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
foreach (XElement e in root.Elements())
    e.Remove();
Console.WriteLine(root);
```

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

However, this doesn't do what you want. In this situation, after you've removed the first element, A, it's removed from the XML tree contained in root, and the code in the Elements method that does the iterating can't find the next element.

This example produces the following output:

```xml
<Root>
  <B>2</B>
  <C>3</C>
</Root>
```

The solution again is to call <xref:System.Linq.Enumerable.ToList%2A> to materialize the collection, as follows:

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
foreach (XElement e in root.Elements().ToList())
    e.Remove();
Console.WriteLine(root);
```

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

This example produces the following output:

```xml
<Root />
```

Alternatively, you can eliminate the iteration altogether by calling <xref:System.Xml.Linq.XElement.RemoveAll%2A> on the parent element:

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
root.RemoveAll();
Console.WriteLine(root);
```

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

## Example: Why LINQ can't automatically handle these issues

One approach would be to always bring everything into memory instead of doing lazy evaluation. However, it would be very expensive in terms of performance and memory use. In fact, if LINQ, and LINQ to XML, were to take this approach, it would fail in real-world situations.

Another possible approach would be to put some sort of transaction syntax into LINQ, and have the compiler attempt to analyze the code to determine if any particular collection needed to be materialized. However, attempting to determine all code that has side-effects is incredibly complex. Consider the following code:

```csharp
var z =
    from e in root.Elements()
    where TestSomeCondition(e)
    select DoMyProjection(e);
```

```vb
Dim z = _
    From e In root.Elements() _
    Where (TestSomeCondition(e)) _
    Select DoMyProjection(e)
```

Such analysis code would need to analyze the methods TestSomeCondition and DoMyProjection, and all methods that those methods called, to determine if any code had side-effects. But the analysis code could not just look for any code that had side-effects. It would need to select for just the code that had side-effects on the child elements of `root` in this situation.

LINQ to XML doesn't attempt to do any such analysis. It's up to you to avoid these problems.

## Example: Use declarative code to generate a new XML tree rather than modify the existing tree

To avoid such problems, don't mix declarative and imperative code, even if you know exactly the semantics of your collections and the semantics of the methods that modify the XML tree. If you write code that avoids problems, your code will need to be maintained by other developers in the future, and they may not be as clear on the issues. If you mix declarative and imperative coding styles, your code will be more brittle.  If you write code that materializes a collection so that these problems are avoided, note it with comments as appropriate in your code, so that maintenance programmers will understand the issue.

If performance and other considerations allow, use only declarative code. Don't modify your existing XML tree. Instead, generate a new one as shown in the following example:

```csharp
XElement root = new XElement("Root",
    new XElement("A", "1"),
    new XElement("B", "2"),
    new XElement("C", "3")
);
XElement newRoot = new XElement("Root",
    root.Elements(),
    root.Elements()
);
Console.WriteLine(newRoot);
```

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
