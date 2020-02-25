---
title: Walkthrough - Accessing a Web Service by Using Type Providers (F#)
description: Walkthrough - Accessing a Web Service by Using Type Providers (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 63374fa9-8fb8-43ac-bcb9-ef2290d9f851
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/accessing-a-web-service 
---

# Walkthrough: Accessing a Web Service by Using Type Providers (F#)

This walkthrough shows you how to use the Web Services Description Language (WSDL) type provider that is available in F# 3.0 to access a WSDL service. In other .NET languages, you generate the code to access the web service by calling svcutil.exe, or by adding a web reference in, for example, a C# project to get Visual Studio to call svcutil.exe for you. In F#, you have the additional option of using the WSDL type provider, so as soon as you write the code that creates the WsdlService type, the types are generated and become available. This process relies on the service being available when you are writing the code.

This walkthrough illustrates the following tasks. You must complete them in this order for the walkthrough to succeed:


- Creating the project
<br />

- Configuring the type provider
<br />

- Calling the web service, and processing the results
<br />


## Creating the project
In the step, you create a project and add the appropriate references to use a WSDL type provider.


#### To create and set up an F# project

1. Open a new F# Console Application project.
<br />

2. In **Solution Explorer**, open the shortcut menu for the project's **Reference** node, and then choose **Add Reference**.
<br />

3. In the **Assemblies** area, choose **Framework**, and then, in the list of available assemblies, choose **System.Runtime.Serialization** and **System.ServiceModel**.
<br />

4. In the **Assemblies** area, choose **Extensions**.
<br />

5. In the list of available assemblies, choose **FSharp.Data.TypeProviders**, and then choose the **OK** button to add references to these assemblies.
<br />

## Configuring the type provider
In this step, you use the WSDL type provider to generate types for the TerraServer web service.


#### To configure the type provider and generate types

1. Add the following line of code to open the type provider namespace.
<br />

```fsharp
  open System
  open System.ServiceModel
  open Microsoft.FSharp.Linq
  open Microsoft.FSharp.Data.TypeProviders
```

2. Add the following line of code to invoke the type provider with a web service. In this example, use the TerraServer web service.
<br />

```fsharp
  type TerraService = WsdlService<" HYPERLINK "http://terraserver-usa.com/TerraService2.asmx?WSDL" http://msrmaps.com/TerraService2.asmx?WSDL">
```

  A red squiggle appears under this line of code if the service URI is misspelled or if the service itself is down or isn’t performing. If you point to the code, an error message describes the problem. You can find the same information in the **Error List** window or in the **Output Window** after you build.
<br />  There are two ways to specify configuration settings for a WSDL connection, by using the app.config file for the project, or by using the static type parameters in the type provider declaration. You can use svcutil.exe to generate appropriate configuration file elements. For more information about using svcutil.exe to generate configuration information for a web service, see [ServiceModel Metadata Utility Tool &#40;Svcutil.exe&#41;](https://msdn.microsoft.com/library/aa347733.aspx).For a full description of the static type parameters for the WSDL type provider, see [WsdlService Type Provider &#40;F&#35;&#41;](WsdlService-Type-Provider-%5BFSharp%5D.md).
<br />

## Calling the web service, and processing the results
Each web service has its own set of types that are used as parameters for its method calls. In this step, you prepare these parameters, call a web method, and process the information that it returns.


#### To call the web service, and process the results

1. The web service might time out or stop functioning, so you should include the web service call in an exception handling block. Write the following code to try to get data from the web service.
<br />

```fsharp
  try
  let terraClient = TerraService.GetTerraServiceSoap ()
  let myPlace = new TerraService.ServiceTypes.msrmaps.com.Place(City = "Redmond", State = "Washington", Country = "United States")
  let myLocation = terraClient.ConvertPlaceToLonLatPt(myPlace)
  printfn "Redmond Latitude: %f Longitude: %f" (myLocation.Lat) (myLocation.Lon)
  with
  | :? ServerTooBusyException as exn ->
  let innerMessage =
  match (exn.InnerException) with
  | null -> ""
  | innerExn -> innerExn.Message
  printfn "An exception occurred:\n %s\n %s" exn.Message innerMessage
  | exn -> printfn "An exception occurred: %s" exn.Message
```

Notice that you create the data types that are needed for the web service, such as **Place** and **Location**, as nested types under the WsdlService type **TerraService**.
<br />


## See Also
[WsdlService Type Provider &#40;F&#35;&#41;](WsdlService-Type-Provider-%5BFSharp%5D.md)

[Type Providers](Type-Providers.md)