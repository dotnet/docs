---
title: "Security in Windows Forms Overview"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "code access security [Windows Forms], Windows Forms"
  - "permissions [Windows Forms], Windows Forms"
  - "Windows Forms, security"
  - "security [Windows Forms], about security"
  - "access control [Windows Forms], Windows Forms"
ms.assetid: 4810dc9f-ea23-4ce1-8ea1-657f0ff1d820
---
# Security in Windows Forms Overview

Before the release of the .NET Framework, all code running on a user's computer had the same rights or permissions to access resources that a user of the computer had. For example, if the user was allowed to access the file system, the code was allowed to access the file system; if the user was allowed to access a database, the code was allowed to access that database. Although these rights or permissions may be acceptable for code in executables that the user has explicitly installed on the local computer, they may not be acceptable for potentially malicious code coming from the Internet or a local Intranet. This code should not be able to access the user's computer resources without permission.

The .NET Framework introduces an infrastructure called Code Access Security that lets you differentiate the permissions, or rights, that code has from the rights that the user has. By default, code coming from the Internet and the Intranet can only run in what is known as partial trust. Partial trust subjects an application to a series of restrictions: among other things, an application is restricted from accessing the local hard disk, and cannot run unmanaged code. The .NET Framework controls the resources that code is allowed to access based on the identity of that code: where it came from, whether it has a [Strong-Named Assemblies](../app-domains/strong-named-assemblies.md), whether it is signed with a certificate, and so on.

ClickOnce technology, which you use to deploy Windows Forms applications, helps make it easier for you to develop applications that run in partial trust, in full trust, or in partial trust with elevated permissions. ClickOnce provides features such as Permission Elevation and Trusted Application Deployment so that your application can request full trust or elevated permissions from the local user in a responsible manner.

## Understanding Security in the .NET Framework

Code access security allows code to be trusted to varying degrees, depending on where the code originates and on other aspects of the code's identity. For more information about the evidence the common language runtime uses to determine security policy, see [Evidence](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/7y5x1hcd(v=vs.100)). It helps protect computer systems from malicious code and helps protect trusted code from intentionally or accidentally compromising security. Code access security also gives you more control over what actions your application can perform, because you can specify only those permissions you need your application to have. Code access security affects all managed code that targets the common language runtime, even if that code does not make a single code-access-security permission check. For more information about security in the .NET Framework, see [Key Security Concepts](../../standard/security/key-security-concepts.md) and [Code Access Security Basics](../misc/code-access-security-basics.md).

If the user run a Windows Forms executable file directly off of a Web server or a file share, the degree of trust granted to your application depends on where the code resides, and how it is started. When an application runs, it is automatically evaluated and it receives a named permission set from the common language runtime. By default, the code from the local computer is granted the Full Trust permission set, code from a local network is granted the Local Intranet permission set, and code from the Internet is granted the Internet permission set.

> [!NOTE]
> In the .NET Framework version 1.0 Service Pack 1 and Service Pack 2, the Internet zone code group receives the Nothing permission set. In all other releases of the .NET Framework, the Internet zone code group receives the Internet permissions set.
>
> The default permissions granted in each of these permission sets are listed in the [Default Security Policy](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/03kwzyfc(v=vs.100)) topic. Depending on the permissions that the application receives, it either runs correctly or generates a security exception.
>
> Many Windows Forms applications will be deployed using ClickOnce. The tools used for generating a ClickOnce deployment have different security defaults than what was discussed earlier. For more information, see the following discussion.

The actual permissions granted to your application can be different from the default values, because the security policy can be modified; this means that your application can have permission on one computer, but not on another.

## Developing a More Secure Windows Forms Application

Security is important in all steps of application development. Start by reviewing and following the [Secure Coding Guidelines](../../standard/security/secure-coding-guidelines.md).

Next, decide whether your application must run in full trust, or whether it should run in partial trust. Running your application in full trust makes it easier to access resources on the local computer, but exposes your application and its users to high security risks if you do not design and develop your application strictly according to the Secure Coding Guidelines topic. Running your application in partial trust makes it easier to develop a more secure application and reduces much risk, but requires more planning in how to implement certain features.

If you choose partial trust (that is, either the Internet or Local Intranet permission sets), decide how you want your application to behave in this environment. Windows Forms provides alternative, more secure ways to implement features when in a semi-trusted environment. Certain parts of your application, such as data access, can be designed and written differently for both partial trust and full trust environments. Some Windows Forms features, such as application settings, are designed to work in partial trust. For more information, see [Application Settings Overview](./advanced/application-settings-overview.md).

If your application needs more permissions than partial trust allows, but you do not want to run in full trust, you can run in partial trust while asserting only those additional permissions you need. For example, if you want to run in partial trust, but must grant your application read-only access to a directory on the user's file system, you can request <xref:System.Security.Permissions.FileIOPermission> only for that directory. Used correctly, this approach can give your application increased functionality and minimize security risks to your users.

When you develop an application that will run in partial trust, keep track of what permissions your application must run and what permissions your application could optionally use. When all the permissions are known, you should make a declarative request for permission at the application level. Requesting permissions informs the .NET Framework run time about which permissions your application needs and which permissions it specifically does not want. For more information about requesting permissions, see [Requesting Permissions](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/yd267cce(v=vs.100)).

When you request optional permissions, you must handle security exceptions that will be generated if your application performs an action that requires permissions not granted to it. Appropriate handling of the <xref:System.Security.SecurityException> will ensure that your application can continue to operate. Your application can use the exception to determine whether a feature should become disabled for the user. For example, an application can disable the **Save** menu option if the required file permission is not granted.

Sometimes, it is difficult to know if you have asserted all the appropriate permissions. A method call which looks innocuous on the surface, for example, may access the file system at some point during its execution. If you do not deploy your application with all the required permissions, it may test fine when you debug it on your desktop, but fail when deployed. Both the .NET Framework 2.0 SDK and Visual Studio 2005 contain tools for calculating the permissions an application needs: the MT.exe command line tool and the Calculate Permissions feature of Visual Studio, respectively.

The following topics describe additional Windows Forms security features.

|Topic|Description|
|-----------|-----------------|
|- [More Secure File and Data Access in Windows Forms](more-secure-file-and-data-access-in-windows-forms.md)|Describes how to access files and data in a partial trust environment.|
|- [More Secure Printing in Windows Forms](more-secure-printing-in-windows-forms.md)|Describes how to access printing features in a partial trust environment.|
|- [Additional Security Considerations in Windows Forms](additional-security-considerations-in-windows-forms.md)|Describes performing window manipulation, using the Clipboard, and making calls to unmanaged code in a partial trust environment.|

### Deploying an Application with the Appropriate Permissions

The most common means of deploying a Windows Forms application to a client computer is with ClickOnce, a deployment technology that describes all of the components your application needs to run. ClickOnce uses XML files called manifests to describe the assemblies and files that make up your application, and also the permissions your application requires.

ClickOnce has two technologies for requesting elevated permissions on a client computer. Both technologies rely on the use of Authenticode certificates. The certificates help provide some assurance to your users that the application has come from a trusted source.

The following table describes these technologies.

|Elevated permission technology|Description|
|------------------------------------|-----------------|
|Permission Elevation|Prompts the user with a security dialog box the first time your application runs. The **Permission Elevation** dialog box informs the user about who published the application, so that the user can make an informed decision about whether to grant it additional trust|
|Trusted Application Deployment|Involves a system administrator performing a one-time installation of a publisher's Authenticode certificate on a client computer. From that point on, any applications signed with the certificate are regarded as trusted, and can run at full trust on the local computer without additional prompting.|

Which technology you choose will depend on your deployment environment. For more information, see [Choosing a ClickOnce Deployment Strategy](/visualstudio/deployment/choosing-a-clickonce-deployment-strategy).

By default, ClickOnce applications deployed using either Visual Studio or the .NET Framework SDK tools (Mage.exe and MageUI.exe) are configured to run on a client computer that has Full Trust. If you are deploying your application by using partial trust or by using only some additional permissions, you will have to change this default. You can do this with either Visual Studio or the .NET Framework SDK tool MageUI.exe when you configure your deployment. For more information about how to use MageUI.exe, see [Walkthrough: Manually deploying a ClickOnce application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application).  Also see [How to: Set Custom Permissions for a ClickOnce Application](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2012/hafybdaa(v=vs.110)) or [How to: Set Custom Permissions for a ClickOnce Application](/visualstudio/deployment/how-to-set-custom-permissions-for-a-clickonce-application).

For more information about the security aspects of ClickOnce and Permission Elevation, see [Securing ClickOnce Applications](/visualstudio/deployment/securing-clickonce-applications). For more information about Trusted Application Deployment, see [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview).

### Testing the Application

If you have deployed your Windows Forms application by using Visual Studio, you can enable debugging in partial trust or a restricted permission set from the development environment.  Also see [How to: Debug a ClickOnce Application with Restricted Permissions](/visualstudio/deployment/how-to-debug-a-clickonce-application-with-restricted-permissions).

## See also

- [Windows Forms Security](windows-forms-security.md)
- [Code Access Security Basics](../misc/code-access-security-basics.md)
- [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)
- [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview)
- [Mage.exe (Manifest Generation and Editing Tool)](../tools/mage-exe-manifest-generation-and-editing-tool.md)
- [MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](../tools/mageui-exe-manifest-generation-and-editing-tool-graphical-client.md)
