---
title: Windows Forms breaking changes
description: Lists the breaking changes in Windows Forms for .NET Core 3.0 and 3.1.
ms.date: 09/08/2020
---
# Breaking changes in Windows Forms for .NET Core 3.0 and 3.1

Windows Forms support was added to .NET Core in version 3.0. This article lists breaking changes for Windows Forms by the .NET version in which they were introduced. If you're upgrading a Windows Forms app from .NET Framework or from a previous version of .NET Core (3.0 or later), this article applies to you.

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [Removed controls](#removed-controls) | 3.1 |
| [CellFormatting event not raised if tooltip is shown](#cellformatting-event-not-raised-if-tooltip-is-shown) | 3.1 |
| [Control.DefaultFont changed to Segoe UI 9 pt](#default-control-font-changed-to-segoe-ui-9-pt) | 3.0 |
| [Modernization of the FolderBrowserDialog](#modernization-of-the-folderbrowserdialog) | 3.0 |
| [SerializableAttribute removed from some Windows Forms types](#serializableattribute-removed-from-some-windows-forms-types) | 3.0 |
| [AllowUpdateChildControlIndexForTabControls compatibility switch not supported](#allowupdatechildcontrolindexfortabcontrols-compatibility-switch-not-supported) | 3.0 |
| [DomainUpDown.UseLegacyScrolling compatibility switch not supported](#domainupdownuselegacyscrolling-compatibility-switch-not-supported) | 3.0 |
| [DoNotLoadLatestRichEditControl compatibility switch not supported](#donotloadlatestricheditcontrol-compatibility-switch-not-supported) | 3.0 |
| [DoNotSupportSelectAllShortcutInMultilineTextBox compatibility switch not supported](#donotsupportselectallshortcutinmultilinetextbox-compatibility-switch-not-supported) | 3.0 |
| [DontSupportReentrantFilterMessage compatibility switch not supported](#dontsupportreentrantfiltermessage-compatibility-switch-not-supported) | 3.0 |
| [EnableVisualStyleValidation compatibility switch not supported](#enablevisualstylevalidation-compatibility-switch-not-supported) | 3.0 |
| [UseLegacyContextMenuStripSourceControlValue compatibility switch not supported](#uselegacycontextmenustripsourcecontrolvalue-compatibility-switch-not-supported) | 3.0 |
| [UseLegacyImages compatibility switch not supported](#uselegacyimages-compatibility-switch-not-supported) | 3.0 |
| [About and SplashScreen templates are broken for Visual Basic](#about-and-splashscreen-templates-are-broken) | 3.0 |

## .NET Core 3.1

[!INCLUDE[Removed controls](~/includes/core-changes/windowsforms/3.1/remove-controls-3.1.md)]

***

[!INCLUDE[CellFormatting event](~/includes/core-changes/windowsforms/3.1/cellformatting-event-not-raised.md)]

***

## .NET Core 3.0

[!INCLUDE[Control.DefaultFont changed to Segoe UI 9pt](~/includes/core-changes/windowsforms/3.0/control-defaultfont-changed.md)]

***

[!INCLUDE[Modernization of the FolderBrowserDialog](~/includes/core-changes/windowsforms/3.0/modernized-folderbrowserdialog.md)]

***

[!INCLUDE[SerializableAttribute removed from some Windows Forms types](~/includes/core-changes/windowsforms/3.0/remove-serializationattribute.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.AllowUpdateChildControlIndexForTabControls compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-allowupdatechildcontrolindexfortabcontrols.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.DomainUpDown.UseLegacyScrolling compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacyscrolling.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.DoNotLoadLatestRichEditControl compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-donotloadlatestricheditcontrol.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.DoNotSupportSelectAllShortcutInMultilineTextBox compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-donotsupportselectallshortcutinmultilinetextbox.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.DontSupportReentrantFilterMessage compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-dontsupportreentrantfiltermessage.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.EnableVisualStyleValidation compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-enablevisualstylevalidation.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.UseLegacyContextMenuStripSourceControlValue compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacycontextmenustripsourcecontrolvalue.md)]

***

[!INCLUDE[Switch.System.Windows.Forms.UseLegacyImages compatibility switch not supported](~/includes/core-changes/windowsforms/3.0/deprecate-uselegacyimages.md)]

***

[!INCLUDE[About and SplashScreen templates are broken for Visual Basic](~/includes/core-changes/visualbasic/3.0/vb-winforms-splash-about-broken.md)]

***

## See also

- [Port a Windows Forms app to .NET Core](/dotnet/desktop/winforms/migration/?view=netdesktop-6.0&preserve-view=true)
