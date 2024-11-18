.NET Standard 2.0 has 32,638 of the 37,118 available APIs.

| .NET implementation         | Version support                                          |
| --------------------------- | -------------------------------------------------------- |
| .NET and .NET Core          | 2.0, 2.1, 2.2, 3.0, 3.1, 5.0, 6.0, 7.0, 8.0, 9.0         |
| .NET Framework <sup>1</sup> | 4.6.1 <sup>2</sup>, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1 |
| Mono                        | 5.4, 6.4                                                 |
| Xamarin.iOS                 | 10.14, 12.16                                             |
| Xamarin.Mac                 | 3.8, 5.16                                                |
| Xamarin.Android             | 8.0, 10.0                                                |
| Universal Windows Platform  | 10.0.16299, TBD                                          |
| Unity                       | 2018.1                                                   |

<sup>1</sup> The versions listed for .NET Framework apply to .NET Core 2.0 SDK and later versions of the tooling. Older versions used a different mapping for .NET Standard 1.5 and higher. You can [download tooling for .NET Core tools for Visual Studio 2015](https://github.com/dotnet/core/blob/main/release-notes/download-archives) if you cannot upgrade to Visual Studio 2017 or a later version.

<sup>2</sup> The versions listed here represent the rules that NuGet uses to determine whether a given .NET Standard library is applicable. While NuGet considers .NET Framework 4.6.1 as supporting .NET Standard 1.5 through 2.0, there are several issues with consuming .NET Standard libraries that were built for those versions from .NET Framework 4.6.1 projects. For .NET Framework projects that need to use such libraries, we recommend that you upgrade the project to target .NET Framework 4.7.2 or higher.

For more information, see [.NET Standard 2.0][2.0]. For an interactive table, see [.NET Standard versions](https://dotnet.microsoft.com/platform/dotnet-standard#versions).

[2.0]: https://github.com/dotnet/standard/blob/v2.1.0/docs/versions/netstandard2.0.md
