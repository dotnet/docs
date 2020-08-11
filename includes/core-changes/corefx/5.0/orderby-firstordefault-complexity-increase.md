### Complexity of LINQ OrderBy increased

The implementation of <xref:System.Linq.Enumerable.OrderBy%2A> has changed, resulting in an increased complexity.

#### Change description

In .NET Core 1.x - 3.x, `OrderBy().First()` and `OrderBy().FirstOrDefault()` operate with `O(N)` complexity. Since only the first (or default) element is required, only one enumeration is required to find it. However, the supplied predicate is invoked exactly `N` times, where `N` is the length of the sequence.

In .NET 5.0 and later versions, a [change was made](https://github.com/dotnet/runtime/pull/36643) such that `OrderBy().First()` and `OrderBy().FirstOrDefault()` operate with `O(N log N)` complexity. However, the predicate may be invoked less than `N` times, which is more important for overall performance.

> [!NOTE]
> This change matches the implementation and complexity of the operation in .NET Framework.

#### Reason for change

The benefit of invoking the predicate fewer times outweighs a lower overall complexity, so the implementation that was introduced in .NET Core 1.0 was reverted.

#### Version introduced

5.0

#### Recommended action

No action is required.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Linq.Enumerable.OrderBy%2A?displayProperty=fullName>

<!--

#### Affected APIs

- `Overload:System.Linq.Enumerable.OrderBy`

-->
