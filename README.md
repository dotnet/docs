# .NET Docs

[![GitHub contributors](https://img.shields.io/github/contributors/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/graphs/contributors/)
[![GitHub repo size](https://img.shields.io/github/repo-size/dotnet/docs)](https://github.com/dotnet/docs)
[![GitHub issues-opened](https://img.shields.io/github/issues/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/issues?q=is%3Aissue+is%3Aopened)
[![GitHub issues-closed](https://img.shields.io/github/issues-closed/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/issues?q=is%3Aissue+is%3Aclosed)
[![GitHub pulls-opened](https://img.shields.io/github/issues-pr/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/pulls?q=is%3Aissue+is%3Aopened)
[![GitHub pulls-merged](https://img.shields.io/github/issues-search/dotnet/docs?label=merged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Amerged&color=darkviolet)](https://github.com/dotnet/docs/pulls?q=is%3Apr+is%3Aclosed+is%3Amerged)
[![GitHub pulls-unmerged](https://img.shields.io/github/issues-search/dotnet/docs?label=unmerged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Aunmerged&color=red)](https://github.com/dotnet/docs/pulls?q=is%3Apr+is%3Aclosed+is%3Aunmerged)
[![OpenSSF Best Practices](https://www.bestpractices.dev/projects/9215/badge)](https://www.bestpractices.dev/projects/9215)

This repository contains the conceptual documentation for .NET. The [.NET documentation site](https://learn.microsoft.com/dotnet) is built from multiple repositories in addition to this one:

- [ASP.NET Core](https://github.com/dotnet/AspNetCore.Docs)
- [.NET Aspire](https://github.com/dotnet/docs-aspire)
- [.NET Desktop workloads](https://github.com/dotnet/docs-desktop)
- [.NET MAUI](https://github.com/dotnet/docs-maui)
- [Entity Framework 6/Core](https://github.com/dotnet/EntityFramework.Docs)
- [Community toolkit](https://github.com/MicrosoftDocs/communitytoolkit)

API reference documentation is published from the following repositories. The following reference API repositories are public. Only some accept issues and pull requests, although some folders in `dotnet-api-docs` use the product repository as the source of truth. Others are pass-through repositories because API reference is generated directly from the `///` in the product source. 

- [.NET API reference](https://github.com/dotnet/dotnet-api-docs)
- [.NET MAUI API reference](https://github.com/dotnet/maui-api-docs)
- [Android API reference](https://github.com/dotnet/android-api-docs)
- [Entity Framework 6/Core API reference](https://github.com/dotnet/EntityFramework.ApiDocs)
- [Roslyn API reference](https://github.com/dotnet/roslyn-api-docs)
- [Community toolkit API reference](https://github.com/MicrosoftDocs/community-toolkit-api-ref-dotnet)

The C# language specification documentation comes from the following two repositories:

- [C# language design](https://github.com/dotnet/csharplang)
- [C# specification - draft](https://github.com/dotnet/csharpstandard)

Our team's tasks are tracked in our [project boards](https://github.com/dotnet/docs/projects?query=is%3Aopen). You'll see monthly sprint projects, along with long-running projects for major documentation updates. The projects contain documentation issues across the repositories that build .NET docs. Issues are tracked in the relevant repositories. We have a large community using these resources. We make our best effort to respond to issues in a timely fashion. To create a new issue, click the "Open a documentation issue" button at the bottom of any of our published docs, or [choose one of the available templates](https://github.com/dotnet/docs/issues/new/choose). The control at the bottom of each article automatically routes you to the correct repo and fills in some relevant information based on the article.

## :purple_heart: Contribute

We welcome contributions to help us improve and complete the .NET docs. This is a very large repo, covering a large area. If this is your first visit, see the [Contributor guide](https://learn.microsoft.com/contribute/content/dotnet/dotnet-contribute) for information on working with us. Look for issues labeled [`help wanted` :label:](https://github.com/dotnet/docs/issues?q=is%3Aopen+is%3Aissue+label%3A%22help+wanted%22+) for ideas to get started. 

Before submitting a PR with 3rd party dependencies, see our policy on [3rd party dependencies](admin/3rdPartyDependencies.md).

We work to merge or close PRs in a timely fashion. We regularly review and approve PRs. We encourage contributors to respond to comments in a similar timely fashion. Many times, reviews identify small changes such as spelling or grammar issues, or word choice. Maintainers can accept those suggestions and merge the PR. In other situations, maintainers ask for more significant changes before a PR is ready to merge. We expect contributors to make those changes. Maintainers will help by answering questions or pointing to other resources, if needed.

We consider PRs to be abandoned when they've had no activity (either commits or discussion) in the past 30 days. Team members will close PRs that have been abandoned. Contributors can reopen and continue to work.

## :bookmark_tabs: Code of conduct

This project has adopted the code of conduct defined by the Contributor Covenant
to clarify expected behavior in our community. For more information, see the [.NET Foundation: Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

## :octocat: GitHub Action workflows

- [![Live branch protection](https://github.com/dotnet/docs/actions/workflows/live-protection.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/live-protection.yml): Adds a comment to PRs that were not automated, but rather manually created that target the `live` branch.
- [![Close stale issues](https://github.com/dotnet/docs/actions/workflows/stale.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/stale.yml):  Closes stale issues that have not been updated in 180 days.
- [![`dependabot` auto-approve and auto-merge](https://github.com/dotnet/docs/actions/workflows/dependabot-approve-and-automerge.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/dependabot-approve-and-automerge.yml):  Automatically approves and auto-merges PRs originating from the `dependabbot[bot]`.
- [![Generate what's new article](https://github.com/dotnet/docs/actions/workflows/whats-new.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/whats-new.yml):  Creates a PR to generate the "What's new" article on the first of every month.
- [![Markdownlint](https://github.com/dotnet/docs/actions/workflows/markdownlint.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/markdownlint.yml):  The current status for the entire repositories Markdown linter status.
- [![MSDocs build verifier](https://github.com/dotnet/docs/actions/workflows/docs-verifier.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/docs-verifier.yml):  Runs various Markdown verifications, beyond the linter, such as ensuring links and redirects are valid.
- [![OPS status checker](https://github.com/dotnet/docs/actions/workflows/check-for-build-warnings.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/check-for-build-warnings.yml):  Builds the site for the PR in context, and verifies the build reporting either, `success`, `warnings`, or `error`.
- [![Snippets 5000](https://github.com/dotnet/docs/actions/workflows/snippets5000.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/snippets5000.yml):  Custom .NET build validation, locates code impacted by a PR, and builds.
- [![Target supported version](https://github.com/dotnet/docs/actions/workflows/version-sweep.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/version-sweep.yml):  Runs monthly, creating issues on projects that target .NET versions that are out of support.
- [![Update dependabot.yml](https://github.com/dotnet/docs/actions/workflows/dependabot-bot.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/dependabot-bot.yml):  Automatically updates the `dependabot` configuration weekly, but only if required.
- [![quest import](https://github.com/dotnet/docs/actions/workflows/quest.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/quest.yml): Automatically synchronizes issues with Quest (Azure DevOps).
- [![bulk quest import](https://github.com/dotnet/docs/actions/workflows/quest-bulk.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/quest-bulk.yml): Manual bulk import of issues into Quest (Azure DevOps).
