---
# required metadata

title: [ARTICLE TITLE | SERVICE NAME]
description:
keywords:
author: [GITHUB USERNAME]

ms.date: [CREATION/UPDATE DATE]
ms.topic: article
ms.prod: .net-core

ms.assetid: [GET ONE FROM guidgenerator.com]

# optional metadata

#ROBOTS:
#audience:
#ms.devlang: dotnet
#ms.reviewer: [ALIAS]

---

# Metadata and Markdown Template

This core-docs template contains examples of Markdown syntax, as well as guidance on setting the metadata. To get the most of it, you must view both the [raw Markdown](https://raw.githubusercontent.com/dotnet/docs/master/styleguide/template.md) and the [rendered view](https://github.com/dotnet/docs/blob/master/styleguide/template.md) (for instance, the raw Markdown shows the metadata block, while the rendered view does not).

When creating a Markdown file, you should copy this template to a new file, fill out the metadata as specified below, set the H1 heading above to the title of the article, and delete the content. 


## Metadata 

The full metadata block is above (in the [raw Markdown](https://raw.githubusercontent.com/dotnet/docs/master/styleguide/template.md)), divided into required fields and optional fields. Some key notes:

- You **must** have a space between the colon (:) and the value for a metadata element.
- If an optional metadata element does not have a value, comment out the element with a # or remove it (do not leave it blank or use "na"); if you are adding a value to an element that was commented out, be sure to remove the #.
- Colons in a value (for example, a title) break the metadata parser. In this case, surround the title with double quotes (for example, `title: "Writing .NET Core console apps: An advanced step-by-step guide"`).
- **title**: This title will appear in search engine results. You can also add a pipe (|) followed by the product name (for example, `title: Developing Libraries with Cross Platform Tools | .NET Core`). The title doesn't need be identical to the title in your H1 heading and it should contain 65 characters or less (including | PRODUCT NAME).
- **author**, **manager**, **ms.reviewer**: The author field should contain the **GitHub username** of the author, not their alias.  The "manager" and "ms.reviewer" fields, on the other hand, should contain Microsoft aliases. ms.reviewer specifies the name of the PM/dev associated with the article or feature.
- **ms.devlang** defines the technology. Some of the supported values are: dotnet, cpp, csharp, fsharp, vb and xml.
- **ms.assetid**: This is the GUID of the article that is used for internal tracking purposes such as Business Intelligence (BI). When creating a new Markdown file, get a GUID from [https://www.guidgenerator.com](https://www.guidgenerator.com). 

## Basic Markdown, GFM, and special characters

All basic and GitHub Flavored Markdown (GFM) is supported. For more information on these, see:

- [Baseline Markdown syntax](https://daringfireball.net/projects/markdown/syntax)
- [GFM documentation](https://guides.github.com/features/mastering-markdown)

Markdown uses special characters such as \*, \`, and \# for formatting. If you wish to include one of these characters in your content, you must do one of two things:

- Put a backslash before the special character to "escape" it (for example, `\*` for a \*)
- Use the [HTML entity code](http://www.ascii.cl/htmlcodes.htm) for the character (for example, `&#42;` for a &#42;).

## File name

File names use the following rules:
* Contain only lowercase letters, numbers, and hyphens.
* No spaces or punctuation characters. Use the hyphens to separate words and numbers in the file name.
* Use action verbs that are specific, such as develop, buy, build, troubleshoot. No -ing words.
* No small words - don't include a, and, the, in, or, etc.
* Must be in Markdown and use the .md file extension.
* Keep file names reasonably short. They are part of the URL for your articles.  



## Headings

Use sentence-style capitalization. Always capitalize:
- The first word of a heading. 
- The word following a colon in a title or heading (for example, "How to: Sort an array"). 

Headings should be done using atx-style, that is, use 1-6 hash characters (#) at the start of the line to indicate a heading, corresponding to HTML headings levels H1 through H6. Examples of first- and second-level headers are used above. 

There **must** be only one first-level heading (H1) in your topic, which will be displayed as the on-page title.

If your heading finishes with a `#` character, you need to add an extra `#` character in the end in order for the title to render correctly. For example, `# Async Programming in F# #`.     

Second-level headings will generate the on-page TOC that appears in the "In this article" section underneath the on-page title.

### Third-level heading
#### Fourth-level heading
##### Fifth level heading
###### Sixth-level heading
 
## Text styling

*Italics*
 Use for files, folders, paths (for long items, split onto their own line), new terms.

**Bold**
Use for UI elements.

`Code`
Use for inline code, language keywords, NuGet package names, command-line commands, database table and column names, and URLs that you don't want to be clickable.

## Links

### Internal Links

To link to a header in the same Markdown file (also known as anchor links), you'll need to find out the id of the header you're trying to link to. To confirm the ID, view the source of the rendered article, find the id of the header (for example, `id="blockquote"`), and link using # + id (for example, `#blockquote`).
The id is auto-generated based on the header text. So, for example, given a unique section named `## Step 2`, the id would look like this `id="step-2"`.

- Example: [Chapter 1](#chapter-1)

To link to a Markdown file in the same repo, use [relative links](https://www.w3.org/TR/WD-html40-970917/htmlweb.html#h-5.1.2), including the ".md" at the end of the filename.

- Example: [Readme file](../readme.md)
- Example: [Welcome to .NET](../docs/welcome.md)

To link to a header in a Markdown file in the same repo, use relative linking + hashtag linking.

- Example: [.NET Community](../docs/welcome.md#community)

### External Links

To link to an external file, use the full URL as the link.

- Example: [GitHub](http://www.github.com)

If a URL appears in a Markdown file, it will be transformed into a clickable link.

- Example: http://www.github.com

### Links to APIs

The build system has some extensions that allow us to link to .NET Core APIs without having to use external links.  
When linking to an API, you can use its unique identifier (UID) that is auto-generated from the source code.

You can use one of the following syntax:

1. Markdown link: `[link_text](xref:UID)`
2. Auto link: `<xref:UID>`
3. Shorthand form: `@UID`

- Example: `@System.String`
- Example: `[String class](xref:System.String)` 

For more information about using this notation, see [Using cross reference](https://dotnet.github.io/docfx/tutorial/links_and_cross_references.html#using-cross-reference).

> Right now, there is no easy way to find the UIDs. The best way to find the UID for an API is to search for it in this repo: [docascode/coreapi](https://github.com/docascode/coreapi). We're working on having a better system in the future.

When the UID contains the special characters \` or \#, the UID value needs to be HTML encoded as %60 and %23 respectively as in the following examples:
- Example: @System.Threading.Tasks.Task\`1 becomes `@System.Threading.Tasks.Task%601`
- Example: @System.Exception.\#ctor becomes `@System.Exception.%23ctor`

## Lists

### Ordered lists

1. This 
1. Is
1. An
1. Ordered
1. List  


#### Ordered list with an embedded list

1. Here
1. comes
1. an
1. embedded
    1. Miss Scarlett
    1. Professor Plum
1. ordered
1. list


### Unordered Lists

- This
- is
- a
- bulleted
- list


##### Unordered list with an embedded list

- This 
- bulleted 
- list
    - Mrs. Peacock
    - Mr. Green
- contains  
- other
    1. Colonel Mustard
    1. Mrs. White
- lists


## Horizontal rule

---

## Tables

| Tables        | Are           | Cool  |
| ------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| col 1 is default | left-aligned     |    $1 |

You can use a [Markdown table generator tool](http://www.tablesgenerator.com/markdown_tables) to help creating them more easily. 

## Code

The best way to include code is to include snippets from a working sample. Create your
sample following the instructions in the [contributing guide](../CONTRIBUTING.md#contributing-to-samples).

You can include the code using include syntax:

```
[!code-csharp[<title>](<pathToFile>#<RegionName)]
```

The example above shows C# syntax, but other languages are supported.
Use `code-fsharp` for F# samples; use `code-vbnet` for Visual Basic samples.
Other languages that are supported are:
* C++: `code-cpp`
* HTML: `code-html`
* JavaScript: `code-javascript`
* Powershell: `code-ps`
* SQL: `code-sql`
* XML: `code-xml`



The text you place for `<title>` shows up as a rollover on the text. The `<pathToFile>`
is the path to the source file. The `<RegionName>` should be a region in your source
code that should be included. Use the `#region` and `#endregion` preprocessor syntax
to specify the region of code to include.

For cases where regions don't work, you can specify the start and end of a snippet
using an XML element name in a single line comment. For example, you could write this in C#:

```csharp
// <CodeToInclude>
int j = 5;
int i ; 10;
int sum = i + j;
// </CodeToInclude>
```

In other languages, use the comment syntax for that language.
Finally, you can use line
numbers: `#L1-L10` would include lines 1 through 10. We discourage line numbers
because they are very brittle.

Including snippets from full programs ensures that all code runs through our Continuous Integration (CI)
system. However, if you need to show something that causes compile time or
runtime errors, you can use inline code blocks.

### Inline code blocks with language identifier

Use three backticks (\`\`\`) + a language ID to apply language-specific color coding to a code block. Here is the entire list of [GFM language IDs](https://github.com/jmm/gfm-lang-ids/wiki/GitHub-Flavored-Markdown-(GFM)-language-IDs).

##### C&#9839;

```cs
using System;
namespace HelloWorld
{
    class Hello 
    {
        static void Main() 
        {
            Console.WriteLine("Hello World!");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
```
#### Python

```python
friends = ['john', 'pat', 'gary', 'michael']
for i, name in enumerate(friends):
    print "iteration {iteration} is {name}".format(iteration=i, name=name)
```
#### PowerShell

```powershell
Clear-Host
$Directory = "C:\Windows\"
$Files = Get-Childitem $Directory -recurse -Include *.log `
-ErrorAction SilentlyContinue
```

### Generic code block

Use three backticks (&#96;&#96;&#96;) for generic code block coding.   

> The recommended approach is to use code blocks with language identifiers as explained in the previous section to ensure the proper syntax highlighting in the documentation site. Use generic code blocks only when necessary.

```
function fancyAlert(arg) {
    if(arg) {
        $.docs({div:'#foo'})
    }
}
```

## Blockquotes

> The drought had lasted now for ten million years, and the reign of the terrible lizards had long since ended. Here on the Equator, in the continent which would one day be known as Africa, the battle for existence had reached a new climax of ferocity, and the victor was not yet in sight. In this barren and desiccated land, only the small or the swift or the fierce could flourish, or even hope to survive.

## Images

### Static Image or Animated gif

![this is the alt text](../images/Logo_DotNet.png)

### Linked Image

[![alt text for linked image](../images/Logo_DotNet.png)](https://dot.net) 

## Videos

### Channel 9

<iframe src="https://channel9.msdn.com/Shows/On-NET/Shipping-NET-Core-RC2--Tools-Preview-1/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

### YouTube

<iframe width="420" height="315" src="https://www.youtube.com/embed/g2a4W6Q7aRw" frameborder="0" allowfullscreen></iframe>

## docs.microsoft extensions

docs.microsoft provides a few additional extensions to GitHub Flavored Markdown. 

### Alerts

It's important to use the following alert styles so they render with the proper style in the documentation site. However, the rendering engine on GitHub doesn't diferentiate them.     

#### Note

> [!NOTE]
> This is a NOTE

#### Warning

> [!WARNING]
> This is a WARNING

#### Tip

> [!TIP]
> This is a TIP

#### Important

> [!IMPORTANT]
> This is IMPORTANT

And they'll render like this:
![Alert styles](../images/alerts.png)

###  Includes

You can embed the Markdown of one file into another using an include.

[!INCLUDE[sample include file](../includes/sampleinclude.md)]

### Buttons

> [!div class="button"]
[button links](../docs/core/index.md)

You can see an example of buttons in action at the [Intune docs](https://docs.microsoft.com/en-us/intune/get-started/choose-how-to-enroll-devices). 

### Selectors

> [!div class="op_single_selector"]
- [macOS](../docs/core/tutorials/using-on-macos.md)
- [Windows](../docs/csharp/getting-started/with-visual-studio-2017.md)

You can see an example of selectors in action at the [Intune docs](https://docs.microsoft.com/en-us/intune/deploy-use/what-to-tell-your-end-users-about-using-microsoft-intune#how-your-end-users-get-their-apps).

### Step-By-Steps

>[!div class="step-by-step"]
[Pre](../docs/csharp/expression-trees-interpreting.md)
[Next](../docs/csharp/expression-trees-translating.md)

You can see an example of step-by-steps in action at the [Advanced Threat Analytics docs](https://docs.microsoft.com/en-us/advanced-threat-analytics/deploy-use/install-ata-step2).
