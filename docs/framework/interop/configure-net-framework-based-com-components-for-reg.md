---
title: "How to: Configure .NET Framework-Based COM Components for Registration-Free Activation"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "components [.NET Framework], manifest"
  - "application manifests [.NET Framework]"
  - "manifests [.NET Framework]"
  - "registration-free COM interop, configuring .NET-based components"
  - "activation, registration-free"
ms.assetid: 32f8b7c6-3f73-455d-8e13-9846895bd43b
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure .NET Framework-Based COM Components for Registration-Free Activation
Registration-free activation for .NET Framework-based components is only slightly more complicated than it is for COM components. The setup requires two manifests:  
  
-   COM applications must have a Win32-style application manifest to identify the managed component.  
  
-   .NET Framework-based components must have a component manifest for activation information needed at run time.  
  
 This topic describes how to associate an application manifest with an application; associate a component manifest with a component; and embed a component manifest in an assembly.  
  
### To create an application manifest  
  
1.  Using an XML editor, create (or modify) the application manifest owned by the COM application that is interoperating with one or more managed components.  
  
2.  Insert the following standard header at the beginning of the file:  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
    ```  
  
     For information about manifest elements and their attributes, see [Application Manifests](https://msdn.microsoft.com/library/windows/desktop/aa374191.aspx).  
  
3.  Identify the owner of the manifest. In the following example, `myComApp` version 1 owns the manifest file.  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
      <assemblyIdentity type="win32"   
                        name="myOrganization.myDivision.myComApp"   
                        version="1.0.0.0"   
                        processorArchitecture="msil"   
      />  
    ```  
  
4.  Identify dependent assemblies. In the following example, `myComApp` depends on `myManagedComp`.  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
      <assemblyIdentity type="win32"   
                        name="myOrganization.myDivision.myComApp"   
                        version="1.0.0.0"   
                        processorArchitecture="x86"   
                        publicKeyToken="8275b28176rcbbef"  
      />  
      <dependency>  
        <dependentAssembly>  
          <assemblyIdentity type="win32"   
                        name="myOrganization.myDivision.myManagedComp"   
                        version="6.0.0.0"   
                        processorArchitecture="X86"   
                        publicKeyToken="8275b28176rcbbef"  
          />  
        </dependentAssembly>  
      </dependency>  
    </assembly>  
    ```  
  
5.  Save and name the manifest file. The name of an application manifest is the name of the assembly executable followed by the .manifest extension. For example, the application manifest file name for myComApp.exe is myComApp.exe.manifest.  
  
 You can install an application manifest in the same directory as the COM application. Alternatively, you can add it as a resource to the application's .exe file. For additional information, For more information, see [About Side-by-Side Assemblies](https://msdn.microsoft.com/library/windows/desktop/ff951640.aspx).  
  
#### To create a component manifest  
  
1.  Using an XML editor, create a component manifest to describe the managed assembly.  
  
2.  Insert the following standard header at the beginning of the file:  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
    ```  
  
3.  Identify the owner of the file. The `<assemblyIdentity>` element of the `<dependentAssembly>` element in application manifest file must match the one in the component manifest. In the following example, `myManagedComp` version 1.2.3.4 owns the manifest file.  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
           <assemblyIdentity  
                        name="myOrganization.myDivision.myManagedComp"  
                        version="1.2.3.4"  
                        publicKeyToken="8275b28176rcbbef"  
                        processorArchitecture="msil"  
           />  
    ```  
  
4.  Identify each class in the assembly. Use the `<clrClass>` element to uniquely identify each class in the managed assembly. The element, which is a subelement of the `<assembly>` element, has the attributes described in the following table.  
  
    |Attribute|Description|Required|  
    |---------------|-----------------|--------------|  
    |`clsid`|The identifier that specifies the class to be activated.|Yes|  
    |`description`|A string that informs the user about the component. An empty string is the default.|No|  
    |`name`|A string that represents the managed class.|Yes|  
    |`progid`|The identifier to be used for late-bound activation.|No|  
    |`threadingModel`|The COM threading model. "Both" is the default value.|No|  
    |`runtimeVersion`|Specifies the common language runtime (CLR) version to use. If you do not specify this attribute, and the CLR is not already loaded, the component is loaded with the latest installed CLR prior to CLR version 4. If you specify v1.0.3705, v1.1.4322, or v2.0.50727, the version automatically rolls forward to the latest installed CLR version prior to CLR version 4 (usually v2.0.50727). If another version of the CLR is already loaded and the specified version can be loaded side-by-side in-process, the specified version is loaded; otherwise, the loaded CLR is used. This might cause a load failure.|No|  
    |`tlbid`|The identifier of the type library that contains type information about the class.|No|  
  
     All attribute tags are case-sensitive. You can obtain CLSIDs, ProgIDs, threading models, and the runtime version by viewing the exported type library for the assembly with the OLE/COM ObjectViewer (Oleview.exe).  
  
     The following component manifest identifies two classes, `testClass1` and `testClass2`.  
  
    ```xml  
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>  
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
           <assemblyIdentity  
                        name="myOrganization.myDivision.myManagedComp"  
                        version="1.2.3.4"   
                        publicKeyToken="8275b28176rcbbef"  
           />  
           <clrClass  
                        clsid="{65722BE6-3449-4628-ABD3-74B6864F9739}"  
                        progid="myManagedComp.testClass1"  
                        threadingModel="Both"  
                        name="myManagedComp.testClass1"  
                        runtimeVersion="v1.0.3705">  
           </clrClass>  
           <clrClass  
                        clsid="{367221D6-3559-3328-ABD3-45B6825F9732}"  
                        progid="myManagedComp.testClass2"  
                        threadingModel="Both"  
                        name="myManagedComp.testClass2"  
                        runtimeVersion="v1.0.3705">  
           </clrClass>  
           <file name="MyManagedComp.dll">  
           </file>  
    </assembly>  
    ```  
  
5.  Save and name the manifest file. The name of a component manifest is the name of the assembly library followed by the .manifest extension. For example, the myManagedComp.dll is myManagedComp.manifest.  
  
 You must embed the component manifest as a resource in the assembly.  
  
#### To embed a component manifest in a managed assembly  
  
1.  Create a resource script that contains the following statement:  
  
     `RT_MANIFEST 1 myManagedComp.manifest`  
  
     In this statement, `myManagedComp.manifest` is the name of the component manifest being embedded. For this example, the script file name is `myresource.rc`.  
  
2.  Compile the script using the Microsoft Windows Resource Compiler (Rc.exe). At the command prompt, type the following command:  
  
     `rc myresource.rc`  
  
     Rc.exe produces the `myresource.res` resource file.  
  
3.  Compile the assembly's source file again and specify the resource file by using the **/win32res** option:  
  
    ```  
    /win32res:myresource.res  
    ```  
  
     Again, `myresource.res` is the name of the resource file containing embedded resource.  
  
## See Also  
 [Registration-Free COM Interop](registration-free-com-interop.md)  
 [Requirements for Registration-Free COM Interop](https://msdn.microsoft.com/library/0c43bc57-eecf-4e6c-8114-490141cce4da(v=vs.100)))  
 [Configuring COM Components for Registration-Free Activation](https://msdn.microsoft.com/library/bfe9b02f-d964-4784-960e-a1f94692fbfe(v=vs.100)))  
 [Registration-Free Activation of .NET-Based Components: A Walkthrough](https://msdn.microsoft.com/library/ms973915.aspx)
