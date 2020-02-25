---
title: Collections.Set Module (F#)
description: Collections.Set Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b2009751-2a35-437e-a9ea-d78f1e924982 
---

# Collections.Set Module (F#)

Functional programming operators related to the [Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8) type.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Set
```

## Values


|Value|Description|
|-----|-----------|
|[add](https://msdn.microsoft.com/library/d06ab305-1183-487c-8dc0-9076ed0b4c28)<br />**: 'T -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Returns a new set with an element added to the set. No exception is raised if the set already contains the given element.|
|[contains](https://msdn.microsoft.com/library/7d616d1e-bca9-463e-b11e-88b5dc8b930b)<br />**: 'T -&gt; Set&lt;'T&gt; -&gt; bool**|Evaluates to **true** if the given element is in the given set.|
|[count](https://msdn.microsoft.com/library/54acc46d-af76-474e-9ff7-bd4bd6b7b4c4)<br />**: Set&lt;'T&gt; -&gt; int**|Returns the number of elements in the set.|
|[difference](https://msdn.microsoft.com/library/75bf5d03-8825-4b21-8526-4da87ea419e6)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Returns a new set with the elements of the second set removed from the first.|
|[empty](https://msdn.microsoft.com/library/2b3b133b-a220-4161-8a7b-dff7b764688a)<br />**: Set&lt;'T&gt;**|The empty set for the specified type.|
|[exists](https://msdn.microsoft.com/library/55bf43f8-e5f2-4e3d-900a-e4d7ca983541)<br />**: ('T -&gt; bool) -&gt; Set&lt;'T&gt; -&gt; bool**|Tests if any element of the collection satisfies the given predicate. If the input function is **predicate** and the elements are **i0...iN**, then this function computes **predicate i0 or ... or predicate iN**.|
|[filter](https://msdn.microsoft.com/library/085960a3-1909-4ed1-985b-3f023dc4bd5f)<br />**: ('T -&gt; bool) -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Returns a new collection containing only the elements of the collection for which the given predicate returns **true**.|
|[fold](https://msdn.microsoft.com/library/81b0358f-3719-4e0b-b5f1-995946a68523)<br />**: ('State -&gt; 'T -&gt; 'State) -&gt; 'State -&gt; Set&lt;'T&gt; -&gt; 'State**|Applies the given accumulating function to all the elements of the set|
|[foldBack](https://msdn.microsoft.com/library/17933093-9571-4889-8a9f-532d60ac64dd)<br />**: ('T -&gt; 'State -&gt; 'State) -&gt; Set&lt;'T&gt; -&gt; 'State -&gt; 'State**|Applies the given accumulating function to all the elements of the set.|
|[forall](https://msdn.microsoft.com/library/9d985cca-ad37-4402-a039-7db47442f578)<br />**: ('T -&gt; bool) -&gt; Set&lt;'T&gt; -&gt; bool**|Tests if all elements of the collection satisfy the given predicate. If the input function is **p** and the elements are **i0...iN,** then this function computes **p i0 &amp;&amp; ... &amp;&amp; p iN**.|
|[intersect](https://msdn.microsoft.com/library/540f4b96-34d6-47f0-8881-e3a434abade1)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Computes the intersection of the two sets.|
|[intersectMany](https://msdn.microsoft.com/library/2a0a9352-205f-4ea2-9b4c-c58f73a8e784)<br />**: seq&lt;Set&lt;'T&gt;&gt; -&gt; Set&lt;'T&gt;**|Computes the intersection of a sequence of sets. The sequence must be non-empty.|
|[isEmpty](https://msdn.microsoft.com/library/64ddfbfd-3313-4495-9067-b614dd530aa7)<br />**: Set&lt;'T&gt; -&gt; bool**|Returns **true** if the set is empty.|
|[isProperSubset](https://msdn.microsoft.com/library/5f3d1d4a-8ba5-488f-89b1-e312fd3fd29b)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; bool**|Evaluates to **true** if all elements of the first set are in the second, and at least one element of the second is not in the first.|
|[isProperSuperset](https://msdn.microsoft.com/library/64bb2c29-59db-4d2c-9a54-7a0440b4e37f)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; bool**|Evaluates to **true** if all elements of the second set are in the first, and at least one element of the first is not in the second.|
|[isSubset](https://msdn.microsoft.com/library/8c2ffe09-d863-4de4-a350-795c44822bc8)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; bool**|Evaluates to **true** if all elements of the first set are in the second|
|[isSuperset](https://msdn.microsoft.com/library/f09b4a5f-e03b-435e-82a3-927e576635f3)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; bool**|Evaluates to **true** if all elements of the second set are in the first.|
|[iter](https://msdn.microsoft.com/library/3f10b1f1-c1c9-4a86-af37-41e9c8dd8f54)<br />**: ('T -&gt; unit) -&gt; Set&lt;'T&gt; -&gt; unit**|Applies the given function to each element of the set, in order according to the comparison function.|
|[map](https://msdn.microsoft.com/library/a71c114e-5143-49a0-9fc7-adf83612742a)<br />**: ('T -&gt; 'U) -&gt; Set&lt;'T&gt; -&gt; Set&lt;'U&gt;**|Returns a new collection containing the results of applying the given function to each element of the input set.|
|[maxElement](https://msdn.microsoft.com/library/95ff87fd-243e-41a4-b1f8-9d6d3a9c0ad6)<br />**: Set&lt;'T&gt; -&gt; 'T**|Returns the highest element in the set according to the ordering being used for the set.|
|[minElement](https://msdn.microsoft.com/library/2733d7c6-e170-40e3-8c68-a65864e17da4)<br />**: Set&lt;'T&gt; -&gt; 'T**|Returns the lowest element in the set according to the ordering being used for the set.|
|[ofArray](https://msdn.microsoft.com/library/10434aec-34c8-4101-9ec9-751533f8e3de)<br />**: 'T array -&gt; Set&lt;'T&gt;**|Creates a set that contains the same elements as the given array.|
|[ofList](https://msdn.microsoft.com/library/bc089500-969e-402f-9162-d0a23fdd5b58)<br />**: 'T list -&gt; Set&lt;'T&gt;**|Creates a set that contains the same elements as the given list.|
|[ofSeq](https://msdn.microsoft.com/library/5e8b5b4e-2d88-49bf-b74a-cf3ef553a888)<br />**: seq&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Creates a new collection from the given enumerable object.|
|[partition](https://msdn.microsoft.com/library/e5406822-361f-441b-ab6f-f22326b66320)<br />**: ('T -&gt; bool) -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt; &#42; Set&lt;'T&gt;**|Splits the set into two sets containing the elements for which the given predicate returns true and false respectively.|
|[remove](https://msdn.microsoft.com/library/812a6d19-c1f0-4c57-9cbe-15d141d64ddb)<br />**: 'T -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Returns a new set with the given element removed. No exception is raised if the set doesn't contain the given element.|
|[singleton](https://msdn.microsoft.com/library/10355cec-dab2-40d0-b044-ed928dbd646f)<br />**: 'T -&gt; Set&lt;'T&gt;**|The set containing the given element.|
|[toArray](https://msdn.microsoft.com/library/88500f7a-3568-4ee2-8ad1-49ad08e94e90)<br />**: Set&lt;'T&gt; -&gt; 'T array**|Creates an array that contains the elements of the set in order.|
|[toList](https://msdn.microsoft.com/library/32881ed4-7818-4ff3-afb1-f6f62489986c)<br />**: Set&lt;'T&gt; -&gt; 'T list**|Creates a list that contains the elements of the set in order.|
|[toSeq](https://msdn.microsoft.com/library/42338202-65da-4fc7-ad3f-101619e08f99)<br />**: Set&lt;'T&gt; -&gt; seq&lt;'T&gt;**|Returns an ordered view of the collection as an enumerable object.|
|[union](https://msdn.microsoft.com/library/9fd1499c-e4da-4ee2-8f21-67ae8e10a42d)<br />**: Set&lt;'T&gt; -&gt; Set&lt;'T&gt; -&gt; Set&lt;'T&gt;**|Computes the union of the two sets.|
|[unionMany](https://msdn.microsoft.com/library/0b4b238d-9393-4f23-8bed-7986a0177820)<br />**: seq&lt;Set&lt;'T&gt;&gt; -&gt; Set&lt;'T&gt;**|Computes the union of a sequence of sets.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)