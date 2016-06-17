# Code Sharing with the .NET Standard Library #

The .NET Standard Library aims at maintaining binary compatibility between the .NET-capable platforms for which an application is developed and future versions of those platforms. It also supports source code compatibility between platforms that support a particular version of the .NET Standard. 

<aside style="border-style:double">
**Important:** This is very preliminary documentation for the .NET Standard Library. Because the standard has not been formalized yet, it is subject to change.
</aside>

The .NET Standard Library consists of two parts: a set of contracts (or reference assemblies) that are included in the standard, and a single moniker-based versioning scheme.

# What Is the .NET Standard Library? #

The .NET Standard Library is not itself a platform, but rather a standard that platforms implement. The standard defines a set of reference assemblies that platforms must support. These reference assemblies in turn define the API surface area that the platform must implement.    

An assembly in the .NET Standard Library is a library or executable file that targets a .NET-capable platform.  A reference assembly (also known as a contract) is a library that defines types and their members but contains no implementation code. Because they contain no implementation, reference assemblies are used for compilation only. The reference assemblies that comprise the .NET Standard Library are found on [GitHub](https://github.com/dotnet/corefx/tree/master/src "GitHub"). 

To take a simple example, the System.Resources.ResourceManager reference assembly defines one exception type with three unique members, two attribute types with two unique members each, and a [ResourceManager](https://dotnet.github.io/api/System.Resources.ResourceManager.html "ResourceManager") class with two constructors and two string retrieval methods. The following is the entire content of the System.Resources.ResourceManager reference assembly:

    
    namespace System.Resources
    {
       [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
       public partial class MissingManifestResourceException : System.Exception
       {
          public MissingManifestResourceException() { }
          public MissingManifestResourceException(string message) { }
          public MissingManifestResourceException(string message, System.Exception inner) { }
       }

      [System.AttributeUsageAttribute((System.AttributeTargets)(1), AllowMultiple = false)]
      [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
      public sealed partial class NeutralResourcesLanguageAttribute : System.Attribute
      {
         public NeutralResourcesLanguageAttribute(string cultureName) { }
         public string CultureName { get { return default(string); } }
      }

      [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
      public partial class ResourceManager
      {
         public ResourceManager(string baseName, System.Reflection.Assembly assembly) { }
         public ResourceManager(System.Type resourceSource) { }
         public string GetString(string name) { return default(string); }
         public virtual string GetString(string name, System.Globalization.CultureInfo culture) { return default(string); }
      }

      [System.AttributeUsageAttribute((System.AttributeTargets)(1), AllowMultiple = false)]
      [System.ComponentModel.EditorBrowsableAttribute((System.ComponentModel.EditorBrowsableState)(1))]
      public sealed partial class SatelliteContractVersionAttribute : System.Attribute
      {
         public SatelliteContractVersionAttribute(string version) { }
         public string Version { get { return default(string); } }
      }
   } 
            
Platforms that support the .NET Standard Library then provide implementations of the API surface area defined by these reference assemblies. Some of the implementing platforms are:

- The .NET Framework, which, starting with Windows 8, is a system component included with the Windows operating system.

- .NET Core,  which is a modular, cross-platform, open source implementation of the .NET Framework that runs on Windows devices, as well as on Linux and OS X.

- The Universal Windows Platform, an application architecture for creating apps that can run on a variety of Windows devices, such as desktop Windows systems, Windows tablets, and Windows phones.   

For more information on the .NET Standard Library and individual platforms that implement the standard, see the "Implementing Platforms" section.

The .NET Standard Library is versioned. That is, each version of the .NET Standard Library defines a set of APIs that platforms supporting the .NET Standard Library must implement. Each version of the standard is a superset of previous versions. This allows apps that target an earlier version of the Standard Library to run on later versions. A unique moniker identifies each version. For more information, see the ".NET Standard Library Versions" section.

The following figure illustrates the relationship between the .NET Standard Library and its implementing platforms. The Anchors column in the figure lists some platforms that implement the .NET Standard Library.

![The .NET Standard Library](http://i.imgur.com/SyKEAb1.png)

The current version of the .NET Standard Library is 1.6. 

# Binary Compatibility #

In general, binary compatibility means that executable code developed for a particular platform can run without modification on some other platform. The .NET Standard Library aims at guaranteeing two kinds of binary compatibility:   

- Cross-platform binary compatibility. A single class library binary is platform-agnostic. That is, it can be called from any implementing platform. 
 
- Backward binary compatibility. A component (that is, a library or an executable) that targets a specific version of a platform can run without modification on later versions of that platform.  Concretely, this means that a library that targets the .NET Standard 1.6 on a Linux system, for example, can be called seamlessly from an application that targets a later version of the standard running on a Linux system. 
 
## Binary Compatibility and Portable Class Libraries ##

Until the introduction of the .NET Standard Library, .NET implementations were free to choose which types and type members the platform would implement. Because of their differing surface areas, members present on one platform were not necessarily present on another platform.   
 
The Portable Class Library (PCL) was the sole mechanism that provided for cross-platform binary compatibility. A Portable Class Library is a class library that targets multiple platforms, which you specify when you create the PCL project. A particular PCL, for example, might simultaneously target the Windows Store for Windows 8.1, Windows Phone 8.1, and the .NET Framework 4. Because the API surface area of each platform is different, the PCL includes a profile that is the intersection of the combined surface areas. In other words, only the types and members shared by all the target platforms are available to the PCL project. And the cross-platform binary compatibility of PCL projects is limited to the platforms that you specify when you create the PCL project.  

In addition, backward binary compatibility can be a problem for Portable Class Libraries. When these libraries are deployed as NuGet packages, they are expressed with a static set of platforms. For example, `portable-net45+win8` indicates that a library targets Windows Store apps on Windows 8 and the .NET Framework 4.5. This can limit their ability to be called from Portable Class Libraries that target future compatible platforms, such as the Universal Windows Platform for Windows 10.

## Binary Compatibility and the .NET Standard Library ##

The .NET Standard Library ensures cross-platform binary compatibility in two ways:

- Each platform must implement the full set of APIs defined in each .NET Standard Library reference assembly that it supports. In other words, platforms that target the same version of the .NET Standard Library have the same API surface area. 

- .NET implementations use a single file format across all platforms. Compilers translate source code to Intermediate Language (IL), which is output in a PE-formatted file.

The .NET Standard Library also ensures backward binary compatibility by using a single version-based moniker to express its support for specific platforms. For example, the moniker for binaries that target the .NET Standard 1.6 is simply `netstandard1.6`. Because the moniker uses linear versioning, NuGet and other tools can easily infer compatibility and enforce backward compatibility: higher (newer) .NET Standard Library versions are always compatible with lower (earlier) ones. For example, a binary that targets the .NET Standard Library 1.3 can run on a platform that implements the .NET Standard Library 1.6.    

# Source Code Compatibility #

Source code compatibility allows developers to write source code that, when it is compiled to binaries, will run on multiple platforms (the binaries themselves need not be compatible across platforms), or will run on future versions of the same platform. Typically, .NET has maintained a high degree of backward compatibility of source code across single platform versions. The .NET Standard Library also aims at enhancing the compatibility of source code across platforms as well.

## Source Code Compatibility before the .NET Standard Library ##

A basic problem of source code compatibility before the introduction of the .NET Standard Library was that platforms were free to choose the subset of APIs that their platform implemented. The result was a confusing developer experience that complicated application and library development. Often, a commonly used API existed in only some, but not all, platforms. And generally, a workaround to the commonly used API was not well documented. 

Portable Class Libraries were intended to provide cross-platform binary libraries, but the APIs available for a particular profile (a particular set of target platforms) was the intersection of the APIs available on each platform. This made it very difficult to determine in advance which APIs were and were not supported. Commonly used APIs were sometimes not present in a particular profile, and it was often not clear why particular APIs had apparently "disappeared."

## The .NET Standard Library and Source Code Compatibility ##

The .NET Standard Library addresses the problem of source code compatibility by defining the API surface area that a particular version of the standard must implement. This surface area is defined by the types and type members found in the reference assemblies that are included in a particular version of the the .NET Standard Library.

When a platform provides an implementation for a particular reference assembly or contract, it must implement all of the types and type members defined in that reference assembly. If the member has no implementation on that platform, it should throw a [PlatformNotSupportedException](http://dotnet.github.io/api/System.PlatformNotSupportedException.html#System_PlatformNotSupportedException "PlatformNotSupportedException") exception. 

Note, however, that implementing platforms are not required to implement all of the contracts in the .NET Standard Library. Instead, individual implementations can choose not to implement a particular contract. For more information, see "Partial Implementations of the .NET Standard Library."

Aside from partial implementations, the fact that the .NET Standard Library defines a set of APIs that are present on all implementing platforms, and that the APIs available in later versions of the .NET Standard Library are a superset of those available in earlier versions, ensures that:

- Source code that targets a particular version of the .NET Standard Library on one platform can compile and execute on another platform that supports the same version of the .NET Standard Library. 

- Source code that targets a particular version of the .NET Standard Library can compile and execute on any platform that supports a later version of the .NET Standard Library. 

# .NET Standard Library Versions #

A particular version of the .NET Standard Library is defined by:

-  The set of reference assemblies that that version of the standard supports.
  
-  The individual types and members found in those reference assemblies.

Any change in a reference assembly's API surface area causes the .NET Standard Library version to change (and its version number to increment). For example, adding a new method, such as a new `String.Contains(String, StringComparison)` overload to the [http://dotnet.github.io/api/System.String.html](http://dotnet.github.io/api/System.String.html "String") class in the System.Runtime reference assembly would cause the .NET Standard Library version to change.

Lower versions of the .NET Standard Library are always compatible with higher versions. This means that the APIs in a lower (or earlier) version of the standard are always a subset of the APIs in higher (or later) versions. Conversely, the APIs in higher (or later) versions of the standard are a superset of APIs in lower (or earlier) versions. 

The current version of the .NET Standard Library is 1.6.

Although the .NET Standard Platform was introduced simultaneously with the introduction of .NET Core, it has been versioned retroactively to support portability for existing Portable Class Libraries. The following table shows the mappings between individual versions of .NET platforms and versions of the .NET Standard Library.

<table>
<!-- <col style="width:50%"> -->
<thead>
   <tr>
      <th>Target Platform</th>
      <th>Alias</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
   </tr>
</thead>
<tr>
   <td>.NET Standard Library</td>
   <td>netstandard</td>
   <td>1.0</td>
   <td>1.1</td>
   <td>1.2</td>
   <td>1.3</td>
   <td>1.4</td>
   <td>1.5</td>
   <td>1.6</td>
</tr>
<tr>
   <td>.NET Core</td>
   <td>netcoreapp</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td>1.0</td>
</tr>
<tr>
   <td>.NET Framework</td>
   <td>net</td>
   <td></td>
   <td>4.5</td>
   <td>4.5.1
       4.5.2</td>
   <td>4.6</td>
   <td>4.6.1</td>
   <td>4.6.2</td>
   <td></td>
</tr>
<tr>
   <td>Universal Windows Platform</td>
   <td>uap</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td>10.0</td>
   <td></td>
   <td></td>
</tr>
<tr>
   <td>Windows</td>
   <td>win</td>
   <td></td>
   <td>8.0</td>
   <td>8.1</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
</tr>
<tr>
   <td>Windows Phone</td>
   <td>wpa</td>
   <td></td>
   <td>8.0</td>
   <td>8.1</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
</tr>
<tr>
   <td>Windows Phone Silverlight</td>
   <td>wp</td>
   <td>8.0
       8.1</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
</tr>
<tr>
   <td>Mono/Xamarin Platforms</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
   <td>***</td>
</tr>
<tr>
   <td>Mono</td>
   <td></td>
   <td></td>
   <td></td>
   <td>***</td>
   <td></td>
   <td></td>
   <td></td>
   <td></td>
</tr>
</table>

The following table shows the relationship of some PCL profiles to versions of the .NET Standard Library.

<table>
   <thead>
       <tr>
         <th>Profile</th>
         <th>.NET Standard Library Version</th>
       </tr>
   </thead>
   <tr>
      <td>Profile 7 (Net Framework 4.5, Windows 8)</td>
      <td>1.1</td>
   </tr>
   <tr>
      <td>Profile 31 (Windows 8.1, Windows Phone Silverlight 8.1)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 32 (Windows 8.1, Windows Phone 8.1)</td>
      <td>1.2</td>
   </tr>
   <tr>
      <td>Profile 44 (Net Framework 4.5, Windows 8)</td>
      <td>1.2</td>
   </tr>
   <tr>
      <td>Profile 49 (Net Framework 4.5, Windows 8)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 78 (Net Framework 4.5, Windows 8)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 84 (Net Framework 4.5, Windows 8)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 111 (Net Framework 4.5, Windows 8, Windows Phone 8.1)</td>
      <td>1.1</td>
   </tr>
   <tr>
      <td>Profile 151 (Net Framework 4.5.1, Windows 8.1, Windows Phone Silverlight 8.1)</td>
      <td>1.2</td>
   </tr>
   <tr>
      <td>Profile 157 (Windows 8.1, Windows Phone 8.1, Windows Phone Silverlight 8.1)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 259 (Net Framework 4.5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8.1)</td>
      <td>1.0</td>
   </tr>
   <tr>
      <td>Profile 7 (Net Framework 4.5, Windows 8)</td>
      <td>1.1</td>
   </tr>
</table>

Class Libraries that target an earlier .NET Standard Library, such as Net Platform Standard 1.0, can be loaded by the largest number of existing platforms, but have access to a smaller subset of APIs. On the other hand, class libraries that target a later .NET Standard Library version, such as 1.6, can be loaded by a smaller number of platforms (or can be loaded by newer platforms), but have access to a larger set of APIs.

# Implementing Platforms #

Platforms provide implementations for the types in members in reference assemblies from a particular .NET Standard Library version. Types that implement a particular version of the .NET Standard Library must implement all of the APIs defined by a particular contract or reference assembly.   

Implementation assemblies provided by a platform are termed *anchored assemblies*. Anchored assemblies can only be updated on a platform by updating the platform itself. 

However, a platform need not provide an implementation for every reference assembly. For example, a new platform named .NET for Microwaves 1.0 that is single-threaded might choose not to implement the types in the System.Threading reference assembly. For more information, see the "Partial Implementations of the .NET Standard Library" section.

In many cases, individual members in the .NET Standard Platform may either be inapplicable or have no implementation for the underlying platform. In that case, the member should throw a [PlatformNotSupportedException](http://dotnet.github.io/api/System.PlatformNotSupportedException.html#System_PlatformNotSupportedException "PlatformNotSupportedException") exception.

In addition, a platform can implement types and members that are not found in the .NET Standard Library. For example, the .NET Framework 4.5, which conforms to the .NET Standard Library 1.1, includes an overloaded [String.Normalize ](https://msdn.microsoft.com/en-us/library/system.string.normalize(v=vs.110).aspx "String.Normalize") method that is not found in the .NET Standard Library.  

## Partial Implementations of the .NET Standard Library ##

Individual platforms can choose to implement a subset of reference assemblies from a particular .NET Standard Library version. Later versions of the platform can add support for additional reference assemblies. They cannot, however, remove support for any reference assemblies that they have already implemented.

A class library developer who needs to determine whether his or her class library will work on a given platform can use configure the library's project.json file to determine whether a particular contract is supported on a target platform. 

For example, suppose that a new platform, named .NET For Refrigerators 1.0 that complies with the .NET Standard Library 1.6, is released, and that the platform does not implement the System.AppContext contract. Class library authors targeting the .NET Standard Library 1.6 can determine whether their package works on .NET For Refrigerators by including the following in the library's project.json file:
 
    {
       "supports": [
      ".NET For Refrigerators 1.0"
       ],
       "dependencies": {
      "System.AppContext": "5.0.0"
       },
       "frameworks": {
      "netstandard1.6": { }
       } 
    }

This causes NuGet to do a compatibility check to ensure that an implementation assembly for System.AppContext is present in .NET For Refrigerators. If the dependency check fails, you have two options:

1. Don't support .NET For Refrigerators.

2. Detect the runtime platform and use a platform-specific alternative to the System.AppContext contract, if one is available.





 

