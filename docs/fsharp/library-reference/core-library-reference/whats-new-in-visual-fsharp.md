---
title: What's new in Visual F#
description: What's new in Visual F#
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 06/06/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d5cfe385-7d71-409e-a585-d67ee3acd150
---

Learn about what's new in Visual F#. On this page we only cover the most recent release. For full details, please refer to [the language changelog](https://aka.ms/visualfsharpchangelog).

### 4.0.0 - Visual Studio 2015 Update 1 - November 30, 2015

#### Enhancements
* Perf: `for i in expr do body` optimization [#219](https://github.com/Microsoft/visualfsharp/pull/219)
* Remove type provider security dialog and use custom icon for type provider assembly reference [#448](https://github.com/Microsoft/visualfsharp/pull/448)
* Perf: Enable parallel build inside Visual Studio [#487](https://github.com/Microsoft/visualfsharp/pull/487)
* Perf: Remove StructBox for Value Types [#549](https://github.com/Microsoft/visualfsharp/pull/549)
* Add compiler warnings for redundant arguments in raise/failwith/failwithf/nullArg/invalidOp/invalidArg [#630](https://github.com/Microsoft/visualfsharp/pull/630)
* Add a compiler warning for lower case literals in patterns [#666](https://github.com/Microsoft/visualfsharp/pull/666)

#### Bug fixes
* Fix scope of types for named values in attributes improperly set [#437](https://github.com/Microsoft/visualfsharp/pull/437)
* Add general check for escaping typars to check phase [#442](https://github.com/Microsoft/visualfsharp/pull/442)
* Fix AccessViolationException on obfuscated assemblies [#519](https://github.com/Microsoft/visualfsharp/pull/519)
* Fix memory leaks while reloading solutions in Visual Studio [#591](https://github.com/Microsoft/visualfsharp/pull/591)
* Enable breakpoints in `with` augmentations for class types [#608](https://github.com/Microsoft/visualfsharp/pull/608)
* Fix false escaping type parameter check error [#613](https://github.com/Microsoft/visualfsharp/pull/613)
* Fix quotation of readonly fields [#622](https://github.com/Microsoft/visualfsharp/pull/622)
* Keep the reference icons when opening references [#623](https://github.com/Microsoft/visualfsharp/pull/623)
* Don't suppress missing FSI transitive references [#626](https://github.com/Microsoft/visualfsharp/pull/626)
* Make Seq.cast's non-generic and generic IEnumerable implementations equivalent [#651](https://github.com/Microsoft/visualfsharp/pull/651)

### 4.0.0 - July 20, 2015

#### Language, compiler, runtime, interactive

* Normalization and expansion of [Array](collections.array-module-%5bfsharp%5d.md), [List](collections.list-module-%5BFSharp%5D.md), and [Seq](collections.seq-module-%5BFSharp%5D.md) modules
  * New APIs for 4.0: `chunkBySize`, `contains`, `except`, `findBack`, `findInstanceBack`, `indexed`, `item`, `mapFold`, `mapFoldBack`, `sortByDescending`, `sortDescending`, `splitInto`, `tryFindBack`, `tryFindIndexBack`, `tryHead`, `tryItem`, `tryLast`
  ![Collection API additions](images/fsharp-4.0.0-breakdown.png)
* Other new APIs
  * [Option.filter](option.filter%5b%27t%5d-function-%5bfsharp%5d.md), `Option.toObj`, `Option.ofObj`, [Option.toNullable](option.tonullable%5b%27t%5d-function-%5bfsharp%5d.md), `Option.ofNullable`
  * `String.filter`
  * `Checked.int8`, `Checked.uint8` 
  * `Async.AwaitTask` (non-generic)
  * `WebClient.AsyncDownloadFile`, `WebClient.AsyncDownloadData`
  * `tryUnbox`, `isNull`
* New active pattern to match constant `Decimal` in quotations
* Slicing support for lists
* Support for consuming high-rank (> 4) arrays
* Support for units of measure in `printf`-family functions
* Support for constructors/class names as first-class functions
* Improved exception stack traces in async code
* Automatic `mutable`/`ref` conversion
* Support for static arguments to provided methods
* Support for non-nullable provided types
* Added `NonStructuralComparison` module containing non-structural comparison operators
* Support for rational exponents in units of measure
* Give fsi.exe, fsiAnyCpi.exe nice icons
* `Microsoft.` optional in namespace paths from FSharp.Core
* Support for extension properties in object initializers
* Pre-support (not yet used) for additional nativeptr intrinsics
* Simplified, more robust resolution of type references in quotations
* Support for inheritance of types that have multiple interface instantiations
* Extended preprocessor grammar
* Support for implicit quotation of expressions used as method arguments
* Support for multiple properties in `[<StructuredFormatDisplay>]`
* Eliminate tuple allocation for implicitly returned formal arguments
* Perf: fsc.exe now uses `GCLatencyMode.Batch`
* Perf: Improved `hash`/`compare`/`distinctBy`/`groupBy` performance
* Perf: `Seq.toArray` perf improvement
* Perf: Use `OptimizedClosures.FSharpFunc` in seq.fs where applicable
* Perf: Use literals and mutable variables instead of ref cells for better performance in SHA1 calc
* Perf: Use smart blend of `System.Array.Copy` and iterative copy for array copies
* Perf: Change `Seq.toList` to mutation-based to remove reliance on `List.rev`
* Perf: Change `pdbClose` to test if files are locked before inducing GCs
* Perf: Use server GC mode for compiler
* Bugfix: Changed an error message within the Set module to use the correct module name.
* Bugfix: Fix assembly name of warning FS2003
* Bugfix [#132](http://visualfsharp.codeplex.com/workitem/132): FSI Shadowcopy causes a significant degrade in the fsi first execute time
* Bugfix [#131](https://visualfsharp.codeplex.com/workitem/131): Fix getentryassembly return value when shadowcopy is enabled in FSI
* Bugfix [#61](https://visualfsharp.codeplex.com/workitem/61) Nonverifiable code generated with units of measure conversion
* Bugfix [#68](https://visualfsharp.codeplex.com/workitem/68) BadImageFormatException with Units of Measure
* Bugfix [#146](https://visualfsharp.codeplex.com/workitem/146) BadImageFormatException in both Release and Debug build with units of measure
* Bugfix: Incorrent cross-module inlining between different .NET profiles
* Bugfix: Properly document exceptions in `Array` module
* Bugfix [#24](https://visualfsharp.codeplex.com/workitem/24): Error reporting of exceptions in type providers `AddMemberDelayed`
* Bugfix [#13](https://github.com/fsharp/fsharp/issues/13): Error on FSI terminal resize
* Bugfix [#29](https://github.com/fsharp/fsharp/issues/29): Module access modifier `internal` does not give internal access if no namespaces are used
* Bugfix: Fix typo in error message for invalid attribute combination
* Bugfix [#27](https://github.com/microsoft/visualfsharp/issues/27): Private module values can be mutated by other modules
* Bugfix [#38](https://github.com/microsoft/visualfsharp/issues/38): ICE - System.ArgumentException: not a measure abbreviation, or incorrect kind
* Bugfix [#44](https://github.com/microsoft/visualfsharp/issues/44): Problems using FSI to `#load` multiple files contributing to the same namespace
* Bugfix [#95](https://github.com/microsoft/visualfsharp/issues/95): `[<RequireQualifiedAccess>]` allows access to DU member if qualified only by module name
* Bugfix [#89](https://github.com/microsoft/visualfsharp/issues/89): Embedding an untyped quotation in a typed quotation results in ArgumentException
* Bugfix: Show warning when Record is accessed without type but `[<RequireQualifiedAccess>]` was set
* Bugfix [#139](https://visualfsharp.codeplex.com/workitem/139): Memory leak in `Async.AwaitWaitHandle`
* Bugfix [#122](https://github.com/microsoft/visualfsharp/issues/122): `stfld` does not give `.volatile` annotation
* Bugfix [#30](https://github.com/microsoft/visualfsharp/issues/30): Compilation error "Incorrect number of type arguments to local call"
* Bugfix [#163](https://github.com/microsoft/visualfsharp/issues/163): Array slicing does not work properly with non 0-based arrays
* Bugfix [#148](https://github.com/microsoft/visualfsharp/issues/148): XML doc comment generation adding empty garbage
* Bugfix [#98](https://github.com/Microsoft/visualfsharp/issues/98): Using a single, optional, static parameter to a type provider causes failure
* Bugfix [#109](https://github.com/Microsoft/visualfsharp/issues/109): Invalid interface generated by --sig
* Bugfix [#123](https://github.com/Microsoft/visualfsharp/issues/123): Union types without sub-classes should be sealed
* Bugfix [#68](https://github.com/Microsoft/visualfsharp/issues/68): F# 3.1 / Profile 259: `<@ System.Exception() @>` causes AmbiguousMatchException at runtime
* Bugfix [#9](https://github.com/Microsoft/visualfsharp/issues/9): Internal error in FSI: FS0192: binding null type in envBindTypeRef
* Bugfix [#10](https://github.com/Microsoft/visualfsharp/issues/10): Internal error: binding null type in envBindTypeRef
* Bugfix [#266](https://github.com/Microsoft/visualfsharp/issues/266): `windowed` error message incorrectly flags "non-negative" input when "positive" is what's needed
* Bugfix [#270](https://github.com/Microsoft/visualfsharp/issues/270): "internal error: null: convTypeRefAux" in interactive when consuming quotation containing type name with commas or spaces
* Bugfix [#276](https://github.com/Microsoft/visualfsharp/issues/276): Combining struct field with units of measure will result managed type instead of unmanaged type
* Bugfix [#269](https://github.com/Microsoft/visualfsharp/issues/269): Accidentally `#load`ing a DLL in script causes internal error
* Bugfix [#293](https://github.com/Microsoft/visualfsharp/issues/293): `#r` references without relative path are not loaded when file is local
* Bugfix [#237](https://github.com/Microsoft/visualfsharp/issues/237): Problems using FSI on multiple namespaces in a single file
* Bugfix [#338](https://github.com/Microsoft/visualfsharp/issues/338): Escaped unicode characters are encoded incorrectly
* Bugfix [#370](https://github.com/Microsoft/visualfsharp/issues/370): `Seq.sortBy` cannot handle sequences of floats containing NaN
* Bugfix [#368](https://github.com/Microsoft/visualfsharp/issues/368): Optimizer incorrectly assumes immutable field accesses are side-effect free
* Bugfix [#337](https://github.com/Microsoft/visualfsharp/issues/337): Skip interfaces that lie outside the set of referenced assemblies
* Bugfix [#383](https://github.com/Microsoft/visualfsharp/issues/383): Class with `[<AllowNullLiteral(false)>]` barred from inheriting from normal non-nullable class
* Bugfix [#420](https://github.com/Microsoft/visualfsharp/issues/420): Compiler emits incorrect visibility modifier for internal constructors of abstract class
* Bugfix [#362](https://github.com/Microsoft/visualfsharp/issues/362): Depickling assertion followed by nullref internal errors in units-of-measure case
* Bugfix [#342](https://github.com/Microsoft/visualfsharp/issues/342): FS0193 error when specifying sequential struct layout of a type
* Bugfix [#299](https://github.com/Microsoft/visualfsharp/issues/299): AmbiguousMatchException with `[<ReflectedDefinition>]` on overloaded extension methods
* Bugfix [#316](https://github.com/Microsoft/visualfsharp/issues/316): Null array-valued attribute causes internal compiler error
* Bugfix [#147](https://github.com/Microsoft/visualfsharp/issues/147): FS0073: internal error: Undefined or unsolved type variable: 'a
* Bugfix [#34](https://github.com/Microsoft/visualfsharp/issues/34): Error in pass2 for type FSharp.DataFrame.FSharpFrameExtensions, error: duplicate entry 'Frame2.GroupRowsBy' in method table
* Bugfix [#212](https://github.com/Microsoft/visualfsharp/issues/212): Record fields initialized in wrong order
* Bugfix [#445](https://github.com/Microsoft/visualfsharp/issues/445): Inconsistent compiler prompt message when using `--pause` switch
* Bugfix [#238](https://github.com/Microsoft/visualfsharp/issues/238): Generic use of member constraint solved to record field causes crash

#### Visual Studio

* Updated all templates (except tutorial) to include AssemblyInfo.fs setup in the same manner as default C# project templates
* Add keyboard shortcuts for FSI reset and clear all
* Improved debugger view for Map values
* Improved performance reading stdout/stderr from fsi.exe to F# Interactive window
* Support for VS project up-to-date check
* Improved project template descriptions, make it clearer how to target Xamarin platforms
* Intellisense completion in object initializers
* Add menu entry "Open folder in File Explorer" on folder nodes
* Intellisense completion for named arguments
* `Alt+Enter` sends current line of code to interactive if there is no selection
* Support for debugging F# scripts with the VS debugger
* Add support for hexadecimal values (like 0xFF) ??to MSBuild property BaseAddress
* Updated menu icons used for F# interactive to align with other VS interactive windows
* Bugfix: Fix url of fsharp.org website in vs templates
* Bugfix [#141](https://visualfsharp.codeplex.com/workitem/141): The "Error List" window does not parse MSBuild messages correctly
* Bugfix [#147](https://visualfsharp.codeplex.com/workitem/147): Go to definition doesn't work for default struct ctors
* Bugfix [#50](https://github.com/microsoft/visualfsharp/issues/50): Members hidden from IntelliSense still show up in tooltips
* Bugfix [#57](https://github.com/microsoft/visualfsharp/issues/57) (partial): Visual Studio locking access to XML doc files
* Bugfix [#157](https://github.com/Microsoft/visualfsharp/issues/157): Should not allow Framework 4 / F# 3.1 combination in project properties
* Bugfix [#114](https://github.com/Microsoft/visualfsharp/issues/114): Portable Library (legacy) template displays wrong target framework version
* Bugfix [#273](https://github.com/Microsoft/visualfsharp/issues/273): VS editor shows bogus errors when scripts use multi-hop `#r` and `#load` with relative paths
* Bugfix [#312](https://github.com/Microsoft/visualfsharp/issues/312): F# library project templates and portable library templates do not have `AutoGenerateBindingRedirects` set to true
* Bugfix [#321](https://github.com/Microsoft/visualfsharp/issues/321): Provided type quickinfo shouldn't show hidden and obsolete members from base class
* Bugfix [#319](https://github.com/Microsoft/visualfsharp/issues/319): Projects with target runtime 3.0 don't show up correctly on the VS project dialog
* Bugfix [#283](https://github.com/Microsoft/visualfsharp/issues/283): Changing target framework causes incorrect binding redirects to be added to app.config
* Bugfix [#278](https://github.com/Microsoft/visualfsharp/issues/278): NullReferenceException when trying to add some COM references
* Bugfix [#259](https://github.com/Microsoft/visualfsharp/issues/259): Renaming files in folders causes strange UI display
* Bugfix [#350](https://github.com/Microsoft/visualfsharp/issues/350): Renaming linked file results in error dialog
* Bugfix [#381](https://github.com/Microsoft/visualfsharp/issues/381): Intellisense stops working when referencing PCL component from script (requires `#r "System.Runtime"`)
* Bugfix [#104](https://github.com/Microsoft/visualfsharp/issues/104): Using paste to add files to an F# project causes the order of files in the project and on the UI to get out of sync
* Bugfix [#417](https://github.com/Microsoft/visualfsharp/issues/417): 'Move file up/down' keybindings should be scoped to solution explorer
* Bugfix [#246](https://github.com/Microsoft/visualfsharp/issues/246): Fix invalid already rendered folder error
* Bugfix [#106](https://github.com/Microsoft/visualfsharp/issues/106) (partial): Visual F# Tools leak memory while reloading solutions
