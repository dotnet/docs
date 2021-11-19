---
title: "Breaking change: Most code access security APIs are obsolete"
description: Learn about the .NET 5 breaking change in core .NET libraries where most code access security (CAS)-related types in .NET are now obsolete as warning.
ms.date: 11/01/2020
---
# Most code access security APIs are obsolete

Most code access security (CAS)-related types in .NET are now obsolete as warning. This includes CAS attributes, such as <xref:System.Security.Permissions.SecurityPermissionAttribute>, CAS permission objects, such as <xref:System.Net.SocketPermission>, <xref:System.Security.Policy.EvidenceBase>-derived types, and other supporting APIs.

## Change description

In .NET Framework 2.x - 4.x, CAS attributes and APIs can influence the course of code execution, including ensuring that CAS-demand stack walks succeed or fail.

```csharp
// In .NET Framework, the attribute causes CAS stack walks
// to terminate successfully when this permission is demanded.
[SocketPermission(SecurityAction.Assert, Host = "contoso.com", Port = "443")]
public void DoSomething()
{
    // open a socket to contoso.com:443
}
```

In .NET Core 2.x - 3.x, the runtime does not honor CAS attributes or CAS APIs. The runtime ignores attributes on method entry, and most programmatic APIs have no effect.

```csharp
// The .NET Core runtime ignores the following attribute.
[SocketPermission(SecurityAction.Assert, Host = "contoso.com", Port = "443")]
public void DoSomething()
{
    // open a socket to contoso.com:443
}
```

Additionally, programmatic calls to expansive APIs (`Assert`) always succeed, while programmatic calls to restrictive APIs (`Deny`, `PermitOnly`) always throw an exception at run time. (<xref:System.Security.Permissions.PrincipalPermission> is an exception to this rule. See the [Recommended action](#cas-action) section below.)

```csharp
public void DoAssert()
{
    // The line below has no effect at run time.
    new SocketPermission(PermissionState.Unrestricted).Assert();
}

public void DoDeny()
{
    // The line below throws PlatformNotSupportedException at run time.
    new SocketPermission(PermissionState.Unrestricted).Deny();
}
```

In .NET 5 and later versions, most CAS-related APIs are obsolete and produce compile-time warning `SYSLIB0003`.

```csharp
[SocketPermission(SecurityAction.Assert, Host = "contoso.com", Port = "443")] // warning SYSLIB0003
public void DoSomething()
{
    new SocketPermission(PermissionState.Unrestricted).Assert(); // warning SYSLIB0003
    new SocketPermission(PermissionState.Unrestricted).Deny(); // warning SYSLIB0003
}
```

This is a compile-time only change. There is no run-time change from previous versions of .NET Core. Methods that perform no operation in .NET Core 2.x - 3.x will continue to perform no operation at run time in .NET 5 and later. Methods that throw <xref:System.PlatformNotSupportedException> in .NET Core 2.x - 3.x will continue to throw a <xref:System.PlatformNotSupportedException> at run time in .NET 5 and later.

## Reason for change

[Code access security (CAS)](/previous-versions/dotnet/framework/code-access-security/code-access-security) is an unsupported legacy technology. The infrastructure to enable CAS exists only in .NET Framework 2.x - 4.x, but is deprecated and not receiving servicing or security fixes.

Due to CAS's deprecation, the [supporting infrastructure was not brought forward to .NET Core](../../../porting/net-framework-tech-unavailable.md) or .NET 5+. However, the APIs were brought forward so that apps could cross-compile against .NET Framework and .NET Core. This led to "fail open" scenarios, where some CAS-related APIs exist and are callable but perform no action at run time. This can lead to security issues for components that expect the runtime to honor CAS-related attributes or programmatic API calls. To better communicate that the runtime doesn't respect these attributes or APIs, we have obsoleted the majority of them in .NET 5.0.

## Version introduced

5.0

## <a id="cas-action">Recommended action</a>

- If you're asserting any security permission, remove the attribute or call that asserts the permission.

  ```csharp
  // REMOVE the attribute below.
  [SecurityPermission(SecurityAction.Assert, ControlThread = true)]
  public void DoSomething()
  {
  }

  public void DoAssert()
  {
      // REMOVE the line below.
      new SecurityPermission(SecurityPermissionFlag.ControlThread).Assert();
  }
  ```

- If you're denying or restricting (via `PermitOnly`) any permission, contact your security advisor. Because CAS attributes are not honored by the .NET 5+ runtime, your application could have a security hole if it incorrectly relies on the CAS infrastructure to restrict access to these methods.

  ```csharp
  // REVIEW the attribute below; could indicate security vulnerability.
  [SecurityPermission(SecurityAction.Deny, ControlThread = true)]
  public void DoSomething()
  {
  }

  public void DoPermitOnly()
  {
      // REVIEW the line below; could indicate security vulnerability.
      new SecurityPermission(SecurityPermissionFlag.ControlThread).PermitOnly();
  }
  ```

- If you're demanding any permission (except <xref:System.Security.Permissions.PrincipalPermission>), remove the demand. All demands will succeed at run time.

  ```csharp
  // REMOVE the attribute below; it will always succeed.
  [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
  public void DoSomething()
  {
  }

  public void DoDemand()
  {
      // REMOVE the line below; it will always succeed.
      new SecurityPermission(SecurityPermissionFlag.ControlThread).Demand();
  }
  ```

- If you're demanding <xref:System.Security.Permissions.PrincipalPermission>, consult the guidance for [PrincipalPermissionAttribute is obsolete as error](principalpermissionattribute-obsolete.md). That guidance applies for both <xref:System.Security.Permissions.PrincipalPermission> and <xref:System.Security.Permissions.PrincipalPermissionAttribute>.

- If you absolutely must disable these warnings (which is not recommended), you can suppress the `SYSLIB0003` warning in code.

  ```csharp
  #pragma warning disable SYSLIB0003 // disable the warning
  [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
  #pragma warning restore SYSLIB0003 // re-enable the warning
  public void DoSomething()
  {
  }

  public void DoDemand()
  {
  #pragma warning disable SYSLIB0003 // disable the warning
      new SecurityPermission(SecurityPermissionFlag.ControlThread).Demand();
  #pragma warning restore SYSLIB0003 // re-enable the warning
  }
  ```

  You can also suppress the warning in your project file. Doing so disables the warning for all source files within the project.

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
     <TargetFramework>net5.0</TargetFramework>
     <!-- NoWarn below suppresses SYSLIB0003 project-wide -->
     <NoWarn>$(NoWarn);SYSLIB0003</NoWarn>
    </PropertyGroup>
  </Project>
  ```

  > [!NOTE]
  > Suppressing `SYSLIB0003` disables only the CAS-related obsoletion warnings. It does not disable any other warnings or change the behavior of the .NET 5+ runtime.
- Security

## Affected APIs

- <xref:System.AppDomain.PermissionSet?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationPermission?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationPermissionAttribute?displayProperty=fullName>
- <xref:System.Data.Common.DBDataPermission?displayProperty=fullName>
- <xref:System.Data.Common.DBDataPermissionAttribute?displayProperty=fullName>
- <xref:System.Data.Odbc.OdbcPermission?displayProperty=fullName>
- <xref:System.Data.Odbc.OdbcPermissionAttribute?displayProperty=fullName>
- <xref:System.Data.OleDb.OleDbPermission?displayProperty=fullName>
- <xref:System.Data.OleDb.OleDbPermissionAttribute?displayProperty=fullName>
- <xref:System.Data.OracleClient.OraclePermission?displayProperty=fullName>
- <xref:System.Data.OracleClient.OraclePermissionAttribute?displayProperty=fullName>
- <xref:System.Data.SqlClient.SqlClientPermission?displayProperty=fullName>
- <xref:System.Data.SqlClient.SqlClientPermissionAttribute?displayProperty=fullName>
- <xref:System.Diagnostics.EventLogPermission?displayProperty=fullName>
- <xref:System.Diagnostics.EventLogPermissionAttribute?displayProperty=fullName>
- <xref:System.Diagnostics.PerformanceCounterPermission?displayProperty=fullName>
- <xref:System.Diagnostics.PerformanceCounterPermissionAttribute?displayProperty=fullName>
- <xref:System.DirectoryServices.DirectoryServicesPermission?displayProperty=fullName>
- <xref:System.DirectoryServices.DirectoryServicesPermissionAttribute?displayProperty=fullName>
- <xref:System.Drawing.Printing.PrintingPermission?displayProperty=fullName>
- <xref:System.Drawing.Printing.PrintingPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.DnsPermission?displayProperty=fullName>
- <xref:System.Net.DnsPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpPermission?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.NetworkInformationPermission?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.NetworkInformationPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.PeerToPeer.Collaboration.PeerCollaborationPermission?displayProperty=fullName>
- <xref:System.Net.PeerToPeer.Collaboration.PeerCollaborationPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.PeerToPeer.PnrpPermission?displayProperty=fullName>
- <xref:System.Net.PeerToPeer.PnrpPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.SocketPermission?displayProperty=fullName>
- <xref:System.Net.SocketPermissionAttribute?displayProperty=fullName>
- <xref:System.Net.WebPermission?displayProperty=fullName>
- <xref:System.Net.WebPermissionAttribute?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.AllowReversePInvokeCallsAttribute?displayProperty=fullName>
- <xref:System.Security.CodeAccessPermission?displayProperty=fullName>
- <xref:System.Security.HostProtectionException?displayProperty=fullName>
- <xref:System.Security.IPermission?displayProperty=fullName>
- <xref:System.Security.IStackWalk?displayProperty=fullName>
- <xref:System.Security.NamedPermissionSet?displayProperty=fullName>
- <xref:System.Security.PermissionSet?displayProperty=fullName>
- <xref:System.Security.Permissions.CodeAccessSecurityAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.DataProtectionPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.DataProtectionPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.DataProtectionPermissionFlags?displayProperty=fullName>
- <xref:System.Security.Permissions.EnvironmentPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.EnvironmentPermissionAccess?displayProperty=fullName>
- <xref:System.Security.Permissions.EnvironmentPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.FileDialogPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.FileDialogPermissionAccess?displayProperty=fullName>
- <xref:System.Security.Permissions.FileDialogPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.FileIOPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.FileIOPermissionAccess?displayProperty=fullName>
- <xref:System.Security.Permissions.FileIOPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.GacIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.GacIdentityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.HostProtectionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.HostProtectionResource?displayProperty=fullName>
- <xref:System.Security.Permissions.IUnrestrictedPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.IsolatedStorageContainment?displayProperty=fullName>
- <xref:System.Security.Permissions.IsolatedStorageFilePermission?displayProperty=fullName>
- <xref:System.Security.Permissions.IsolatedStorageFilePermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.IsolatedStoragePermission?displayProperty=fullName>
- <xref:System.Security.Permissions.IsolatedStoragePermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermissionAccessEntry?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermissionAccessEntryCollection?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.KeyContainerPermissionFlags?displayProperty=fullName>
- <xref:System.Security.Permissions.MediaPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.MediaPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.MediaPermissionAudio?displayProperty=fullName>
- <xref:System.Security.Permissions.MediaPermissionImage?displayProperty=fullName>
- <xref:System.Security.Permissions.MediaPermissionVideo?displayProperty=fullName>
- <xref:System.Security.Permissions.PermissionSetAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.PermissionState?displayProperty=fullName>
- <xref:System.Security.Permissions.PrincipalPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.PrincipalPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.PublisherIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.PublisherIdentityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.ReflectionPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.ReflectionPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.ReflectionPermissionFlag?displayProperty=fullName>
- <xref:System.Security.Permissions.RegistryPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.RegistryPermissionAccess?displayProperty=fullName>
- <xref:System.Security.Permissions.RegistryPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.ResourcePermissionBase?displayProperty=fullName>
- <xref:System.Security.Permissions.ResourcePermissionBaseEntry?displayProperty=fullName>
- <xref:System.Security.Permissions.SecurityAction?displayProperty=fullName>
- <xref:System.Security.Permissions.SecurityAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.SecurityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.SecurityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.SecurityPermissionFlag?displayProperty=fullName>
- <xref:System.Security.Permissions.SiteIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.SiteIdentityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.StorePermission?displayProperty=fullName>
- <xref:System.Security.Permissions.StorePermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.StorePermissionFlags?displayProperty=fullName>
- <xref:System.Security.Permissions.StrongNameIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.StrongNameIdentityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.StrongNamePublicKeyBlob?displayProperty=fullName>
- <xref:System.Security.Permissions.TypeDescriptorPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.TypeDescriptorPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.TypeDescriptorPermissionFlags?displayProperty=fullName>
- <xref:System.Security.Permissions.UIPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.UIPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.UIPermissionClipboard?displayProperty=fullName>
- <xref:System.Security.Permissions.UIPermissionWindow?displayProperty=fullName>
- <xref:System.Security.Permissions.UrlIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.UrlIdentityPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.WebBrowserPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.WebBrowserPermissionAttribute?displayProperty=fullName>
- <xref:System.Security.Permissions.WebBrowserPermissionLevel?displayProperty=fullName>
- <xref:System.Security.Permissions.ZoneIdentityPermission?displayProperty=fullName>
- <xref:System.Security.Permissions.ZoneIdentityPermissionAttribute?displayProperty=fullName>
- [System.Security.Policy.ApplicationTrust.ApplicationTrust(PermissionSet, IEnumerable\<StrongName>)](/dotnet/api/system.security.policy.applicationtrust.-ctor#System_Security_Policy_ApplicationTrust__ctor_System_Security_PermissionSet_System_Collections_Generic_IEnumerable_System_Security_Policy_StrongName__)
- <xref:System.Security.Policy.ApplicationTrust.FullTrustAssemblies?displayProperty=fullName>
- <xref:System.Security.Policy.FileCodeGroup?displayProperty=fullName>
- <xref:System.Security.Policy.GacInstalled?displayProperty=fullName>
- <xref:System.Security.Policy.IIdentityPermissionFactory?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyLevel.AddNamedPermissionSet(System.Security.NamedPermissionSet)?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyLevel.ChangeNamedPermissionSet(System.String,System.Security.PermissionSet)?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyLevel.GetNamedPermissionSet(System.String)?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyLevel.RemoveNamedPermissionSet%2A?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyStatement.PermissionSet?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyStatement.%23ctor%2A?displayProperty=fullName>
- <xref:System.Security.Policy.Publisher?displayProperty=fullName>
- <xref:System.Security.Policy.Site?displayProperty=fullName>
- <xref:System.Security.Policy.StrongName?displayProperty=fullName>
- <xref:System.Security.Policy.StrongNameMembershipCondition?displayProperty=fullName>
- <xref:System.Security.Policy.Url?displayProperty=fullName>
- <xref:System.Security.Policy.Zone?displayProperty=fullName>
- <xref:System.Security.SecurityManager?displayProperty=fullName>
- <xref:System.ServiceProcess.ServiceControllerPermission?displayProperty=fullName>
- <xref:System.ServiceProcess.ServiceControllerPermissionAttribute?displayProperty=fullName>
- <xref:System.Transactions.DistributedTransactionPermission?displayProperty=fullName>
- <xref:System.Transactions.DistributedTransactionPermissionAttribute?displayProperty=fullName>
- <xref:System.Web.AspNetHostingPermission?displayProperty=fullName>
- <xref:System.Web.AspNetHostingPermissionAttribute?displayProperty=fullName>
- <xref:System.Xaml.Permissions.XamlLoadPermission?displayProperty=fullName>

<!--

#### Category

- Core .NET libraries
- Security

### Affected APIs

- `P:System.AppDomain.PermissionSet`
- `T:System.Configuration.ConfigurationPermission`
- `T:System.Configuration.ConfigurationPermissionAttribute`
- `T:System.Data.Common.DBDataPermission`
- `T:System.Data.Common.DBDataPermissionAttribute`
- `T:System.Data.Odbc.OdbcPermission`
- `T:System.Data.Odbc.OdbcPermissionAttribute`
- `T:System.Data.OleDb.OleDbPermission`
- `T:System.Data.OleDb.OleDbPermissionAttribute`
- `T:System.Data.OracleClient.OraclePermission`
- `T:System.Data.OracleClient.OraclePermissionAttribute`
- `T:System.Data.SqlClient.SqlClientPermission`
- `T:System.Data.SqlClient.SqlClientPermissionAttribute`
- `T:System.Diagnostics.EventLogPermission`
- `T:System.Diagnostics.EventLogPermissionAttribute`
- `T:System.Diagnostics.PerformanceCounterPermission`
- `T:System.Diagnostics.PerformanceCounterPermissionAttribute`
- `T:System.DirectoryServices.DirectoryServicesPermission`
- `T:System.DirectoryServices.DirectoryServicesPermissionAttribute`
- `T:System.Drawing.Printing.PrintingPermission`
- `T:System.Drawing.Printing.PrintingPermissionAttribute`
- `T:System.Net.DnsPermission`
- `T:System.Net.DnsPermissionAttribute`
- `T:System.Net.Mail.SmtpPermission`
- `T:System.Net.Mail.SmtpPermissionAttribute`
- `T:System.Net.NetworkInformation.NetworkInformationPermission`
- `T:System.Net.NetworkInformation.NetworkInformationPermissionAttribute`
- `T:System.Net.PeerToPeer.Collaboration.PeerCollaborationPermission`
- `T:System.Net.PeerToPeer.Collaboration.PeerCollaborationPermissionAttribute`
- `T:System.Net.PeerToPeer.PnrpPermission`
- `T:System.Net.PeerToPeer.PnrpPermissionAttribute`
- `T:System.Net.SocketPermission`
- `T:System.Net.SocketPermissionAttribute`
- `T:System.Net.WebPermission`
- `T:System.Net.WebPermissionAttribute`
- `T:System.Runtime.InteropServices.AllowReversePInvokeCallsAttribute`
- `T:System.Security.CodeAccessPermission`
- `T:System.Security.HostProtectionException`
- `T:System.Security.IPermission`
- `T:System.Security.IStackWalk`
- `T:System.Security.NamedPermissionSet`
- `T:System.Security.PermissionSet`
- `T:System.Security.Permissions.CodeAccessSecurityAttribute`
- `T:System.Security.Permissions.DataProtectionPermission`
- `T:System.Security.Permissions.DataProtectionPermissionAttribute`
- `T:System.Security.Permissions.DataProtectionPermissionFlags`
- `T:System.Security.Permissions.EnvironmentPermission`
- `T:System.Security.Permissions.EnvironmentPermissionAccess`
- `T:System.Security.Permissions.EnvironmentPermissionAttribute`
- `T:System.Security.Permissions.FileDialogPermission`
- `T:System.Security.Permissions.FileDialogPermissionAccess`
- `T:System.Security.Permissions.FileDialogPermissionAttribute`
- `T:System.Security.Permissions.FileIOPermission`
- `T:System.Security.Permissions.FileIOPermissionAccess`
- `T:System.Security.Permissions.FileIOPermissionAttribute`
- `T:System.Security.Permissions.GacIdentityPermission`
- `T:System.Security.Permissions.GacIdentityPermissionAttribute`
- `T:System.Security.Permissions.HostProtectionAttribute`
- `T:System.Security.Permissions.HostProtectionResource`
- `T:System.Security.Permissions.IUnrestrictedPermission`
- `T:System.Security.Permissions.IsolatedStorageContainment`
- `T:System.Security.Permissions.IsolatedStorageFilePermission`
- `T:System.Security.Permissions.IsolatedStorageFilePermissionAttribute`
- `T:System.Security.Permissions.IsolatedStoragePermission`
- `T:System.Security.Permissions.IsolatedStoragePermissionAttribute`
- `T:System.Security.Permissions.KeyContainerPermission`
- `T:System.Security.Permissions.KeyContainerPermissionAccessEntry`
- `T:System.Security.Permissions.KeyContainerPermissionAccessEntryCollection`
- `T:System.Security.Permissions.KeyContainerPermissionAccessEntryEnumerator`
- `T:System.Security.Permissions.KeyContainerPermissionAttribute`
- `T:System.Security.Permissions.KeyContainerPermissionFlags`
- `T:System.Security.Permissions.MediaPermission`
- `T:System.Security.Permissions.MediaPermissionAttribute`
- `T:System.Security.Permissions.MediaPermissionAudio`
- `T:System.Security.Permissions.MediaPermissionImage`
- `T:System.Security.Permissions.MediaPermissionVideo`
- `T:System.Security.Permissions.PermissionSetAttribute`
- `T:System.Security.Permissions.PermissionState`
- `T:System.Security.Permissions.PrincipalPermission`
- `T:System.Security.Permissions.PrincipalPermissionAttribute`
- `T:System.Security.Permissions.PublisherIdentityPermission`
- `T:System.Security.Permissions.PublisherIdentityPermissionAttribute`
- `T:System.Security.Permissions.ReflectionPermission`
- `T:System.Security.Permissions.ReflectionPermissionAttribute`
- `T:System.Security.Permissions.ReflectionPermissionFlag`
- `T:System.Security.Permissions.RegistryPermission`
- `T:System.Security.Permissions.RegistryPermissionAccess`
- `T:System.Security.Permissions.RegistryPermissionAttribute`
- `T:System.Security.Permissions.ResourcePermissionBase`
- `T:System.Security.Permissions.ResourcePermissionBaseEntry`
- `T:System.Security.Permissions.SecurityAction`
- `T:System.Security.Permissions.SecurityAttribute`
- `T:System.Security.Permissions.SecurityPermission`
- `T:System.Security.Permissions.SecurityPermissionAttribute`
- `T:System.Security.Permissions.SecurityPermissionFlag`
- `T:System.Security.Permissions.SiteIdentityPermission`
- `T:System.Security.Permissions.SiteIdentityPermissionAttribute`
- `T:System.Security.Permissions.StorePermission`
- `T:System.Security.Permissions.StorePermissionAttribute`
- `T:System.Security.Permissions.StorePermissionFlags`
- `T:System.Security.Permissions.StrongNameIdentityPermission`
- `T:System.Security.Permissions.StrongNameIdentityPermissionAttribute`
- `T:System.Security.Permissions.StrongNamePublicKeyBlob`
- `T:System.Security.Permissions.TypeDescriptorPermission`
- `T:System.Security.Permissions.TypeDescriptorPermissionAttribute`
- `T:System.Security.Permissions.TypeDescriptorPermissionFlags`
- `T:System.Security.Permissions.UIPermission`
- `T:System.Security.Permissions.UIPermissionAttribute`
- `T:System.Security.Permissions.UIPermissionClipboard`
- `T:System.Security.Permissions.UIPermissionWindow`
- `T:System.Security.Permissions.UrlIdentityPermission`
- `T:System.Security.Permissions.UrlIdentityPermissionAttribute`
- `T:System.Security.Permissions.WebBrowserPermission`
- `T:System.Security.Permissions.WebBrowserPermissionAttribute`
- `T:System.Security.Permissions.WebBrowserPermissionLevel`
- `T:System.Security.Permissions.ZoneIdentityPermission`
- `T:System.Security.Permissions.ZoneIdentityPermissionAttribute`
- `M:`System.Security.Policy.ApplicationTrust.ApplicationTrust(PermissionSet, IEnumerable<StrongName>)`
- `P:System.Security.Policy.ApplicationTrust.FullTrustAssemblies`
- `T:System.Security.Policy.FileCodeGroup`
- `T:System.Security.Policy.GacInstalled`
- `T:System.Security.Policy.IIdentityPermissionFactory`
- `M:System.Security.Policy.PolicyLevel.AddNamedPermissionSet(System.Security.NamedPermissionSet)`
- `M:System.Security.Policy.PolicyLevel.ChangeNamedPermissionSet(System.String,System.Security.PermissionSet)`
- `M:System.Security.Policy.PolicyLevel.GetNamedPermissionSet(System.String)`
- `Overload:System.Security.Policy.PolicyLevel.RemoveNamedPermissionSet`
- `T:System.Security.Policy.PolicyStatement.PermissionSet`
- `Overload:System.Security.Policy.PolicyStatement.#ctor`
- `T:System.Security.Policy.Publisher`
- `T:System.Security.Policy.Site`
- `T:System.Security.Policy.StrongName`
- `T:System.Security.Policy.StrongNameMembershipCondition`
- `T:System.Security.Policy.Url`
- `T:System.Security.Policy.Zone`
- `T:System.Security.SecurityManager`
- `T:System.ServiceProcess.ServiceControllerPermission`
- `T:System.ServiceProcess.ServiceControllerPermissionAttribute`
- `T:System.Transactions.DistributedTransactionPermission`
- `T:System.Transactions.DistributedTransactionPermissionAttribute`
- `T:System.Web.AspNetHostingPermission`
- `T:System.Web.AspNetHostingPermissionAttribute`
- `T:System.Xaml.Permissions.XamlLoadPermission`

-->
