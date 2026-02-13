---
name: sort-redirects
description: Sorts redirect entries in Open Publishing redirection JSON files alphabetically by source_path. Use after manually adding redirects or when the file becomes unsorted.
---

# Sort Redirects

Sort redirect entries in Open Publishing redirection JSON files alphabetically by `source_path`. This ensures consistency and makes the redirect files easier to maintain.

## When to Use

- After manually adding redirect entries to a JSON file
- When the redirect file has become unsorted
- As part of maintaining the redirect files
- After merging branches that may have caused unsorted entries

## Steps

### Required: Use the provided script

**DO NOT manually sort the JSON file.** Use the `sort-redirects.ps1` script to handle the sorting automatically.

1. **Run the sort script** - Use the `sort-redirects.ps1` script (see below) to sort the redirect entries in the appropriate JSON file.

## Redirection File Selection

| Product Area | Redirection File |
|--------------|------------------|
| Windows Forms (WinForms) | `.openpublishing.redirection.winforms.json` |
| Windows Presentation Foundation (WPF) | `.openpublishing.redirection.wpf.json` |

## Scripts

### sort-redirects.ps1

**ALWAYS use this script to sort redirect entries.** This script automatically sorts all entries in the JSON file alphabetically by `source_path` and handles formatting.

Location (relative to this skill file): `./scripts/sort-redirects.ps1`

| Parameter | Required | Default | Description |
|-----------|----------|---------|-------------|
| `RedirectionFile` | No | `.openpublishing.redirection.json` | The redirection JSON file name |

**Example:**

```powershell
.\scripts\sort-redirects.ps1 `
    -RedirectionFile ".openpublishing.redirection.wpf.json"
```

## Important Notes

- Redirect entries are sorted **alphabetically** by `source_path` in the JSON file.
- The script preserves all existing redirect entries, only changing their order.
- Always commit the sorted file with a clear commit message indicating the sorting operation.
