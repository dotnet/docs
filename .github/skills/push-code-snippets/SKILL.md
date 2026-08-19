---
name: push-code-snippets
description: 'Extracts inline code blocks from an input .NET documentation article file into article-relative ./snippets/ files and compilable projects. Use when moving fenced C#, Visual Basic, or XAML examples out of Markdown, adding :::code references and snippet markers, or converting embedded samples to standalone snippet projects.'
argument-hint: 'Provide the Markdown article file whose inline snippets need extraction'
ai-usage: ai-generated
---

# Push Code Snippets

Move eligible inline code blocks from the target article into standalone files under an article-relative `./snippets/` folder. Add compilable project scaffolding and replace each extracted block with a `:::code` reference.

## Input

This skill requires one Markdown article file as input. Treat the supplied file as the target article. If the user doesn't provide a file, ask for one before you begin the extraction.

## Select Snippets

Extract an inline code block when any of these conditions apply:

- The block is longer than six lines.
- The block demonstrates a complete, compilable example.
- The block represents a complete application or significant functionality.
- The user explicitly requests its extraction.

Keep blocks of six lines or fewer inline unless another condition applies. Keep pseudocode and conceptual examples inline.

If the article contains only XAML snippets, create only C# projects to contain the XAML. Don't create Visual Basic projects for XAML-only snippets.

## Snippet Locations

Use this path pattern:

`./snippets/{article-name}/[net-or-framework]/[optional-subject]/{code-language}/`

Examples:

- Standard C#: `./snippets/create-app/csharp/`
- Standard Visual Basic: `./snippets/create-app/vb/`
- .NET in a dual-platform article: `./snippets/create-app/net/csharp/`
- .NET Framework in a dual-platform article: `./snippets/create-app/framework/csharp/`
- Separate projects to prevent conflicts: `./snippets/create-app/AsyncProgram/csharp/`

The path components have these meanings:

- `./`: The folder that contains the target article.
- `snippets/`: The root folder for that article's snippets.
- `{article-name}`: The article filename without the `.md` extension.
- `[net-or-framework]`: An optional folder for articles that demonstrate both platforms. Use `net/` for modern .NET and `framework/` for .NET Framework. Omit this folder when the article targets only one platform.
- `[optional-subject]`: An optional descriptive folder for snippets that can't compile in one project, such as two examples that each require a different `Program.cs` file.
- `{code-language}`: Use `csharp` for C# and XAML, and `vb` for Visual Basic.

For an article in the C# or Visual Basic language guide, provide only the guide's language and omit the language folder. For example, use `./snippets/pattern-matching/Program.cs`.

## Extraction Workflow

Follow these steps in order.

### 1. Analyze the Article

1. Locate all eligible inline code blocks in the target article.
2. Identify each block's language and platform.
3. Determine whether the article belongs to the C# or Visual Basic language guide.
4. Check whether the article discusses single-file applications.

### 2. Choose the Application Structure

If the article discusses single-file applications, stop and ask the user whether to use single-file applications or traditional project-based applications.

Otherwise, use project-based applications. Use the `dotnet` CLI to create each project; never create project files manually. Run the command from the intended parent folder, don't specify an output folder with `-o`, and specify a meaningful project name with `-n` when practical. Use `dotnet new console` unless the snippet requires another project type, such as `dotnet new winforms`.

Use single-file applications only when the user requests them or confirms their use for an article that discusses them. Single-file applications:

- Support only C#. Use a project for Visual Basic snippets.
- Can share the article's snippet folder.
- Can use descriptive filenames instead of `Program.cs`.
- Must not have a project file in their folder.
- Must be validated with `dotnet run file.cs`.

### 3. Extract and Complete the Code

1. Copy each selected block into the appropriate snippet file.
2. Add only the imports, namespaces, types, and other scaffolding required for compilation.
3. Preserve the example's documented behavior.
4. For standard articles, provide both C# and Visual Basic versions unless the snippets contain only XAML.
5. For language-guide articles, provide only the guide's language.

The code must compile, but the project entry point doesn't need to execute every snippet.

### 4. Add Markers and References

Wrap each extracted snippet in comments with a meaningful CamelCase identifier. Use the same identifier in equivalent C# and Visual Basic examples.

C# markers:

```csharp
// <ButtonClick>
...code here...
// </ButtonClick>
```

Visual Basic markers:

```vb
' <ButtonClick>
...code here...
' </ButtonClick>
```

Don't use identifiers such as `1`, `2`, `code1`, or `snippet1`.

Replace each inline block with a `:::code` reference:

```markdown
:::code language="{code-language}" source="{relative-file-path}" id="{snippet-identifier}":::
```

For example:

```markdown
:::code language="csharp" source="./snippets/doc-name/csharp/File.cs" id="ButtonClick":::

:::code language="vb" source="./snippets/doc-name/vb/File.vb" id="ButtonClick":::
```

Place C# and Visual Basic references one after the other. Don't put them in language tabs. Verify every source path and identifier against the created files.

### 5. Update Article Frontmatter

When the article includes both C# and Visual Basic examples, ensure its frontmatter contains an entry for each language:

```yml
dev_langs:
  - "csharp"
  - "vb"
```

Omit `dev_langs` when the article uses only one language, such as an article in a language guide.

Markup languages don't require languages in the frontmatter. For example, XAML snippets don't require a `dev_langs` entry.

Because this workflow rewrites an existing article, ensure its frontmatter contains `ai-usage: ai-assisted` unless the user asks only for a review without edits.

### 6. Validate the Result

1. Build every project that the extraction creates or changes with `dotnet build`.
2. Run every single-file application with `dotnet run file.cs`.
3. Verify that all `:::code` paths resolve and all identifiers match their markers.
4. Report the validation commands and results, plus any eligible blocks that remain inline and why.

## Avoid Common Mistakes

- Don't extract short snippets without a qualifying reason.
- Don't create project files manually.
- Don't omit either C# or Visual Basic from a standard article.
- Don't create Visual Basic projects for XAML-only snippets.
- Don't use language tabs for snippet references.
- Don't omit or mismatch snippet markers.
- Don't leave extracted code in a noncompilable state.