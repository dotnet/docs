---
title: Microsoft.Win32.Registry class
description: Learn about the Microsoft.Win32.Registry class.
ms.date: 12/31/2023
ms.topic: article
---
# The Microsoft.Win32.Registry class

[!INCLUDE [context](includes/context.md)]

The <xref:Microsoft.Win32.Registry> class provides the set of standard root keys found in the registry on machines running Windows. The registry is a storage facility for information about applications, users, and default system settings. Applications can use the registry for storing information that needs to be preserved after the application is closed, and access that same information when the application is reloaded. For example, you can store color preferences, screen locations, or the size of a window. You can control this data for each user by storing the information in a different location in the registry.

The base, or root, <xref:Microsoft.Win32.RegistryKey> instances that are exposed by the `Registry` class delineate the basic storage mechanism for subkeys and values in the registry. All keys are read-only because the registry depends on their existence. The keys exposed by `Registry` are:

| Key                                             | Description                                                        |
|-------------------------------------------------|--------------------------------------------------------------------|
| <xref:Microsoft.Win32.Registry.CurrentUser>     | Stores information about user preferences.                         |
| <xref:Microsoft.Win32.Registry.LocalMachine>    | Stores configuration information for the local machine.            |
| <xref:Microsoft.Win32.Registry.ClassesRoot>     | Stores information about types (and classes) and their properties. |
| <xref:Microsoft.Win32.Registry.Users>           | Stores information about the default user configuration.           |
| <xref:Microsoft.Win32.Registry.PerformanceData> | Stores performance information for software components.            |
| <xref:Microsoft.Win32.Registry.CurrentConfig>   | Stores non-user-specific hardware information.                     |
| <xref:Microsoft.Win32.Registry.DynData>         | Stores dynamic data.                                               |

Once you've identified the root key under which you want to store/retrieve information from the registry, you can use the <xref:Microsoft.Win32.RegistryKey> class to add or remove subkeys and manipulate the values for a given key.

Hardware devices can place information in the registry automatically using the Plug and Play interface. Software for installing device drivers can place information in the registry by writing to standard APIs.

## Static methods for getting and setting values

The <xref:Microsoft.Win32.Registry> class also contains `static` <xref:Microsoft.Win32.Registry.GetValue%2A> and <xref:Microsoft.Win32.Registry.SetValue%2A> methods for setting and retrieving values from registry keys. These methods open and close registry keys each time they're used. So when you access a large number of values, they don't perform as well as analogous methods in the <xref:Microsoft.Win32.RegistryKey> class.

The <xref:Microsoft.Win32.RegistryKey> class also provides methods that allow you to:

- Set Windows access control security for registry keys.
- Test the data type of a value before retrieving it.
- Delete keys.
