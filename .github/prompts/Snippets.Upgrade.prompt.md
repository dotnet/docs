---
agent: agent
model: Claude Sonnet 4 (copilot)
description: Upgrade snippets to the latest .NET and possibly migrate from .NET Framework
---

# Code Snippet Upgrade Instructions

## When to Apply These Instructions

Apply these instructions when working with code snippets that need modernization, especially when:
- Migrating snippets from old locations
- Upgrading .NET Framework code to modern .NET
- Improving snippet quality and completeness
- Adding missing language versions (C# or VB)

## Snippet Structure Requirements

All snippets must follow this folder structure relative to the referencing article:

```
./snippets/{article-name}/[net|framework]/{language}/
```

**Examples:**
- `./snippets/how-to-add-data-to-the-clipboard/net/csharp/MainForm.cs`
- `./snippets/how-to-add-data-to-the-clipboard/framework/vb/MainForm.vb`

## Required Upgrade Actions

### 1. File Naming and Organization
- **USE** PascalCase for class names and file names (e.g., `MainForm.cs`, `DataProcessor.cs`)
- **ORGANIZE** files logically within the language folder

### 2. Snippet Identifiers and Naming
- **USE** meaningful, descriptive snippet identifiers in CamelCase format
- **REPLACE** simplistic identifiers (like single numbers) with descriptive snippet names
- **EXAMPLES** of good snippet identifiers:
  - `BasicClipboardData` instead of `1`
  - `CustomDataFormat` instead of `2`
  - `ClipboardImageHandling` instead of `code1`
- **ENSURE** snippet identifiers clearly describe the code's purpose or functionality

### 3. .NET Version and Syntax Modernization
- **TARGET** the latest stable .NET version for `/net/` folders
- **USE** modern C# features for .NET snippets:
  - File-scoped namespaces
  - Top-level statements where appropriate
  - Pattern matching
  - String interpolation
  - var keyword where type is obvious
  - Modern using statements

### 4. Project File Requirements
- **USE** `dotnet new` to create the projects. Fallback to manual project creation if `dotnet new` is failing.
- **CREATE** a complete, compilable project structure
- **INCLUDE** appropriate `.csproj` or `.vbproj` file
- **TARGET** latest .NET version: `<TargetFramework>net8.0-windows</TargetFramework>`
- **ADD** necessary package references and properties

### 5. Code Quality Standards
- **ENSURE** code compiles without warnings
- **FOLLOW** .NET naming conventions
- **USE** appropriate access modifiers
- **INCLUDE** necessary using/import statements
- **ADD** minimal but helpful code comments for complex logic

### 6. Language Parity
- **CREATE** both C# and VB.NET versions unless the parent article is in a language-specific folder
- **MAINTAIN** functional equivalence between language versions
- **ADAPT** language-specific idioms appropriately

## Framework-Specific Considerations

### For .NET Framework Snippets (`/framework/` folders)
- **MAINTAIN** .NET Framework compatibility
- **AVOID** modern C# features not available in the target framework version
- **USE** classic C# syntax and patterns
- **TARGET** appropriate framework version (typically .NET Framework 4.8)

### For Modern .NET Snippets (`/net/` folders)
- **USE** latest .NET features and syntax
- **TARGET** latest stable .NET version
- **LEVERAGE** modern performance patterns
- **UTILIZE** new APIs where beneficial

## Example Transformation

**Before (simple identifier):**
```
./snippets/clipboard-article/code.cs
```

**After (descriptive structure):**
```
./snippets/how-to-add-data-to-the-clipboard/net/csharp/
├── ClipboardExample.csproj
├── MainForm.cs
└── Program.cs
```

## Validation Checklist

Before completing snippet upgrades, verify:
- [ ] Files have descriptive, meaningful names
- [ ] Project compiles without errors or warnings
- [ ] Code follows .NET naming conventions
- [ ] Appropriate target framework is specified
- [ ] Both C# and VB versions exist (when required)
- [ ] Modern syntax is used for .NET snippets
- [ ] Framework-compatible syntax for .NET Framework snippets