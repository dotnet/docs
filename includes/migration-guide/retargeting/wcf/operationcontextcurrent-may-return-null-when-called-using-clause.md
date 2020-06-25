### OperationContext.Current may return null when called in a using clause

#### Details

<xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType> may return `null` and a <xref:System.NullReferenceException> may result if all of the following conditions are true:

- You retrieve the value of the <xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType> property in a method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>.
- You instantiate the <xref:System.ServiceModel.OperationContextScope> object in a `using` clause.
- You retrieve the value of the <xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType> property within the `using statement`. For example:
<pre><code class="lang-csharp">using (new OperationContextScope(OperationContext.Current))&#13;&#10;{&#13;&#10;OperationContext context = OperationContext.Current;      // OperationContext.Current is null.&#13;&#10;// ...&#13;&#10;}&#13;&#10;`</pre>



#### Suggestion

To address this issue, you can do the following:

- Modify your code as follows to instantiate a new non- `null` <xref:System.ServiceModel.OperationContext.Current%2A> object:
<pre><code class="lang-csharp">OperationContext ocx = OperationContext.Current;&#13;&#10;using (new OperationContextScope(OperationContext.Current))&#13;&#10;{&#13;&#10;OperationContext.Current = new OperationContext(ocx.Channel);&#13;&#10;// ...&#13;&#10;}&#13;&#10;`</pre>

<ul><li>Install the latest update to the .NET Framework 4.6.2, or upgrade to a later version of the .NET Framework. This disables the flow of the <xref:System.Threading.ExecutionContext> in <xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType> and restores the behavior of WCF applications in the .NET Framework 4.6.1 and earlier versions. This behavior is configurable; it is equivalent to adding the following app setting to your configuration file:
<pre><code class="lang-xml">&lt;appSettings&gt;&#13;&#10;&lt;add key=&quot;Switch.System.ServiceModel.DisableOperationContextAsyncFlow&quot; value=&quot;true&quot; /&gt;&#13;&#10;&lt;/appSettings&gt;&#13;&#10;`</pre>

If this change is undesirable and your application depends on execution context flowing between operation contexts, you can enable its flow as follows:

<pre><code class="lang-xml">&lt;appSettings&gt;&#13;&#10;&lt;add key=&quot;Switch.System.ServiceModel.DisableOperationContextAsyncFlow&quot; value=&quot;false&quot; /&gt;&#13;&#10;&lt;/appSettings&gt;&#13;&#10;`</pre>



| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.6.2       |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.ServiceModel.OperationContext.Current?displayProperty=fullNameWithType>

