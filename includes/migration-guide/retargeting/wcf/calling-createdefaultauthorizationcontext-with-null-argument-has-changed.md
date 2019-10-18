### Calling CreateDefaultAuthorizationContext with a null argument has changed

|   |   |
|---|---|
|Details|The implementation of the <xref:System.IdentityModel.Policy.AuthorizationContext?displayProperty=name> returned by a call to the <xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext(System.Collections.Generic.IList{System.IdentityModel.Policy.IAuthorizationPolicy})?displayProperty=name> with a null authorizationPolicies argument has changed its implementation in the .NET Framework 4.6.|
|Suggestion|In rare cases, WCF apps that use custom authentication may see behavioral differences. In such cases, the previous behavior can be restored in either of two ways:<ol><li>Recompile your app to target an earlier version of the .NET Framework than 4.6. For IIS-hosted services, use the &lt;httpRuntime targetFramework=&quot;x.x&quot; /&gt; element to target an earlier version of the .NET Framework.</li><li>Add the following line to the <code>&lt;appSettings&gt;</code> section of your app.config file: <code>&lt;add key=&quot;appContext.SetSwitch:Switch.System.IdentityModel.EnableCachedEmptyDefaultAuthorizationContext&quot; value=&quot;true&quot; /&gt;</code></li></ol>|
|Scope|Minor|
|Version|4.6|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext(System.Collections.Generic.IList{System.IdentityModel.Policy.IAuthorizationPolicy})?displayProperty=nameWithType></li></ul>|
