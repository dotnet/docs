---
title: "Walkthrough: Creating Direct3D9 Content for Hosting in WPF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "cpp"
helpviewer_keywords: 
  - "WPF [WPF], creating Direct3D9 content"
  - "Direct3D9 [WPF interoperability], creating Direct3D9 content"
ms.assetid: 286e98bc-1eaa-4b5e-923d-3490a9cca5fc
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Creating Direct3D9 Content for Hosting in WPF
This walkthrough shows how to create Direct3D9 content that is suitable for hosting in a Windows Presentation Foundation (WPF) application. For more information on hosting Direct3D9 content in WPF applications, see [WPF and Direct3D9 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-direct3d9-interoperation.md).  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create a Direct3D9 project.  
  
-   Configure the Direct3D9 project for hosting in a WPF application.  
  
 When you are finished, you will have a DLL that contains Direct3D9 content for use in a WPF application.  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev10_long](../../../../includes/vs-dev10-long-md.md)].  
  
-   DirectX SDK 9or later.  
  
## Creating the Direct3D9 Project  
 The first step is to create and configure the Direct3D9 project.  
  
#### To create the Direct3D9 project  
  
1.  Create a new Win32 Project in C++ named `D3DContent`.  
  
     The Win32 Application Wizard opens and displays the Welcome screen.  
  
2.  Click **Next**.  
  
     The Application Settings screen appears.  
  
3.  In the **Application type:** section, select the **DLL** option.  
  
4.  Click **Finish**.  
  
     The D3DContent project is generated.  
  
5.  In Solution Explorer, right-click the D3DContent project and select **Properties**.  
  
     The **D3DContent Property Pages** dialog box opens.  
  
6.  Select the **C/C++** node.  
  
7.  In the **Additional Include Directories** field, specify the location of the DirectX include folder. The default location for this folder is %ProgramFiles%\Microsoft DirectX SDK (*version*)\Include.  
  
8.  Double-click the **Linker** node to expand it.  
  
9. In the **Additional Library Directories** field, specify the location of the DirectX libraries folder. The default location for this folder is %ProgramFiles%\Microsoft DirectX SDK (*version*)\Lib\x86.  
  
10. Select the **Input** node.  
  
11. In the **Additional Dependencies** field, add the `d3d9.lib` and `d3dx9.lib` files.  
  
12. In Solution Explorer, add a new module definition file (.def) named `D3DContent.def` to the project.  
  
## Creating the Direct3D9 Content  
 To get the best performance, your Direct3D9 content must use particular settings. The following code shows how to create a Direct3D9 surface that has the best performance characteristics. For more information, see [Performance Considerations for Direct3D9 and WPF Interoperability](../../../../docs/framework/wpf/advanced/performance-considerations-for-direct3d9-and-wpf-interoperability.md).  
  
#### To create the Direct3D9 content  
  
1.  Using Solution Explorer, add three C++ classes to the project named the following.  
  
     `CRenderer` (with virtual destructor)  
  
     `CRendererManager`  
  
     `CTriangleRenderer`  
  
2.  Open Renderer.h in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#RendererH](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/renderer.h#rendererh)]  
  
3.  Open Renderer.cpp in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#RendererCPP](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/renderer.cpp#renderercpp)]  
  
4.  Open RendererManager.h in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#RendererManagerH](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/renderermanager.h#renderermanagerh)]  
  
5.  Open RendererManager.cpp in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#RendererManagerCPP](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/renderermanager.cpp#renderermanagercpp)]  
  
6.  Open TriangleRenderer.h in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#TriangleRendererH](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/trianglerenderer.h#trianglerendererh)]  
  
7.  Open TriangleRenderer.cpp in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#TriangleRendererCPP](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/trianglerenderer.cpp#trianglerenderercpp)]  
  
8.  Open stdafx.h in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#StdafxH](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/stdafx.h#stdafxh)]  
  
9. Open dllmain.cpp in the Code Editor and replace the automatically generated code with the following code.  
  
     [!code-cpp[System.Windows.Interop.D3DImage#DllMain](../../../../samples/snippets/cpp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/cpp/dllmain.cpp#dllmain)]  
  
10. Open D3DContent.def in the code editor.  
  
11. Replace the automatically generated code with the following code.  
  
    ```  
    LIBRARY "D3DContent"  
  
    EXPORTS  
  
    SetSize  
    SetAlpha  
    SetNumDesiredSamples  
    SetAdapter  
  
    GetBackBufferNoRef  
    Render  
    Destroy  
    ```  
  
12. Build the project.  
  
## Next Steps  
  
-   Host the Direct3D9 content in a WPF application. For more information, see [Walkthrough: Hosting Direct3D9 Content in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-direct3d9-content-in-wpf.md).  
  
## See Also  
 <xref:System.Windows.Interop.D3DImage>  
 [Performance Considerations for Direct3D9 and WPF Interoperability](../../../../docs/framework/wpf/advanced/performance-considerations-for-direct3d9-and-wpf-interoperability.md)  
 [Walkthrough: Hosting Direct3D9 Content in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-direct3d9-content-in-wpf.md)
