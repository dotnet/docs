---
title: System.Resources.SatelliteContractVersionAttribute class
description: Learn about the System.Resources.SatelliteContractVersionAttribute class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Resources.SatelliteContractVersionAttribute class

[!INCLUDE [context](includes/context.md)]

In desktop apps, the <xref:System.Resources.SatelliteContractVersionAttribute> attribute establishes a contract between a main assembly and all its satellites. You apply this attribute to your main assembly, and pass it the version number of the satellite assemblies that will work with this version of the main assembly. When the resource manager (<xref:System.Resources.ResourceManager> object) looks up resources, it explicitly loads the satellite version specified by this attribute on the main assembly.

When you update the main assembly, you increment its assembly version number. However, you might not want to ship new copies of your satellite assemblies if the existing ones are compatible with your app. In this case, increment the main assembly's version number but leave the satellite contract version number the same. The resource manager will use your existing satellite assemblies.

If you want to revise a satellite assembly but not the main assembly, increment the version number on your satellite. In this case, ship a publisher policy assembly along with your satellite assembly stating that your new satellite assembly has backward compatibility with your old satellite assembly. The resource manager will still use the old contract number written into your main assembly based on the <xref:System.Resources.SatelliteContractVersionAttribute> attribute; however, the loader will bind to the satellite assembly version that is specified by the policy assembly.

A vendor of a shared component uses a publisher policy assembly to make a compatibility statement about a particular version of a released assembly. A publisher policy assembly is a strongly named assembly that has a name in the format `policy.<major>.<minor>.<ComponentAssemblyName>`, and is registered in the [Global Assembly Cache (GAC)](../../framework/app-domains/gac.md). The publisher policy is generated from an XML configuration file (see the [\<bindingRedirect> Element](../../framework/configure-apps/file-schema/runtime/bindingredirect-element.md)) by using the [Al.exe (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md) tool. The Assembly Linker is used with the `/link` option to link the XML configuration file to a manifest assembly, which is then stored in the global assembly cache. The publisher policy assemblies can be used when a vendor ships a maintenance release (service pack) that contains bug fixes.

## Windows 8.x Store apps

This attribute is ignored in Windows 8.x Store apps, because package resource index (PRI) files do not have versioning semantics. In addition, the Windows 8.x Store packaging model requires all resources to ship in the same package, with no possibility of redeploying satellite assemblies or PRI files.
