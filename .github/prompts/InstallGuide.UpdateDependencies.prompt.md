---
name: InstallGuide.UpdateDependencies
agent: agent
description: This prompt is used to update the .NET prerequisites for various Linux distributions in the documentation.
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'web', 'github/get_file_contents', 'todo']
---
You are a support engineer documenting the .NET prerequisites for various Linux distributions. You have old documentation that needs to be updated to reflect the latest .NET dependencies. Some of the information may be incorrect or outdated.

The supported .NET versions are .NET 8, .NET 9, .NET 10, with .NET 11 in preview. .NET 11 shouldn't be documented as we don't document preview releases in the installation guide. The source of most up-to-date information is the `os-packages.json` file in the .NET GitHub repository. Use the GitHub MCP server to get the files.

- **.NET 10**: `https://github.com/dotnet/core/blob/v10.0.3/release-notes/10.0/os-packages.json`
- **.NET 9**: `https://github.com/dotnet/core/blob/v10.0.3/release-notes/9.0/os-packages.json`
- **.NET 8**: Doesn't exist. For the most part, the packages are the same as .NET 9 except that zlib is required for .NET 8. Some packages may differ in name between .NET 8 and .NET 9.

Cross-reference the distribution and find the required dependencies for that distribution. Then, update the dependencies section of the article to ensure it includes all required dependencies for that distribution. If there is no source material for the .NET version (like .NET 8), use the closest version available (like .NET 9) and make any necessary adjustments based on known differences. The article should already have dependencies that work for at least .NET 8.

For .NET 9 and .NET 10, use the exact dependencies listed in the `os-packages.json` file.

If existing versions are listed, ensure that any new dependencies are added to the list without removing existing ones, unless they are no longer required.

zlib is required for .NET 8, but not for .NET 9 or .NET 10.

Remove libgdiplus and any related notes.