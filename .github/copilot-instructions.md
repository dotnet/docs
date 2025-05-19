When writing documentation, follow the following guidelines:

Unless otherwise specified, all .NET content refers to modern .NET (not .NET Framework).

Follow the style of the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/).

Headings should be in sentence case, not title case. Don't use gerunds in titles.

Use the active voice whenever possible, and second person to address the reader directly.

Use a conversational tone with contractions.

Be concise.

Break up long sentences.

Use the present tense for instructions and descriptions. For example, "The method returns a value" instead of "The method will return a value."

Do not use "we" or "our" to refer to the authors of the documentation.

Use the imperative mood for instructions. For example, "Call the method" instead of "You should call the method."

Use "might" instead of "may" to indicate possibility. For example, "This method might throw an exception" instead of "This method may throw an exception."

Use the Oxford comma in lists of three or more items.

Number ordered list items all as "1." instead of "1.", "2.", etc. Use bullets for unordered lists.

Use **bold** when referring to UI elements. Use `code style` for file names and folders, custom types, and other text that should never be localized.

Put raw URLs within angle brackets.

Include links to related topics and resources where appropriate. Use relative links if the target file lives in this repo. If you add a link to another page on learn.microsoft.com that's not in this repo, remove https://learn.microsoft.com/en-us from the link.

When mentioning APIs, use cross-references to the API documentation. These links are formatted as <xref:api-doc-ID>. You can find the API doc ID in the XML files in the https://github.com/dotnet/dotnet-api-docs repository. For types, the doc ID is the value of the `Value` attribute of the `<TypeSignature>` element where the `Language` attribute value is `DocId`. For other (member) APIs, the doc ID is the value of the `Value` attribute of the `<MemberSignature>` element where the `Language` attribute value is `DocId`. Omit the first two characters of the DocId. For example, the xref link for System.String is <xref:System.String>.

If you're assigned a GitHub issue that's labeled "breaking-change", include the prompt directions in the prompts/breaking-change.md file in this repo.

If you include a code snippet that's more than 6 lines long, put it in a separate .cs file in a folder named "snippets" in the same folder as the document. Within the "snippets" folder, add a new directory with the name of the document. For example, if the document is named "my-doc.md", create a folder named "snippets/my-doc" folder. Also add a simple .csproj file to the same directory that targets the latest version of .NET. It can be a library or executable project.

If you're adding a new Markdown file, it should be named in all lowercase with hyphens separating words. Also, omit any filler words such as "the" or "a" from the file name.
