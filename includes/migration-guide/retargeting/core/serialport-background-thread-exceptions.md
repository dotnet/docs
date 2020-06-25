### SerialPort background thread exceptions

#### Details

Background threads created with <xref:System.IO.Ports.SerialPort> streams no longer terminate the process when OS exceptions are thrown. <br/>In applications that target the .NET Framework 4.7 and earlier versions, a process is terminated when an operating system exception is thrown on a background thread created with a <xref:System.IO.Ports.SerialPort> stream. <br/>In applications that target the .NET Framework 4.7.1 or a later version, background threads wait for OS events related to the active serial port and could crash in some cases, such as sudden removal of the serial port.

#### Suggestion

For apps that target the .NET Framework 4.7.1, you can opt out of the exception handling if it is not desirable by adding the following to the `<runtime>` section of your `app.config` file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.IO.Ports.DoNotCatchSerialStreamThreadExceptions=true" />
</runtime>
```

For apps that target earlier versions of the .NET Framework but run on the .NET Framework 4.7.1 or later, you can opt in to the exception handling by adding the following to the `<runtime>` section of your `app.config` file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.IO.Ports.DoNotCatchSerialStreamThreadExceptions=false" />
</runtime>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.7.1       |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.IO.Ports.SerialPort?displayProperty=nameWithType>
