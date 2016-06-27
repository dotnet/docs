---
# required metadata

title: [ARTICLE TITLE | SERVICE NAME]
description:
keywords:
author: [GITHUB USERNAME]
manager: [MANAGER ALIAS]
ms.date: [CREATION/UPDATE DATE]
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.assetid: [GET ONE FROM guidgenerator.com]

# optional metadata

#ROBOTS:
#audience:
#ms.devlang: dotnet
#ms.reviewer: [ALIAS]
#ms.suite: ems
#ms.tgt_pltfrm:
#ms.custom:

---

# Metadata and Markdown Template

This core-docs template contains examples of Markdown syntax, as well as guidance on setting the metadata. To get the most of it, you must view both the [raw Markdown](https://raw.githubusercontent.com/dotnet/core-docs/master/template.md) and the [rendered view](https://github.com/dotnet/core-docs/blob/master/template.md) (for instance, the raw Markdown shows the metadata block, while the rendered view does not).

When creating a Markdown file, you should copy this template to a new file, fill out the metadata as specified below, set the H1 heading above to the title of the article, and delete the content. 


## Metadata 

The full metadata block is above (in the [raw Markdown](https://raw.githubusercontent.com/dotnet/core-docs/master/template.md)), divided into required fields and optional fields. Some key notes:

- You **must** have a space between the colon (:) and the value for a metadata element.
- If an optional metadata element does not have a value, comment out the element with a # (do not leave it blank or use "na"); if you are adding a value to an element that was commented out, be sure to remove the #.
- Colons in a value (for example, a title) break the metadata parser. In their place, use the HTML encoding for a colon of `&#58;` (for example, `"title: Writing .NET Core console apps&#58 An advanced step-by-step guide"`).
- **title**: This title will appear in search engine results. The title should end with a pipe (|) followed by the name of the service (for example, see above). The title doesn't need (and probably shouldn't) be identical to the title in your H1 heading. It should be roughly 65 characters (including | SERVICE NAME)
- **author**, **manager**, **reviewer**: The author field should contain the **GitHub username** of the author, not their alias.  The "manager" and "reviewer" fields, on the other hand, should contain aliases. ms.reviewer specifies the name of the PM associated with the article or service.
- **ms.assetid**: This is the GUID of the article from CAPS. When creating a new Markdown file, get a GUID from [https://www.guidgenerator.com](https://www.guidgenerator.com). 

## Basic Markdown, GFM, and special characters

All basic and GitHub-flavored Markdown is supported. For more information on these, see:

- [Baseline Markdown syntax](https://daringfireball.net/projects/markdown/syntax)
- [GitHub-flavored Markdown (GFM) documentation](https://guides.github.com/features/mastering-markdown)

Markdown uses special characters such as \*, \`, and \# for formatting. If you wish to include one of these characters in your content, you must do one of two things:

- Put a backslash before the special character to "escape" it (for example, \\\* for a \*)
- Use the [HTML entity code](http://www.ascii.cl/htmlcodes.htm) for the character (for example, \&\#42\; for a &#42;).

## File name

File names use the following rules:
* Contain only lowercase letters, numbers, and hyphens.
* No spaces or punctuation characters. Use the hyphens to separate words and numbers in the file name.
* No more than 80 characters - this is a publishing system limit.
* Use action verbs that are specific, such as develop, buy, build, troubleshoot. No -ing words.
* No small words - don't include a, and, the, in, or, etc.
* Must be in Markdown and use the .md file extension.

## Headings

Headings should be done using atx-style, that is, use 1-6 hash characters (#) at the start of the line to indicate a heading, corresponding to HTML headings levels H1 through H6. Examples of first- and second-level headers are used above. 

There **must** be only one first-level heading (H1) in your topic, which will be displayed as the on-page title.  

Second-level headings will generate the on-page TOC that appears in the "In this article" section underneath the on-page title.

### Third-level heading
#### Fourth-level heading
##### Fifth level heading
###### Sixth-level heading

## Text styling

*Italics* 

**Bold** 

~~Strikethrough~~

## Links

### Internal Links

To link to a header in the same Markdown file, view the source of the published article, find the id of the head (for example, `id="blockquote"`), and link using # + id (for example, `#blockquote`).

- Example: [Blockquotes](#blockquote)

To link to a Markdown file in the same repo, use [relative links](https://www.w3.org/TR/WD-html40-970917/htmlweb.html#h-5.1.2), including the ".md" at the end of the filename.

- Example: [Readme file](readme.md)
- Example: [Welcome to .NET](./docs/welcome.md)

To link to a header in a Markdown file in the same repo, use relative linking + hashtag linking.

- Example: [.NET Community](./docs/welcome.md#community)

### External Links

To link to an external file, use the full URL as the link.

- Example: [GitHub](http://www.github.com)

If a URL appears in a Markdown file, it will be transformed into a clickable link.

- Example: http://www.github.com

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


## Code

### Generic codeblock

Indent code four spaces for generic codeblock coding.

    function fancyAlert(arg) {
      if(arg) {
        $.docs({div:'#foo'})
      }
    }


### Codeblocks with language identifier

Use three backticks (&#96;&#96;&#96;) + a language ID to apply language-specific color coding to a code block.  Here is the entire list of [GitHub Flavored Markdown (GFM) language IDs](https://github.com/jmm/gfm-lang-ids/wiki/GitHub-Flavored-Markdown-(GFM)-language-IDs).

##### C&#9839;

```c#
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

### Inline code

Use backticks (&#96;) for `inline code`.

## Blockquotes

> The drought had lasted now for ten million years, and the reign of the terrible lizards had long since ended. Here on the Equator, in the continent which would one day be known as Africa, the battle for existence had reached a new climax of ferocity, and the victor was not yet in sight. In this barren and desiccated land, only the small or the swift or the fierce could flourish, or even hope to survive.

## Images

### Static Image

![this is the alt text](./images/Logo_DotNet.png)

### Linked Image

[![alt text for linked image](./images/Logo_DotNet.png)](https://dot.net) 

### Animated gif

![animated gif](https://github.com/Microsoft/Docs/tree/master/media/hololens.gif)

## Alerts

### Note

> [!NOTE]
> This is NOTE

### Warning

> [!WARNING]
> This is WARNING

### Tip

> [!TIP]
> This is TIP

### Important

> [!IMPORTANT]
> This is IMPORTANT

## Videos

### Channel 9

<iframe src="https://channel9.msdn.com/Shows/On-NET/Shipping-NET-Core-RC2--Tools-Preview-1/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

### YouTube

<iframe width="420" height="315" src="https://www.youtube.com/embed/g2a4W6Q7aRw" frameborder="0" allowfullscreen></iframe>

## docs.ms extensions

Doc.ms provides a few extensions to GitHub Flavored Markdown. 

###  Includes

You can embed the Markdown of one file into another using an include.

[!INCLUDE[sample include file](./includes/sampleinclude.md)]

### Buttons

> [!div class="button"]
[button links](/rights-management)

### Selectors

> [!div class="op_single_selector"]
- [foo](/rights-management/template.md)
- [bar](/rights-management/scratch.md)

### Step-By-Steps

>[!div class="step-by-step"]
[Pre](https://www.example.com)
[Next](https://www.example.com)