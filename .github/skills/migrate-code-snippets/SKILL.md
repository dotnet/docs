---
name: migrate-code-snippets
description: 'Migrates .NET documentation code from the legacy ~/samples/snippets/ location to article-relative ./snippets/ projects. Use when replacing legacy [!code-*] references, creating compilable C# and Visual Basic snippet projects, or removing migrated legacy snippets.'
argument-hint: 'Provide the article whose legacy snippets need migration'
owner: adegeo
version: 2
---

# Migrate Code Snippets

Migrate code snippets from the legacy `~/samples/snippets/` location to the `./snippets/` location relative to the article that uses the snippet. Legacy snippets are often outdated, incomplete, and unable to compile. New snippets must be complete, compilable, and include project files. Unless the article is part of a language guide, provide both C# and Visual Basic versions of each snippet.

Unless the user asks otherwise, update only the target article and its snippet files. Don't update other articles that reference the same legacy snippets. At the end of the migration, ask for permission to update those articles separately.

## Avoid Common Mistakes

- Don't modernize the code.
- Don't omit either the C# or Visual Basic version, except for language-guide articles.
- Preserve whether the example targets .NET or .NET Framework.
- Update every legacy snippet reference in the target article.
- Don't leave incomplete or noncompilable code.

## Snippet Locations

This repository has two locations for code snippets.

### Legacy Location

- Path: `~/samples/snippets/`
- Example: `~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs`

Legacy code is often written for .NET Framework, incomplete, unable to compile, missing project files, or written with older syntax and patterns.

Legacy article references generally use this syntax:

```markdown
[!code-{code-language}[description](~/samples/snippets/{path-to-file}#{snippet-identifier})]
```

### Current Location

Use this path pattern:

`./snippets/{article-name}/[net-or-framework]/[optional-subject]/{code-language}/`

Examples:

- Standard C#: `./snippets/anchors-in-regular-expressions/csharp/Form1.cs`
- Standard Visual Basic: `./snippets/anchors-in-regular-expressions/vb/Form1.vb`
- .NET in a dual-framework article: `./snippets/clipboard-operations/net/csharp/Form1.cs`
- .NET Framework in a dual-framework article: `./snippets/clipboard-operations/framework/csharp/Form1.cs`
- Separate projects to prevent conflicts: `./snippets/program-structure/AsyncProgram/csharp/Program.cs`
- Language guide: `./snippets/pattern-matching/Program.cs`

The path components have these meanings:

- `./`: The folder that contains the target article.
- `snippets/`: The root folder for that article's snippets.
- `{article-name}`: The article filename without the `.md` extension. For example, use `anchors-in-regular-expressions` for `anchors-in-regular-expressions.md`.
- `[net-or-framework]`: An optional folder for articles that demonstrate both platforms. Use `net/` for modern .NET (like .NET 10) and `framework/` for .NET Framework. Omit this folder when the article targets only one platform.
- `[optional-subject]`: An optional descriptive folder for snippets that can't compile in one project, such as two examples that each require a different `Program.cs` file.
- `{code-language}`: Use `csharp` for C# and `vb` for Visual Basic.

For a C# or Visual Basic language-guide article, provide only the guide's language and omit the language folder. For all other articles, provide both languages and include the `csharp/` and `vb/` folders.

Current snippets must:

- Be complete and compilable.
- Include a project file.
- Target the latest .NET or .NET Framework version appropriate to the article.
- Provide both C# and Visual Basic versions, except in language-guide articles.
- Use syntax appropriate for the target platform.
- Use meaningful CamelCase snippet identifiers, such as `BasicClipboardData`, `CustomDataFormat`, or `ClipboardImageHandling`. Don't use identifiers such as `1`, `2`, `code1`, or `snippet1`.

Current article references use this syntax:

```markdown
:::code language="{code-language}" source="{relative-file-path}" id="{snippet-identifier}":::
```

## Migration Workflow

Follow these steps in order.

### 1. Analyze the Code and Article

1. Locate every legacy snippet reference in the target article. References might use `~/samples/snippets/` or a relative path that navigates to the repository's `samples` folder.
2. Identify the language of each reference.
3. Record each source file and snippet identifier.
4. Read the referenced legacy code and enough article context to preserve its behavior and target platform.

### 2. Create or Reuse the Folder Structure

1. Use `./snippets/{article-name}/[optional-subject]/{code-language}/` unless the platform or language-guide rules require another structure.
2. If the article already has current snippets, reuse its folder structure and merge code into an existing project when practical. Add classes or code files as needed. The code must compile, but the program entry point doesn't need to run every snippet.
3. If the article has no current snippet project, use the `dotnet` CLI to create one. Never create project files manually.
4. Create a console app unless the snippet requires another project type, such as Windows Forms.
5. Specify a meaningful project name with `-n`. For example, use `dotnet new console -n ClipboardExample` for clipboard examples or `dotnet new console -n EventsOverview` for event examples.

### 3. Migrate the Code

1. Copy the snippet code and only the supporting code required for it to compile.
2. Preserve the original code and behavior. Don't modernize it.
3. Add only the minimum scaffolding necessary for compilation.

### 4. Provide the Required Languages

For standard articles, create both versions:

- C#: `./snippets/{article-name}/csharp/`
- Visual Basic: `./snippets/{article-name}/vb/`

For a language-guide article, create only the guide's language and use `./snippets/{article-name}/` without a language folder.

### 5. Update the Article References

Replace every legacy reference in the target article with the current directive and a meaningful CamelCase identifier.

Before:

```markdown
[!code-csharp[description](~/samples/snippets/path/file.cs#snippet1)]
```

After:

```markdown
:::code language="csharp" source="./snippets/article-name/csharp/file.cs" id="BasicClipboardData":::
```

### 6. Validate the Projects

Build every C# and Visual Basic project that the migration creates or changes. The projects don't need to run, but all builds must succeed.

### 7. Remove Unused Legacy Files

1. Search the entire repository for each migrated legacy snippet path. Account for references that use different relative paths to reach the same file.
2. Delete a legacy snippet file only when no article still references it.
3. Don't change other articles unless the user requested those changes. Report any remaining references and ask for permission to migrate them separately.

### 8. Report the Migration

Use each workflow step title as a heading, and summarize what you did for that step with bullet points. Include all build commands and results, remaining references from other articles, and any legacy files that you couldn't delete.