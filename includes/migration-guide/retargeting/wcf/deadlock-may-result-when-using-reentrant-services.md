### Deadlock may result when using Reentrant services

#### Details

A deadlock may result in a Reentrant service, which restricts instances of the service to one thread of execution at a time. Services prone to encounter this problem will have the following <xref:System.ServiceModel.ServiceBehaviorAttribute> in their code:

<pre><code class="lang-csharp">[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]&#13;&#10;`</pre>



#### Suggestion

To address this issue, you can do the following:

- Set the service's concurrency mode to <xref:System.ServiceModel.ConcurrencyMode.Single?displayProperty=fullNameWithType> or &lt;System.ServiceModel.ConcurrencyMode.Multiple?displayProperty=fullNameWithType&gt;. For example:
<pre><code class="lang-csharp">[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]&#13;&#10;`</pre>

<ul><li>Install the latest update to the .NET Framework 4.6.2, or upgrade to a later version of the .NET Framework. This disables the flow of the <xref:System.Threading.ExecutionContext> in <xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType>. This behavior is configurable; it is equivalent to adding the following app setting to your configuration file:
<pre><code class="lang-xml">&lt;appSettings&gt;&#13;&#10;&lt;add key=&quot;Switch.System.ServiceModel.DisableOperationContextAsyncFlow&quot; value=&quot;true&quot; /&gt;&#13;&#10;&lt;/appSettings&gt;&#13;&#10;`</pre>

The value of `Switch.System.ServiceModel.DisableOperationContextAsyncFlow` should never be set to `false` for Rentrant services.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6.2       |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.ServiceModel.ServiceBehaviorAttribute?displayProperty=fullNameWithType>
- <xref:System.ServiceModel.ConcurrencyMode.Reentrant?displayProperty=fullNameWithType>

