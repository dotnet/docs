# Project.json reference

 **Note**
> This topic is likley to change before release! You can track the status of this issue through our public GitHub issue tracker.


* [name](#name)
* [version](#version)
* [summary](#summary)
* [description](#description)
* [copyright](#copyright)
* [title](#title)
* [entryPoint](#entryPoint)
* [projectUrl](#projectUrl)
* [licenseUrl](#licenseUrl)
* [iconUrl](#iconUrl)
* [compilerName](#compilerName)
* [testRunner](#testRunner)
* [authors](#authors)
* [owners](#owners)
* [tags](#tags)
* [language](#language)
* [releaseNotes](#releaseNotes)
* [requireLicenseAcceptance](#requireLicenseAcceptance)
* [embedInteropTypes](#embedInteropTypes)
* [compile](#compile)
* [content](#content)
* [resource](#resource)
* [preprocess](#preprocess)
* [publishExclude](#publishExclude)
* [shared](#shared)
* [namedResource](#namedResource)
* [packInclude](#packInclude)
* [exclude](#exclude)
* [contentBuiltIn](#contentBuiltIn)
* [compileBuiltIn](#compileBuiltIn)
* [resourceBuiltIn](#resourceBuiltIn)
* [excludeBuiltIn](#excludeBuiltIn)
* [dependencies](#dependencies)
* [tools](#tools)
* [commands](#commands)
* [scripts](#scripts)
* [compilationOptions](#compilationOptions)
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

The [Semver](http://semver.org/spec/v1.0.0.html) version of the project, also used for the nuget package.

For example:

    {
        "version": "1.0.0-*"
    }

<a name="summary"></a>
## summary
Type: String

A short description of the project.

For example:

    {
        "summary": "This is my library."
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

<a name="projectUrl"></a>
## projectUrl
Type: String

The url for the homepage of the project.

For example:

    {
        "projectUrl": "http://www.mylibrary.gov"
    }

<a name="licenseUrl"></a>
## licenseUrl
Type: String

The url for the licence the project uses.

For example:

    {
        "licenseUrl": "http://www.mylibrary.gov/licence"
    }

<a name="iconUrl"></a>
## iconUrl
Type: String

The url for an icon that will be used in various places such as the package explorer.

For example:

    {
        "iconUrl": "http://www.mylibrary.gov/favicon.ico"
    }

<a name="compilerName"></a>
## compilerName
Type: String

The name of the compiler used for this project. `csc` by default. Currently `csc`, the c# compiler or `fsc`, the f# compiler are supported.
 
For example:

    {
        "compilerName": "fsc"
    }

<a name="testRunner"></a>
## testRunner
Type: String

The name of the testrunner, such as [NUnit](http://nunit.org/) or [xUnit](http://xunit.github.io/), to use with this project, setting this also marks the project as a test project.

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

<a name="owners"></a>
## owners
Type: String[]

An array of strings with the names of the owners of the project.

For example:

    {
        "owners": ["Fabrikam", "Microsoft"]
    }

<a name="tags"></a>
## tags
Type: String[]

An array of strings with tags for the project, used for searching in NuGet.

For example:

    {
        "tags": ["hyperscale", "cats"]
    }

<a name="language"></a>
## language
Type: String

The (human) language of the project, corresponds to the "neutral-language" compiler argument.

For example:

    {
        "language": "en-US"
    }

<a name="releaseNotes"></a>
## releaseNotes
Type: String

Release notes for the project.

For example:

    {
        "releaseNotes": "Initial version, implemented flimflams."
    }

<a name="requireLicenseAcceptance"></a>
## requireLicenseAcceptance
Type: Boolean

A boolean that causes a prompt to accept the package license when installing the package to be shown. Only used for nuget packages, ignored in other uses.

For example:

    {
        "requireLicenseAcceptance": true
    }

<a name="embedInteropTypes"></a>
## embedInteropTypes
Type: Boolean

If set to true, embeds COM interop types in the assembly. 

For example:

    {
        "embedInteropTypes": true
    }

<a name="compile"></a>
## compile
Type: String or String[] with a globbing pattern

Specifies what files are included in compilation.

For example:

    {
        "compile": "**/*.cs"
    }

<a name="content"></a>
## content
Type: String or String[] with a globbing pattern

Specifies what files are included in the build output, such as images or fonts.

For example:

    {
        "content": "content/*.jpg"
    }

<a name="resource"></a>
## resource
Type: String or String[] with a globbing pattern

Specifies resource files for the project.

For example:

    {
        "resource": [ "compiler/resources/**/*", "**/*.resx" ]
    }

<a name="preprocess"></a>
## preprocess
Type: String or String[] with a globbing pattern

Specifies what files are included in preprocessing.

For example:

    {
        "preprocess": "compiler/preprocess/**/*.cs"
    }

<a name="publishExclude"></a>
## publishExclude
Type: String or String[] with a globbing pattern

Specifies what files are excluded from publishing.

For example:

    {
        "publishExclude": "**/*.pdb"
    }

<a name="shared"></a>
## shared
Type: String or String[] with a globbing pattern

Specifies what files are shared, this is used for library export.

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

Specifies what files are included when creating the NuGet package.

For example:

    {
        "packInclude": "myDeploymentScripts/**/*.ps1"
    }

<a name="exclude"></a>
## exclude
Type: String or String[] with a globbing pattern

Specifies what files to exclude from the build.

For example:

    {
        "exclude": ["bin/**", "obj/**"]
    }

<a name="contentBuiltIn"></a>
## contentBuiltIn
Type: String or String[] with a globbing pattern

Specifies what files are considerd content by the build.

For example:

    {
        "contentBuiltIn": "content/*.jpg"
    }

<a name="compileBuiltIn"></a>
## compileBuiltIn
Type: String or String[] with a globbing pattern

Specifies what files are included in compilation.

For example:

    {
        "compileBuiltIn": "**/*.cs"
    }

<a name="resourceBuiltIn"></a>
## resourceBuiltIn
Type: String or String[] with a globbing pattern

Specifies resource files for the project.

For example:

    {
        "resourceBuiltIn": [ "compiler/resources/**/*", "**/*.resx" ]
    }

<a name="excludeBuiltIn"></a>
## excludeBuiltIn
Type: String or String[] with a globbing pattern

Specifies what files to exclude from the build.

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
          "version": "1.0.0-rc2-16453"
        },
        "Microsoft.Extensions.HashCodeCombiner.Sources": {
          "type": "build",
          "version": "1.0.0-rc2-16054"
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

An object that defines scripts run during the build proces. each key in this object identifies where in the build the script is run, each value is either a string with the script to run or an array of strings containg scripts that will run in order.
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

<a name="compilationOptions"></a>
## compilationOptions
Type: Object

An object whose properties control various aspects of compilation, the valid properties are listed below. Can also be specified per target framework as described in the [frameworks section](#frameworks)

For example:

    "compilationOptions": {
      "allowUnsafe": true
    }

<a name="define"></a>
### define
Type: String[]

A list of defines such as "DEBUG" or "TRACE" that can be used in conditional compilation in the code.

For example:

    {
        "compilationOptions": {
            "define": ["TEST", "OTHERCONDITION"]
        }
    }

<a name="nowarn"></a>
### nowarn
Type: String[]

A list of warnings to ignore.

For example:

    {
        "compilationOptions": {
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
        "compilationOptions": {
            "additionalArguments": ["/parallel", "/nostdlib"]
        }
    }

<a name="languageVersion"></a>
### languageVersion
Type: String

The version of the language used by the compiler: ISO-1, ISO-2, 3, 4, 5, 6, or Default

For example:

    {
        "compilationOptions": {
            "languageVersion": "5"
        }
    }

<a name="allowUnsafe"></a>
### allowUnsafe
Type: Boolean

Allows unsafe code in this project.

For example:

    {
        "compilationOptions": {
            "allowUnsafe": true
        }
    }

<a name="platform"></a>
### platform
Type: String

The name of the target platform, such as AnyCpu, x86 or x64.

For example:

    {
        "compilationOptions": {
            "platform": "x64"
        }
    }

<a name="warningsAsErrors"></a>
### warningsAsErrors
Type: Boolean

If set to true, treats warnings as errors.

For example:

    {
        "compilationOptions": {
            "warningsAsErrors": true
        }
    }

<a name="optimize"></a>
### optimize
Type: Boolean

Enables the compiler to optimize the code in this project.

For example:

    {
        "compilationOptions": {
            "optimize": true
        }
    }

<a name="keyFile"></a>
### keyFile
Type: String

The path for the key file used for signing this assembly.

For example:

    {
        "compilationOptions": {
            "keyFile": "../keyfile.snk"
        }
    }

<a name="delaySign"></a>
### delaySign
Type: Boolean

Causes signing to be delayed.

For example:

    {
        "compilationOptions": {
            "delaySign": true
        }
    }

<a name="publicSign"></a>
### publicSign
Type: Boolean

Enables signing of the resulting assembly.

For example:

    {
        "compilationOptions": {
            "publicSign": true
        }
    }

<a name="emitEntryPoint"></a>
### emitEntryPoint
Type: Boolean

Creates an executable if set to true, otherwise the project will produce a `.dll`.

For example:

    {
        "compilationOptions": {
            "emitEntryPoint": true
        }
    }

<a name="xmlDoc"></a>
### xmlDoc
Type: Boolean

Enables xml docs to be generated from comments in the source code.

For example:

    {
        "compilationOptions": {
            "xmlDoc": true
        }
    }

<a name="preserveCompilationContext"></a>
### preserveCompilationContext
Type: Boolean

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

An object whos properties define different configurations for this project, such as Debug and Release. Each value is an object that can contain a `compilationOptions` object with options specific for this coniguration.

For example:

    "configurations": {
      "Release": {
        "compilationOptions": {
          "allowUnsafe": false
        }
      }
    }

<a name="frameworks"></a>
## frameworks
Type: Object

Specifies what frameworks this project supports, such as .NET Framework or Universal Windows Platform (UWP). Must be a valid Target Framework Moniker (TFM). Each value is an object that can contain information specific to this framework such as `compilationoptions`, `analyzerOptions`, `dependencies` as well as the properties in the following sections.

For example:

    "frameworks": {
        "dnxcore50": {
            "compilationoptions": {
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
                "Microsoft.Extensions.JsonParser.Sources": "1.0.0-rc2-23811"
            }
        }
    }

<a name="frameworkAssemblies"></a>
### frameworkAssemblies
Type: Object

Similar to dependencies but contains reference to assemblies in the GAC that are not nuget packages. Can also specify the version to use as well as the dependency type. This is used when targeting .NET Framework and Portable Class Library(PCL) targets. You can only build a project with this specified on Windows.

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
