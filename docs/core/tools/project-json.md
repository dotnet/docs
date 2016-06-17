---
title: project.json reference
description: project.json reference
keywords: .NET, .NET Core
author: aL3891
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 3aef32bd-ee2a-4e24-80f8-a2b615e0336d
---

# project.json reference

 **Note**
<<<<<<< b280eecc27e38909a78eb2067d77d627d31b7d27
> This topic is likely to change before release! You can track the status of this issue through our public GitHub issue tracker.
=======
> This topic is preliminary and subject to change in the next release. You can track the status of this issue through our public GitHub issue tracker.
>>>>>>> Update project-json-reference.md


* [name](#name)
* [version](#version)
* [description](#description)
* [copyright](#copyright)
* [title](#title)
* [entryPoint](#entryPoint)
* [testRunner](#testRunner)
* [authors](#authors)
* [language](#language)
* [embedInteropTypes](#embedInteropTypes)
* [preprocess](#preprocess)
* [publishExclude](#publishExclude)
* [shared](#shared)
* [namedResource](#namedResource)
* [packInclude](#packInclude)
* [excludeBuiltIn](#excludeBuiltIn)
* [dependencies](#dependencies)
* [tools](#tools)
* [commands](#commands)
* [scripts](#scripts)
* [buildOptions](#buildOptions)
    * [define](#define)
    * [nowarn](#nowarn)
    * [additionalArguments](#additionalArguments)
    * [languageVersion](#languageVersion)
    * [allowUnsafe](#allowUnsafe)
    * [platform](#platform)
    * [warningsAsErrors](#warningsAsErrors)
    * [optimize](#optimize)
    * [keyFile](#keyFile)
    * [delaySign](#delaySign)
    * [publicSign](#publicSign)
    * [emitEntryPoint](#emitEntryPoint)
    * [xmlDoc](#xmlDoc)
    * [preserveCompilationContext](#preserveCompilationContext)
    * [compilerName](#compilerName)
    * [compile](#compile)
        * [include](#compile-include)
        * [exclude](#compile-exclude)
        * [includeFiles](#compile-include-files)
        * [excludeFiles](#compile-exclude-files)
        * [builtIns](#compile-builtins)
        * [mappings](#compile-mappings)
    * [embed](#embed)
        * [include](#embed-include)
        * [exclude](#embed-exclude)
        * [includeFiles](#embed-include-files)
        * [excludeFiles](#embed-exclude-files)
        * [builtIns](#embed-builtins)
        * [mappings](#embed-mappings)
    * [copyToOutput](#copytooutput)
        * [include](#copytooutput-include)
        * [exclude](#copytooutput-exclude)
        * [includeFiles](#copytooutput-include-files)
        * [excludeFiles](#copytooutput-exclude-files)
        * [builtIns](#copytooutput-builtins)
        * [mappings](#copytooutput-mappings)
* [publishOptions](#publishoptions)
    * [include](#publish-include)
    * [exclude](#publish-exclude)
    * [includeFiles](#publish-include-files)
    * [excludeFiles](#publish-exclude-files)
    * [builtIns](#publish-builtins)
    * [mappings](#publish-mappings)
* [runtimeOptions](#runtimeoptions)
    * [configProperties](#configproperties)
        * [System.GC.Server](#gcserver)
        * [System.GC.Concurrent](#gcconcurrent)
        * [System.GC.RetainVM](#retainvm)
        * [System.Threading.ThreadPool.MinThreads](#minthreads)
        * [System.Threading.ThreadPool.MaxThreads](#maxthreads)
* [packOptions](#packoptions)
    * [summary](#summary)
    * [tags](#tags)
    * [owners](#owners)
    * [releaseNotes](#releasenotes)
    * [iconUrl](#iconurl)
    * [projectUrl](#projecturl)
    * [licenseUrl](#licenseurl)
    * [requireLicenseAcceptance](#requirelicenseacceptance)
    * [repository](#repository)
    * [files](#files)
        * [include](#files-include)
        * [exclude](#files-exclude)
        * [includeFiles](#files-include-files)
        * [excludeFiles](#files-exclude-files)
        * [builtIns](#files-builtins)
        * [mappings](#files-mappings)
* [analyzerOptions](#analyzerOptions)
    * [languageId](#languageId)
* [configurations](#configurations)
* [frameworks](#frameworks)
    * [dependencies](#dependencies)
    * [frameworkAssemblies](#frameworkAssemblies)
    * [wrappedProject](#wrappedProject)
    * [imports](#imports)
    * [bin](#bin)
        * [assembly](#assembly)

<a name="name"></a>
## name
Type: String

The name of the project, used for the assembly name as well as the name of the package. The top level folder name is used if this property is not specified.

For example:

    {
        "name": "MyLibrary"
    }

<a name="version"></a>
## version
Type: String

The [Semver](http://semver.org/spec/v1.0.0.html) version of the project, also used for the NuGet package.

For example:

    {
        "version": "1.0.0-*"
    }

<a name="description"></a>
## description
Type: String

A longer description of the project. Used in the assembly properties.

For example:

    {
        "description": "This is my library and it's really great!"
    }

<a name="copyright"></a>
## copyright
Type: String

The copyright information for the project. Used in the assembly properties.

For example:

    {
        "copyright": "Fabrikam 2016"
    }

<a name="title"></a>
## title
Type: String

The friendly name of the project, can contain spaces and special characters not allowed when using the `name` property. Used in the assembly properties.

For example:

    {
        "title": "My Library"
    }

<a name="entryPoint"></a>
## entryPoint
Type: String

The entrypoint method for the project. `Main` by default.

For example:

    {
        "entryPoint": "ADifferentMethod"
    }
    
<a name="testRunner"></a>
## testRunner
Type: String

The name of the test runner, such as [NUnit](http://nunit.org/) or [xUnit](http://xunit.github.io/), to use with this project. Setting this also marks the project as a test project.

For example:

    {
        "testRunner": "NUnit"
    }

<a name="authors"></a>
## authors
Type: String[]

An array of strings with the names of the authors of the project.

For example:

    {
        "authors": ["Anne", "Bob"]
    }

<a name="language"></a>
## language
Type: String

The (human) language of the project. Corresponds to the "neutral-language" compiler argument.

For example:

    {
        "language": "en-US"
    }

<a name="embedInteropTypes"></a>
## embedInteropTypes
Type: Boolean

If set to true, embeds COM interop types in the assembly. 

For example:

    {
        "embedInteropTypes": true
    }

<a name="preprocess"></a>
## preprocess
Type: String or String[] with a globbing pattern

Specifies which files are included in preprocessing.

For example:

    {
        "preprocess": "compiler/preprocess/**/*.cs"
    }

<a name="shared"></a>
## shared
Type: String or String[] with a globbing pattern

Specifies which files are shared, this is used for library export.

For example:

    {
        "shared": "shared/**/*.cs"
    }

<a name="namedResource"></a>
## namedResource
Type: Object

An object whose properties are names of named resources.

For example:

    {
        "namedResource": {
            "MyString" : "Hello there!"
        }
    }

<a name="packInclude"></a>
## packInclude
Type: String or String[] with a globbing pattern

Specifies which files are included when creating the NuGet package.

For example:

    {
        "packInclude": "myDeploymentScripts/**/*.ps1"
    }

<a name="excludeBuiltIn"></a>
## excludeBuiltIn
Type: String or String[] with a globbing pattern

Specifies which files to exclude from the build.

For example:

    {
        "excludeBuiltIn": ["bin/**", "obj/**"]
    }

<a name="dependencies"></a>
## dependencies
Type: Object

An object that defines the package dependencies of the project, each key of this object is the name of a package and each value contains versioning information.

For example:

    "dependencies": {
        "System.Reflection.Metadata": "1.2.0-rc3-23811",
        "Microsoft.Extensions.JsonParser.Sources": {
          "type": "build",
          "version": "1.0.0"
        },
        "Microsoft.Extensions.HashCodeCombiner.Sources": {
          "type": "build",
          "version": "1.0.0"
        },
        "Microsoft.Extensions.DependencyModel": "1.0.0-*"
    }

<a name="tools"></a>
## tools
Type: Object

An object that defines package dependencies that are used as tools for the current project, not as references. Packages defined here are available in scripts that run during the build process, but they are not accessible to the code in the project itself. Tools can for example include code generators or post-build tools that perform tasks related to packing.

For example:

    {
        "tools": {
            "MyObfuscator": "1.2.4"
        }
    }

<a name="commands"></a>
## commands
Type: Object

TODO: Investigate actual status

Commands are deprecated in the cli. (?)

<a name="scripts"></a>
## scripts
Type: Object

An object that defines scripts run during the build process. Each key in this object identifies where in the build the script is run. Each value is either a string with the script to run or an array of strings containing scripts that will run in order.
The supported events are:
* precompile
* postcompile
* prepublish
* postpublish

For example:

    {
        "scripts": {
            "precompile": "generateCode.cmd"
            "postcompile": [ "obfuscate.cmd", "removeTempFiles.cmd" ]
        }
    }

<a name="buildOptions"></a>
## buildOptions
Type: Object

An object whose properties control various aspects of compilation. The valid properties are listed below. Can also be specified per target framework as described in the [frameworks section](#frameworks)

For example:

    "buildOptions": {
      "allowUnsafe": true,
      "emitEntryPoint": true
    }

<a name="define"></a>
### define
Type: String[]

A list of defines such as "DEBUG" or "TRACE" that can be used in conditional compilation in the code.

For example:

    {
        "buildOptions": {
            "define": ["TEST", "OTHERCONDITION"]
        }
    }

<a name="nowarn"></a>
### nowarn
Type: String[]

A list of warnings to ignore.

For example:

    {
        "buildOptions": {
            "nowarn": ["CS0168", "CS0219"]
        }
    }

This ignores the warnings `The variable 'var' is assigned but its value is never used` and `The variable 'var' is assigned but its value is never used`

<a name="additionalArguments"></a>
### additionalArguments
Type: String[]

A list of extra arguments that will be passed to the compiler.

For example:

    {
        "buildOptions": {
            "additionalArguments": ["/parallel", "/nostdlib"]
        }
    }

<a name="languageVersion"></a>
### languageVersion
Type: String

The version of the language used by the compiler: ISO-1, ISO-2, 3, 4, 5, 6, or Default

For example:

    {
        "buildOptions": {
            "languageVersion": "5"
        }
    }

<a name="allowUnsafe"></a>
### allowUnsafe
Type: Boolean

Allows unsafe code in this project.

For example:

    {
        "buildOptions": {
            "allowUnsafe": true
        }
    }

<a name="platform"></a>
### platform
Type: String

The name of the target platform, such as AnyCpu, x86 or x64.

For example:

    {
        "buildOptions": {
            "platform": "x64"
        }
    }

<a name="warningsAsErrors"></a>
### warningsAsErrors
Type: Boolean

If set to true, treats warnings as errors.

For example:

    {
        "buildOptions": {
            "warningsAsErrors": true
        }
    }

<a name="optimize"></a>
### optimize
Type: Boolean

Enables the compiler to optimize the code in this project.

For example:

    {
        "buildOptions": {
            "optimize": true
        }
    }

<a name="keyFile"></a>
### keyFile
Type: String

The path for the key file used for signing this assembly.

For example:

    {
        "buildOptions": {
            "keyFile": "../keyfile.snk"
        }
    }

<a name="delaySign"></a>
### delaySign
Type: Boolean

Causes signing to be delayed.

For example:

    {
        "buildOptions": {
            "delaySign": true
        }
    }

<a name="publicSign"></a>
### publicSign
Type: Boolean

Enables signing of the resulting assembly.

For example:

    {
        "buildOptions": {
            "publicSign": true
        }
    }

<a name="emitEntryPoint"></a>
### emitEntryPoint
Type: Boolean

Creates an executable if set to true; otherwise, the project will produce a `.dll` file.

For example:

    {
        "buildOptions": {
            "emitEntryPoint": true
        }
    }

<a name="xmlDoc"></a>
### xmlDoc
Type: Boolean

Enables XML documentation to be generated from triple-slash comments in the source code.

For example:

    {
        "buildOptions": {
            "xmlDoc": true
        }
    }

<a name="preserveCompilationContext"></a>
### preserveCompilationContext
Type: Boolean

TODO

<a name="compilerName"></a>
### compilerName
Type: String

The name of the compiler used for this project. `csc` by default. Currently, `csc` (the C# compiler) or `fsc` (the F# compiler) are supported.
 
For example:

    {
        "compilerName": "fsc"
    }
    
### compile
Type: Object

An object containing properties for compilation configuration.

<a name="compile-include"></a>
#### include
Type: String or String[] with a globbing pattern.

TODO

<a name="compile-exclude"></a>
#### exclude
Type: String or String[] with a globbing pattern.

Specifies which files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }

<a name="compile-include-files"></a>
#### includeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="compile-exclude-files"></a>
#### excludeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="compile-builtins"></a>
#### builtIns
Type: Object

TODO

<a name="compile-mappings"></a>
#### mappings
Type: Object

TODO

### embed
Type: Object

An object containing properties for compilation configuration.

<a name="embed-include"></a>
#### include
Type: String or String[] with a globbing pattern.

TODO

<a name="embed-exclude"></a>
#### exclude
Type: String or String[] with a globbing pattern.

Specifies which files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }
<a name="embed-include-files"></a>
#### includeFiles

Type: String or String[] with a globbing pattern.

TODO
<a name="embed-exclude-files"></a>
#### excludeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="embed-builtins"></a>
#### builtIns
Type: Object

TODO

<a name="embed-mappings"></a>
#### mappings
Type: Object

TODO

### copyToOutput
Type: Object

An object containing properties for compilation configuration.

<a name="copytooutput-include"></a>
#### include
Type: String or String[] with a globbing pattern.

TODO

<a name="copytooutput-exclude"></a>
#### exclude
Type: String or String[] with a globbing pattern.

Specifies which files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }

<a name="copytooutput-include-files"></a>
#### includeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="copytooutput-include-files"></a>
#### excludeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="copytooutput-include-builtins"></a>
#### builtIns
Type: Object

TODO

<a name="copytooutput-mappings"></a>
#### mappings
Type: Object

TODO

## publishOptions
Type: Object

An object containing properties for compilation configuration.

<a name="publish-include"></a>
### include
Type: String or String[] with a globbing pattern.

TODO

<a name="publish-exclude"></a>
### exclude
Type: String or String[] with a globbing pattern.

Specifies which files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }

<a name="publish-include-files"></a>
### includeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="publish-exclude-files"></a>
### excludeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="publish-builtins"></a>
### builtIns
Type: Object

TODO

<a name="publish-mappings"></a>
### mappings
Type: Object

TODO

## runtimeOptions
Type: Object

TODO

### configProperties
Type: Object

Contains runtime configuration settings.

<a name="gcserver"></a>
#### System.GC.Server
Type: Boolean

TODO

<a name="gcconcurrent"></a>
#### System.GC.Concurrent
Type: Boolean

TODO

<a name="retainvm"></a>
#### System.GC.RetainVM
Type: Boolean

TODO

<a name="minthreads"></a>
#### System.Threading.ThreadPool.MinThreads
Type: Integer

TODO

<a name="maxthreads"></a>
#### System.Threading.ThreadPool.MaxThreads
Type: Integer

TODO

## packOptions
Type: Object

TODO

<a name="summary"></a>
### summary
Type: String

A short description of the project.

For example:

    {
        "summary": "This is my library."
    }

<a name="tags"></a>
### tags
Type: String[]

An array of strings with tags for the project, used for searching in NuGet.

For example:

    {
        "tags": ["hyperscale", "cats"]
    }

<a name="owners"></a>
### owners
Type: String[]

An array of strings with the names of the owners of the project.

For example:

    {
        "owners": ["Fabrikam", "Microsoft"]
    }

<a name="releaseNotes"></a>
### releaseNotes
Type: String

Release notes for the project.

For example:

    {
        "releaseNotes": "Initial version, implemented flimflams."
    }

<a name="iconUrl"></a>
### iconUrl
Type: String

The URL for an icon that will be used in various places such as the package explorer.

For example:

    {
        "iconUrl": "http://www.mylibrary.gov/favicon.ico"
    }

<a name="projectUrl"></a>
### projectUrl
Type: String

The URL for the homepage of the project.

For example:

    {
        "projectUrl": "http://www.mylibrary.gov"
    }

<a name="licenseUrl"></a>
### licenseUrl
Type: String

The URL for the license the project uses.

For example:

    {
        "licenseUrl": "http://www.mylibrary.gov/licence"
    }

<a name="requireLicenseAcceptance"></a>
### requireLicenseAcceptance
Type: Boolean

A boolean that causes a prompt to accept the package license when installing the package to be shown. Only used for NuGet packages, ignored in other uses.

For example:

    {
        "requireLicenseAcceptance": true
    }
    
### repository
Type: Object

TODO

### files

<a name="files-include"></a>
#### include
Type: String or String[] with a globbing pattern.

TODO

<a name="files-exclude"></a>
#### exclude
Type: String or String[] with a globbing pattern.

Specifies which files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }

<a name="files-include-files"></a>
#### includeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="files-exclude-files"></a>
#### excludeFiles

Type: String or String[] with a globbing pattern.

TODO

<a name="files-builtins"></a>
#### builtIns
Type: Object

TODO

<a name="files-mappings"></a>
#### mappings
Type: Object

TODO

<a name="analyzerOptions"></a>
## analyzerOptions
Type: Object

An object with properties used by code analysers.

For example:

    {
        "analyzerOptions": { }
    }

<a name="languageId"></a>
### languageId
Type: String

TODO: Check language ids
The id of the language to analyze.

For example:

    "analyzerOptions": {
      "languageId": "vb"
      }
    }

<a name="configurations"></a>
## configurations
Type: Object

An object whose properties define different configurations for this project, such as Debug and Release. Each value is an object that can contain a `buildOptions` object with options specific for this configuration.

For example:

    "configurations": {
      "Release": {
        "buildOptions": {
          "allowUnsafe": false
        }
      }
    }

<a name="frameworks"></a>
## frameworks
Type: Object

Specifies which frameworks this project supports, such as the .NET Framework or Universal Windows Platform (UWP). Must be a valid Target Framework Moniker (TFM). Each value is an object that can contain information specific to this framework such as `buildOptions`, `analyzerOptions`, `dependencies` as well as the properties in the following sections.

For example:

    "frameworks": {
        "dnxcore50": {
            "buildOptions": {
                "define": ["FOO", "BIZ"]
            }
        }
    }

<a name="dependencies"></a>
### dependencies
Type: Object

Dependencies that are specific for this framework. This is useful in scenarios where you cannot simply specify a package-level dependency across all targets. Reasons for this can include one target lacking built-in support that other targets have, or requiring a different version of a dependency than other targets.

For example:

    "frameworks": {
        "dnxcore50": {
            "dependencies": {
                "Microsoft.Extensions.JsonParser.Sources": "1.0.0"
            }
        }
    }

<a name="frameworkAssemblies"></a>
### frameworkAssemblies
Type: Object

Similar to dependencies but contains reference to assemblies in the GAC that are not NuGet packages. Can also specify the version to use as well as the dependency type. This is used when targeting .NET Framework and Portable Class Library (PCL) targets. You can only build a project with this specified on Windows.

For example:

    "frameworks": {
        "net451": {
            "frameworkAssemblies": {
                "System.Runtime": {
                    "type": "build",
                    "version": "4.0.0"
                }
            }
        }

<a name="wrappedProject"></a>
### wrappedProject
Type: String

TODO

<a name="bin"></a>
### bin
Type: Object

An object with a single property, `assembly`, whose value is the assembly path.

For example:

    "frameworks": {
      "dnxcore50": {
         "bin": {
           "assembly" :"c:/otherProject/otherdll.dll"
        }
      }
    }

<a name="imports"></a>
### imports
Type: String

TODO
Specifies other framework profiles that this project is compatible with.

For example:

    "frameworks": {
      "dnxcore50": {
         "imports": "portable-net45+win8"
      }
    }

Will cause other packages targeting `portable-net45+win8` to be usable when targeting `dnxcore50` with the current project
