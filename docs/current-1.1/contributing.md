# Using the current-1.1 folder and sub-folders

This folder is the top-level node that matches the [docs](../index.md)
folder, but contains deltas for the the .NET Core 1.1 release.

The goal of this separate parallel folder structure is to provide a location
for the 1.1 release related content that can be relatively easily merged into
the main structure when provide version switching in the published site.

The content under this node should be a smaller document set that represents
the deltas from the current Long Term Support (LTS) release and the latest
fast track release. 

## Structure

There are two cases to adding new content for this release:

* Changes to existing documents
    - Copy the existing content into a parallel folder under this structure. Make your changes, and add the modified file to the TOC for the 1.1 preview release.
* New documents
    - Put the new document in the proper location, and add it to the TOC under the node for the 1.1 preview release. 

All fast-track release files should have the following added near the
top of the topic:

> [!WARNING]
> This topic represents pre-release software. This version will be supported
> only until the following fast-track release. For the latest release with
> long term support, see [link to corresponding LTS document](#link-instructions)

### link instructions

In both cases, provide links from the fast track to the LTS page (or parent index.md)
for navigational purposes.
Consider providing links from the LTS page (or parent index.md) to the
new fast track content page.

## Future Considerations

Our end goal is to surface different releases as branches in the
[docs repo](https://github.com/dotnet/docs). Until that publishing
scenario is supported, we'll use different top-level folders for each
fast track release. 

When the time comes, we can merge each fast track release into the main
[docs](../docs) folder, merge the TOC nodes, and publish as a separate doc
set. We may need to merge modifications to both the LTS version of a file
and the fast track version of a file, but we should be able to find those
changes relatively easily.

## Open Questions:

1. I'm using the term 'fast track' in this doc. I know that's wrong, but I don't have the current branding term.
2. Warning language is first pass and needs review and update.

## Tasks before merge

1. Update with answers to open questions.
2. Add an index.md in this directory
3. Update the TOC.md to place this release at the bottom of the TOC, below the current LTS release.
