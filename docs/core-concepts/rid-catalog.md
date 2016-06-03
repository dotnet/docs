# Runtime IDentifier (RID) catalog

## What are RIDs?
RID is short for *Runtime IDentifier*. RIDs are used to identify target operating systems where an application or asset 
(that is, assembly) will run. They look like this: "ubuntu.14.04-x64", "win7-x64", "osx.10.11-x64". 
For the packages with native dependencies, it will designate on which platforms the package can be restored. 

It is important to note that RIDs are really opaque strings. This means that they have to match exactly for operations 
using them to work. As an example, let us consider the case of [Elementary OS](https://elementary.io/), which is a straightforward clone of 
Ubuntu 14.04. Although .NET Core and CLI work on top of that version of Ubuntu, if you try to use them on Elementary OS 
without any modifications, the restore operation for any package will fail. This is because we currently (May 3rd, 2016) don't 
have a RID that designates Elementary OS as a platform. 

RIDs that represent concrete operating systems should be of the form: `[os].[version]-[arch]` where:
- `[os]` is the operating system moniker, for example, `win`
- `[version]` is the operating system version in the form of a dot (`.`) separated version number, for example, `10.1511`, 
accurate enough to reasonably enable assets to target operating system platform APIs represented by that version.
  - This **shouldn't** be marketing versions, as they often represent multiple discrete versions of the operating 
system with varying platform API surface area, for example, `win.10-x64`
- `[arch]` is the processor architecture, for example, `x86`, `x64`, `arm`, `arm64`, etc.

The RID graph is defined in a package called `Microsoft.NETCore.Platforms` in a file called `runtime.json` which you can 
see on the [CoreFX repo](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json). If 
you use this file, you will notice that some of the RIDs have an `"#import"` statement in them. These statements are 
compatibility statements. That means that a RID that has an imported RID in it, can be a target for restoring packages 
for that RID. Slightly confusing, but let's look at an example. Let's take a look at OS X:

```json
"osx.10.11-x64": {
            "#import": [ "osx.10.11", "osx.10.10-x64" ]
}
```
The above RID specifies that `osx.10.11-x64` imports `osx.10.10-x64`. This means that when restoring packages, NuGet will
be able to restore packages that specify that they need `osx.10.10-x64` on `osx.10.11-x64`.

A slightly bigger example RID graph:  

- `win.10.1511-x64`
  - `win.10.1511`
  - `win.10-x64`
    - `win.10`
    - `win.6.3.9200-x64`
      - `win.6.3-x64`
      - `win.6.3`
      - `win.6.3.9200`
      - `win.6.2.9200-x64`
        - `win.6.2.9200`
        - `win.6.1.7600-x64`
          - `win.6.1.7600`
          - `win.6.1-x64`
            - `win.6.1`
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
In order to use RIDs, you have to know which RIDs there are. This document lists out the currently supported RIDs in 
.NET Core. Please be aware that this document is getting updated regularly as new RIDs are added to the platform. If you 
wish to check if new ones are added, please check back here.

> We are working towards getting this information into a more interactive form. When that happens, this page will be 
> updated to point to that tool and/or its usage documentation. 

## Windows RIDs

* Windows 7
    * `win7-x64`
    * `win7-x86`
* Windows 8
    * `win8-x64`
    * `win8-x86`
* Windows 10
    * `win10-x64`
    * `win10-x86`

## Linux RIDs

* Red Hat Enterprise Linux
    * `rhel.7.0-x64`
    * `rhel.7.1-x64`
    * `rhel.7.2-x64`
* Ubuntu
    * `ubuntu.14.04-x64`
    * `ubuntu.14.10-x64`
    * `ubuntu.15.04-x64`
* CentOS
    * `centos.7-x64`
    * `centos.7.1-x64`
* Debian
    * `debian.8-x64`
    * `debian.8.2-x64`
* Currently supported Ubuntu derivatives 
    * `linuxmint.17-x64`
    * `linuxmint.17.1-x64`
    * `linuxmint.17.2-x64`
    * `linuxmint.17.3-x64`

## OS X RIDs

* `osx.10.10-x64`
* `osx.10.11-x64`
