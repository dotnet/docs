# .NET Docs

This repository contains the source for the official .NET documentation, which is published to [docs.microsoft.com/dotnet](https://docs.microsoft.com/dotnet). It also includes a collection of samples that demonstrate various .NET features.

## Repository Structure

The repository is organized as follows:

*   `docs/`: Contains the Markdown files that are published as .NET documentation.
*   `samples/`: Contains a collection of sample projects that demonstrate various .NET features.
*   `xml/`: Contains XML files that are used to generate API documentation.
*   `styleguide/`: Contains the style guide for writing .NET documentation.

## How to Use the Samples

The samples in this repository are organized by language and platform. To run a sample, you will need to have the .NET SDK installed. You can download it from the [.NET website](https://dotnet.microsoft.com/download).

To run a sample, navigate to the sample's directory and use the `dotnet` command-line interface (CLI) to build and run the project. For example, to run the `PatternMatching` sample, you would use the following commands:

```bash
cd samples/csharp/PatternMatching
dotnet run
```

## Contributing

We welcome contributions to help us improve and complete the .NET docs. To contribute, see the [Contributing Guide](CONTRIBUTING.md) and the [issues list](https://github.com/dotnet/docs/issues).

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

## Samples Build Status

| Samples | Ubuntu 16.04<br/>_.NET Core 1.1.0_ | Ubuntu 16.04<br/>_.NET Core 2.0.0-preview_  |
| ------------- |------------| -----|
| `/samples/core` | ![](https://constructors.visualstudio.com/_apis/public/build/definitions/3186585f-1677-4c9e-a8b2-baac48a4032a/56/badge)| ![](https://constructors.visualstudio.com/_apis/public/build/definitions/3186585f-1677-4c9e-a8b2-baac48a4032a/57/badge) |
|`/samples/csharp`| ![](https://constructors.visualstudio.com/_apis/public/build/definitions/3186585f-1677-4c9e-a8b2-baac48a4032a/54/badge)| ![](https://constructors.visualstudio.com/_apis/public/build/definitions/3186585f-1677-4c9e-a8b2-baac48a4032a/55/badge) |
