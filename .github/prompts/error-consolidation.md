# Copilot prompts to consolidate error codes.

Overall steps:

1. Make a new template, by hand.
1. Add any new errors that should be added here.
1. Consolidate existing errors, as identified by person.
1. Run Copilot search for other existing errors that person may have missed.
1. Search for missing errors.

## Add a single existing file into the new consolidated article.

We're going to work through a series of files consolidating errors and warnings.

- For the duration of this chat, all references to "destination file" refer to `using-statement-declaration-errors.md.
- For the duration of this chat, all references to "the target theme" refer to errors and warnings related to `using` statements and `using` variable declarations. Note that the `using` keyword can also be used for a `using` directive. Don't include those error messages.

The destination file already contains a skeleton for the final output.

For each source file I specify in this chat, you'll do the following tasks:

- Add the contents of the source file to the destination.md file.
  - Include the source error code in the YML header for f1_keywords and helpviewer_keywords.
  - Add an entry with an anchor for the error error code and its corresponding error message.
  - Add the contents of the source file as a new H2 in the destination file.
  - Add a redirection for the source file in the file .openpublishing.redirection.csharp.json. Make the destination point to destination file. Place the new entry in sorted order based on 'source_path_from_root'.
- Update the TOC file:
  - Add the error code to the list of display names in the TOC for the destination file, sorted by numeric error code.
  - Remove the TOC entry for the source file.
  - Finally, delete the source markdown file.

## Search for other related articles that may be missed.

Search all files in the docs/csharp/language-reference/compiler-messages and the docs/csharp/misc folder for any other errors and warnings that involve the target theme. Give me a list to review for possible additional consolidation. Don't make any edits until the originating user approves.

## Final search in roslyn source

Let's check undocumented errors and the roslyn source for any missing errors.  For every error code listed in "sorry-we-don-t-have-specifics-on-this-csharp-error.md" under the `f1_keywords` front matter, do the following:
1. Find that number as a constant in `ErrorCodes.cs`.
2. Locate the corresponding `data` element in CSharpResources.resx. The `name` atttribute should match the number of the constant.
3. Read the error message found in the `<value>` element that is a child of that `<data>` element.
Give me a list of all error numbers and corresponding error messages that relate to the target theme.

To make sure you've found all related errors, we'll check the source.  Look in `CSharpResources.resx` for any elements where the `<value>` element is a message related to the target theme. The symbolic constant for that value is in the `name` attribute on the parent `data` element. Find that value in `ErrorCodes.cs`. It will map to the compiler error code, where the code is "CS" followed by the number as a four digit number. Build a list of any related errors, but don't make any edits yet.

I'll give you error codes one by one. For each, I want you to do the following:

- Add the new error code to the front matter of the destination file, for both the `f1_keywords` and `helpview_keywords` table.
- Add the new error code and error message to the table at the top of the destination file.
- Add the new error code to the list of `displayName` elements in the TOC file entry for the destination file.
- Remove the new error code from the front matter in the file `csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-errors.md` file.

Note that no redirections need to be added for these error codes.

## Build consolidated sections

For all remaining work, all edits will be in the target file. The final format should mirror the structure of the other target theme files in the docs/csharp/language-reference/compiler-messages folder. Every H2 is a theme, all anchors are for the theme, not an individual error code.

To do that, make a new H2 section for the theme. Remove all the H2s for the individual error codes that are part of that theme. Where applicable, the new H2 can include text or examples from the H2s you remove. The new section should include links to language reference articles that discuss the feature or theme.

The list of errors at the top of the file should remain in numerical order, so it's easy for readers to scan. Each impacted error code should now have a link to the anchor tag for the new section. Repeat the list in the new section, but without the anchors, as shown in the highlighted text.

Understand these instructions, then suggest a list of themes and the included error codes. I'll approve each theme before you begin editing.
