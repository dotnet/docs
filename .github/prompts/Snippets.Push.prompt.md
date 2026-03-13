---
agent: agent
model: Claude Sonnet 4 (copilot)
description: Push inline code block snippets out of articles into standalone files with proper project structure.
---

# Push inline code snippets to files

**IMPORTANT**: Unless otherwise asked to, **only** edit the article file in context. At the end of your operations you may ask for permission to edit other articles that might benefit from the same snippet extraction.

**IMPORTANT**: Don't share code across multiple articles. Each article should have its own copy of the snippet in its own folder structure.

**IMPORTANT**: If only XAML snippets are present, only create C# projects to hold the XAML. Do not create VB projects for XAML-only snippets.

## Quick Reference

**WHEN TO PUSH:** Code >6 lines, complete/compilable examples, or when specifically requested
**FOLDER PATTERN:** `./snippets/{doc-file}/[net-or-framework]/{csharp|vb}/`
**PROJECT CREATION:** Always use `dotnet new {winforms|wpf|console|classlib}` commands to create a new project for the code language
**LANGUAGES:** Create both C# and VB versions
**SNIPPET IDs:** Use CamelCase region markers like `<ButtonClick>`
**ARTICLE REFS:** Replace with `:::code language="csharp" source="./path" id="SnippetId":::`

## When to push snippets out of articles

**PUSH SNIPPETS WHEN:**
- Code blocks are longer than 6 lines or the rest of the article is using them
- Code demonstrates complete, compilable examples
- Code represents a complete application or significant functionality
- User specifically requests snippet extraction

**KEEP INLINE WHEN:**
- Code blocks are 6 lines or shorter
- Code shows configuration snippets (XAML, JSON, XML)
- XAML snippets that are more than 3 lines
- Code is pseudo-code or conceptual examples

## Target folder structure

**IMPORTANT**: Follow a folder structure based on the article and code language:

### New snippet location (standard)
- Path pattern: `./snippets/{doc-file}/[net-or-framework]/{code-language}/`
- Example: `./snippets/create-windows-forms-app/net/csharp/`

**Path components explained:**
- `{doc-file}`: The markdown article filename WITHOUT the `.md` extension
  - Example: For article `create-windows-forms-app.md` → use `create-windows-forms-app`
- `[net-or-framework]`: Choose based on target framework:
  - `net`: For .NET (.NET 6 and newer)
  - `framework`: For .NET Framework (4.8 and older)
  - **Rule**: Only include this subfolder when the article demonstrates BOTH .NET and .NET Framework approaches. Otherwise, omit this folder. When in doubt, ask.
- `{code-language}`: 
  - `csharp`: For C# code or when demonstrating XAML
  - `vb`: For Visual Basic code

## Framework targeting and project types

**Determine target framework:**
- Check article frontmatter `ms.service` value:
  - `dotnet-framework` → .NET Framework 4.8
  - `dotnet-desktop` → Current .NET (e.g., .NET 10)
- Examine code patterns and article content

**Create appropriate project with `dotnet new`:**

| Project Type | Indicators | .NET Command | .NET Framework Command |
|--------------|------------|--------------|------------------------|
| **Windows Forms** | `System.Windows.Forms`, `Form`, `/winforms/` path | `dotnet new winforms` | `dotnet new winforms --framework net48` |
| **WPF** | `System.Windows`, `Window`, XAML, `/wpf/` path | `dotnet new wpf` | `dotnet new wpf --framework net48` |
| **Console** | `Console.WriteLine`, simple examples, no UI | `dotnet new console` | `dotnet new console --framework net48` |
| **Class Library** | Reusable components, no entry point | `dotnet new classlib` | `dotnet new classlib --framework net48` |

## Push process

### 1. Analyze and prepare
- Locate code blocks >6 lines or complete examples (unless overridden by user request)
- Determine project type from code patterns and article location
- Check framework targeting from frontmatter
- Create folder structure: `./snippets/{doc-file}/[net-or-framework]/{csharp|vb}/`

### 2. Create projects and extract code
- Run appropriate `dotnet new` command in each language folder, **don't** specify an output folder with `-o`. Specify a meaningful project name with `-n` if possible
- Copy and complete code to make it compilable
- Add missing using statements, namespaces, class declarations
- Modernize code patterns if targeting current .NET
- Test compilation with `dotnet build`
- If snippets are XAML-based, store them in a C# project

### 3. Add snippet references and update article
- Add CamelCase region markers: `// <ButtonClick>` and `// </ButtonClick>`
- Use same identifiers across C# and VB versions
- Replace inline code with snippet references:
  ```markdown
  :::code language="xaml" source="./snippets/doc-name/net/csharp/File.xaml" id="ButtonClick":::
  :::code language="csharp" source="./snippets/doc-name/net/csharp/File.cs" id="ButtonClick":::
  :::code language="vb" source="./snippets/doc-name/net/vb/File.vb" id="ButtonClick":::
  ```
- DO NOT use language tabs, simply put them side-by-side
- Verify all paths and references are correct

### 4. Make sure frontmatter specifies a language when required
If both CSharp and VB examples are provided make sure the following frontmatter is at the top of the article:

```yml
dev_langs:
  - "csharp"
  - "vb"
```

If just XAML is provided, don't use a `dev_langs` section.

## Common mistakes to avoid

- ❌ Extracting short snippets (≤6 lines) without request
- ❌ Skipping `dotnet new` commands or creating incomplete projects
- ❌ Missing C# or VB versions
- ❌ Using language tabs
- ❌ Wrong project type (winforms vs wpf vs console)
- ❌ Incorrect framework targeting (net vs framework)
- ❌ Missing or inconsistent snippet region identifiers
- ❌ Code that doesn't compile

## Quality checklist

- ✅ Correct folder structure and project type
- ✅ Both C# and VB versions compile successfully
- ✅ Snippet regions use CamelCase identifiers
- ✅ Article uses correct `:::code...:::` syntax with valid paths