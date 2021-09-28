---
description: "Learn more about: Modeling and Mapping"
title: "Modeling and Mapping"
ms.date: "03/30/2017"
ms.assetid: ec8a9515-3708-4cde-a688-4d8e6975f150
---
# Modeling and Mapping

In the Entity Framework, you can define the conceptual model, storage model, and the mapping between the two in the way that best suits your application. The Entity Data Model Tools in Visual Studio allow you to create an .[edmx file](/previous-versions/dotnet/netframework-4.0/cc982042(v=vs.100)) from a database or a graphical model and then update that file when either the database or model changes.  
  
 Starting with the Entity Framework 4.1 you can also create a model programmatically using Code First development. There are two different scenarios for Code First development. In both cases, the developer defines a model by coding .NET Framework class definitions, and then optionally specifies additional mapping or configuration by using Data Annotations or the fluent API.  
  
 For more information, see [Creating a Model](/ef/ef6/modeling/).  
  
 You can also use the EDM Generator, which is included with the .NET Framework. The EdmGen.exe generates the .csdl, .ssdl, and .msl files from an existing data source. You can also manually create the model and mapping content. For more information, see [EDM Generator (EdmGen.exe)](edm-generator-edmgen-exe.md).
