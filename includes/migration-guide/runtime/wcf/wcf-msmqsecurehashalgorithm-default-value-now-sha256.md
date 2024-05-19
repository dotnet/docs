### WCF MsmqSecureHashAlgorithm default value is now SHA256

#### Details

Starting with the .NET Framework 4.7.1, the default message signing algorithm in WCF for Msmq messages is SHA256. In the .NET Framework 4.7 and earlier versions, the default message signing algorithm is SHA1.

#### Suggestion

If you run into compatibility issues with this change on the .NET Framework 4.7.1 or later, you can opt-out the change by adding the following line to the `<runtime>` section of your app.config file:

```xml
<configuration>
  <runtime>
    <AppContextSwitchOverrides value="Switch.System.ServiceModel.UseSha1InMsmqEncryptionAlgorithm=true" />
  </runtime>
</configuration>
```

| Name    | Value   |
|:--------|:--------|
| Scope   | Minor   |
| Version | 4.7.1   |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
