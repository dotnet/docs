---
title: "How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "COM interop [Windows Forms], Windows Forms"
  - "COM [Windows Forms]"
  - "Windows Forms, unmanaged"
  - "ActiveX controls [Windows Forms], COM interop"
  - "Windows Forms, interop"
ms.assetid: a9e04765-d2de-4389-a494-a9a6d07aa6ee
---
# How to: Support COM interop by displaying each Windows Form on its own thread

You can resolve COM interoperability problems by displaying your form on a .NET Framework message loop, which you can create by using the <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType> method.

To make a Windows Form work correctly from a COM client application, you must run the form on a Windows Forms message loop. To do this, use one of the following approaches:

- Use the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method to display the Windows Form. For more information, see [How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method](com-interop-by-displaying-a-windows-form-shadow.md).

- Display each Windows Form on a separate thread.

There is extensive support for this feature in Visual Studio.

Also see [Walkthrough: Supporting COM Interop by Displaying Each Windows Form on Its Own Thread](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ms233639(v=vs.100)).

## Example

The following code example demonstrates how to display the form on a separate thread and call the <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType> method to start a Windows Forms message pump on that thread. To use this approach, you must marshal any calls to the form from the unmanaged application by using the <xref:System.Windows.Forms.Control.Invoke%2A> method.

This approach requires that each instance of a form runs on its own thread by using its own message loop. You cannot have more than one message loop running per thread. Therefore, you cannot change the client application's message loop. However, you can modify the .NET Framework component to start a new thread that uses its own message loop.

[!code-vb[System.Windows.Forms.ComInterop#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ComInterop/VB/COMForm.vb#1)]

[!code-vb[System.Windows.Forms.ComInterop#10](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ComInterop/VB/FormManager.vb#10)]

[!code-vb[System.Windows.Forms.ComInterop#100](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ComInterop/VB/Form1.vb#100)]

## Compile the code

Compile the `COMForm`, `Form1`, and `FormManager` types into an assembly called `COMWinform.dll`. Register the assembly for COM interop by using one of the methods described in [Packaging an Assembly for COM](../../interop/packaging-an-assembly-for-com.md). You can now use the assembly and its corresponding type library (.tlb) file in unmanaged applications. For example, you can use the type library as a reference in a Visual Basic 6.0 executable project.

## See also

- [Exposing .NET Framework Components to COM](../../interop/exposing-dotnet-components-to-com.md)
- [Packaging an Assembly for COM](../../interop/packaging-an-assembly-for-com.md)
- [Registering Assemblies with COM](../../interop/registering-assemblies-with-com.md)
- [How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method](com-interop-by-displaying-a-windows-form-shadow.md)
- [Windows Forms and Unmanaged Applications Overview](windows-forms-and-unmanaged-applications-overview.md)
