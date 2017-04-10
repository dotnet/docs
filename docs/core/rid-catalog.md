---
title: .NET Core Runtime IDentifier (RID) catalog
description: .NET Core Runtime IDentifier (RID) catalog
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 08/22/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: b2032f5d-771f-48d9-917c-587d9509035c
---

# .NET Core Runtime IDentifier (RID) catalog

## What are RIDs?
RID is short for *Runtime IDentifier*. RIDs are used to identify target operating systems where an application or asset 
(that is, assembly) will run. They look like this: "ubuntu.14.04-x64", "win7-x64", "osx.10.11-x64". 
For the packages with native dependencies, it will designate on which platforms the package can be restored. 

It is important to note that RIDs are really opaque strings. This means that they have to match exactly for operations 
using them to work. As an example, let us consider the case of [Elementary OS](https://elementary.io/), which is a straightforward clone of 
Ubuntu 14.04. Although .NET Core and CLI work on top of that version of Ubuntu, if you try to use them on Elementary OS 
without any modifications, the restore operation for any package will fail. This is because we currently don't 
have a RID that designates Elementary OS as a platform. 

RIDs that represent concrete operating systems usually follow this pattern: `[os].[version]-[arch]` where:
- `[os]` is the operating system moniker, for example, `ubuntu`.
- `[version]` is the operating system version in the form of a dot (`.`) separated version number, for example, `15.10`, 
accurate enough to reasonably enable assets to target operating system platform APIs represented by that version.
  - This **shouldn't** be marketing versions, as they often represent multiple discrete versions of the operating 
system with varying platform API surface area.
- `[arch]` is the processor architecture, for example, `x86`, `x64`, `arm`, `arm64`, etc.

The RID graph is defined in a package called `Microsoft.NETCore.Platforms` in a file called `runtime.json`, which you can 
see on the [CoreFX repo](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json). If 
you use this file, you will notice that some of the RIDs have an `"#import"` statement in them. These statements are 
compatibility statements. That means that a RID that has an imported RID in it can be a target for restoring packages 
for that RID. Slightly confusing, but let's look at an example. Let's take a look at macOS:

```json
"osx.10.11-x64": {
    "#import": [ "osx.10.11", "osx.10.10-x64" ]
}
```
The above RID specifies that `osx.10.11-x64` imports `osx.10.10-x64`. This means that when restoring packages, NuGet will
be able to restore packages that specify that they need `osx.10.10-x64` on `osx.10.11-x64`.

A slightly bigger example RID graph:  

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

Although they look easy enough to use, there are some special things about RIDs that you have to keep in mind when 
working with them:

* They are **opaque strings** and should be treated as black boxes
    * You should not construct RIDs programmatically
* You need to use the RIDs that are already defined for the platform and this document shows that
* The RIDs do need to be specific so don't assume anything from the actual RID value; please consult this document 
to determine which RID(s) you need for a given platform

## Using RIDs
In order to use RIDs, you have to know which RIDs there are. New RIDs are added regularly to the platform. 
For the latest version, please check the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo.

> [!NOTE]
> We are working towards getting this information into a more interactive form. 
> When that happens, this page will be updated to point to that tool and/or its usage documentation. 

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
* OpenSUSE
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
* `osx.10.12-x64`
