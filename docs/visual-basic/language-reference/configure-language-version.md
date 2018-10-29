---
title: Select the Visual Basic language version
description: Configure the compiler to perform syntax validation using a specific compiler version.
ms.date: 05/24/2018
---

# Select the Visual Basic language version

The Visual Basic compiler defaults to the latest major version of the language that has been released. You may choose to compile any project using a new point release of the language. Choosing a newer version of the language enables your project to make use of the latest language features. In other scenarios, you may need to validate that a project compiles cleanly when using an older version of the language.

This capability decouples the decision to install new versions of the SDK and tools in your development environment from the decision to incorporate new language features in a project. You can install the latest SDK and tools on your build machine. Each project can be configured to use a specific version of the language for its build.

There are three ways to set the language version:

- Manually edit your [**.vbproj** file](#edit-the-vbproj-file)
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects)
- Configure the [`-langversion` compiler option](#set-the-langversion-compiler-option)

## Edit the vbproj file

You can set the language version in your **.vbproj** file. Add the following element:

```xml
<PropertyGroup>
   <LangVersion>latest</LangVersion>
</PropertyGroup>
```

The value `latest` uses the latest minor version of the Visual Basic language. Valid values are:

|Value|Meaning|
|------------|-------------|
|default|The compiler accepts all valid language syntax from the latest major version that it can support.|
|9|The compiler accepts only syntax that is included in Visual Basic 9.0 or lower.|
|10|The compiler accepts only syntax that is included in Visual Basic 10.0 or lower.|
|11|The compiler accepts only syntax that is included in Visual Basic 11.0 or lower.|
|12|The compiler accepts only syntax that is included in Visual Basic 12.0 or lower.|
|14|The compiler accepts only syntax that is included in Visual Basic 14.0 or lower.|
|15|The compiler accepts only syntax that is included in Visual Basic 15.0 or lower.|
|15.3|The compiler accepts only syntax that is included in Visual Basic 15.3 or lower.|
|15.5|The compiler accepts only syntax that is included in Visual Basic 15.5 or lower.|
|latest|The compiler accepts all valid language syntax that it can support.|

The special strings `default` and `latest` resolve to the latest major
and minor language versions installed on the build machine, respectively.

## Configure multiple projects

You can create a **Directory.build.props** file that contains the `<LangVersion>` element to configure multiple directories. You typically do that in your solution directory. Add the following to a **Directory.build.props** file in your solution directory:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>15.5</LangVersion>
 </PropertyGroup>
</Project>
```

Now, builds in every subdirectory of the directory containing that file will use Visual Basic version 15.5 syntax. For more information, see the article on [Customize your build](/visualstudio/msbuild/customize-your-build.md).

## Set the langversion compiler option

You can use the `-langversion` command-line option. For more information, see the article on the [-langversion](../reference/command-line-compiler/langversion.md) compiler option. You can see a list of the valid values by typing  `vbc -langversion:?` .
