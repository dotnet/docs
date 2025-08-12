# .NET Documentation Guidelines

## Terminology
- Unless otherwise specified, all .NET content refers to modern .NET (not .NET Framework).

## Writing Style
Follow [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/) with these specifics:

### Voice and Tone
- Active voice, second person addressing reader directly
- Conversational tone with contractions
- Present tense for instructions/descriptions
- Imperative mood for instructions ("Call the method" not "You should call the method")
- Use "might" instead of "may" for possibility
- Use "can" instead of "may" for permissible actions
- Avoid "we"/"our" referring to documentation authors

### Structure and Format
- Sentence case headings (no gerunds in titles)
- Be concise, break up long sentences
- Oxford comma in lists
- Number all ordered list items as "1." (not sequential numbering like "1.", "2.", "3.", etc.)
- Use bullets for unordered lists
- Ordered and unordered lists should use complete sentences with proper punctuation, ending with a period if it's more than three words
- Avoid "etc." or "and so on" - provide complete lists or use "for example"
- No consecutive headings without content between them

### Formatting Conventions
- **Bold** for UI elements
- `Code style` for file names, folders, custom types, non-localizable text
- Raw URLs in angle brackets
- Use relative links for files in this repo
- Remove `https://learn.microsoft.com/en-us` from learn.microsoft.com links

## API References
Use cross-references: `<xref:api-doc-ID>`

To find API doc IDs:
1. Check XML files in https://github.com/dotnet/dotnet-api-docs
2. For types: `Value` attribute of `<TypeSignature>` where `Language="DocId"` (omit first 2 characters)
3. For members: `Value` attribute of `<MemberSignature>` where `Language="DocId"` (omit first 2 characters)

If unsure, use API browser: `https://learn.microsoft.com/api/apibrowser/dotnet/search?api-version=0.2&locale=en-us&search={API_NAME}&$skip=0&$top=5`

Use the `url` value from results for manual links.

## Code Snippets
For snippets >6 lines:
1. Create `./snippets/my-doc/language` folder in same directory as document (for a document named `my-doc.md`) where language is either vb (for visual basic) or cs (for c#)
1. Add snippet as separate code file
1. Include simple project file targeting latest .NET
1. All code should use the latest stable versions/features
1. Create examples in both C# and Visual Basic

## File Naming
New Markdown files: lowercase with hyphens, omit filler words (the, a, etc.)

## Special Cases
- Breaking changes: Include directions from `.github/prompts/breaking-change.md`
- When you (Copilot) is assigned an issue in GitHub, after you've completed your work and the workflows (status checks) have run, check to make sure there are no build warnings under the OpenPublishing.Build status check. If there are, open the build report (under View Details) and resolve any build warnings you introduced.
