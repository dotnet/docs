---
title: System.Diagnostics.ProcessStartInfo.UseShellExecute property
description: Learn about the System.Diagnostics.ProcessStartInfo.UseShellExecute property.
ms.date: 01/24/2024
---
# System.Diagnostics.ProcessStartInfo.UseShellExecute property

[!INCLUDE [context](includes/context.md)]

The <xref:System.Diagnostics.ProcessStartInfo> class specifies a set of values that are used when you start a process.

Setting the <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> property to `false` enables you to redirect input, output, and error streams.

The word "shell" in this context (`UseShellExecute`) refers to a graphical shell (similar to the Windows shell) rather than command shells (for example, `bash` or `sh`) and lets users launch graphical applications or open documents.

> [!NOTE]
> <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> must be `false` if the <xref:System.Diagnostics.ProcessStartInfo.UserName> property is not `null` or an empty string, or an <xref:System.InvalidOperationException> will be thrown when the <xref:System.Diagnostics.Process.Start(System.Diagnostics.ProcessStartInfo)?displayProperty=nameWithType> method is called.

When you use the operating system shell to start processes, you can start any document (which is any registered file type associated with an executable that has a default open action) and perform operations on the file, such as printing, by using the <xref:System.Diagnostics.Process> object. When <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> is `false`, you can start only executables by using the <xref:System.Diagnostics.Process> object.

> [!NOTE]
> <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> must be `true` if you set the <xref:System.Diagnostics.ProcessStartInfo.ErrorDialog> property to `true`.

## WorkingDirectory

The <xref:System.Diagnostics.ProcessStartInfo.WorkingDirectory> property behaves differently depending on the value of the <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> property. When <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> is `true`, the <xref:System.Diagnostics.ProcessStartInfo.WorkingDirectory> property specifies the location of the executable. If <xref:System.Diagnostics.ProcessStartInfo.WorkingDirectory> is an empty string, it's assumed that the current directory contains the executable.

When <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> is `false`, the <xref:System.Diagnostics.ProcessStartInfo.WorkingDirectory> property is not used to find the executable. Instead, it is used only by the process that is started and has meaning only within the context of the new process. When <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> is `false`, the <xref:System.Diagnostics.ProcessStartInfo.FileName> property can be either a fully qualified path to the executable, or a simple executable name that the system will attempt to find within folders specified by the `PATH` environment variable. The interpretation of the search path depends on the operating system. For more information, enter [`HELP PATH`](/windows-server/administration/windows-commands/path) or [`man sh`](https://pubs.opengroup.org/onlinepubs/9699919799/basedefs/V1_chap08.html#tag_08_03) at a command prompt.
