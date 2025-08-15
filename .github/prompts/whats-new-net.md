When you're assigned an issue where one label includes the word "Release" and you're given a link to an issue with this prompt file as context to update the what's new in .NET pages, follow these guidelines:

## Task

You'll update 4 articles. For .NET 10, you update these:

- https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-10/overview.md
- https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-10/runtime.md
- https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-10/libraries.md
- https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-10/sdk.md

For other releases, replace "dotnet-10" in the preceding paths with the correct release. For example, use "dotnet-11" for the ".NET 11" releases.

## Source material

To learn what's new in the targeted release, use the corresponding release notes in the [dotnet core](https://github.com/dotnet/core) repository. The release notes will be in a subfolder of the "release-notes" folder.

For production releases, the path is `<major-release>/<release-number>`, where:

- `<major-release>` is the release number. For example, `8.0`, `9.0` or `10.0`.
- `<minor-release>` is the three part release number. For example, `8.0.3`, `9.0.6` or `10.0.0`.

For preview releases, the path is `<major-release>/preview/preview<n>` where:

- `<major-release>` is the release number. For example, `8.0`, `9.0` or `10.0`.
- `n` is the preview number. For example, `1`, `3`, or `6`.

The primary release notes are in the `README.MD` file in that folder.  That file contains links to other release notes for components of .NET: libraries, runtime, SDK, languages, and so on. Use all that information for source.

The source files you use are release notes from the product team. These take the form of announcements, so you should edit any incorporated content per the following guidelines:

- Remove any 1st person references (we, us, our), and rewrite that information in the 2nd person: Tell the reader what the reader can do, using "you" to refer to the reader.
- Remove any marketing and promotional language. These articles provide technical information, not marketing copy.

## Updates for each file

Each file should be organized to provide a cohesive story about "What's new" in the release. When you edit:

- The introductory paragraph states when the last update was made (Preview N, general release, any service release). That is the only mention of the latest minor, patch, or preview version.
- If one of the areas (SDK, libraries, or runtime) doesn't have any updates for the current release (preview, RC, or GA), update the introductory paragraph and ms.date value, without making any other changes.
- Each file should organize updates by feature area, not by when an update was made. In other words, starting with the 2nd preview, incorporate updates to the existing text to provide a single view of all updates made in the major release. For example, the "RC1" updates should add in updates in RC1 where it fits in the document, not make a new "RC1" section.
- If a preview introduces a new feature that's unrelated to existing new features, add a new H2 for that feature area.

In addition, follow these recommendations:

- Follow the Microsoft Writing Style Guide, as noted in the `.github/copilot-instructions.md` file in this repository.
- Each file should have its `ms.date` metadata field updated to match the date you're assigned the issue.
- Ensure each file has the `ai-usage: ai-assisted` metadata field added.
- Update phrasing on the latest update to reference the current release (preview, GA, or service release). Individual features shouldn't reference a given preview release, but the article should make it clear which was the last preview.
- Search this repository for articles that have been recently updated pertaining to new features. Add links to those as you write about that feature. Or, add applicable information from the release notes into existing feature articles where it makes sense.
- For the runtime and libraries articles, include extensive examples as well as links to recently updated articles related to the new feature. The examples should be at least as thorough as the examples from the source release notes.
- Where applicable, the SDK article should include the samples.
- The overview article generally doesn't include examples. Its purpose is to direct readers to more detailed information in other articles.
- All APIs should be referenced using an `xref` style link, at least on first mention. Later mentions should be code-fenced in single back-ticks.
- All links to article in the `dotnet/docs` repository should be file relative.
- Spell out acronyms on first use in each file.
- Avoid gerund form in headings.
- In general, don't mention specific contributors or pull requests to the product repos.
- Code snippets longer than 6 lines should be moved to a code file and included using the `:::` extension. All code files should be included in a buildable project to ensure the snippets build correctly.

Next, create a pull request. In the description, include the text "Fixes #\<issue-number>", where "issue-number" is the GitHub issue number.
