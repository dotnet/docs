---
title: Overview of GitHub Copilot app modernization for .NET (Preview)
description: Learn about essential concepts for GitHub Copilot app modernization for .NET 
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# GitHub Copilot app modernization for .NET (Preview) overview

[GitHub Copilot app modernization for .NET (Preview)]([https://aka.ms/appmod-dotnet-marketplace](https://aka.ms/ghcp-appmod/dotNET)) helps you migrate .NET applications to Azure quickly and confidently by guiding you through assessment, solution recommendations, code fixes, validation and deployment.

With this assistant, you can:
- Assess your application's code, configuration, and dependencies.
- Plan and set up the right Azure resource
- Fix issues and apply best practices for cloud migration
- Validate that your app builds and tests successfully
- Deploy to Azure

This process streamlines modernization and boosts developer productivity and confidence. App Modernization for .NET is an all-in-one migration assistant that uses AI to improve developer velocity, quality, and results.

Please refer to [Github Copilot App Modernization Overview](https://aka.ms/ghcp-appmod/dotNET) for overview and prerequisites.

For a complete walkthrough of setting up and using GitHub Copilot app modernization for .NET for Migration, see [Quickstart: Assessing an application and applying code changes](quickstart.md).

## Key concepts

GitHub Copilot app modernization for .NET supports end-to-end migration to Azure, including assessment, planning, code remediation, build fixes, and deployment. It uses GitHub Copilot AI capabilities to help you migrate and run your applications on Azure with confidence, accelerating the entire modernization lifecycle.

When code changes are needed, the tool guides you through remediation using predefined tasks for common issues, such as:

- Switching from password-based authentication to managed identities
- Moving from AWS S3 to Azure Blob Storage

For more information, see [Predefined tasks](predefined-tasks.md).

## Key Features

App Modernization for .NET (Preview) supports the following scenarios:

- **Assessment of modernization issue**  

    Evaluates your application's readiness for Azure migration in Visual Studio, powered by [AppCAT for .NET](../appcat/install.md).

    ![Assessment](media/overview_assessment.png)

- **Solution recommendations**  

    Recommends target Azure services for your application's resource dependencies, tailored to each category of assessed issues.

    ![Solution](media/overview_solution.png)

- **Code remediation for common issues**

    Accelerates code changes for [common modernization issues](predefined-tasks.md) by applying predefined tasks that represent expert best practices.

    ![Apply Task](media/overview_remediation.png)

- **Automatic fixes for compilation errors:**  

    Automatically discovers and fixes compilation errors introduced by code changes.

## Feedback and privacy

- **Feedback:** We value your feedback—share [your thoughts here](https://aka.ms/AM4DFeedback) to help us improve the product.
- **License:** This extension is licensed under the [GitHub Copilot Product Specific Terms](https://github.com/customer-terms/github-copilot-product-specific-terms).
- **Trademarks:** This project might contain trademarks or logos for projects, products, or services. Authorized use of Microsoft trademarks or logos is subject to and must follow [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general). Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship. Any use of third-party trademarks or logos is subject to those third parties' policies.
- **Privacy:** App Modernization for .NET (Preview) uses GitHub Copilot in the same way you use it to modify code, and doesn't retain code snippets beyond the immediate session. Telemetry metrics are collected and analyzed to track feature usage and effectiveness. Review the [Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839) for more information.
- **Transparency:** App Modernization for .NET (Preview) uses GitHub Copilot to make code changes, and AI might sometimes make mistakes. Carefully review and test any code changes made by the tool before using them in your production environment.

## Next Steps

- [Quickstart: Assessing an application and applying code changes](quickstart.md)
- [Common modernization issues with predefined tasks](predefined-tasks.md)
- [Frequently Asked Questions](faq.md)
