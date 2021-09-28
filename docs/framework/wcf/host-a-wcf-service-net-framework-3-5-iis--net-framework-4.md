---
description: "Learn more about: How to: Host a WCF Service Written with .NET Framework 3.5 in IIS Running Under .NET Framework 4"
title: "How to: Host a WCF Service Written with .NET Framework 3.5 in IIS Running Under .NET Framework 4"
ms.date: "03/30/2017"
ms.topic: how-to
ms.assetid: 9aabc785-068d-4d32-8841-3ef39308d8d6
---
# How to: Host a WCF Service Written with .NET Framework 3.5 in IIS Running Under .NET Framework 4

When hosting a Windows Communication Foundation (WCF) service written with .NET Framework 3.5 on a machine running .NET Framework 4, you may get a <xref:System.ServiceModel.ProtocolException> with the following text.

```output
Unhandled Exception: System.ServiceModel.ProtocolException: The content type text/html; charset=utf-8 of the response message does not match the content type of the binding (application/soap+xml; charset=utf-8). If using a custom encoder, be sure that the IsContentTypeSupported method is implemented properly. The first 1024 bytes of the response were: '<html>    <head>        <title>The application domain or application pool is currently running version 4.0 or later of the .NET Framework. This can occur if IIS settings have been set to 4.0 or later for this Web application, or if you are using version 4.0 or later of the ASP.NET Web Development Server. The <compilation> element in the Web.config file for this Web application does not contain the required 'targetFrameworkMoniker' attribute for this version of the .NET Framework (for example, '<compilation targetFrameworkMoniker=".NETFramework,Version=v4.0">'). Update the Web.config file with this attribute, or configure the Web application to use a different version of the .NET Framework.</title>...
```

 Or if you try to browse to the service's .svc file you may see an error page with the following text.

```output
The application domain or application pool is currently running version 4.0 or later of the .NET Framework. This can occur if IIS settings have been set to 4.0 or later for this Web application, or if you are using version 4.0 or later of the ASP.NET Web Development Server. The <compilation> element in the Web.config file for this Web application does not contain the required 'targetFrameworkMoniker' attribute for this version of the .NET Framework (for example, '<compilation targetFrameworkMoniker=".NETFramework,Version=v4.0">'). Update the Web.config file with this attribute, or configure the Web application to use a different version of the .NET Framework.
```

 These errors occur because the application domain IIS is running within is running .NET Framework 4 and the WCF service is expecting to run under .NET Framework 3.5. This topic explains the modifications required to get the service to run.

 Next find the <`compilers`> element and change the CompilerVersion provider option to have a value of 4.0. By default, there are two <`compiler`> elements under the <`compilers`> element. You must update the CompilerVersion provider option for both as shown in the following example.

```xml
<system.codedom>
      <compilers>
        <compiler language="c#;cs;csharp" extension=".cs" warningLevel="4"
                  type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <providerOption name="CompilerVersion" value="v3.5"/>
          <providerOption name="WarnAsError" value="false"/>
        </compiler>
        <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" warningLevel="4"
                  type="Microsoft.VisualBasic.VBCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <providerOption name="CompilerVersion" value="v3.5"/>
          <providerOption name="OptionInfer" value="true"/>
          <providerOption name="WarnAsError" value="false"/>
        </compiler>
      </compilers>
    </system.codedom>
```

### Add the required targetFramework attribute

1. Open the service's Web.config file and look for the <`compilation`> element.

2. Add the `targetFramework` attribute to the <`compilation`> element as shown in the following example.

    ```xml
    <compilation debug="false"
            targetFramework="4.0">

            <assemblies>
              <add assembly="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
              <add assembly="System.Xml.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
              <add assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
              <add assembly="System.Data.DataSetExtensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
            </assemblies>

          </compilation>
    ```

3. Find the <`compilers`> element and change the CompilerVersion provider option to have a value of 4.0. By default, there are two <`compiler`> elements under the <`compilers`> element. You must update the CompilerVersion provider option for both as shown in the following example.

    ```xml
    <system.codedom>
          <compilers>
            <compiler language="c#;cs;csharp" extension=".cs" warningLevel="4"
                      type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
              <providerOption name="CompilerVersion" value="v3.5"/>
              <providerOption name="WarnAsError" value="false"/>
            </compiler>
            <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" warningLevel="4"
                      type="Microsoft.VisualBasic.VBCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
              <providerOption name="CompilerVersion" value="v3.5"/>
              <providerOption name="OptionInfer" value="true"/>
              <providerOption name="WarnAsError" value="false"/>
            </compiler>
          </compilers>
        </system.codedom>
    ```
