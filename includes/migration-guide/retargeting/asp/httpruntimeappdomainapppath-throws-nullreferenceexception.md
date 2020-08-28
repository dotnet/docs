### HttpRuntime.AppDomainAppPath Throws a NullReferenceException

#### Details

In the .NET Framework 4.6.2, the runtime throws a `T:System.NullReferenceException` when retrieving a `P:System.Web.HttpRuntime.AppDomainAppPath` value that includes null characters.In the .NET Framework 4.6.1 and earlier versions, the runtime throws an `T:System.ArgumentNullException`.

#### Suggestion

You can do either of the follow to respond to this change:

- Handle the `T:System.NullReferenceException` if you application is running on the .NET Framework 4.6.2.
- Upgrade to the .NET Framework 4.7, which restores the previous behavior and throws an `T:System.ArgumentNullException`.

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.6.2       |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Web.HttpRuntime.AppDomainAppPath?displayProperty=nameWithType>
