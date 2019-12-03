### ASP.NET ValidationContext.MemberName is not NULL when using custom DataAnnotations.ValidationAttribute

|   |   |
|---|---|
|Details|In .NET Framework 4.7.2 and earlier versions, when using a custom <xref:System.ComponentModel.DataAnnotations.ValidationAttribute?displayProperty=nameWithType>, the <xref:System.ComponentModel.DataAnnotations.ValidationContext.MemberName?displayProperty=nameWithType> property returns <code>null</code>.  In .NET Framework 4.8, it returns the member name.|
|Suggestion|To restore the previous behavior, add the following setting to your app config file:<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;appSettings&gt;&#13;&#10;...&#13;&#10;&lt;add key=&quot;aspnet:GetValidationMemberName&quot;  value=&quot;true&quot;/&gt;&#13;&#10;...&#13;&#10;&lt;/appSettings&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>This behavior will change in an upcoming service release, when you will have to explicitly opt in to the new behavior. The property will return a non-null value for a custom `ValidationAttribute` if the `aspnet:GetValidationMemberName` switch is set to `true`.|
|Scope|Unknown|
|Version|4.8|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.ComponentModel.DataAnnotations.ValidationContext.MemberName?displayProperty=nameWithType></li></ul>|
