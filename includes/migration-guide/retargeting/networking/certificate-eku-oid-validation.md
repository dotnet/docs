### Certificate EKU OID validation

#### Details

Starting with .NET Framework 4.6, the <xref:System.Net.Security.SslStream> or <xref:System.Net.ServicePointManager> classes perform enhanced key use (EKU) object identifier (OID) validation. An enhanced key usage (EKU) extension is a collection of object identifiers (OIDs) that indicate the applications that use the key. EKU OID validation uses remote certificate callbacks to ensure that the remote certificate has the correct OIDs for the intended purpose.

#### Suggestion

If this change is undesirable, you can disable certificate EKU OID validation by adding the following switch to the [\<AppContextSwitchOverrides>](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) in the [`](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) of your app configuration file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Net.DontCheckCertificateEKUs=true" />
</runtime>
```

> [!IMPORTANT]
> This setting is provided for backward compatibility only. Its use is otherwise not recommended.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Net.Security.SslStream?displayProperty=nameWithType>
- <xref:System.Net.ServicePointManager?displayProperty=nameWithType>
- <xref:System.Net.Http.HttpClient?displayProperty=nameWithType>
- <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>
- <xref:System.Net.HttpWebRequest?displayProperty=nameWithType>
- <xref:System.Net.FtpWebRequest?displayProperty=nameWithType>
