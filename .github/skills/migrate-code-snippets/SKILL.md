---
name: migrate-code-snippets
description: 'Migrates .NET documentation code from the legacy ~/samples/snippets/ location to article-relative ./snippets/ projects for an input article file. Use when replacing legacy [!code-*] references, creating compilable C# and Visual Basic snippet projects, or removing migrated legacy snippets.'
argument-hint: 'Provide the Markdown article file whose legacy snippets need migration'
owner: adegeo
version: 2
---

# Migrate Code Snippets

Migrate code snippets from the legacy `~/samples/snippets/` location to the `./snippets/` location relative to the article that uses the snippet. Legacy snippets are often outdated, incomplete, and unable to compile. New snippets must be complete, compilable, and include project files. Unless the article is part of a language guide, provide both C# and Visual Basic versions of each snippet.

## Input

This skill requires one Markdown article file as input. Treat the supplied file as the target article. If the user doesn't provide a file, ask for one before you begin the migration. Don't update other articles that reference the same legacy snippets.

## Avoid Common Mistakes

- Don't modernize the code.
- Don't omit either the C# or Visual Basic version, except for language-guide articles.
- Preserve whether the example targets .NET or .NET Framework.
- Update every legacy snippet reference in the target article.
- Don't leave incomplete or noncompilable code.

## Legacy Snippets

- Path: `~/samples/snippets/`
- Example: `~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs`

Legacy code is often written for .NET Framework, incomplete, unable to compile, missing project files, or written with older syntax and patterns.

Legacy article references generally use this syntax:

```markdown
[!code-{code-language}[description](~/samples/snippets/{path-to-file}#{snippet-identifier})]
```

## Migration Workflow

Follow these steps in order.

### 1. Analyze the Code and Article

1. Locate every legacy snippet reference in the target article. References might use `~/samples/snippets/` or a relative path that navigates to the repository's `samples` folder.
2. Identify the language of each reference.
3. Record each source file and snippet identifier.
4. Read the referenced legacy code and enough article context to preserve its behavior and target platform.
5. Determine which examples require separate subject folders because their entry points, project types, target frameworks, or dependencies conflict.

### 2. Create the Snippet Folder Structure

Choose every required platform, subject, and language path segment. For a language-guide article, omit the language segment. Load and follow the `create-snippet-folders` skill with the target article and the complete list of chosen segments. Use the returned directories for the migrated files.

### 3. Create or Reuse the Projects

Reuse an existing project only when its language, platform, project type, and dependencies are compatible with the migrated code. For each new project, change to its intended snippet directory and use the `dotnet` CLI to create it. Never create project files manually, and don't specify an output folder with `-o`.

Use `dotnet new console` unless the snippet requires another project type, such as Windows Forms. Specify a meaningful project name with `-n`, such as `ClipboardExample` or `EventsOverview`.

### 4. Migrate the Code

1. Copy the snippet code and only the supporting code required for it to compile.
2. Preserve the original code and behavior. Don't modernize it.
3. Add only the minimum scaffolding necessary for compilation.

For every structure returned by the shared skill, provide the corresponding C# or Visual Basic version. The code must compile, but the project entry point doesn't need to run every snippet.

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