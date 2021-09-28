### Managed browser hosting controls from the .NET Framework 1.1 and 2.0 are blocked

#### Details

Hosting these controls is blocked in Internet Explorer.

#### Suggestion

Internet Explorer will fail to launch an application that uses managed browser hosting controls. The previous behavior can be restored by setting the EnableIEHosting value of the registry subkey `HKLM/SOFTWARE/MICROSOFT/.NETFramework` to `1` for x86 systems and for 32-bit processes on x64 systems, and by setting the `EnableIEHosting` value of the registry subkey `HKLM/SOFTWARE/Wow6432Node/Microsoft/.NETFramework` to `1` for 64-bit processes on x64 systems.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
