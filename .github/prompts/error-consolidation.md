# Copilot prompts to consolidate error codes.

## Add a single existing file into the new consolidated article. 

Add the contents of cs1027.md to the preprocessor-errors.md file, sort that file by 'source_path_from_root'. Add a redirection for cs1027.md to point to preprocessor-errors.md, add "cs1027: to the list of display names in the TOC for preprocessor-errors.md. Finally, delete cs1027.md

## Search for other related articles that may be missed.

Search all files in the docs/csharp/language-reference/compiler-messages and the docs/csharp/misc folder for any other errors and warnings that involve preprocessor tokens. Give me a list to review for possible additional consolidation.

## Final search in roslyn source

To make sure you've found all related errors, we'll check the source.  Look in `CSharpResources.resx` for any elements where the `<value>` element is a message related to preprocessor tokens. The symbolic constant for that value is in the `name` attribute on the parent `data` element. Find that value in `ErrorCodes.cs`. It will map to the compiler error code, where the code is "CS" followed by the number as a four digit number. Build a list of any not already added to preprocessor-errors.md

## Build consolidated sections

Examine the highlighted section. Other H2s with similar themes should be combined in a similar format. The recommendations to fix the errors should point to language reference articles that explain the impacted syntax.

To do that, make a new H2 section for the theme. Remove all the H2s for the individual error codes that are part of that theme. Where applicable, the new H2 can include text or examples from the H2s you remove.

The list of errors at the top of the file should remain in numerical order, so it's easy for readers to scan. Each impacted error code should now have a link to the anchor tag for the new section. Repeat the list in the new section, but without the anchors, as shown in the highlighted text.

Start with CS1024 and other errors that indicate "Not a valid preprocessor directive"