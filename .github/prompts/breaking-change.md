When you're assigned an issue that's labeled "breaking-change", or when you're given a link to an issue that's labeled "breaking-change" and asked to create a new breaking change document, follow the following guidelines:

The document should be in Markdown format.

Ignore all breaking change documentation under https://github.com/dotnet/docs/tree/main/docs/framework/migration-guide - that is for legacy .NET Framework breaking changes. Modern .NET breaking changes live in the https://github.com/dotnet/docs/tree/main/docs/core/compatibility folder and its subfolders.

Rephrase all content to be clear and concise, if necessary.

Describe previous behavior in past tense and new behavior in present tense.

The document should start with the following header, including --- characters. Placeholder text is shown in angle brackets.

   ---
   title: "Breaking change - <A concise descriptive title of the breaking change>"
   description: "Learn about the breaking change in <product/version without the preview number> where <very brief description>."
   ms.date: <Today's date>
   ai-usage: ai-assisted
   ms.custom: <URL of the issue>
   ---

After the header, include the following sections in this order. Use the description in parentheses as a guide for the content of each section.

h1: "(The same title used in the document header, sans 'Breaking Change - ')"

   (An introductory paragraph summarizing the breaking change. Include the major version but not the preview number.)

h2: Version introduced

   (The version in which the breaking change was introduced. Include the preview number here, if given.)

h2: Previous behavior

   (A brief description of the behavior before the change, including an example code snippet if applicable.)

h2: New behavior

   (A brief description of the behavior after the change, including an example code snippet if applicable.)

h2: Type of breaking change

   If the type of breaking change is "behavioral change", add the following sentence (without the backticks): `This is a [behavioral change](../../categories.md#behavioral-change).`

   If the type of breaking change is "source incompatible" or "binary incompatible", add the following sentence (without the backticks): `This change can affect [source compatibility](../../categories.md#source-compatibility).` or `This change can affect [binary compatibility](../../categories.md#binary-compatibility).`

   If the issue lists multiple types of breaking changes, create a single sentence that links to each applicable type, such as "This is both a []() and []() change.". If there is no type of breaking change selected in the issue, write "TODO: Add type of breaking change."

h2: Reason for change

   (The complete reasoning behind the change, including any relevant links.)

h2: Recommended action

   (A brief description of the action or actions that users should take, including example code snippets if applicable.)

h2: Affected APIs

   (A bullet list of APIs that are affected by the change. If there are no affected APIs (or "No response") write "None.". Use xref-style links as described in the copilot-instructions.md file. At the end of each doc ID, add "?displayProperty=fullName", for example "<xref:System.String?displayProperty=fullName>".)

Then, add the new document to both the "By area" and "By version" sections of the TOC file located at https://github.com/dotnet/docs/blob/main/docs/core/compatibility/toc.yml. Also add an entry to the index file under the appropriate area H2 heading in the https://github.com/dotnet/docs/blob/main/docs/core/compatibility/10.0.md file by adding a row to the table (create a new heading/table if it doesn't exist yet).

Next, create a pull request. In the description, include the text "Fixes #\<issue-number>", where "issue-number" is the GitHub issue number.
