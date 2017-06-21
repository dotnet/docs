---
title: .NET Core Runtime IDentifier (RID) catalog | Microsoft Docs
description: 
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: b2032f5d-771f-48d9-917c-587d9509035c
---
# .NET Core Runtime IDentifier (RID) catalog

RID is short for *Runtime IDentifier*. RIDs are used to identify target operating systems where an application or asset 
(that is, assembly) runs. The following are examples of RIDs: `ubuntu.14.04-x64`, `win7-x64`, or `osx.10.11-x64`. 
For the packages with native dependencies, it designates on which platforms the package can be restored. 

It's important to note that RIDs are opaque strings, that is, they have to match exactly for operations 
using them to work. As an example, let's consider the case of the [elementary OS Loki](https://elementary.io/), 
which is an OS version based on Ubuntu 16.04. Even though .NET Core and CLI work on top of that Ubuntu version, if you try to use them on elementary OS 
without any modifications, the restore operation for any package will fail. This happens because we currently don't 
have a RID that designates elementary OS as a platform.

RIDs that represent concrete operating systems usually follow this pattern: `[os].[version]-[arch]` where:
- `[os]` is the operating system moniker. For example, `ubuntu`.
- `[version]` is the operating system version in the form of a dot-separated (`.`) version number. For example, `15.10`.  
Accurate enough to reasonably enable assets to target OS platform APIs represented by that version.
  - The version **shouldn't** be marketing versions, as they often represent multiple discrete versions of the operating 
system with varying platform API surface area.
- `[arch]` is the processor architecture. For example: `x86`, `x64`, `arm`, or `arm64`.

The RID graph is defined in a package called `Microsoft.NETCore.Platforms` in a file called `runtime.json`, which you can 
see on the [CoreFX repo](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json). If 
you open this file, you can see that some of the RIDs have an `"#import"` statement in them. These statements are 
compatibility statements. That means that an RID that contains an imported RID can be a target for restoring packages 
for that RID. Slightly confusing, but let's look at an example for a macOS RID:

```json
"osx.10.11-x64": {
    "#import": [ "osx.10.11", "osx.10.10-x64" ]
}
```

The above RID specifies that `osx.10.11-x64` imports `osx.10.10-x64`. When NuGet restores packages, it
can restore packages that specify that they need `osx.10.10-x64` on `osx.10.11-x64`.

The following example shows a slightly bigger RID graph:  

- `win10-arm`
  - `win10`
  - `win81-arm`
    - `win81`
    - `win8-arm`
      - `win8`
        - `win7`
          - `win`
            - `any`

All RIDs eventually map back to the root `any` RID.

Although they look easy enough to use, there are some considerations about RIDs that you have to keep in mind when 
working with them:

* They are **opaque strings** and should be treated as black boxes.
* Don't build RIDs programmatically.
* Use RIDs that are already defined for the platform.
* The RIDs need to be specific, so don't assume anything from the actual RID value.

## Using RIDs
To be able to use RIDs, you have to know which RIDs exist. New values are added regularly to the platform. 
For the latest version, see the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo.

## Windows RIDs

* Windows 7 / Windows Server 2008 R2
    * `win7-x64`
    * `win7-x86`
* Windows 8 / Windows Server 2012
    * `win8-x64`
    * `win8-x86`
    * `win8-arm`
* Windows 8.1 / Windows Server 2012 R2
    * `win81-x64`
    * `win81-x86`
    * `win81-arm`
* Windows 10 / Windows Server 2016
    * `win10-x64`
    * `win10-x86`
    * `win10-arm`
    * `win10-arm64`

## Linux RIDs

* Red Hat Enterprise Linux
    * `rhel.7-x64`
* Ubuntu
    * `ubuntu.14.04-x64`
    * `ubuntu.14.10-x64`
    * `ubuntu.15.04-x64`
    * `ubuntu.15.10-x64`
    * `ubuntu.16.04-x64`
    * `ubuntu.16.10-x64`
* CentOS
    * `centos.7-x64`
* Debian
    * `debian.8-x64`
* Fedora
    * `fedora.23-x64`
    * `fedora.24-x64`
* openSUSE
    * `opensuse.13.2-x64`
    * `opensuse.42.1-x64`
* Oracle Linux
    * `ol.7-x64`
    * `ol.7.0-x64`
    * `ol.7.1-x64`
    * `ol.7.2-x64`
* Currently supported Ubuntu derivatives 
    * `linuxmint.17-x64`
    * `linuxmint.17.1-x64`
    * `linuxmint.17.2-x64`
    * `linuxmint.17.3-x64`
    * `linuxmint.18-x64`

## OS X RIDs

* `osx.10.10-x64`
* `osx.10.11-x64`
* `osx.10.12-x64`: can only be used in .NET Core 1.1 or later versions applications.
