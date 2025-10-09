# Copilot prompts to consolidate error codes.

We're going to edit this file, string-literal.md, to contain information about all errors and warnings related to string and character literal declarations. I'll write prompts for specific tasks. Don't make any edits yet. In future prompts, the destination for new error and warning content is always this file.


## Add a single existing file into the new consolidated article. 

Start with CS1009.md as the source file.
For each source file:

- Add the contents of the source file to the destination.md file.
  - Include the source error code in the YML header for `f1_keywords` and `helpviewer_keywords`.
  - Add an entry with an anchor for the error error code and its corresponding error message.
  - Add the contents of the source file as a new H2 in the destination file.
- Add a redirection for the source file in the file `.openpublishing.redirection.csharp.json`. Make the destination point to destination file. Place the new entry in sorted order based on 'source_path_from_root'.
- Update the TOC file:
  - Add the error code to the list of display names in the TOC for the destination file, sorted by numeric error code.
  - Remove the TOC entry for the source file.
- Finally, delete the source markdown file. 

## Search for other related articles that may be missed.

Search all files in the docs/csharp/language-reference/compiler-messages and the docs/csharp/misc folder for any other errors and warnings that involve string literals or constants. Give me a list to review for possible additional consolidation.

## Final search in roslyn source

To make sure you've found all related errors, we'll check the source.  Look in `CSharpResources.resx` for any elements where the `<value>` element is a message related to preprocessor tokens. The symbolic constant for that value is in the `name` attribute on the parent `data` element. Find that value in `ErrorCodes.cs`. It will map to the compiler error code, where the code is "CS" followed by the number as a four digit number. Build a list of any related errors, but don't make any edits yet.

For each new file:

- Add the new error code to the front matter of the consolidated article, for both the `f1_keywords` and `helpview_keywords` table.
- Add the new error code and error message to the table at the top of the destination article.
- Add the new error code to the list of `displaName` elements in the TOC file.
- Remove the new error code from the front matter in the file `csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-errors.md` file.

Note that no redirections need to be added for these error codes.

## Build consolidated sections

For all remaining work, all edits will be in the `string-literal.md` file. The final format should mirror the structure of the `preprocessor-errors.md` file.

To do that, make a new H2 section for the theme. Remove all the H2s for the individual error codes that are part of that theme. Where applicable, the new H2 can include text or examples from the H2s you remove.

The list of errors at the top of the file should remain in numerical order, so it's easy for readers to scan. Each impacted error code should now have a link to the anchor tag for the new section. Repeat the list in the new section, but without the anchors, as shown in the highlighted text.

Start with the section for all errors related to raw string literals.
