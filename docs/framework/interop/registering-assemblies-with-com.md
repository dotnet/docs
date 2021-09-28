---
title: "Registering Assemblies with COM"
description: Register or unregister assemblies with COM using the Assembly Registration Tool (Regasm.exe), which adds information about the class to the system registry.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "COM interop, registering assemblies"
  - "unregistering assemblies"
  - "interoperation with unmanaged code, registering assemblies"
  - "registering assemblies"
ms.assetid: 87925795-a3ae-4833-b138-125413478551
---
# Registering Assemblies with COM

You can run a command-line tool called the [Assembly Registration Tool (Regasm.exe)](../tools/regasm-exe-assembly-registration-tool.md) to register or unregister an assembly for use with COM. Regasm.exe adds information about the class to the system registry so COM clients can use the .NET Framework class transparently. The <xref:System.Runtime.InteropServices.RegistrationServices> class provides the equivalent functionality.  
  
 A managed component must be registered in the Windows registry before it can be activated from a COM client. The following table shows the keys that Regasm.exe typically adds to the Windows registry. (000000 indicates the actual GUID value.)  
  
|GUID|Description|Registry key|  
|----------|-----------------|------------------|  
|CLSID|Class identifier|HKEY_CLASSES_ROOT\CLSID\\{000…000}|  
|IID|Interface identifier|HKEY_CLASSES_ROOT\Interface\\{000…000}|  
|LIBID|Library identifier|HKEY_CLASSES_ROOT\TypeLib\\{000…000}|  
|ProgID|Programmatic identifier|HKEY_CLASSES_ROOT\000…000|  
  
 Under the HKCR\CLSID\\{0000…0000} key, the default value is set to the ProgID of the class, and two new named values, Class and Assembly, are added. The runtime reads the Assembly value from the registry and passes it on to the runtime assembly resolver. The assembly resolver attempts to locate the assembly, based on assembly information such as the name and version number. For the assembly resolver to locate an assembly, the assembly has to be in one of the following locations:  
  
- The global assembly cache (must be a strong-named assembly).  
  
- In the application directory. Assemblies loaded from the application path are only accessible from that application.  
  
- Along an file path specified with the **/codebase** option to Regasm.exe.  
  
 Regasm.exe also creates the InProcServer32 key under the HKCR\CLSID\\{0000…0000} key. The default value for the key is set to the name of the DLL that initializes the common language runtime (Mscoree.dll).  
  
## Examining Registry Entries  

 COM interop provides a standard class factory implementation to create an instance of any .NET Framework class. Clients can call **DllGetClassObject** on the managed DLL to get a class factory and create objects, just as they would with any other COM component.  
  
 For the `InprocServer32` subkey, a reference to Mscoree.dll appears in place of a traditional COM type library to indicate that the common language runtime creates the managed object.  
  
## See also

- [Exposing .NET Framework Components to COM](exposing-dotnet-components-to-com.md)
- [How to: Reference .NET Types from COM](how-to-reference-net-types-from-com.md)
- [Calling a .NET Object](/previous-versions/dotnet/netframework-4.0/8hw8h46b(v=vs.100))
- [Deploying an Application for COM Access](/previous-versions/dotnet/netframework-4.0/c2850st8(v=vs.100))
