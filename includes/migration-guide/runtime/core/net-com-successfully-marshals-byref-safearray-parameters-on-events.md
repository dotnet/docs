### .NET COM successfully marshals ByRef SafeArray parameters on events

#### Details

In .NET Framework 4.7.2 and earlier versions, a ByRef [SafeArray](/windows/desktop/api/oaidl/ns-oaidl-safearray) parameter on a COM event would fail to marshal back to native code. With this change, the [SafeArray](/windows/desktop/api/oaidl/ns-oaidl-safearray) is now marshalled successfully.

- [ x ] Quirked

#### Suggestion

If properly marshalling ByRef SafeArray parameters on COM Events breaks execution, you can disable this code by adding the following configuration switch to your application config:

```xml
<appSettings>
  <add key="Switch.System.Runtime.InteropServices.DoNotMarshalOutByrefSafeArrayOnInvoke" value="true" />
</appSettings>
```

| Name    | Value   |
| :------ | :------ |
| Scope   | Minor   |
| Version | 4.8     |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
