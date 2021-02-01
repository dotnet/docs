### ConcurrentQueue&lt;T&gt;.TryPeek can return an erroneous null via its out parameter

#### Details

In some multi-threaded scenarios, <xref:System.Collections.Concurrent.ConcurrentQueue%601.TryPeek(%600@)?displayProperty=fullName> can return true, but populate the out parameter with a null value (instead of the correct, peeked value).

#### Suggestion

This issue is fixed in the .NET Framework 4.5.1. Upgrading to that Framework will solve the issue.

| Name    | Value       |
|:--------|:------------|
| Scope   |Major|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

- <xref:System.Collections.Concurrent.ConcurrentQueue%601.TryPeek(%600@)?displayProperty=nameWithType>

<!--

#### Affected APIs

- ``M:System.Collections.Concurrent.ConcurrentQueue`1.TryPeek(`0@)``

-->
