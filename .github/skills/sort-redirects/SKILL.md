---
name: sort-redirects
description: Sorts redirect entries in Open Publishing redirection JSON files alphabetically by path. Use after adding redirects or when the file becomes unsorted.
---

# Sort Redirects

Sort redirect entries in Open Publishing redirection JSON files alphabetically by path. This ensures consistency and makes the redirect files easier to maintain.

## When to Use

- After adding redirect entries to a JSON file
- When the redirect file has become unsorted
- After merging branches that may have caused unsorted entries

## Steps

1. **Identify the redirection file** - Determine which `.openpublishing.redirection.*.json` file needs sorting.
2. **Run the sort script** - Use the `sort-redirects.ps1` script with the file path.

## Scripts

### sort-redirects.ps1

Sorts all entries in the JSON file alphabetically by path (ignoring leading `/` for `source_path_from_root`). Handles both `source_path_from_root` and `source_path` properties.

Location (relative to this skill file): `./scripts/sort-redirects.ps1`

| Parameter | Required | Description |
|-----------|----------|-------------|
| `RedirectionFile` | Yes | The path to a redirection JSON file (e.g., `.openpublishing.redirection.csharp.json`) |

**Example:**

```powershell
.\scripts\sort-redirects.ps1 -RedirectionFile ".openpublishing.redirection.csharp.json"
```

## Important Notes

- The script preserves all existing redirect entries, only changing their order.
- Sorting is case-sensitive and alphabetical by the normalized path (without leading `/`).
