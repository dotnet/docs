# .NET Docs

[![GitHub contributors](https://img.shields.io/github/contributors/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/graphs/contributors/)
[![GitHub repo size](https://img.shields.io/github/repo-size/dotnet/docs)](https://github.com/dotnet/docs)
[![GitHub issues-opened](https://img.shields.io/github/issues/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/issues?q=is%3Aissue+is%3Aopened)
[![GitHub issues-closed](https://img.shields.io/github/issues-closed/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/issues?q=is%3Aissue+is%3Aclosed)
[![GitHub pulls-opened](https://img.shields.io/github/issues-pr/dotnet/docs.svg)](https://GitHub.com/dotnet/docs/pulls?q=is%3Aissue+is%3Aopened)
[![GitHub pulls-merged](https://img.shields.io/github/issues-search/dotnet/docs?label=merged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Amerged&color=darkviolet)](https://github.com/dotnet/docs/pulls?q=is%3Apr+is%3Aclosed+is%3Amerged)
[![GitHub pulls-unmerged](https://img.shields.io/github/issues-search/dotnet/docs?label=unmerged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Aunmerged&color=red)](https://github.com/dotnet/docs/pulls?q=is%3Apr+is%3Aclosed+is%3Aunmerged)

This repository contains the conceptual documentation for .NET. The [.NET documentation site](https://learn.microsoft.com/dotnet) is built from multiple repositories in addition to this one:

- [API reference](https://github.com/dotnet/dotnet-api-docs)
- [.NET Compiler Platform SDK reference](https://github.com/dotnet/roslyn-api-docs)

Issues and tasks for all but the API reference repository are tracked here. We have a large community using these resources. We make our best effort to respond to issues in a timely fashion. You can read more about our procedures for classifying and resolving issues in our [Issues policy](issues-policy.md) topic. To create a new issue, [choose from any of the available templates](https://github.com/dotnet/docs/issues/new/choose).

## :purple_heart: Contribute

We welcome contributions to help us improve and complete the .NET docs. This is a very large repo, covering a large area. If this is your first visit, see our [labels and projects roadmap](styleguide/labels-projects.md) for help navigating the issues and projects in this repository. If you contribution includes 3rd party dependencies, see our guidance on using [3rd party dependencies](styleguide/3rdPartyDependencies.md).

To contribute, see:

- The [.NET Contributor Guide :ledger:](https://learn.microsoft.com/contribute/dotnet/dotnet-contribute) for instructions on procedures we use.
- Issues labeled [`help wanted` :label:](https://github.com/dotnet/docs/issues?q=is%3Aopen+is%3Aissue+label%3A%22help+wanted%22+) for ideas.
- [#Hacktoberfest and Microsoft Docs :jack_o_lantern:](https://learn.microsoft.com/contribute/hacktoberfest) for details on our participation in the annual event.

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
- [![No response](https://github.com/dotnet/docs/actions/workflows/no-response.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/no-response.yml):  If an issue is labeled with `needs-more-info` and the op doesn't respond within 14 days, the issue is closed.
- [![OPS status checker](https://github.com/dotnet/docs/actions/workflows/check-for-build-warnings.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/check-for-build-warnings.yml):  Builds the site for the PR in context, and verifies the build reporting either, `success,` `warnings`, or `error`.
- [![Snippets 5000](https://github.com/dotnet/docs/actions/workflows/build-validation.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/build-validation.yml):  Custom .NET build validation, locates code impacted by a PR, and builds.
- [![Target supported version](https://github.com/dotnet/docs/actions/workflows/version-sweep.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/version-sweep.yml):  Runs monthly, creating issues on projects that target .NET versions that are out of support.
- [![Update dependabot.yml](https://github.com/dotnet/docs/actions/workflows/dependabot-bot.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/dependabot-bot.yml):  Automatically updates the `dependabot` configuration weekly, but only if required.
- [![quest import](https://github.com/dotnet/docs/actions/workflows/quest.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/quest.yml): Automatically synchronizes issues with Quest (Azure DevOps).
- [![bulk quest import](https://github.com/dotnet/docs/actions/workflows/quest-bulk.yml/badge.svg)](https://github.com/dotnet/docs/actions/workflows/quest-bulk.yml): Manual bulk import of issues into Quest (Azure DevOps).
