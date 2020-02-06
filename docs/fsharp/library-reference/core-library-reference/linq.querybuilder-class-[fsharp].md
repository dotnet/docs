---
title: Linq.QueryBuilder Class (F#)
description: Linq.QueryBuilder Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0b39a0a2-d3bf-4db0-a96b-58b109156eec 
---

# Linq.QueryBuilder Class (F#)

The type used to support the F# query syntax.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type QueryBuilder =
class
new QueryBuilder : unit -> QueryBuilder
member this.All : QuerySource<'T,'Q> * ('T -> bool) -> bool
member this.AverageBy : QuerySource<'T,'Q> * ('T -> ^Value) -> ^Value
member this.AverageByNullable : QuerySource<'T,'Q> * ('T -> Nullable<^Value>) -> Nullable<^Value>
member this.Contains : QuerySource<'T,'Q> * 'T -> bool
member this.Count : QuerySource<'T,'Q> -> int
member this.Distinct : QuerySource<'T,'Q> -> QuerySource<'T,'Q>
member this.ExactlyOne : QuerySource<'T,'Q> -> 'T
member this.ExactlyOneOrDefault : QuerySource<'T,'Q> -> 'T
member this.Exists : QuerySource<'T,'Q> * ('T -> bool) -> bool
member this.Find : QuerySource<'T,'Q> * ('T -> bool) -> 'T
member this.For : QuerySource<'T,'Q> * ('T -> QuerySource<'Result,'Q2>) -> QuerySource<'Result,'Q>
member this.GroupBy : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<IGrouping<'Key,'T>,'Q>
member this.GroupJoin : QuerySource<'Outer,'Q> * QuerySource<'Inner,'Q> * ('Outer -> 'Key) * ('Inner -> 'Key) * ('Outer -> seq<'Inner> -> 'Result) -> QuerySource<'Result,'Q>
member this.GroupValBy : QuerySource<'T,'Q> * ('T -> 'Value) * ('T -> 'Key) -> QuerySource<IGrouping<'Key,'Value>,'Q>
member this.Head : QuerySource<'T,'Q> -> 'T
member this.HeadOrDefault : QuerySource<'T,'Q> -> 'T
member this.Join : QuerySource<'Outer,'Q> * QuerySource<'Inner,'Q> * ('Outer -> 'Key) * ('Inner -> 'Key) * ('Outer -> 'Inner -> 'Result) -> QuerySource<'Result,'Q>
member this.Last : QuerySource<'T,'Q> -> 'T
member this.LastOrDefault : QuerySource<'T,'Q> -> 'T
member this.LeftOuterJoin : QuerySource<'Outer,'Q> * QuerySource<'Inner,'Q> * ('Outer -> 'Key) * ('Inner -> 'Key) * ('Outer -> seq<'Inner> -> 'Result) -> QuerySource<'Result,'Q>
member this.MaxBy : QuerySource<'T,'Q> * ('T -> 'Value) -> 'Value
member this.MaxByNullable : QuerySource<'T,'Q> * ('T -> Nullable<'Value>) -> Nullable<'Value>
member this.MinBy : QuerySource<'T,'Q> * ('T -> 'Value) -> 'Value
member this.MinByNullable : QuerySource<'T,'Q> * ('T -> Nullable<'Value>) -> Nullable<'Value>
member this.Nth : QuerySource<'T,'Q> * int -> 'T
member this.Quote : Expr<'T> -> Expr<'T>
member this.Run : Expr<QuerySource<'T,IQueryable>> -> IQueryable<'T>
member this.Select : QuerySource<'T,'Q> * ('T -> 'Result) -> QuerySource<'Result,'Q>
member this.Skip : QuerySource<'T,'Q> * int -> QuerySource<'T,'Q>
member this.SkipWhile : QuerySource<'T,'Q> * ('T -> bool) -> QuerySource<'T,'Q>
member this.SortBy : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<'T,'Q>
member this.SortByDescending : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<'T,'Q>
member this.SortByNullable : QuerySource<'T,'Q> * ('T -> Nullable<'Key>) -> QuerySource<'T,'Q>
member this.SortByNullableDescending : QuerySource<'T,'Q> * ('T -> Nullable<'Key>) -> QuerySource<'T,'Q>
member this.Source : IEnumerable<'T> -> QuerySource<'T,IEnumerable>
member this.Source : IQueryable<'T> -> QuerySource<'T,'Q>
member this.SumBy : QuerySource<'T,'Q> * ('T -> ^Value) -> ^Value
member this.SumByNullable : QuerySource<'T,'Q> * ('T -> Nullable<^Value>) -> Nullable<^Value>
member this.Take : QuerySource<'T,'Q> * int -> QuerySource<'T,'Q>
member this.TakeWhile : QuerySource<'T,'Q> * ('T -> bool) -> QuerySource<'T,'Q>
member this.ThenBy : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<'T,'Q>
member this.ThenByDescending : QuerySource<'T,'Q> * ('T -> 'Key) -> QuerySource<'T,'Q>
member this.ThenByNullable : QuerySource<'T,'Q> * ('T -> Nullable<'Key>) -> QuerySource<'T,'Q>
member this.ThenByNullableDescending : QuerySource<'T,'Q> * ('T -> Nullable<'Key>) -> QuerySource<'T,'Q>
member this.Where : QuerySource<'T,'Q> * ('T -> bool) -> QuerySource<'T,'Q>
member this.Yield : 'T -> QuerySource<'T,'Q>
member this.YieldFrom : QuerySource<'T,'Q> -> QuerySource<'T,'Q>
member this.Zero : unit -> QuerySource<'T,'Q>
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/8cf5ab08-a0ea-43d2-8207-511e4204283d)|Create an instance of this builder.|

## Instance Members


|Member|Description|
|------|-----------|
|[All](https://msdn.microsoft.com/library/a8d98783-4121-40c9-82d7-3e5ac50b1d09): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|A query operator that determines whether all elements selected so far satisfy a condition.|
|[AverageBy](https://msdn.microsoft.com/library/8fc50dd7-0351-4a1c-a935-f97be6ede471): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; ^Value) -&gt; ^Value|A query operator that selects a value for each element selected so far and returns the average of these values.|
|[AverageByNullable](https://msdn.microsoft.com/library/eeba3a2d-5bcb-4785-ac44-2e53e3f4b8b3): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;^Value&gt;) -&gt; **System.Nullable&#96;1**&lt;^Value&gt;|A query operator that selects a nullable value for each element selected so far and returns the average of these values. If any nullable does not have a value, it is ignored.|
|[Contains](https://msdn.microsoft.com/library/bd79b737-4390-48f5-b828-68db728ad884): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; 'T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|A query operator that determines whether the selected elements contain a specified element.|
|[Count](https://msdn.microsoft.com/library/06d61195-7013-4ad9-8b46-fae239be7632): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)|A query operator that returns the number of selected elements.|
|[Distinct](https://msdn.microsoft.com/library/7aebf91a-bea2-4cf6-bdc9-5317e64c37fe): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that selects distinct elements from the elements selected so far.|
|[ExactlyOne](https://msdn.microsoft.com/library/821ec03c-537f-494f-a468-ab0f3910b0ae): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the single, specific element selected so far.|
|[ExactlyOneOrDefault](https://msdn.microsoft.com/library/e51cfccf-1f20-4fe9-bb11-45d53ceb8321): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the single, specific element of those selected so far, or a default value if that element is not found.|
|[Exists](https://msdn.microsoft.com/library/74c6c4f6-c92c-4c4a-b5b7-188e5491c858): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|A query operator that determines whether any element selected so far satisfies a condition.|
|[Find](https://msdn.microsoft.com/library/8add5f31-9ca9-4f3e-8bcb-06d117015779): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)QuerySource&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; 'T|A query operator that selects the first element selected so far that satisfies a specified condition.|
|[For](https://msdn.microsoft.com/library/8f8ca87c-5648-476b-a540-af94aba2c0ca): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q2&gt;) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q&gt;|A method used to support the F# query syntax. Projects each element of a sequence to another sequence and combines the resulting sequences into one sequence.|
|[GroupBy](https://msdn.microsoft.com/library/1f3eeef6-c5f8-4942-87cd-94d7db5d6e99): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;**System.Linq.IGrouping&#96;2**&lt;'Key,'T&gt;,'Q&gt;|A query operator that groups the elements selected so far according to a specified key selector.|
|[GroupJoin](https://msdn.microsoft.com/library/a0a6c3b9-65fb-4bc6-bf05-c53ab4c6604f): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Outer,'Q&gt; &#42; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Inner,'Q&gt; &#42; ('Outer -&gt; 'Key) &#42; ('Inner -&gt; 'Key) &#42; ('Outer -&gt; seq&lt;'Inner&gt; -&gt; 'Result) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q&gt;|A query operator that correlates two sets of selected values based on matching keys and groups the results. Normal usage is **groupJoin (for y in elements2 -&gt; key1 = key2) into group**.|
|[GroupValBy](https://msdn.microsoft.com/library/9d95eca7-906f-4369-93a7-bb8dbbd8ae87): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Value) &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;**System.Linq.IGrouping&#96;2**&lt;'Key,'Value&gt;,'Q&gt;|A query operator that selects a value for each element selected so far and groups the elements by the given key.|
|[Head](https://msdn.microsoft.com/library/2e552c64-3e90-41af-bdc9-55876b60ee11): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the first element from those selected so far.|
|[HeadOrDefault](https://msdn.microsoft.com/library/e71dc2f9-5acd-4b00-a305-453cb838f1f8): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the first element of those selected so far, or a default value if the sequence contains no elements.|
|[Join](https://msdn.microsoft.com/library/4718e1d1-a70c-40bd-a690-b187b4849583): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Outer,'Q&gt; &#42; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Inner,'Q&gt; &#42; ('Outer -&gt; 'Key) &#42; ('Inner -&gt; 'Key) &#42; ('Outer -&gt; 'Inner -&gt; 'Result) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q&gt;|A query operator that correlates two sets of selected values based on matching keys. Normal usage is **join (for y in elements2 -&gt; key1 = key2)**.|
|[Last](https://msdn.microsoft.com/library/bb3e1243-1369-4b44-8490-df8a20803dd6): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the last element of those selected so far.|
|[LastOrDefault](https://msdn.microsoft.com/library/67cce080-1b2b-49ee-94bc-3f18b085daed): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; 'T|A query operator that selects the last element of those selected so far, or a default value if no element is found.|
|[LeftOuterJoin](https://msdn.microsoft.com/library/bd5c4e49-f1e8-45c0-8d26-04c2173e0204): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Outer,'Q&gt; &#42; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Inner,'Q&gt; &#42; ('Outer -&gt; 'Key) &#42; ('Inner -&gt; 'Key) &#42; ('Outer -&gt; seq&lt;'Inner&gt; -&gt; 'Result) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q&gt;|A query operator that correlates two sets of selected values based on matching keys and groups the results. If any group is empty, a group with a single default value is used instead. Normal usage is **leftOuterJoin (for y in elements2 -&gt; key1 = key2) into group**.|
|[MaxBy](https://msdn.microsoft.com/library/a4c11a06-592d-4b9c-b8d5-284c93189dfe): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Value) -&gt; 'Value|A query operator that selects a value for each element selected so far and returns the maximum resulting value.|
|[MaxByNullable](https://msdn.microsoft.com/library/b561d7ff-be4e-46dd-99c6-6f69008f2b74): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Value&gt;) -&gt; **System.Nullable&#96;1**&lt;'Value&gt;|A query operator that selects a nullable value for each element selected so far and returns the maximum of these values. If any nullable does not have a value, it is ignored.|
|[MinBy](https://msdn.microsoft.com/library/a43dd6d0-dc3a-4488-96b3-281f9f565d57): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Value) -&gt; 'Value|A query operator that selects a value for each element selected so far and returns the minimum resulting value.|
|[MinByNullable](https://msdn.microsoft.com/library/8d790531-3401-4454-a701-45752652bcb9): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Value&gt;) -&gt; **System.Nullable&#96;1**&lt;'Value&gt;|A query operator that selects a nullable value for each element selected so far and returns the minimum of these values. If any nullable does not have a value, it is ignored.|
|[Nth](https://msdn.microsoft.com/library/87fb29d1-46ed-4dbc-8027-c19e1cc9d80e): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375) -&gt; 'T|A query operator that selects the element at a specified index among those selected so far.|
|[Quote](https://msdn.microsoft.com/library/0e0e0a24-8646-41b7-93f0-7fdc13ed0875): Expr&lt;'T&gt; -&gt; Expr&lt;'T&gt;|A method used to support the F# query syntax. Indicates that the query should be passed as a quotation to the Run method.|
|[Run](https://msdn.microsoft.com/library/33bbcef1-2a4a-45cb-9105-01aa0082cfc9): Expr&lt;[QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,IQueryable&gt;&gt; -&gt;**System.Linq.IQueryable&#96;1**&lt;'T&gt;|A method used to support the F# query syntax. Runs the given quotation as a query using LINQ IQueryable rules.|
|[Select](https://msdn.microsoft.com/library/5b26a6ed-0975-403a-9bca-34cd448ecc8f): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Result) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'Result,'Q&gt;|A query operator that projects each of the elements selected so far.|
|[Skip](https://msdn.microsoft.com/library/f4f212fb-9f35-4398-84ce-95f12e0b6687): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that bypasses a specified number of the elements selected so far and selects the remaining elements.|
|[SkipWhile](https://msdn.microsoft.com/library/614605f7-7282-44f5-ac23-190a24f34fb2): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that bypasses elements in a sequence as long as a specified condition is true and then selects the remaining elements.|
|[SortBy](https://msdn.microsoft.com/library/edbaae82-a4bf-4487-b247-de2fbf2e5ba8): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that sorts the elements selected so far in ascending order by the given sorting key.|
|[SortByDescending](https://msdn.microsoft.com/library/146a9bec-6e0c-47c6-b570-eada6f3cf399): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that sorts the elements selected so far in descending order by the given sorting key.|
|[SortByNullable](https://msdn.microsoft.com/library/5e804c59-b88a-48f0-9ccd-f9a61019ced3): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Key&gt;) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that sorts the elements selected so far in ascending order by the given nullable sorting key.|
|[SortByNullableDescending](https://msdn.microsoft.com/library/085b8f79-1d9e-4af4-bd70-d61a2c2c2b4b): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Key&gt;) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that sorts the elements selected so far in descending order by the given nullable sorting key.|
|[Source](https://msdn.microsoft.com/library/bb702f3f-5f53-4aa0-bd3b-69579fb479ce): **System.Collections.Generic.IEnumerable&#96;1**&lt;'T&gt; -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,IEnumerable&gt;|A method used to support the F# query syntax. Inputs to queries are implicitly wrapped by a call to one of the overloads of this method.|
|[Source](https://msdn.microsoft.com/library/5e0a1fed-f583-4d24-9921-765018ec926e): **System.Linq.IQueryable&#96;1**&lt;'T&gt; -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A method used to support the F# query syntax. Inputs to queries are implicitly wrapped by a call to one of the overloads of this method.|
|[SumBy](https://msdn.microsoft.com/library/96cbc51e-55e2-4ab4-bc8f-51edc5ac23eb): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; ^Value) -&gt; ^Value|A query operator that selects a value for each element selected so far and returns the sum of these values.|
|[SumByNullable](https://msdn.microsoft.com/library/77cd4b85-cc4d-49d3-b84f-15bc1bc97d15): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;^Value&gt;) -&gt; **System.Nullable&#96;1**&lt;^Value&gt;|A query operator that selects a nullable value for each element selected so far and returns the sum of these values. If any nullable does not have a value, it is ignored.|
|[Take](https://msdn.microsoft.com/library/f047ed67-560c-4cda-9b51-70746710040e): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that selects a specified number of contiguous elements from those selected so far.|
|[TakeWhile](https://msdn.microsoft.com/library/3f08e7c3-ea4b-44d4-a5d9-10c2d8e46032): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that selects elements from a sequence as long as a specified condition is true, and then skips the remaining elements.|
|[ThenBy](https://msdn.microsoft.com/library/9adf72a5-cff5-4a18-9d35-626d11e8ae03): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that performs a subsequent ordering of the elements selected so far in ascending order by the given sorting key. This operator may only be used immediately after a **sortBy**, **sortByDescending**, **thenBy** or **thenByDescending**, or their nullable variants.|
|[ThenByDescending](https://msdn.microsoft.com/library/75f16aa1-184b-4d6c-a880-0ce852e12a27): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; 'Key) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that performs a subsequent ordering of the elements selected so far in descending order by the given sorting key. This operator may only be used immediately after a **sortBy**, **sortByDescending**, **thenBy** or **thenByDescending**, or their nullable variants.|
|[ThenByNullable](https://msdn.microsoft.com/library/84abbc26-7979-4106-9f40-84f98885de31): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Key&gt;) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that performs a subsequent ordering of the elements selected so far in ascending order by the given nullable sorting key. This operator may only be used immediately after a **sortBy**, **sortByDescending**, **thenBy** or **thenByDescending**, or their nullable variants.|
|[ThenByNullableDescending](https://msdn.microsoft.com/library/d0635d53-71f0-4071-a955-5222f7967401): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; **System.Nullable&#96;1**&lt;'Key&gt;) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that performs a subsequent ordering of the elements selected so far in descending order by the given nullable sorting key. This operator may only be used immediately after a **sortBy**, **sortByDescending**, **thenBy** or **thenByDescending**, or their nullable variants.|
|[Where](https://msdn.microsoft.com/library/2bf64a26-135f-4340-863a-d0f142c6ad45): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; &#42; ('T -&gt; [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)) -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A query operator that selects those elements based on a specified predicate.|
|[Yield](https://msdn.microsoft.com/library/6634a987-e56a-486a-8d0a-b1d3218f16ff): 'T -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A method used to support the F# query syntax. Returns a sequence of length one that contains the specified value.|
|[YieldFrom](https://msdn.microsoft.com/library/3b356180-969c-4901-8253-aac77731f1ac): [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt; -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A method used to support the F# query syntax. Returns a sequence that contains the specified values.|
|[Zero](https://msdn.microsoft.com/library/f7724401-70a6-4767-a801-94b3d27ff349): unit -&gt; [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)&lt;'T,'Q&gt;|A method used to support the F# query syntax. Returns an empty sequence that has the specified type argument.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)