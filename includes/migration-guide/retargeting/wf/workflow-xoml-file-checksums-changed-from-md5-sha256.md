### Workflow XOML file checksums changed from MD5 to SHA256

#### Details

To support debugging XOML-based workflows with Visual Studio, when workflow projects containing XOML files build, a checksum of the contents of the XOML file is included in the code generated as a <xref:System.Workflow.ComponentModel.Compiler.WorkflowMarkupSourceAttribute.MD5Digest?displayProperty=nameWithType> value. In the .NET Framework 4.7.2 and earlier versions, this checksum hashing used the MD5 algorithm, which caused issues on FIPS-enabled systems. Starting with the .NET Framework 4.8, the algorithm used is SHA256. To be compatible with the WorkflowMarkupSourceAttribute.MD5Digest, only the first 16 bytes of the generated checksum are used.This may cause problems during debugging. You may need to re-build your project.

#### Suggestion

If re-building your project does not solve the problem, try setting the `AppContext` switch &quot;Switch.System.Workflow.ComponentModel.UseLegacyHashForXomlFileChecksum&quot; to true.In code:

```csharp
System.AppContext.SetSwitch(=Switch.System.Workflow.ComponentModel.UseLegacyHashForXomlFileChecksum=, true);
```

Or in a configuration file (this needs to be in MSBuild.exe.config for the MSBuild.exe that you are using):

```xml
<configuration>
<runtime>
<AppContextSwitchOverrides value==Switch.System.Workflow.ComponentModel.UseLegacyHashForXomlFileChecksum=true= />
</runtime>
</configuration>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.8         |
| Type    | Retargeting |
