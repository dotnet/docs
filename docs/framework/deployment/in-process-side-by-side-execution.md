---
title: "In-Process Side-by-Side Execution"
description: Use in-process side-by-side hosting to execute many versions of the common language runtime (CLR) in a single .NET process.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "in-process side-by-side execution"
  - "side-by-side execution, in-process"
ms.assetid: 18019342-a810-4986-8ec2-b933a17c2267
---
# In-Process Side-by-Side Execution

Starting with the .NET Framework 4, you can use in-process side-by-side hosting to run multiple versions of the common language runtime (CLR) in a single process. By default, managed COM components run with the .NET Framework version they were built with, regardless of the .NET Framework version that is loaded for the process.  
  
## Background  

 The .NET Framework has always provided side-by-side hosting for managed code applications, but before the .NET Framework 4, it did not provide that functionality for managed COM components. In the past, managed COM components that were loaded into a process ran either with the version of the runtime that was already loaded or with the latest installed version of the .NET Framework. If this version was not compatible with the COM component, the component would fail.  
  
 The .NET Framework 4 provides a new approach to side-by-side hosting that ensures the following:  
  
- Installing a new version of the .NET Framework has no effect on existing applications.  
  
- Applications run against the version of the .NET Framework that they were built with. They do not use the new version of the .NET Framework unless expressly directed to do so. However, it is easier for applications to transition to using a new version of the .NET Framework.  
  
## Effects on Users and Developers  
  
- **End users and system administrators**. These users can now have greater confidence that when they install a new version of the runtime, either independently or with an application, it will have no impact on their computers. Existing applications will continue to run as they did before.  
  
- **Application developers**. Side-by-side hosting has almost no effect on application developers. By default, applications always run against the version of the .NET Framework they were built on; this has not changed. However, developers can override this behavior and direct the application to run under a newer version of the .NET Framework (see [scenario 2](#scenarios)).  
  
- **Library developers and consumers**. Side-by-side hosting does not solve the compatibility problems that library developers face. A library that is directly loaded by an application -- either through a direct reference or through an <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> call -- continues to use the runtime of the <xref:System.AppDomain> it is loaded into. You should test your libraries against all versions of the .NET Framework that you want to support. If an application is compiled using the .NET Framework 4 runtime but includes a library that was built using an earlier runtime, that library will use the .NET Framework 4 runtime as well. However, if you have an application that was built using an earlier runtime and a library that was built using the .NET Framework 4, you must force your application to also use the .NET Framework 4 (see [scenario 3](#scenarios)).  
  
- **Managed COM component developers**. In the past, managed COM components automatically ran using the latest version of the runtime installed on the computer. You can now execute COM components against the version of the runtime they were built with.  
  
     As shown by the following table, components that were built with the .NET Framework version 1.1 can run side by side with version 4 components, but they cannot run with version 2.0, 3.0, or 3.5 components, because side-by-side hosting is not available for those versions.  
  
    |.NET Framework version|1.1|2.0 - 3.5|4|  
    |----------------------------|---------|----------------|-------|  
    |1.1|Not applicable|No|Yes|  
    |2.0 - 3.5|No|Not applicable|Yes|  
    |4|Yes|Yes|Not applicable|  
  
> [!NOTE]
> .NET Framework versions 3.0 and 3.5 are built incrementally on version 2.0, and do not need to run side by side. These are inherently the same version.  
  
<a name="scenarios"></a>

## Common Side-by-Side Hosting Scenarios  
  
- **Scenario 1:** Native application that uses COM components built with earlier versions of the .NET Framework.  
  
     .NET Framework versions installed: The .NET Framework 4 and all other versions of the .NET Framework used by the COM components.  
  
     What to do: In this scenario, do nothing. The COM components will run with the version of the .NET Framework they were registered with.  
  
- **Scenario 2**: Managed application built with the .NET Framework 2.0 SP1 that you would prefer to run with the .NET Framework 2.0, but are willing to run on the .NET Framework 4 if version 2.0 is not present.  
  
     .NET Framework versions installed: An earlier version of the .NET Framework and the .NET Framework 4.  
  
     What to do: In the [application configuration file](../configure-apps/index.md) in the application directory, use the [\<startup> element](../configure-apps/file-schema/startup/startup-element.md) and the [\<supportedRuntime> element](../configure-apps/file-schema/startup/supportedruntime-element.md) set as follows:  
  
    ```xml  
    <configuration>  
      <startup >  
        <supportedRuntime version="v2.0.50727" />  
        <supportedRuntime version="v4.0" />  
      </startup>  
    </configuration>  
    ```  
  
- **Scenario 3:** Native application that uses COM components built with earlier versions of the .NET Framework that you want to run with the .NET Framework 4.  
  
     .NET Framework versions installed: The .NET Framework 4.  
  
     What to do: In the application configuration file in the application directory, use the `<startup>` element with the `useLegacyV2RuntimeActivationPolicy` attribute set to `true` and the `<supportedRuntime>` element set as follows:  
  
    ```xml  
    <configuration>  
      <startup useLegacyV2RuntimeActivationPolicy="true">  
        <supportedRuntime version="v4.0" />  
      </startup>  
    </configuration>  
    ```  
  
## Example  

 The following example demonstrates an unmanaged COM host that is running a managed COM component by using the version of the .NET Framework that the component was compiled to use.  
  
 To run the following example, compile and register the following managed COM component using the .NET Framework 3.5. To register the component, on the **Project** menu, click **Properties**, click the **Build** tab, and then select the **Register for COM interop** check box.  
  
```csharp
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Runtime.InteropServices;  
  
namespace BasicComObject  
{  
    [ComVisible(true), Guid("9C99C4B5-CA54-4c58-8988-49B6811BA53B")]  
    public class MyObject : SimpleObjectModel.IPrintInfo  
    {  
        public MyObject()  
        {  
        }  
        public void PrintInfo()  
        {  
            Console.WriteLine("MyObject was activated in {0} runtime in:\n\tAppDomain {1}:{2}", System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion(), AppDomain.CurrentDomain.Id, AppDomain.CurrentDomain.FriendlyName);  
        }  
    }  
}  
```  
  
 Compile the following unmanaged C++ application, which activates the COM object that is created by the previous example.  
  
```cpp
#include "stdafx.h"  
#include <string>  
#include <iostream>  
#include <objbase.h>  
#include <string.h>  
#include <process.h>  
  
using namespace std;  
  
int _tmain(int argc, _TCHAR* argv[])  
{  
    char input;  
    CoInitialize(NULL) ;  
    CLSID clsid;  
    HRESULT hr;  
    HRESULT clsidhr = CLSIDFromString(L"{9C99C4B5-CA54-4c58-8988-49B6811BA53B}",&clsid);  
    hr = -1;  
    if (FAILED(clsidhr))  
    {  
        printf("Failed to construct CLSID from String\n");  
    }  
    UUID id = __uuidof(IUnknown);  
    IUnknown * pUnk = NULL;  
    hr = ::CoCreateInstance(clsid,NULL,CLSCTX_INPROC_SERVER,id,(void **) &pUnk);  
    if (FAILED(hr))  
    {  
        printf("Failed CoCreateInstance\n");  
    }else  
    {  
        pUnk->AddRef();  
        printf("Succeeded\n");  
    }  
  
    DISPID dispid;  
    IDispatch* pPrintInfo;  
    pUnk->QueryInterface(IID_IDispatch, (void**)&pPrintInfo);  
    OLECHAR FAR* szMethod[1];  
    szMethod[0]=OLESTR("PrintInfo");
    hr = pPrintInfo->GetIDsOfNames(IID_NULL,szMethod, 1, LOCALE_SYSTEM_DEFAULT, &dispid);  
    DISPPARAMS dispparams;  
    dispparams.cNamedArgs = 0;  
    dispparams.cArgs = 0;  
    VARIANTARG* pvarg = NULL;  
    EXCEPINFO * pexcepinfo = NULL;  
    WORD wFlags = DISPATCH_METHOD ;  
;  
    LPVARIANT pvRet = NULL;  
    UINT * pnArgErr = NULL;  
    hr = pPrintInfo->Invoke(dispid,IID_NULL, LOCALE_USER_DEFAULT, wFlags,  
        &dispparams, pvRet, pexcepinfo, pnArgErr);  
    printf("Press Enter to exit");  
    scanf_s("%c",&input);  
    CoUninitialize();  
    return 0;  
}  
```  
  
## See also

- [\<startup> Element](../configure-apps/file-schema/startup/startup-element.md)
- [\<supportedRuntime> Element](../configure-apps/file-schema/startup/supportedruntime-element.md)
