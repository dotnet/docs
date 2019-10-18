# Labels and projects roadmap

The .NET docs team makes extensive use of [GitHub labels](https://github.com/dotnet/docs/labels) to organize our work. By filtering on combinations of labels, we can quickly focus on sections of the [.NET docs website](https://docs.microsoft.com/dotnet) of interest. 

We also use [GitHub projects](https://github.com/dotnet/docs/projects) to organize sprints and other goal oriented epics.

This roadmap explains how we use these organizational tools, and has links to handy filters we use to find areas of interest.

## Labels

If this is your first experience with [dotnet/docs](https://github.com/dotnet/docs), start with the [up-for-grabs](https://github.com/dotnet/docs/labels/up-for-grabs) issues. These are issues that have a more focused scope. They are a great way to make your first contribution. From the up-for-grabs view, you can further filter issues based on areas and priority.

We use labels to classify issues in many different ways:

- [.NET Guides](find-a-single-.net-guide) and [sections of a guide](#search-one-section-of-a-guide).
- [Target release](#releases)
- [Priority](#priority)

You can combine a label from each set (guide, release, priority) to create a narrow focus to find issues you want to work on.

### Find a single .NET guide

We use labels for each of the architecture guides, and for each .NET Guide. 

![:book: guide on light green background](./images/guide.png "Prefix for architecture guide labels")

Architecture guides are noted with the `:book: guide` prefix and have a light green background. These are the long-form areas that cover recommended architecture. Here are current issues filtered for each of the .NET architecture guides.

- [ASP.NET Core web apps](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20ASP.NET%20Core%20web%20apps)
- [Blazor](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Blazor)
- [Cloud Native](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Cloud%20Native)
- [Docker lifecycle](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Docker%20lifecycle)
- [Framework design guidelines](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Framework%20Design%20Guidelines)
- [gRPC](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20gRPC)
- [Modernizing w/ Windows containers](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Modernizing%20w%2F%20Windows%20containers)
- [.NET Microservices](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20.NET%20Microservices)
- [Serverless apps](https://github.com/dotnet/docs/labels/%3Abook%3A%20guide%20-%20Serverless%20apps)

![:books: Area on dark blue background](./images/area.png "Prefix for .NET Guide area labels")

Each .NET Guide is noted with the `:books: Area` prefix and has a dark blue background. Here are current issues filtered for each of the .NET guides.

- [API Reference](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20API%20Reference)
- [Azure .NET SDK](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20Azure%20.NET%20SDk)
- [C# Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20C%23%20Guide)
- [Desktop Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20Desktop%20Guide)
- [F# Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20F%23%20Guide)
- [ML.NET Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20ML.NET%20Guide)
- [.NET Architecture Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20.NET%20Architecture%20Guide) - Could be removed
- [.NET Core Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20.NET%20Core%20Guide)
- [.NET for Apache Spark Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20.NET%20for%20Apache%20Spark%20Guide)
- [.NET Framework Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20.NET%20Framework%20Guide)
- [.NET Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20.NET%20Guide)
- [Roslyn API Reference](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20Roslyn%20API%20Reference) - could be removed.
- [Visual Basic Guide](https://github.com/dotnet/docs/labels/%3Abooks%3A%20Area%20-%20Visual%20Basic%20Guide)

#### Search one section of a guide

![:card_file_box: Area on medium blue background](./images/technology.png "Prefix for .NET Guide sub-area labels")

The .NET guides are large, so these labels further limit the scope by a section of a guide. Each .NET Guide is noted with the `:card_file_box: Technology` prefix and has a medium blue background. Many of these labels apply to multiple guides. You should add one of these labels after scoping your search to one of the areas described in the previous section.

- AppCompat
- Async Task
- C# Advanced concepts
- C# compiler
- C# Fundamentals
- C# Get Started
- C# Language Reference
- C# Null safety
- C# What's new
- CLI
- Data Access
- Docker
- Installers
- LINQ
- NCL
- .NET Standard
- Roslyn APIs
- Security
- WCF
- WF
- WIF
- WinForms
- WPF

### Releases

![:checkered_flag: Release: on dark dark yellow](./images/release.png "Prefix for release labels")

Issues tagged for a specific release are noted with the `:checkered_flag: Release:` prefix and have a dark yellow background. 

- .NET Core 2.1
- .NET Core 2.2
- .NET Core 3.0
- .NET Framework 4.7.2
- .NET Framework 4.8

### Priority

Priority labels are all `P` followed by a single digit. Lower numbers are higher priority:

- P0
- P1
- P2

### What about the other labels?

There are many other labels used by the content teams to manage different classifications of issues. The labels can be ignored outside of the content team.

## Projects

Contributors should check the [Projects for .NET community collaborators](https://github.com/dotnet/docs/projects/35). We've created different columns for maintenance, document updates, and new content tasks. This can be a way to find tasks of interest. (Note that the project view can be filtered using the labels described above.) 

We also use projects in two other ways:

- Month YYYY project types: These are scrum boards for each month's working plan.
- Long-running epics: These are used to organize tasks toward a goal when the work will occur over several months.

