# How to manage package dependency versions for .NET Core RC2

By [Phillip Carter](https://github.com/cartermp)

This article covers what you need to know about package versions for authoring libraries for .NET Core.

## Glossary

**Fasten** - In the context of authoring libraries, fastening dependencies means you are using the same "family" of packages released on NuGet for .NET Core RC2.

**Metapackage** - A NuGet package that represents a set of NuGet packages.  They're organized in a way that makes sense for general library and app development.

**Trimming** - The act of removing the packages you do not depend on from a metapackage.  The end result is that your library only depends on packages it uses.  See guidance in [How to trim your package dependencies](trimming.md).

## Fasten your dependencies to RC2

When creating libraries with .NET Core RC2, it's important that you fasten your dependencies to RC2.  This means two things.  First, you should only depend on packages marked as `rc2`.  Second, each package should come from the same build; that is, every package should have this pattern: `<package_version>-rc2-<build_number>`.  `build_number` is `3002702` for the `Microsoft.NETCore.App` metapackage and `24027` for all other packages.

**Examples of packages fastened to RC2**

`"System.Collections":"4.0.11-rc2-24027"`

`"NETStandard.Library":"1.5.0-rc2-24027"`

`"Microsoft.NETCore.App":"1.0.0-rc2-3002702"`

**Examples of packages that are NOT fastened to RC2**

`"System.Collections":"4.0.11-rc3-24021-00"`

`"System.Net.Http":"4.1.0-rc2-24008"`

`"System.Text.RegularExpressions":"4.0.10-rc3-24021-00"`

### Why does this matter?

We guarantee that if you fasten your dependencies to RC2, those packages will all work together.  There is no such guarantee if you use packages which aren't fastened to RC2.

### Scenarios

Although there is a big list of all packages and their versions released with .NET Core RC2, you may not have to look through it if your library falls under certain scenarios.

**Are you depending only on** `NETStandard.Library`**?**

If so, you should fasten your `NETStandard.Library` package to version `1.5.0-rc2-24027`.  Because this is a curated metapackage, its package closure is also fastened to RC2.

**Are you depending only on** `Microsoft.NETCore.App`**?**

If so, you should fasten your `Microsoft.NETCore.App` package to version `1.0.0-rc2-3002702`.  Because this is a curated metapackage, its package closure is also fastened to RC2.

**Are you trimming your** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackage dependencies?**

If so, you should ensure that the metapackage you start with is fastened to RC2.  The individual packages you depend on after trimming are also fastened to RC2.

**Are you depending on packages outside the** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackages?**

If so, you need to fasten your other dependencies to RC2.  See the correct package versions and build numbers at the end of this article.

### A note on using a splat string (\*) when versioning

You may have adopted a versioning pattern which uses a splat (\*) string like this:
`"System.Collections":"4.0.11.-rc2-*"`.

**You should not do this**.  Using the splat string could result in restoring packages from different builds.  This could then result in some packages being incompatible.  Pick a specific number and use that number for all your package dependencies.

## Packages and Version Numbers organized by Metapackage

[List of all packages and their versions for RC2](https://github.com/dotnet/versions/blob/master/build-info/dotnet/corefx/release/1.0.0-rc2/Latest_Packages.txt).