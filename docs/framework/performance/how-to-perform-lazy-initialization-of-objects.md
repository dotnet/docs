---
title: "How to: Perform Lazy Initialization of Objects"
description: See how to perform lazy initialization of objects using the System.Lazy<T> class. Lazy initialization means objects aren't created if they're never needed.
ms.date: 07/25/2025
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "lazy initialization in .NET, how to perform"
---
# How to: Perform lazy initialization of objects

The <xref:System.Lazy%601?displayProperty=nameWithType> class simplifies the work of performing lazy initialization and instantiation of objects. By initializing objects in a lazy manner, you can avoid having to create them at all if they're never needed, or you can postpone their initialization until they are first accessed. For more information, see [Lazy initialization](lazy-initialization.md).

## Example 1

 The following example shows how to initialize a value with <xref:System.Lazy%601>. Assume that the lazy variable might not be needed, depending on some other code that sets the `someCondition` variable to `true` or `false`.

```vb
Dim someCondition As Boolean = False

Sub Main()
    'Initialize a value with a big computation, computed in parallel.
    Dim _data As Lazy(Of Integer) = New Lazy(Of Integer)(Function()
                                                             Dim result =
                                                                 ParallelEnumerable.Range(0, 1000).
                                                                 Aggregate(Function(x, y)
                                                                               Return x + y
                                                                           End Function)
                                                             Return result
                                                         End Function)

    '  Do work that might or might not set someCondition to True...

    '  Initialize the data only if needed.
    If someCondition = True Then
        If (_data.Value > 100) Then
            Console.WriteLine("Good data")
        End If
    End If
End Sub
```

```csharp
  static bool someCondition = false;
  // Initialize a value with a big computation, computed in parallel.
  Lazy<int> _data = new Lazy<int>(delegate
  {
      return ParallelEnumerable.Range(0, 1000).
          Select(i => Compute(i)).Aggregate((x,y) => x + y);
  }, LazyThreadSafetyMode.ExecutionAndPublication);

  // Do some work that might or might not set someCondition to true...

  // Initialize the data only if necessary.
  if (someCondition)
  {
      if (_data.Value > 100)
      {
          Console.WriteLine("Good data");
      }
  }
```

## Example 2

The following example shows how to use the <xref:System.Threading.ThreadLocal%601?displayProperty=nameWithType> class to initialize a type that is visible only to the current object instance on the current thread.

[!code-csharp[CDS#13](../../../samples/snippets/csharp/VS_Snippets_Misc/cds/cs/cds2.cs#13)]
[!code-vb[CDS#13](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds/vb/lazyhowto.vb#13)]

## See also

- <xref:System.Threading.LazyInitializer?displayProperty=nameWithType>
- [Lazy Initialization](lazy-initialization.md)
