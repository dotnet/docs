---
title: Using Visual Studio .NET Management Extensions and the POS for .NET WMI Management Classes
description: Using Visual Studio .NET Management Extensions and the POS for .NET WMI Management Classes (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Using Visual Studio .NET Management Extensions and the POS for .NET WMI Management Classes (POS for .NET v1.14 SDK Documentation)

You can use Server Explorer in Microsoft Visual Studio 2013 to navigate the **Microsoft.PointOfService** namespace and drag the instances of the classes into your project’s Class Designer.

This feature requires that Visual Studio 2013 and POS for .NET are installed on the local development computer.

## To use the extension

1. Launch Visual Studio 2013 and, from the **VIEW** menu, open the **Server Explorer** window.

2. Expand the **Servers** node, and then expand the **Machine** node.

3. Right-click the **Management Classes** node and then click **Add Classes** on the shortcut menu.

4. In the **Add Classes** dialog box, expand the **root\\MicrosoftPointOfService** node in the **Available Classes** tree view.

5. Select the **DeviceProperty** class, and then click **Add** to add the class to the Server Explorer. Repeat this step for the **LogicalDevice**, **PosDevice**, and **ServiceObject** classes.

## To use the management classes

1. Create a .NET project.

2. Open the Server Explorer.

3. Right-click the **DeviceProperty** node, and then click **Generate Managed Class** on the shortcut menu to add the generated class to the project. Repeat this step for the **LogicalDevice**, **PosDevice**, and **ServiceObject** classes to generate managed classes.

## To use an instance of a management class

1. In the Server Explorer, expand the desired class to list the available class objects.

2. Drag the instances onto the projects class designer.

## Example

The following code example demonstrates the use of the **PosDevice** class **GetInstances** method to enumerate Point of Service devices. It creates a collection of the devices within a scope. It then lists the type, name and path for each device in the collection and indicates whether the device is enabled or disabled.

```csharp
using System;
using System.Management;
using ROOT.MICROSOFTPOINTOFSERVICE;

namespace Management
{
   public class Test
   {
      public Test()
      {
         ManagementScope scope = new ManagementScope("root\\microsoftpointofservice");
         scope.Connect();
         PosDevice.PosDeviceCollection devices = PosDevice.GetInstances(scope, "");
         string format = "{0,10}\t{1,25}\t{2}\t{3,50}";
         if( devices.Count > 0 )
            Console.WriteLine(format, "Type", "Name", "Enabled", "Path");
         foreach( PosDevice d in devices )
         {
            Console.WriteLine(format, d.Type, d.SoName, d.Enabled ? 'Y' : 'N', d.Path);
         }
      }

      static int Main()
      {
         Test t = new Test();
         return 0;
      }
   }
}
```

## See Also

#### Other Resources

- [POS Device Manager](pos-device-manager.md)
- [Using the POS Device Manager Command-Line Tool](using-the-pos-device-manager-command-line-tool.md)
- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
