---
title: "WPF community feedback"
ms.date: "03/01/2018"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-wpf"
ms.topic: "article"
helpviewer_keywords: 
  - "community resources [WPF]"
  - "forums [WPF]"
  - "bug descriptions [WPF]"
ms.assetid: 468b060a-d54b-4900-a74a-9faccb554045
author: mairaw
ms.author: mairaw
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF community feedback

Microsoft exposes a variety of community resources for you to learn about, discuss, and provide feedback on Windows Presentation Foundation (WPF). These resources include forums and the [Visual Studio Developer Community](https://developercommunity.visualstudio.com/) site. Each community resource offers a different set of benefits. These benefits are described here, as are a set of best practices for using each to ensure the best response from the community at large and Microsoft in particular.

> [!NOTE]
> Don't use the feedback section located at the bottom of each page to send product feedback. These links are for documentation feedback only.

## Forums

The [WPF forum](https://social.msdn.microsoft.com/Forums/vstudio/en-US/home?forum=wpf) is the primary community resource for discussing and resolving issues. Forums facilitate discussion and problem resolution by offering a comprehensive set of supporting features that include:

- Searching.
- Discussion tracking.
- Rich formatting for text and code.
- Visual Studio integration.
- Most Valued Professional (MVP) and community involvement.
- Monitoring to ensure posts are responded to in the quickest possible time.

Another option for you to ask questions to the community about WPF is [Stack Overflow](https://stackoverflow.com/questions/tagged/wpf).

### Forum best practices

Using the following best practices help to address issues posted to the WPF forum in the quickest possible time. These practices are applicable to all forums.

#### Search existing posts

Some issues occur widely enough that others have faced them before you. Consequently, you can solve your problem quickly, or you can add your input to an existing discussion.

#### Use meaningful titles

Concise, meaningful titles improve the discoverability of your posts. They also make it easier for other WPF forum community members to determine if they can solve your problem.

#### Include appropriate content

Describe the issue and how you’ve tried to work through it. If possible, include supporting code snippets, or the simplest possible sample that demonstrates your issue. All these details help to increase the chance your question will be answered quickly.

## Visual Studio Developer Community

Issues can sometimes be difficult to resolve, or irresolvable. Such situations arise because of bugs in the technology, difficulties applying the technology to particular scenarios, or lack of support for particular scenarios. This information is important to Microsoft, and can be provided via the [Visual Studio Developer Community](https://developercommunity.visualstudio.com/) site.

Items posted on the WPF Product Feedback Center are routed to the WPF team's internal bug database. Consequently, it is the most reliable way to get your feedback to the WPF feature owner. In addition, you can validate and track suggestions and bugs as well as vote on them, which helps the WPF team to prioritize issues.

### Developer Community best practices

When posting to the Visual Studio Developer Community, searching existing posts, providing a meaningful title and appropriate content are important best practices, just as they are for posting to the WPF forum. The following are additional best practices you should also employ.

#### Search existing posts

Some issues occur widely enough that others have faced them before you. Consequently, you can solve your problem quickly, or you can add your input to an existing issue.

#### Use meaningful titles

Concise, meaningful titles increase the chance that your issue is directed to the most appropriate WPF team in the shortest amount of time. This is particularly important for a technology like WPF, which contains many interrelated features.

#### Describe how to reproduce your bug

When you post about a bug, it is important to include the following where relevant:

- Provide a clear description of the bug.
- Use code snippets to support the bug description.
- Provide a list of steps that demonstrate how to reproduce the bug.
- Include the smallest possible code sample that reproduces the bug.
- Mention whether the bug is consistently reproducible or not.
- Include relevant exception information.

 If the bug is install or setup related, attach the relevant install logs and snapshots (files prefixed with "dd_" that are located in your %temp% folder).

 For compile or build issues, attach the build logs. The MSBuild system can be configured to supports logging with various verbosities by using the /v: switch from the command line or by configuring the appropriate level from an Integrated Development Environment (IDE) like Visual Studio.

#### Provide environment information

Background information can often be useful for adding context to your post. In particular, mention the operating system platform, processor family, and architecture, such as "Windows 10 Version 1709, Intel(R) Xeon(R), x64."

If the issue you are posting about is related to rendering, you should also include graphics card and driver details, if possible. This information is important because WPF is a presentation framework.

#### Provide solution or project information

Bugs may pertain to the tools used to develop and build your applications and the types of applications you are building. Consequently, it can be useful to specify:

- The type of application you are building, such as:
  - Application (*.exe*) or library (*.dll*)
  - Extensible Application Markup Language (XAML)  browser application (XBAP)
  - Loose XAML application
  - Standalone installed applications
  - Standalone ClickOnce-deployed applications
- The development tool, such as:
  - MSBuild
  - Expression Graphic Designer
  - Expression Interactive Designer
  - Visual Studio
- The solution configuration, such as:
  - A solution
  - A single project
  - A solution with multiple dependent projects
- Whether your application has language-specific or language-neutral resources. For example, did you specify the `UICulture` project property or localizable metadata for `Application`, `Page`, and `Resource` types?
- Whether you used the neutral language setting in the AssemblyInfo.cs or AssemblyInfo.vb file.

#### Provide scenario and impact information

Provide information about the scenario that manifests the bug and its impact. This information is highly important to the WPF team when it decides if, when, and how a problem should be fixed, or whether an acceptable workaround can be used instead.

Ordinarily, crash and data loss scenarios are high impact and, therefore, the easiest to prioritize. Some bugs, however, only show up in uncommon scenarios, which may also be mainline scenarios in some cases. Providing context around scenario and impact helps the WPF team make the right decision.

## See also

[How to report a problem with Visual Studio 2017](/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)
