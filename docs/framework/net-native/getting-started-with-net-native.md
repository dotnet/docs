---
title: "Getting Started with .NET Native"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fc9e04e8-2d05-4870-8cd6-5bd276814afc
caps.latest.revision: 29
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Getting Started with .NET Native
Whether you are writing a new Windows app for Windows 10 or you are migrating an existing Windows Store app, you can follow the same set of procedures. To create a [!INCLUDE[net_native](../../../includes/net-native-md.md)] app, follow these steps:  
  
1.  [Develop a Universal Windows Platform (UWP) app that targets Windows 10](#Step1), and test the debug builds of your app to ensure that it works properly.  
  
2.  [Handle additional reflection and serialization usage](#Step2).  
  
3.  [Deploy and test the release builds of your app](#Step3).  
  
4.  [Manually resolve missing metadata](#Step4), and repeat [step 3](#Step3) until all issues are resolved.  
  
> [!NOTE]
>  If you are migrating an existing Windows Store app to [!INCLUDE[net_native](../../../includes/net-native-md.md)], be sure to review [Migrating Your Windows Store App to .NET Native](../../../docs/framework/net-native/migrating-your-windows-store-app-to-net-native.md).  
  
<a name="Step1"></a>   
## Step 1: Develop and test debug builds of your UWP app  
 Whether you are developing a new app or migrating an existing one, you follow the same process as for any Windows app.  
  
1.  Create a new UWP project in Visual Studio by using the Universal Windows app template for Visual C# or Visual Basic. By default, all UWP applications target the CoreCLR and their release builds are compiled by using the .NET Native tool chain.  
  
2.  Note that there are some known compatibility issues between compiling UWP app projects with the .NET Native tool chain and without it. Refer to the [migration guide](../../../docs/framework/net-native/migrating-your-windows-store-app-to-net-native.md) for more information.  
  
 You can now write C# or Visual Basic code against the [!INCLUDE[net_native](../../../includes/net-native-md.md)] surface area that runs on the local system (or in the simulator).  
  
> [!IMPORTANT]
>  As you develop your app, note any use of serialization or reflection in your code.  
  
 By default, debug builds are JIT-compiled to enable rapid F5 deployment, while release builds are compiled by using the [!INCLUDE[net_native](../../../includes/net-native-md.md)] pre-compilation technology. This means you should build and test the debug builds of your app to ensure that they work normally before compiling them with the .NET Native tool chain.  
  
<a name="Step2"></a>   
## Step 2: Handle additional reflection and serialization usage  
 A runtime directives file, Default.rd.xml, is automatically added to your project when you create it. If you develop in C#, it is found in your project's **Properties** folder. If you develop in Visual Basic, it is found in your project's **My Project** folder.  
  
> [!NOTE]
>  For an overview of the .NET Native compilation process that provides background on why a runtime directives file is needed, see [.NET Native and Compilation](../../../docs/framework/net-native/net-native-and-compilation.md).  
  
 The runtime directives file is used to define the metadata that your app needs at run time. In some cases, the default version of the file may be adequate. However, some code that relies on serialization or reflection may require additional entries in the runtime directives file.  
  
 **Serialization**  
 There are two categories of serializers, and both may require additional entries in the runtime directives file:  
  
-   Non-reflection based serializers. The serializers found in the .NET Framework class library, such as the <xref:System.Runtime.Serialization.DataContractSerializer>, <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, and <xref:System.Xml.Serialization.XmlSerializer> classes, do not rely on reflection. However, they do require that code be generated based on the object to be serialized or deserialized.  For more information, see the "Microsoft Serializers" section in [Serialization and Metadata](../../../docs/framework/net-native/serialization-and-metadata.md).  
  
-   Third-party serializers. Third-party serialization libraries, the most common of which is the Newtonsoft JSON serializer, are generally reflection-based and require entries in the *.rd.xml file to support object serialization and deserialization. For more information, see the "Third-Party Serializers" section in [Serialization and Metadata](../../../docs/framework/net-native/serialization-and-metadata.md).  
  
 **Methods that rely on reflection**  
 In some cases, the use of reflection in code is not obvious. Some common APIs or programming patterns aren't considered part of the reflection API but rely on reflection to execute successfully. This includes the following type instantiation and method construction methods:  
  
-   The <xref:System.Type.MakeGenericType%2A?displayProperty=nameWithType> method  
  
-   The <xref:System.Array.CreateInstance%2A?displayProperty=nameWithType> and <xref:System.Type.MakeArrayType%2A?displayProperty=nameWithType> methods  
  
-   The <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A?displayProperty=nameWithType> method.  
  
 For more information, see [APIs That Rely on Reflection](../../../docs/framework/net-native/apis-that-rely-on-reflection.md).  
  
> [!NOTE]
>  Type names used in runtime directives files must be fully qualified. For example, the file must specify "System.String" instead of "String".  
  
<a name="Step3"></a>   
## Step 3: Deploy and test the release builds of your app  
 After you’ve updated the runtime directives file, you can rebuild and deploy release builds of your app. .NET Native binaries are placed in the ILC.out subdirectory of the directory specified in the **Build output path** text box of  the project's **Properties** dialog box, **Compile** tab. Binaries that aren't in this folder haven't been compiled with .NET Native. Test your app thoroughly, and test all scenarios, including failure scenarios, on each of its target platforms.  
  
 If your app doesn’t work properly (particularly in cases where it throws [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) or [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md) exceptions at run time), follow the instructions in the next section, [Step 4: Manually resolve missing metadata](#Step4). Enabling first-chance exceptions may help you find these bugs.  
  
 When you’ve tested and debugged the debug builds of your app and you’re confident that you’ve eliminated the [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) and [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md) exceptions, you should test your app as an optimized [!INCLUDE[net_native](../../../includes/net-native-md.md)] app. To do this, change your active project configuration from **Debug** to **Release**.  
  
<a name="Step4"></a>   
## Step 4: Manually resolve missing metadata  
 The most common failure you'll encounter with [!INCLUDE[net_native](../../../includes/net-native-md.md)] that you don't encounter on the desktop is a runtime [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md), [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md), or [MissingRuntimeArtifactException](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md) exception. In some cases, the absence of metadata can manifest itself in unpredictable behavior or even in app failures. This section discusses how you can debug and resolve these exceptions by adding directives to the runtime directives file. For information about the format of runtime directives, see [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md). After you’ve added runtime directives, you should [deploy and test your app](#Step3) again and resolve any new [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md), [MissingInteropDataException](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md), and  [MissingRuntimeArtifactException](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md) exceptions until you encounter no more exceptions.  
  
> [!TIP]
>  Specify the runtime directives at a high level to enable your app to be resilient to code changes.  We recommend adding runtime directives at the namespace and type levels rather than the member level. Note that there may be a tradeoff between resiliency and larger binaries with longer compile times.  
  
 When addressing a missing metadata exception, consider these issues:  
  
-   What was the app trying to do before the exception?  
  
    -   For example, was it data binding, serializing or deserializing data, or directly using the reflection API?  
  
-   Is this an isolated case, or do you believe you'll encounter the same issue for other types?  
  
    -   For example, a [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) exception is thrown when serializing a type in the app’s object model.  If you know other types that will be serialized, you can add runtime directives for those types (or for their containing namespaces, depending on how well the code is organized) at the same time.  
  
-   Can you rewrite the code so it doesn’t use reflection?  
  
    -   For example, does the code use the `dynamic` keyword when you know what type to expect?  
  
    -   Does the code call a method that depends on reflection when some better alternative is available?  
  
> [!NOTE]
>  For additional information about handling problems that stem from differences in reflection and the availability of metadata in desktop apps and [!INCLUDE[net_native](../../../includes/net-native-md.md)], see [APIs That Rely on Reflection](../../../docs/framework/net-native/apis-that-rely-on-reflection.md).  
  
 For some specific examples of handling exceptions and other issues that occur when testing your app, see:  
  
-   [Example: Handling Exceptions When Binding Data](../../../docs/framework/net-native/example-handling-exceptions-when-binding-data.md)  
  
-   [Example: Troubleshooting Dynamic Programming](../../../docs/framework/net-native/example-troubleshooting-dynamic-programming.md)  
  
-   [Runtime Exceptions in .NET Native Apps](../../../docs/framework/net-native/runtime-exceptions-in-net-native-apps.md)  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [NIB: .NET Native Setup and Configuration](http://msdn.microsoft.com/library/7c9bc375-8b87-4c33-bede-72d513e362ec)  
 [.NET Native and Compilation](../../../docs/framework/net-native/net-native-and-compilation.md)  
 [Reflection and .NET Native](../../../docs/framework/net-native/reflection-and-net-native.md)  
 [APIs That Rely on Reflection](../../../docs/framework/net-native/apis-that-rely-on-reflection.md)  
 [Serialization and Metadata](../../../docs/framework/net-native/serialization-and-metadata.md)  
 [Migrating Your Windows Store App to .NET Native](../../../docs/framework/net-native/migrating-your-windows-store-app-to-net-native.md)
