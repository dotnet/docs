---
title: ".NET 8 breaking change: Enumerable.Sum throws new OverflowException for some inputs"
description: Learn about the .NET 8 breaking change in core .NET libraries where Enumerable.Sum can throw new OverflowException exceptions for certain inputs.
ms.date: 11/08/2023
---
# Enumerable.Sum throws new OverflowException for some inputs

.NET 8 adds support for vectorization in the <xref:System.Linq.Enumerable.Sum%2A?displayProperty=nameWithType> methods where applicable. As a side-effect of that change, the vectorized implementation can change the order in which the different elements are added. While this shouldn't change the final result in successful runs, it can result in unexpected <xref:System.OverflowException> exceptions for certain sets of pathological inputs.

## Previous behavior

Consider the following code:

```csharp
Test(GetEnumerable1());           // Non-vectorizable
Test(GetEnumerable1().ToArray()); // Vectorizable
Test(GetEnumerable2());           // Non-vectorizable
Test(GetEnumerable2().ToArray()); // Vectorizable

static IEnumerable<int> GetEnumerable1()
{
    for (int i = 0; i < 32; ++i)
    {
        yield return 1_000_000_000;
        yield return -1_000_000_000;
    }
}

static IEnumerable<int> GetEnumerable2()
{
    for (int i = 0; i < 32; ++i)
    {
        yield return 100_000_000;
    }
    for (int i = 0; i < 32; ++i)
    {
        yield return -100_000_000;
    }
}

static void Test(IEnumerable<int> input)
{
    try
    {
        Console.WriteLine(input.Sum());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.GetType().Name);
    }
}
```

Prior to this change, the preceding code printed the following output:

```txt
0
0
OverflowException
OverflowException
```

## New behavior

Starting in .NET 8, the code snippet from the [Previous behavior](#previous-behavior) section prints the following output:

```txt
0
OverflowException
OverflowException
0
```

## Version introduced

.NET 8 Preview 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to take advantage of vectorization in LINQ APIs.

## Recommended action

If your code is impacted by the change, you can either:

- Disable vectorization altogether in your application by setting the `DOTNET_EnableHWIntrinsic` environment variable to 0.
- Write a custom `Sum` method that doesn't use vectorization:

  ```csharp
  static int Sum(IEnumerable<int> values)
  {
      int acc = 0;
      foreach (int value in values)
      {
          checked { acc += value; }
      }
      return acc;
  }
  ```

## Affected APIs

- <xref:System.Linq.Enumerable.Sum%2A?displayProperty=fullName>
