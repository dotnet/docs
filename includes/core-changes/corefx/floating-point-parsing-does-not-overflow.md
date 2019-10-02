### Floating-point parsing operations no longer throw fail or throw an OverflowException

The floating-point parsing methods no longer throw an <xref:System.OverflowException> or return `false` when they parse a string whose numeric value is outside the range of the <xref:System.Single> or <xref:System.Double> floating point type.

#### Change description

In .NET Core 2.2 and earlier versions, the <xref:System.Double.Parse%2A?displayProperty=nameWithType> and <xref:System.Single.Parse%2A?displayProperty=nameWithType> methods throw an <xref:System.OverflowException> for values that outside the range of their respective type. The <xref:System.Double.TryParse%2A?displayProperty=nameWithType> and <xref:System.Single.TryParse%2A?displayProperty=nameWithType> methods return `false` for the string representations of out-of-range numeric values.

Starting with .NET Core 3.0, a

This change was made for better IEEE 754:2008 compliance. 

#### Version introduced

3.0

#### Recommended action

This change can affect your code in either of two ways:

- Your code depends on the handler for the <xref:System.OverflowException> to execute when an overflow occurs. In this case, you should remove the `catch` statement and place any necessary code in an `If` statement that tests whether <xref:System.Double.IsInfinity?displayProperty=nameWithType> or <xref:System.Single.IsInfinity?displayProperty=nameWithType> is `true`.

- Your code assumes that floating-point values are not `Infinity`. In this case, you should add the necessary code to check for floating-point values of `PositiveInfinity` and `NegativeInfinity`.

#### Category

CoreFx

#### Affected APIs

- <xref:System.Double.Parse%2A?displayProperty=nameWithType>
- <xref:System.Double.TryParse%2A?displayProperty=nameWithType>
- <xref:System.Single.Parse%2A?displayProperty=nameWithType>
- <xref:System.Single.TryParse%2A?displayProperty=nameWithType>

<!--

### Affected APIs

- `Overload:System.Double.Parse`
- `Overload:System.Double.TryParse`
- `Overload:System.Single.Parse`
- `Overload:System.Single.TryParse`

-->
