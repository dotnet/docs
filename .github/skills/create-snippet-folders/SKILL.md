---
name: create-snippet-folders
description: 'Creates article-relative ./snippets/ directories and returns their paths. Use when a snippet workflow needs folders composed from an article path plus caller-selected platform, conflict-avoidance subject, and code-language segments.'
argument-hint: 'Provide the article file and each requested platform, subject, and language path'
user-invocable: false
version: 1.0
owner: adegeo
---

# Create Snippet Folders

Create the requested folders that hold code snippets for one documentation article, and return their paths to the calling workflow. Don't choose the structure, inspect project compatibility, create projects, write example code, or update the article.

## Caller Decision Guide

Before requesting directories, choose the path segments as follows:

- Use a platform segment only when the article demonstrates both .NET and .NET Framework approaches:
	- Use `net` for .NET 6 or later snippets.
	- Use `framework` for .NET Framework snippets.
	- Otherwise, omit the platform segment.
- Use a descriptive subject segment when snippets can't coexist and compile in one project. For example, use `AsyncProgram` and `SyncProgram` when two examples both require a `Program.cs` file. Otherwise, omit the subject segment.
- Use `csharp` for C# code or `vb` for Visual Basic code. Omit the language segment only when the caller requests the article's shared snippet root rather than a language-specific directory.

## Input

Require the calling workflow to provide:

- The target Markdown article.
- A list of requested directories. Each directory must specify:
	- The platform segment: `net`, `framework`, or omitted.
	- The subject segment, or omitted.
	- The language segment: `csharp`, `vb`, or omitted.

The caller must decide whether the article requires platform separation, a subject folder to prevent conflicts, and a language folder. If any segment decision is missing, return control to the caller without creating folders. Don't infer missing segments from the article or existing snippets.

## Create the Structure

For each requested directory:

1. Use the folder that contains the target article as the base directory.
2. Use the article filename without `.md` as `{article-name}`.
3. Construct the path in this order:

	 `./snippets/{article-name}/[platform]/[subject]/[language]/`

4. Omit every segment that the caller explicitly marks as omitted. Don't reorder or rename supplied segments.
5. Create the directory and any missing parent directories. If the directory already exists, leave it and its contents unchanged.
6. Return the article-relative and repository-relative path, and report whether the directory was created or already existed.

## Example Requests

Given `docs/core/create-app.md`, these inputs produce these paths:

- Platform omitted, subject omitted, language `csharp`: `./snippets/create-app/csharp/`
- Platform `net`, subject omitted, language `vb`: `./snippets/create-app/net/vb/`
- Platform omitted, subject `AsyncProgram`, language `csharp`: `./snippets/create-app/AsyncProgram/csharp/`
- Platform omitted, subject omitted, language omitted: `./snippets/create-app/`

The skill treats all supplied segments as opaque path decisions except for validating the allowed platform and language values.