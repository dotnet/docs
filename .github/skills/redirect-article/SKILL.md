---
name: redirect-article
description: Deletes a markdown article and creates a redirect entry pointing to a different article. Use when consolidating articles, renaming or moving content, removing outdated documentation, or reorganizing the docs structure while preserving existing URLs.
---

# Redirect Article

Delete a markdown article from the repository and create a redirect entry that points users to a different article. This ensures existing links and bookmarks continue to work after content is reorganized.

## When to Use

- Deleting an article that should redirect to another existing article
- Consolidating multiple articles into a single article
- Renaming or moving an article to a new location
- Removing outdated content while preserving URL functionality

## Steps

### Required: Use the provided script

**DO NOT manually edit files or JSON.** Use the `create-redirect-entry.ps1` script to handle the redirect creation automatically.

1. **Delete the source article** - Remove the original markdown file from the repository using `Remove-Item`.
2. **Create a redirect entry** - **REQUIRED:** Use the `create-redirect-entry.ps1` script (see below) to add the redirect entry to the appropriate JSON file. Do not manually edit the JSON file.
3. **Update internal links** - Search the repository for links to the old article and update them with `grep_search` and `replace_string_in_file`.

## Redirection File Selection

| Product Area | Redirection File |
|--------------|------------------|
| AI | `.openpublishing.redirection.ai.json` |
| Architecture | `.openpublishing.redirection.architecture.json` |
| .NET Aspire | `.openpublishing.redirection.aspire.json` |
| Azure | `.openpublishing.redirection.azure.json` |
| .NET Core | `.openpublishing.redirection.core.json` |
| C# | `.openpublishing.redirection.csharp.json` |
| Desktop WPF | `.openpublishing.redirection.desktop-wpf.json` |
| .NET Framework | `.openpublishing.redirection.framework.json` |
| .NET Framework WinForms | `.openpublishing.redirection.framework-winforms.json` |
| .NET Framework WPF | `.openpublishing.redirection.framework-wpf.json` |
| F# | `.openpublishing.redirection.fsharp.json` |
| .NET Fundamentals | `.openpublishing.redirection.fundamentals.json` |
| Machine Learning | `.openpublishing.redirection.machine-learning.json` |
| Navigate | `.openpublishing.redirection.navigate.json` |
| Orleans | `.openpublishing.redirection.orleans.json` |
| .NET Standard | `.openpublishing.redirection.standard.json` |
| Visual Basic | `.openpublishing.redirection.visual-basic.json` |
| Default/General | `.openpublishing.redirection.json` |

## Scripts

### create-redirect-entry.ps1

**ALWAYS use this script to add redirect entries.** This script automatically adds the entry to the correct JSON file in alphabetical order and handles formatting.

Location (relative to this skill file): `./scripts/create-redirect-entry.ps1`

| Parameter | Required | Default | Description |
|-----------|----------|---------|-------------|
| `RedirectionFile` | No | `.openpublishing.redirection.json` | The redirection JSON file name |
| `SourcePath` | Yes | - | Repository path of the deleted article |
| `RedirectUrl` | Yes | - | Destination URL to redirect to |

**Example:**

```powershell
.\scripts\create-redirect-entry.ps1 `
    -RedirectionFile ".openpublishing.redirection.csharp.json" `
    -SourcePath "docs/csharp/fundamentals/old-article.md" `
    -RedirectUrl "/dotnet/csharp/fundamentals/new-article"
```

## Redirect Entry Format

```json
{
    "source_path": "docs/csharp/fundamentals/old-article.md",
    "redirect_url": "/dotnet/csharp/fundamentals/new-article"
}
```

- **source_path**: File path relative to the repository root (the deleted file's location)
- **redirect_url**: URL path to redirect to (starts with `/dotnet/`)

## Important Notes

- Redirect entries are sorted **alphabetically** by `source_path` in the JSON file.
- Always search the repository for links to the old article and update them.
- The `redirect_url` shouldn't include the file extension or domain—just the URL path.
