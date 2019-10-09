### AspNetCoreModule V1 removed from Windows Hosting Bundle

Starting with ASP.NET Core 3.0, the Windows Hosting Bundle won't contain AspNetCoreModule (ANCM) V1.

ANCM V2 is backwards compatible with ANCM OutOfProcess and is recommended for use with ASP.NET Core 3.0 apps.

For discussion, see https://github.com/aspnet/AspNetCore/issues/7095.

#### Version introduced

3.0

#### Old behavior

ANCM V1 is included in the Windows Hosting Bundle.

#### New behavior

ANCM V1 isn't included in the Windows Hosting Bundle.

#### Reason for change

ANCM V2 is backwards compatible with ANCM OutOfProcess and is recommended for use with ASP.NET Core 3.0 apps.

#### Recommended action

Use ANCM V2 with ASP.NET Core 3.0 apps.

If ANCM V1 is required, it can be installed using the ASP.NET Core 2.1 or 2.2 Windows Hosting Bundle.

This change will break ASP.NET Core 3.0 apps that:

- Explicitly opted into using ANCM V1 with `<AspNetCoreModuleName>AspNetCoreModule</AspNetCoreModuleName>`.
- Have a custom *web.config* file with `<add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />`.

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis
