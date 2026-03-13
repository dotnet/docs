---
agent: agent
model: Claude Sonnet 4 (copilot)
description: Migrate code from the old ~/samples/snippets/ location to the relative ./snippets location.
---

# Migrate code snippets

**IMPORTANT**: Unless otherwise asked to, **only** edit the article file in context. At the end of your operations you may ask for permission to edit other articles referencing the same snippets.

## Repository structure for code snippets

**IMPORTANT**: This repository has TWO different locations for code snippets:

### Old location (legacy - to be migrated FROM)
- Path: `~/samples/snippets/`
- Example: `~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs`
- Status: Legacy, should be migrated to new location

### New location (current standard - migrate TO)
- Path pattern: `./snippets/{doc-file}/[net-or-framework]/{code-language}/`
- Example: `./snippets/how-to-add-data-to-the-clipboard/net/csharp/form1.cs`

**Path components explained:**
- `{doc-file}`: The markdown article filename WITHOUT the `.md` extension
  - Example: For article `how-to-add-data-to-the-clipboard.md` → use `how-to-add-data-to-the-clipboard`
- `[net-or-framework]`: Choose based on target framework:
  - `net`: For .NET (.NET 6 and newer)
  - `framework`: For .NET Framework (4.8 and older)
  - **Rule**: Only include this subfolder when the article demonstrates BOTH .NET and .NET Framework approaches
- `{code-language}`: 
  - `csharp`: For C# code
  - `vb`: For Visual Basic code

## Legacy code characteristics (migrate FROM these)

**Location**: `~/samples/snippets/` folder
**Problems with legacy code:**
- Written for .NET Framework (outdated)
- Often incomplete or non-compilable
- May lack project files
- Uses outdated syntax and patterns

**Legacy article references look like this:**
```markdown
[!code-{code-language}[description](~/samples/snippets/{path-to-file}#{snippet-identifier})]
```

## Current code requirements (migrate TO these)

**Location**: `./snippets/{doc-file}/[framework]/{code-language}/`

**Requirements for current code standards:**
- ✅ MUST be complete and compilable
- ✅ MUST include a project file
- ✅ MUST target appropriate .NET version (see targeting rules below)
- ✅ MUST provide BOTH C# and Visual Basic versions
- ✅ MUST use appropriate syntax for the target framework
- ✅ MUST use meaningful, descriptive snippet identifiers in CamelCase format
  - **Examples** of good snippet identifiers: `BasicClipboardData`, `CustomDataFormat`, `ClipboardImageHandling`
  - **Avoid** simplistic identifiers like `1`, `2`, `code1`, or `snippet1`

**Current article references look like this:**
```markdown
:::code language="{code-language}" source="{file-path}" id="{snippet-identifier}":::
```

**Framework targeting rules:**
- **Migration vs. Modernization**: 
  - **Migration**: Move code to new location with minimal changes
  - **Modernization**: Update code to use latest .NET features and best practices
- **When to migrate only**: When article has `ms.service: dotnet-framework` frontmatter or is specifically about .NET Framework features
- **When to modernize**: When article demonstrates both .NET and .NET Framework, or when specifically requested
- **Default targeting**: 
  - For .NET Framework-specific articles: Keep targeting .NET Framework
  - For general articles: Target latest .NET version (e.g., .NET 10)
  - For mixed articles: Create separate snippets in `net/` and `framework/` subfolders

## Migration steps (follow in order)

**WHEN TO MIGRATE**: Migrate code when you encounter articles with references to `~/samples/snippets/` paths.

**STEP-BY-STEP PROCESS:**

### 1. Analyze existing code and article context
- **Find**: Locate the legacy snippet file in `~/samples/snippets/`
- **Check frontmatter**: Look for `ms.service: dotnet-framework` in the article's frontmatter
- **Determine scope**: 
  - If frontmatter has `ms.service: dotnet-framework` → this is likely a .NET Framework-specific article
  - if frontmatter has `ms.service: dotnet-desktop` or similar → this is likely a dual-framework or general article
  - If article demonstrates both .NET and .NET Framework → prepare for dual targeting
  - If article is general purpose → consider targeting current .NET
- **Identify**: Determine the programming language (C# or Visual Basic)
- **Extract**: Note the snippet identifier used in the article reference

### 2. Create new folder structure
- **Pattern**: `./snippets/{doc-file}/[net-or-framework]/{code-language}/`
- **Example**: For article `clipboard-operations.md` → create `./snippets/clipboard-operations/net/csharp/`
- **Decision tree for framework folder**:
  - Article has `ms.service: dotnet-framework` frontmatter → use `./snippets/{doc-file}/framework/{code-language}/`
  - Article shows ONLY current .NET examples → use `./snippets/{doc-file}/{code-language}/` (omit framework folder)
  - Article shows BOTH .NET and .NET Framework → create both `./snippets/{doc-file}/net/{code-language}/` and `./snippets/{doc-file}/framework/{code-language}/`

### 3. Migrate and update code
- **Copy**: Copy only the snippet code (and any supporting code to compile the snippet) to the new location
- **Update approach**:
  - **For .NET Framework articles**: Migrate with minimal changes, keep .NET Framework targeting
  - **For dual-framework articles**: Create both versions with appropriate targeting and update frontmatter to `ms.service: dotnet-desktop`
  - **For general articles**: Update to target current .NET only if specifically requested or if article demonstrates modernization
- **Complete**: Ensure code is fully functional and compilable
- **Project file**: Create or update project file with appropriate target framework

### 4. Create both language versions
- **Requirement**: MUST provide both C# and Visual Basic versions
- **C# path**: `./snippets/{doc-file}/[framework]/csharp/`
- **VB path**: `./snippets/{doc-file}/[framework]/vb/`

### 5. Update article references
- **Replace**: Change from legacy `[!code-...]` format to modern `:::code...:::` format
- **Before**: `[!code-csharp[description](~/samples/snippets/path/file.cs#snippet1)]`
- **After**: `:::code language="csharp" source="./snippets/doc-name/net/csharp/file.cs" id="BasicClipboardData":::`
- **Note**: Use meaningful CamelCase identifiers instead of simple numbers

### 6. Validate
- **Build**: Ensure all code compiles successfully
- **Test**: Verify snippet references work in the article
- **Clean**: Remove unused legacy files (if no other articles reference them)

### 7. Delete
- **Identify**:
  - Check if the old snippet file is used by any other articles
  - Some articles may use a relative path to the `samples` folder, so simply search for links to `samples/snippets/...`
  - Be confident that all legacy snippets use a `samples/snippets` folder structure
- **Delete**: If old snippet is no longer used by any article, delete it.

## Common mistakes to avoid

- ❌ **Don't** assume all code needs to be modernized - check article context first
- ❌ **Don't** modernize .NET Framework-specific articles unless specifically requested
- ❌ **Don't** ignore the `ms.service: dotnet-framework` frontmatter indicator
- ❌ **Don't** forget to create both C# and VB versions
- ❌ **Don't** mix up the framework targeting (net vs framework)
- ❌ **Don't** forget to update ALL article references to the migrated code
- ❌ **Don't** leave incomplete or non-compilable code
