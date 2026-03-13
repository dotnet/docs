---
agent: agent
model: Claude Sonnet 4.6 (copilot)
description: Push inline code block snippets out of articles into standalone files with proper project structure.
---

# Push inline code snippets to files

**IMPORTANT**: Unless otherwise asked to, **only** edit the article file in context. At the end of your operations you may ask for permission to edit other articles that might benefit from the same snippet extraction.

**IMPORTANT**: Don't share code across multiple articles. Each article should have its own copy of the snippet in its own folder structure.

**IMPORTANT**: If only XAML snippets are present, only create C# projects to hold the XAML. Do not create VB projects for XAML-only snippets.

## Quick Reference

**WHEN TO PUSH:** Code >6 lines, complete/compilable examples, or when specifically requested
**FOLDER PATTERN:** `./snippets/{doc-file}/[optional-sub-subject]/{csharp|vb}/`
**PROJECT CREATION:** Always use `dotnet new` CLI commands — never create project files manually. Default to console apps.
**LANGUAGES:** Create both C# and VB versions (see language guide exception below)
**SNIPPET IDs:** Use CamelCase region markers like `<ButtonClick>`
**ARTICLE REFS:** Replace with `:::code language="csharp" source="./path" id="SnippetId":::`

## When to push snippets out of articles

**PUSH SNIPPETS WHEN:**
- Code blocks are longer than 6 lines
- Code demonstrates complete, compilable examples
- Code represents a complete application or significant functionality
- User specifically requests snippet extraction

**KEEP INLINE WHEN:**
- Code blocks are 6 lines or shorter
- Code is pseudo-code or conceptual examples

## Target folder structure

- Path pattern: `./snippets/{doc-file}/[optional-sub-subject]/{code-language}/`
- Example C#: `./snippets/create-app/csharp/`
- Example VB: `./snippets/create-app/vb/`

**Path components explained:**
- `./`: Current folder of the article being edited
- `snippets/`: Root folder for all snippets
- `{doc-file}`: The markdown article filename WITHOUT the `.md` extension
  - Example: For article `create-app.md` → use `create-app`
- `[optional-sub-subject]`: An optional subfolder to avoid clashes. Used when snippets in the same article can't be merged — for example, two snippets that both require a `Program.cs` file but demonstrate different things. Use descriptive subfolder names like `AsyncProgram/` and `SyncProgram/`.
- `{code-language}`:
  - `csharp`: For C# code (also use for XAML snippets)
  - `vb`: For Visual Basic code

**Language guide exception**: For articles in the C# or VB language guides, only the guide's language is required — do not create a version in the other language, and omit the `{code-language}/` subfolder:
- C# guide path: `./snippets/{doc-file}/`
- VB guide path: `./snippets/{doc-file}/`

## Push process

### 1. Analyze and prepare
- Locate code blocks >6 lines or complete examples (unless overridden by user request)
- Identify the programming language(s) used
- Determine if the article is in a language guide (C# or VB) to apply the language exception

### 2. Create projects and extract code
- **NEVER** create project files manually. Always use the `dotnet` CLI. Default to console apps (`dotnet new console`) unless the snippet requires a different project type (for example, `dotnet new winforms` for a Windows Forms snippet). Don't specify an output folder with `-o`. Specify a meaningful project name with `-n` if possible.
- Copy and complete code to make it compilable. Code only needs to compile — it doesn't have to run from `Main`.
- Add missing using statements, namespaces, and class declarations as needed.
- Build to verify compilation with `dotnet build`.

### 3. Add snippet markers and update article references
- Add CamelCase region markers around each snippet:
  - C#: `// <SnippetId>` and `// </SnippetId>`
  - VB: `' <SnippetId>` and `' </SnippetId>`
- Use the same identifiers across C# and VB versions.
- Use meaningful, descriptive identifiers — avoid `1`, `2`, `code1`, or `snippet1`.
- Replace each inline code block with a `:::code:::` reference:
  ```markdown
  :::code language="csharp" source="./snippets/doc-name/csharp/File.cs" id="SnippetId":::
  :::code language="vb" source="./snippets/doc-name/vb/File.vb" id="SnippetId":::
  ```
- DO NOT use language tabs — place references side-by-side, like so:
  ```markdown
  :::code language="csharp" source="./snippets/doc-name/csharp/File.cs" id="SnippetId":::
  
  :::code language="vb" source="./snippets/doc-name/vb/File.vb" id="SnippetId":::
  ```
- Verify all paths and identifiers are correct.

### 4. Update article frontmatter
If both C# and VB examples are provided, ensure the following frontmatter is present at the top of the article:

```yml
dev_langs:
  - "csharp"
  - "vb"
```

If a single language is used (like in the language guides), omit the `dev_langs` section.

## Common mistakes to avoid

- ❌ Extracting short snippets (≤6 lines) without being asked
- ❌ Creating project files manually instead of using `dotnet new`
- ❌ Missing C# or VB versions for standard articles
- ❌ Creating VB projects for XAML-only snippets
- ❌ Using language tabs instead of side-by-side references
- ❌ Missing or inconsistent snippet region identifiers
- ❌ Code that doesn't compile
