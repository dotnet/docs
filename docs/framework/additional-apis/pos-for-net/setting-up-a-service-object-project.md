---
title: Setting up a Service Object Project
description: Setting up a Service Object Project (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Setting up a Service Object Project (POS for .NET v1.14 SDK Documentation)

To begin programming your Service Object, you first need to create a new **Class Library** project and add the appropriate resources to your project. To create your basic project, perform the following steps.

## To create a new class library project for your Service Object

1. Open **Visual Studio**. On the **File** menu, choose **New** and then choose **Project** to create a new project.

2. In the **New Project** dialog box, select **Class Library** from the **Visual Studio Installed Templates** list.

3. Choose an appropriate name for your Service Object. Note that **Visual Studio** creates a namespace for your project based on the name that you enter here.

## To add references to Point of Service assemblies

1. Be sure that you have installed the **Microsoft Point of Service** product.

2. From the **Solution Explorer** window, right-click the **References** drop-down and then select **Add References**.

3. On the **Browse** tab, locate the **Microsoft.PointOfService** and **Microsoft.PointOfService.ControlBase** assemblies in the **Program Files\\Microsoft Point of Service\\SDK** directory.

4. Select both assemblies and add them to your reference list.

## To add the PosAssembly global attribute to your assembly

1. The <xref:Microsoft.PointOfService.PosExplorer> requires that Service Object assemblies contain the <xref:Microsoft.PointOfService.PosAssemblyAttribute> global attribute.

2. From the Solution Explorer window, open and edit the file **AssemblyInfo.cs**.

3. At the top of the file, add a **using** directive for **Microsoft.PointOfService**, for example:

    **using Microsoft.PointOfService;**

4. Insert the global attribute, **PosAssembly**, into the file. This attribute takes a single argument for the name of your organization. For example:

    **\[assembly: PosAssembly("Your Company Name, Inc")\]**

## See Also

#### Concepts

- [Attributes for Identifying Service Objects and Assigning Hardware](attributes-for-identifying-service-objects-and-assigning-hardware.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
