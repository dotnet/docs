### HttpRequest.ContentEncoding property prohibits UTF7

#### Details

Beginning in .NET Framework 4.5, UTF-7 encoding is prohibited in <xref:System.Web.HttpRequest?displayProperty=fullName>s' bodies. Data for applications that depend on incoming UTF-7 data will not decode properly in some cases.

#### Suggestion

Ideally, applications should be updated to not use UTF-7 encoding in <xref:System.Web.HttpRequest?displayProperty=fullName>s. Alternatively, legacy behavior can be restored by using the `aspnet:AllowUtf7RequestContentEncoding` attribute of the [appSettings](~/docs/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration.md) element.

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

- <xref:System.Web.HttpRequest.ContentEncoding?displayProperty=nameWithType>

<!--

#### Affected APIs

- `P:System.Web.HttpRequest.ContentEncoding`

-->
