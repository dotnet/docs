---
description: Push inline code block snippets out of articles into standalone files with proper project structure.
---

# Push inline code snippets to files

**IMPORTANT**: Unless otherwise asked to, **only** edit the article file in context. At the end of your operations you may ask for permission to edit other articles that might benefit from the same snippet extraction.

## Quick Reference

**WHEN TO PUSH:** Code >6 lines, complete/compilable examples, or when specifically requested
**FOLDER PATTERN:** `./snippets/{doc-file}/{csharp|vb}/`
**PROJECT CREATION:** Always use the `dotnet new console` command to create a new project for the code language
**LANGUAGES:** Create both C# and VB versions
**SNIPPET IDs:** Use CamelCase region markers like `<ButtonClick>`
**ARTICLE REFS:** Replace with `:::code language="csharp" source="./path" id="SnippetId":::`

## When to push snippets out of articles

**PUSH SNIPPETS WHEN:**
- Code blocks are longer than 6 lines or the rest of the article is using them
- Code demonstrates complete, compilable examples
- Code should not be reused across multiple articles
- Code represents a complete application or significant functionality
- User specifically requests snippet extraction

**KEEP INLINE WHEN:**
- Code blocks are 6 lines or shorter (unless you find an example in the article's snippets folder)
- Code shows configuration snippets (XAML, JSON, XML) (unless you find an example in the article's snippets folder)
- Code demonstrates simple one-liner examples (unless you find an example in the article's snippets folder)
- Code is pseudo-code or conceptual examples

## Target folder structure

**IMPORTANT**: Follow a folder structure based on the article and code language:

### New snippet location (standard)
- Path pattern: `./snippets/{doc-file}/{code-language}/`
- Example: `./snippets/create-windows-forms-app/csharp/`

**Path components explained:**
- `{doc-file}`: The markdown article filename WITHOUT the `.md` extension
  - Example: For article `create-windows-forms-app.md` → use `create-windows-forms-app`
- `{code-language}`: 
  - `csharp`: For C# code
  - `vb`: For Visual Basic code

## Push process

### 1. Analyze and prepare
- Locate code to migrate
- Create folder structure: `./snippets/{doc-file}/{csharp|vb}/`

### 2. Create projects and extract code
- Run appropriate `dotnet new` command in each language folder, **don't** specify an output folder with `-o`. Specify a meaningful project name with `-n` if possible
- Copy and complete code to make it compilable
- Add missing using statements, namespaces, class declarations
- Modernize code patterns if targeting current .NET
- Test compilation with `dotnet build`

### 3. Add snippet references and update article
- Add CamelCase region markers: `// <ButtonClick>` and `// </ButtonClick>`
- Use same identifiers across C# and VB versions
- Replace inline code with snippet references:
  ```markdown
  :::code language="csharp" source="./snippets/doc-name/csharp/File.cs" id="ButtonClick":::
  :::code language="vb" source="./snippets/doc-name/vb/File.vb" id="ButtonClick":::
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