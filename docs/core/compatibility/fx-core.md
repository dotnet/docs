---
title: Breaking changes - .NET Framework to .NET Core
titleSuffix: ""
description: Lists the breaking changes from .NET Framework to .NET Core 1.0 - 3.1.
ms.date: 05/05/2020
---
# Breaking changes for migration from .NET Framework to .NET Core

If you're migrating an app from .NET Framework to .NET Core versions 1.0 through 3.1, the breaking changes listed in this article may affect you. Breaking changes are grouped by category, and within those categories, by the version of .NET Core in which they were introduced.

> [!NOTE]
> This article is not a complete list of breaking changes between .NET Framework and .NET Core. The most important breaking changes are added here as we become aware of them.

## Core .NET libraries

- [Change in default value of UseShellExecute](#change-in-default-value-of-useshellexecute)
- [UnauthorizedAccessException thrown by FileSystemInfo.Attributes](#unauthorizedaccessexception-thrown-by-filesysteminfoattributes)
- [Handling corrupted-process-state exceptions is not supported](#handling-corrupted-state-exceptions-is-not-supported)
- [UriBuilder properties no longer prepend leading characters](#uribuilder-properties-no-longer-prepend-leading-characters)
- [Process.StartInfo throws InvalidOperationException for processes you didn't start](#processstartinfo-throws-invalidoperationexception-for-processes-you-didnt-start)

### .NET Core 2.1

[!INCLUDE[Process.Start changes](~/includes/core-changes/corefx/2.1/process-start-changes.md)]

***

### .NET Core 1.0

[!INCLUDE [UnauthorizedAccessException thrown by FileSystemInfo.Attributes](~/includes/core-changes/corefx/1.0/filesysteminfo-attributes-exceptions.md)]

***

[!INCLUDE [corrupted-state-exceptions](~/includes/core-changes/corefx/1.0/corrupted-state-exceptions.md)]

***

[!INCLUDE [uribuilder-behavior-changes](../../../includes/core-changes/corefx/1.0/uribuilder-behavior-changes.md)]

***

[!INCLUDE [startinfo-throws-exception](../../../includes/core-changes/corefx/1.0/startinfo-throws-exception.md)]

***

## Cryptography

- [Boolean parameter of SignedCms.ComputeSignature is respected](#boolean-parameter-of-signedcmscomputesignature-is-respected)

### .NET Core 2.1

[!INCLUDE [Boolean parameter of SignedCms.ComputeSignature is respected](~/includes/core-changes/cryptography/2.1/compute-signature-silent-parameter.md)]

***

## MSBuild

- [Resource manifest file name change](#resource-manifest-file-name-change)

### .NET Core 3.0

[!INCLUDE[Resource file names](~/includes/core-changes/msbuild/3.0/resource-manifest-name.md)]

***

## Networking

- [WebClient.CancelAsync doesn't always cancel immediately](#webclientcancelasync-doesnt-always-cancel-immediately)

### .NET Core 2.0

[!INCLUDE [behavior-change-webclient-cancelasync](../../../includes/core-changes/networking/2.0/behavior-change-webclient-cancelasync.md)]

***

## Windows Forms

Windows Forms support was added to .NET Core in version 3.0. If you're migrating a Windows Forms app from .NET Framework to .NET Core, the breaking changes listed here may affect your app.

- [Removed controls](#removed-controls)
- [CellFormatting event not raised if tooltip is shown](#cellformatting-event-not-raised-if-tooltip-is-shown)
- [Control.DefaultFont changed to Segoe UI 9 pt](#default-control-font-changed-to-segoe-ui-9-pt)
- [Modernization of the FolderBrowserDialog](#modernization-of-the-folderbrowserdialog)
- [SerializableAttribute removed from some Windows Forms types](#serializableattribute-removed-from-some-windows-forms-types)
- [AllowUpdateChildControlIndexForTabControls compatibility switch not supported](#allowupdatechildcontrolindexfortabcontrols-compatibility-switch-not-supported)
- [DomainUpDown.UseLegacyScrolling compatibility switch not supported](#domainupdownuselegacyscrolling-compatibility-switch-not-supported)
- [DoNotLoadLatestRichEditControl compatibility switch not supported](#donotloadlatestricheditcontrol-compatibility-switch-not-supported)
- [DoNotSupportSelectAllShortcutInMultilineTextBox compatibility switch not supported](#donotsupportselectallshortcutinmultilinetextbox-compatibility-switch-not-supported)
- [DontSupportReentrantFilterMessage compatibility switch not supported](#dontsupportreentrantfiltermessage-compatibility-switch-not-supported)
- [EnableVisualStyleValidation compatibility switch not supported](#enablevisualstylevalidation-compatibility-switch-not-supported)
- [UseLegacyContextMenuStripSourceControlValue compatibility switch not supported](#uselegacycontextmenustripsourcecontrolvalue-compatibility-switch-not-supported)
- [UseLegacyImages compatibility switch not supported](#uselegacyimages-compatibility-switch-not-supported)
- [About and SplashScreen templates are broken for Visual Basic](#about-and-splashscreen-templates-are-broken)
- [Types in Microsoft.VisualBasic.ApplicationServices namespace not available](#types-in-microsoftvisualbasicapplicationservices-namespace-not-available)
- [Types in Microsoft.VisualBasic.Devices namespace not available](#types-in-microsoftvisualbasicdevices-namespace-not-available)
- [Types in Microsoft.VisualBasic.MyServices namespace not available](#types-in-microsoftvisualbasicmyservices-namespace-not-available)
- [Microsoft.VisualBasic.Constants.vbNewLine is obsolete](#microsoftvisualbasicconstantsvbnewline-is-obsolete)

### .NET Core 3.1

[!INCLUDE[Removed controls](~/includes/core-changes/windowsforms/3.1/remove-controls-3.1.md)]

***

[!INCLUDE[CellFormatting event](~/includes/core-changes/windowsforms/3.1/cellformatting-event-not-raised.md)]

***

### .NET Core 3.0

[!INCLUDE[Control.DefaultFont changed to Segoe UI 9 pt](~/includes/core-changes/windowsforms/3.0/control-defaultfont-changed.md)]

***

[!INCLUDE[Modernization of the FolderBrowserDialog](~/includes/core-changes/windowsforms/3.0/modernized-folderbrowserdialog.md)]

***

[!INCLUDE[SerializableAttribute removed from some Windows Forms types](~/includes/core-changes/windowsforms/3.0/remove-serializationattribute.md)]

***

[!INCLUDE[AllowUpdateChildControlIndexForTabControls compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-allowupdatechildcontrolindexfortabcontrols.md)]

***

[!INCLUDE[DomainUpDown.UseLegacyScrolling compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacyscrolling.md)]

***

[!INCLUDE[DoNotLoadLatestRichEditControl compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-donotloadlatestricheditcontrol.md)]

***

[!INCLUDE[DoNotSupportSelectAllShortcutInMultilineTextBox compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-donotsupportselectallshortcutinmultilinetextbox.md)]

***

[!INCLUDE[DontSupportReentrantFilterMessage compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-dontsupportreentrantfiltermessage.md)]

***

[!INCLUDE[EnableVisualStyleValidation compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-enablevisualstylevalidation.md)]

***

[!INCLUDE[UseLegacyContextMenuStripSourceControlValue compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacycontextmenustripsourcecontrolvalue.md)]

***

[!INCLUDE[UseLegacyImages compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacyimages.md)]

***

[!INCLUDE[About and SplashScreen templates are broken for Visual Basic](~/includes/core-changes/visualbasic/3.0/vb-winforms-splash-about-broken.md)]

***

[!INCLUDE[Types in Microsoft.VisualBasic.ApplicationServices namespace not available](~/includes/core-changes/visualbasic/3.0/microsoft.visualbasic.applicationservices-unavailable.md)]

***
[!INCLUDE[Types in Microsoft.VisualBasic.Devices namespace not available](~/includes/core-changes/visualbasic/3.0/microsoft.visualbasic.devices-unavailable.md)]

***

[!INCLUDE[Types in Microsoft.VisualBasic.MyServices namespace not available](~/includes/core-changes/visualbasic/3.0/microsoft.visualbasic.myservices-unavailable.md)]

***

[!INCLUDE[vbNewLine is obsolete](~/includes/core-changes/visualbasic/3.0/vbnewline-is-obsolete.md)]

***

## See also

- [APIs that always throw exceptions on .NET Core](unsupported-apis.md)
- [.NET Framework technologies unavailable on .NET Core](../porting/net-framework-tech-unavailable.md)
