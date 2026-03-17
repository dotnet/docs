---
agent: agent
model: Claude Sonnet 4.6 (copilot)
description: Migrate code from the old ~/samples/snippets/ location to the relative ./snippets location.
---

# Migrate code snippets

We no longer use the `~/samples/snippets/` location for code snippets. All code snippets must be migrated to the new `./snippets/` location, which is relative to the article using the snippet. Generally, snippets in the old location are outdated, incomplete, and often can't compile. The new location requires that all snippets be complete, compilable, and include project files. Additionally, the new location requires both C# and Visual Basic versions of each snippet.

**IMPORTANT**: Unless otherwise asked to, **only** edit the article file in context. At the end of your operations you may ask for permission to edit other articles referencing the same snippets.

## Repository structure for code snippets

**IMPORTANT**: This repository has TWO different locations for code snippets:

### Old location (legacy - to be migrated FROM)
- Path: `~/samples/snippets/`
- Example: `~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs`

**Problems with legacy code:**
- Written for .NET Framework (outdated)
- Often incomplete and can't compile
- May lack project files
- Uses outdated syntax and patterns

**Legacy article references generally use old syntax:**
```markdown
[!code-{code-language}[description](~/samples/snippets/{path-to-file}#{snippet-identifier})]
```
### New location (current standard - migrate TO)
- Path pattern: `./snippets/{article-filename-using-snippet}/[optional-sub-subject]/{code-language}/`
- Example C#: `./snippets/anchors-in-regular-expressions/csharp/Form1.cs`
- Example VB: `./snippets/anchors-in-regular-expressions/vb/Form1.vb`

**Path components explained:**
- `./`: Current folder of the article being edited
- `snippets/`: Root folder for all snippets
- `{article-filename-using-snippet}`: The markdown article filename WITHOUT the `.md` extension
  - Example: For article `anchors-in-regular-expressions.md` → use `anchors-in-regular-expressions`
- `[optional-sub-subject]`: An optional subfolder to avoid clashes. Used when a snippet in the article can't be merged with existing snippets. Examples of this would be two different snippets that both use a `Program.cs` file. For example, if there were two snippets in the same file demonstrating an Async `main` and a non-Async `main`, you could create descriptive subfolders like `AsyncProgram/` and `SyncProgram/` to avoid conflicts.
- `{code-language}`: 
  - `csharp`: For C# code
  - `vb`: For Visual Basic code

**IMPORTANT**: Exception to the rules about having multiple code languages: For language guide articles, only the guide's language is required — do not create a version in the other language. The C# Language guide only contains CS code snippets, and the VB Language guide only contains VB code snippets. All other articles should follow the full path pattern including the `{code-language}/` subfolder. For example, you wouldn't use the `./snippets/article-name/csharp/` or `./snippets/article-name/vb/` folder structures for an article in the C# language guide, the folder would simply be `./snippets/article-name/` and the code in C#. The same applies to the VB language guide.

**Requirements for current code standards:**
- ✅ MUST be complete and compilable
- ✅ MUST include a project file
- ✅ MUST target the latest .NET version
- ✅ MUST provide BOTH C# and Visual Basic versions
- ✅ MUST use appropriate syntax for the target framework
- ✅ MUST use meaningful, descriptive snippet identifiers in CamelCase format
  - **Examples** of good snippet identifiers: `BasicClipboardData`, `CustomDataFormat`, `ClipboardImageHandling`
  - **Avoid** simplistic identifiers like `1`, `2`, `code1`, or `snippet1`

**Current article references look like this:**
```markdown
:::code language="{code-language}" source="{relative-file-path}" id="{snippet-identifier}":::
```

## Migration steps (follow in order)

**STEP-BY-STEP PROCESS:**

### 1. Analyze existing code and article context
- **Find**: Locate the legacy snippet file references to `~/samples/snippets/` (path may be relative, navigating back to the root `samples` folder)
- **Identify**: Determine the programming language (C# or Visual Basic)
- **Extract**: Note the snippet identifier used in the article reference

### 2. Create new or reuse existing folder structure
- **Pattern**: `./snippets/{article-filename-using-snippet}/[optional-sub-subject]/{code-language}/`
- **Example**: For article `clipboard-operations.md` → create `./snippets/clipboard-operations/csharp/`
- **Reuse**: If the article already has snippets in the new location, reuse the existing folder structure and try to merge the code into the existing snippets if possible. Use new classes and code files as needed. Code **ONLY** needs to compile, it doesn't have to run from the program main.
- **Create**: If no existing folder structure exists for the article, create a new one following the pattern above.
- **New projects**: **NEVER** create project files manually. Always use the `dotnet` CLI to ensure correct formatting and structure of new code. Projects should be console apps unless otherwise required (such as a Windows Forms-related snippet)

### 3. Migrate and update code
- **Copy**: Copy only the snippet code (and any supporting code to compile the snippet) to the new location
- **Complete**: Ensure code is fully functional and compilable

### 4. Create both language versions
- **Requirement**: MUST provide both C# and Visual Basic versions, except for language guide articles (C# or VB guide), where only the guide's language is required.
- **Standard articles** (both languages required):
  - **C# path**: `./snippets/{article-filename-using-snippet}/csharp/`
  - **VB path**: `./snippets/{article-filename-using-snippet}/vb/`
- **Language guide articles** (single language, no `{code-language}` subfolder):
  - **C# guide path**: `./snippets/{article-filename-using-snippet}/`
  - **VB guide path**: `./snippets/{article-filename-using-snippet}/`

### 5. Update article references
- **Replace**: Change from legacy `[!code-...]` format to modern `:::code...:::` format
- **Before**: `[!code-csharp[description](~/samples/snippets/path/file.cs#snippet1)]`
- **After**: `:::code language="csharp" source="./snippets/article-name/csharp/file.cs" id="BasicClipboardData":::`
- **Note**: Use meaningful CamelCase identifiers instead of simple numbers

### 6. Validate
- **Build**: Ensure all code compiles successfully

### 7. Delete
- **Identify**:
  - Check if the old snippet file is used by any other articles. Search for the old snippet path across the repository to find any references. This can be done by searching for links to `samples/snippets/...` (the file path used in the snippet reference) since some articles may use a relative path to the `samples` folder instead of absolute paths.
- **Delete**: If old snippet was migrated and is no longer used by any other article, delete it.

## Common mistakes to avoid

- ❌ **Don't** assume all code needs to be modernized - check article context first
- ❌ **Don't** forget to create both C# and VB versions
- ❌ **Don't** mix up the framework targeting (net vs framework)
- ❌ **Don't** forget to update ALL article references to the migrated code
- ❌ **Don't** leave incomplete or non-compilable code
