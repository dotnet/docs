---
agent: agent
model: Claude Sonnet 4.6 (copilot)
description: Upgrade snippets to the latest .NET and possibly migrate from .NET Framework
---

# Code Snippet Upgrade Instructions

## When to Apply These Instructions

Apply these instructions when working with code snippets that need modernization, especially when:
- Improving snippet quality and completeness
- Upgrading .NET Framework code to modern .NET
- Adding missing language versions (C# or VB)

## Snippet Structure Requirements

All snippets must follow this folder structure relative to the referencing article:

```
./snippets/{article-name}/[optional-sub-subject]/{code-language}/
```

**Path components explained:**
- `./`: Current folder of the article being edited
- `snippets/`: Root folder for all snippets
- `{article-name}`: The markdown article filename WITHOUT the `.md` extension
- `[optional-sub-subject]`: An optional subfolder to avoid clashes — use when two snippets in the same article can't be merged (for example, both require a `Program.cs` file). Use descriptive names like `AsyncProgram/` and `SyncProgram/`.
- `{code-language}`: `csharp` for C#, `vb` for Visual Basic

**Examples:**
- `./snippets/how-to-add-data-to-the-clipboard/csharp/MainForm.cs`
- `./snippets/how-to-add-data-to-the-clipboard/vb/MainForm.vb`

**Language guide exception**: For articles in the C# or VB language guides, only the guide's language is required — do not create a version in the other language, and omit the `{code-language}/` subfolder. The path is simply `./snippets/{article-name}/`.

## Required Upgrade Actions

### 1. File Naming and Organization
- Use PascalCase for class names and file names (e.g., `MainForm.cs`, `DataProcessor.cs`)
- Organize files logically within the language folder

### 2. Snippet Identifiers and Naming
- Use meaningful, descriptive snippet identifiers in CamelCase format
- Replace simplistic identifiers (like single numbers) with descriptive names
- Good examples: `BasicClipboardData`, `CustomDataFormat`, `ClipboardImageHandling`
- Avoid: `1`, `2`, `code1`, `snippet1`
- Identifiers should clearly describe the code's purpose or functionality

### 3. Syntax Modernization
- Target the latest stable .NET version
- Use modern C# features:
  - File-scoped namespaces
  - Top-level statements where appropriate
  - Pattern matching
  - String interpolation
  - `var` where type is obvious
  - Modern `using` statements

### 4. Project File Requirements
- **NEVER** create project files manually. Always use the `dotnet` CLI. Default to console apps (`dotnet new console`) unless the snippet requires a different project type. Don't specify an output folder with `-o`. Specify a meaningful project name with `-n` if possible.
- Ensure a complete, compilable project structure with an appropriate `.csproj` or `.vbproj` file
- Code only needs to compile — it doesn't have to run from `Main`
- Verify compilation with `dotnet build`

### 5. Code Quality Standards
- Ensure code compiles without errors
- Follow .NET naming conventions
- Use appropriate access modifiers
- Include necessary `using`/`import` statements

### 6. Language Parity
- Create both C# and VB.NET versions for standard articles
- For language guide articles (C# or VB guide), only the guide's language is required
- Maintain functional equivalence between language versions
- Adapt language-specific idioms appropriately

## Example Transformation

**Before (outdated structure):**
```
~/samples/snippets/csharp/clipboard/code.cs
```

**After (current structure):**
```
./snippets/how-to-add-data-to-the-clipboard/csharp/
├── ClipboardExample.csproj
├── MainForm.cs
└── Program.cs

./snippets/how-to-add-data-to-the-clipboard/vb/
├── ClipboardExample.vbproj
├── MainForm.vb
└── Program.vb
```

## Common mistakes to avoid

- ❌ Using the old `[net|framework]` subfolder in paths
- ❌ Creating project files manually instead of using `dotnet new`
- ❌ Missing C# or VB versions for standard articles
- ❌ Using simplistic or non-descriptive snippet identifiers
- ❌ Code that doesn't compile