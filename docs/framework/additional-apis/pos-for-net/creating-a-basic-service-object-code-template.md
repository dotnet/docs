---
title: Creating a Basic Service Object Code Template
description: Creating a Basic Service Object Code Template (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Creating a Basic Service Object Code Template (POS for .NET v1.14 SDK Documentation)

The previous section, [Setting up a Service Object Project](setting-up-a-service-object-project.md), explained how to create an empty project to begin writing your Service Object. This section continues by adding features to that sample project. The following procedures and the sample in this topic show the steps that you must follow to create a basic Service Object template.

## To create a simple class template

1. Add **using** directives for the <xref:Microsoft.PointOfService> and <xref:Microsoft.PointOfService.BaseServiceObjects> to the top of the source file.

2. Choose the POS for .NET **Base** class your Service Object will be derived from. The **Base** class you choose is based on the type of POS device for which you are developing this Service Object. (See [POS for .NET Class Tree](pos-for-net-class-tree.md))

3. If you are building your class on top of Point of Service **Basic** classes, also add a **using** directive for **Microsoft.PointOfService.BasicServiceObjects**.

4. Apply a **ServiceObject** attribute to your Service Object class. This includes the following elements:

      - Device Type
      - Service Object name
      - Description of the Service Object
      - Major version
      - Minor version

5. Create a default public parameterless constructor. This is required for <xref:Microsoft.PointOfService.PosExplorer> to create an instance of your class by using .NET reflection.

## Example

In this sample, notice the additional **using** directives, the **ServiceObject** attribute applied to the Service Object class, the **Base** class used for the Service Object class, and finally the public constructor without arguments.

```csharp
using system;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Samples.ServiceObjects.SOTemplate
{
    [ServiceObject(
                DeviceType.Msr,
                "ServiceObjectTemplate",
                "Bare bones Service Object class",
                1,
                9)]
    public class MyServiceObject : MsrBase
    {
        public MyServiceObject()
        {
        }
    }
}
```

This sample does not compile as is. Its purpose is to demonstrate what elements are necessary for any Service Object class. However, for each **POS for .NET** Service Object **Base** class, the list of abstract methods which must be implemented is different. The following sections continue to add features to the sample until it becomes a complete, functional Service Object implementation.

## See Also

#### Tasks

- [Setting up a Service Object Project](setting-up-a-service-object-project.md)
- [Adding Plug and Play Support](adding-plug-and-play-support.md)

#### Concepts

- [POS for .NET Class Tree](pos-for-net-class-tree.md)
- [Attributes for Identifying Service Objects and Assigning Hardware](attributes-for-identifying-service-objects-and-assigning-hardware.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
