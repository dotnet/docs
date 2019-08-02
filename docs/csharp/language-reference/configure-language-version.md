---
title: C# language versioning - C# Guide
description: Learn about how the C# language version is determined based on your project, and the different values you can manually adjust it to.
ms.date: 07/10/2019
---

# C# language versioning

The C# compiler determines a default language version based on your project's target framework or frameworks. This is because the C# language may have features that rely on types or runtime components that are not available in every .NET implementation. This also ensures that for whatever target your project is built against, you get the highest compatible language version by default.

## Defaults

The compiler determines a default based on these rules:

|Target framework|version|C# language version default|
|----------------|-------|---------------------------|
|.NET Core|3.x|C# 8.0|
|.NET Core|2.x|C# 7.3|
|.NET Standard|all|C# 7.3|
|.NET Framework|all|C# 7.3|

## Default for previews

When your project targets a preview framework that has a corresponding preview language version, the language version used is the preview language version. This ensures that you can use the latest features that are guaranteed to work with that preview in any environment without affecting your projects that target a released .NET Core version.

## Override a default

If you must specify your C# version explicitly, you can do so in several ways:

- Manually edit your [project file](#edit-the-project-file).
- Set the language version [for multiple projects in a subdirectory](#configure-multiple-projects).
- Configure the [`-langversion` compiler option](compiler-options/langversion-compiler-option.md)

### Edit the project file

You can set the language version in your project file. For example, if you explicitly want access to preview features, add an element like this:

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

The value `preview` uses the latest available preview C# language version that your compiler supports.

### Configure multiple projects

You can create a **Directory.Build.props** file that contains the `<LangVersion>` element to configure multiple directories. You typically do that in your solution directory. Add the following to a **Directory.Build.props** file in your solution directory:

```xml
<Project>
 <PropertyGroup>
   <LangVersion>preview</LangVersion>
 </PropertyGroup>
</Project>
```

Now, builds in every subdirectory of the directory containing that file will use the preview C# version. For more information, see the article on [Customize your build](/visualstudio/msbuild/customize-your-build).

## C# language version reference

The following table shows all current C# language versions. Your compiler may not necessarily understand every value if it is older. If you install .NET Core 3.0, then you will have access to everything listed.

|Value|Meaning|
|------------|-------------|
|preview|The compiler accepts all valid language syntax from the latest preview version.|
|latest|The compiler accepts syntax from the latest released version of the compiler (including minor version).|
|latestMajor|The compiler accepts syntax from the latest released major version of the compiler.|
|8.0|The compiler accepts only syntax that is included in C# 8.0 or lower.|
|7.3|The compiler accepts only syntax that is included in C# 7.3 or lower.|
|7.2|The compiler accepts only syntax that is included in C# 7.2 or lower.|
|7.1|The compiler accepts only syntax that is included in C# 7.1 or lower.|
|7|The compiler accepts only syntax that is included in C# 7.0 or lower.|
|6|The compiler accepts only syntax that is included in C# 6.0 or lower.|
|5|The compiler accepts only syntax that is included in C# 5.0 or lower.|
|4|The compiler accepts only syntax that is included in C# 4.0 or lower.|
|3|The compiler accepts only syntax that is included in C# 3.0 or lower.|
|ISO-2|The compiler accepts only syntax that is included in ISO/IEC 23270:2006 C# (2.0) |
|ISO-1|The compiler accepts only syntax that is included in ISO/IEC 23270:2003 C# (1.0/1.2) |
