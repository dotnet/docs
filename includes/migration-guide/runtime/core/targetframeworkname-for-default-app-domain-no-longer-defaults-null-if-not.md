### TargetFrameworkName for default app domain no longer defaults to null if not set

|   |   |
|---|---|
|Details|The <xref:System.AppDomainSetup.TargetFrameworkName?displayProperty=name> was previously null in the default app domain, unless it was explicitly set. Beginning in 4.6, the <xref:System.AppDomainSetup.TargetFrameworkName?displayProperty=name> property for the default app domain will have a default value derived from the TargetFrameworkAttribute (if one is present). Non-default app domains will continue to inherit their <xref:System.AppDomainSetup.TargetFrameworkName?displayProperty=name> from the default app domain (which will not default to null in 4.6) unless it is explicitly overridden.|
|Suggestion|Code should be updated to not depend on <xref:System.AppDomainSetup.TargetFrameworkName> defaulting to null. If it is required that this property continue to evaluate to null, it can be explicitly set to that value.|
|Scope|Edge|
|Version|4.6|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.AppDomainSetup.TargetFrameworkName?displayProperty=nameWithType></li></ul>|
