---
title: "How to: Create COM Wrappers"
description: Create Component Object Model (COM) wrappers using Visual Studio or .NET tools (Tlbimp.exe and Regasm.exe). Both methods generate two types of COM wrappers.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "COM,wrappers creating"
  - "COM,wrappers Visual Studio"
ms.assetid: bdf89bea-1623-45ee-a57b-cf7c90395efa
---
# How to: Create COM Wrappers

You can create Component Object Model (COM) wrappers by using Visual Studio features or the .NET Framework tools Tlbimp.exe and Regasm.exe. Both methods generate two types of COM wrappers:

- A [Runtime Callable Wrapper](../../standard/native-interop/runtime-callable-wrapper.md) from a type library to run a COM object in managed code.

- A [COM Callable Wrapper](../../standard/native-interop/com-callable-wrapper.md) with the required registry settings to run a managed object in a native application.

In Visual Studio, you can add the COM wrapper as a reference to your project.

## Wrap COM Objects in a Managed Application

### To create a runtime callable wrapper using Visual Studio

1. Open the project for your managed application.

2. On the **Project** menu, click **Show All Files**.

3. On the **Project** menu, click **Add Reference**.

4. In the Add Reference dialog box, click the **COM** tab, select the component you want to use, and click **OK**.

     In **Solution Explorer**, note that the COM component is added to the References folder in your project.

You can now write code to access the COM object. You can begin by declaring the object, such as with an `Imports` statement for Visual Basic or a `Using` statement for C#.

> [!NOTE]
> If you want to program Microsoft Office components, first install the [Microsoft Office Primary Interop Assemblies Redistributable](https://www.microsoft.com/Download/details.aspx?id=3508).
  
### To create a runtime callable wrapper using .NET Framework tools  
  
- Run the [Tlbimp.exe (Type Library Importer)](../tools/tlbimp-exe-type-library-importer.md) tool.  
  
 This tool creates an assembly that contains run-time metadata for the types defined in the original type library.  
  
## Wrap Managed Objects in a Native Application  
  
### To create a COM callable wrapper using Visual Studio  
  
1. Create a Class Library project for the managed class that you want to run in native code. The class must have a parameterless constructor.  
  
     Verify that you have a complete four-part version number for your assembly in the AssemblyInfo file. This number is required for maintaining versioning in the Windows registry. For more information about version numbers, see [Assembly Versioning](../../standard/assembly/versioning.md).  
  
2. On the **Project** menu, click **Properties**.  
  
3. Click the **Compile** tab.  
  
4. Select the **Register for COM interop** check box.  
  
 When you build the project, the assembly is automatically registered for COM interop. If you are building a native application in Visual Studio, you can use the assembly by clicking **Add Reference** on the **Project** menu.  
  
### To create a COM callable wrapper using .NET Framework tools  
  
Run the [Regasm.exe (Assembly Registration Tool)](../tools/regasm-exe-assembly-registration-tool.md) tool.  
  
This tool reads the assembly metadata and adds the necessary entries to the registry. As a result, COM clients can create .NET Framework classes transparently. You can use the assembly as if it were a native COM class.  
  
You can run Regasm.exe on an assembly located in any directory, and then run the [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md) to move it to the global assembly cache. Moving the assembly does not invalidate location registry entries, because the global assembly cache is always examined if the assembly is not found elsewhere.  
  
## See also

- [Runtime Callable Wrapper](../../standard/native-interop/runtime-callable-wrapper.md)
- [COM Callable Wrapper](../../standard/native-interop/com-callable-wrapper.md)
