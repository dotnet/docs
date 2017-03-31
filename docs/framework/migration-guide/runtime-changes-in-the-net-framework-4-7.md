---
title: "Runtime Changes in the .NET Framework 4.7 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "runtime changes,.NET Framework"
  - "runtime changes,.NET Framework 4.7"
  - "application compatibility"
ms.assetid: 268eb334-7906-4e0b-a1e3-c74b745de2a5
caps.latest.revision: 1
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.7
## Welcome to CAPS Markdown Editor!

CAPS is using GitHub Flavored Markdown(GFM) which is one of the most popular Markdown flavor. Lets' learn how to make your customized document with below rules.  

*View the [Markdown Basics](https://help.github.com/articles/markdown-basics/)*
*View the [Github Flavored Markdown](https://help.github.com/articles/github-flavored-markdown/)*
*View the [Online sample](http://github.github.com/github-flavored-markdown/sample_content.html).*
  
Quick Guidance
---
When you are authoring your Markdown content in CAPS, you could get help from different ways:
- Use `Alt + F1` in IE or `F1` in Chrome to open `Command Palette`
- Use `Ctrl + space` at any place to open insert.
- Use authoring tool bar on the top of the editor to help create your content

Format your content
---
- **Paragraph**
  Paragraphs in Markdown are just one or more lines of consecutive text followed by one or more blank lines.
  
  ```
  On July 2, an alien ship entered Earth's orbit and deployed several dozen saucer-shaped "destroyer" spacecraft, each 15 miles (24 km) wide.
  
  On July 3, the Black Knights, a squadron of Marine Corps F/A-18 Hornets, participated 
  ```
  
- **Headings**  
  You can either you header dropdown list provided in the authoring toolbar, or manually add '---' or '===' in the     next line under your section title. You can also create a heading by adding one or more `#` symbols before your     heading text. The number of `#` you use will determine the size of the heading.

  ```
  ## The second largest heading (an <h2> tag)
  …
  ###### The 6th largest heading (an <h6> tag)
  ```

- **Block quotes**
  You can indicate block quotes with a `>`.
  ```
  In the words of Abraham Lincoln:
  
  > Pardon my French
  > Second line of the quote
  ```

- **Styling text**
  You can make your text **Bold** or *italic*
  ```
  **This text will be bold**
  *This text will be italic*  
  ```
  You can also use authoring toolbar to achieve this

- **Lists**
  You can add an unordered list by preceding list items with `*` or `-`
  ```
  * Item
  * Item
  * Item
  
  - Item
  - Item
  - Item  
  ```
  You can add ordered list by preceding list items with a number
  ```
  1. Item 1
  2. Item 2
  3. Item 3  
  ```
  You can create nested lists by indenting list items by two spaces.
  ```
  1. Item 1
    1. A corollary to the above item.
    2. Yet another point to consider.
  2. Item 2
    * A corollary that does not need to be ordered.
      * This is indented four spaces, because it's two spaces further than the item above.
      * You might want to consider making a new list.
  3. Item 3 
  ```
  You can also use authoring toolbar to achieve this
  
- **Code formatting**
  You can use triple ticks (```) to format text as its own distinct block.
  Check out this neat program I wrote:  
  ~~~~
  ```
  x = 0
  x = 2 + 2
  what is x
  ```
  ~~~~

Add Reference to your content
---
- **Insert Links**
  You can create an inline link by wrapping link text in brackets `[Link Label]`, and then wrapping the link in    parentheses `(http://URL)`. 
  [Bing.com](http://www.bing.com)
  
  You can also create a link to an existing topic in CAPS with the authoring toolbar
  
- **Insert Image**
  You can reference a online image from external resource by using `![Image Label]`, and then wrapping the image resource url in parentheses `(http://ImageURL)`
  
  You can also insert an image from CAPS with the authoring toolbar


Using tables in your content
---
You can create tables by assembling a list of words and dividing them with hyphens - (for the first row), and then separating each column with a pipe |:

First Header  | Second Header
------------- | -------------
Content Cell  | Content Cell
Content Cell  | Content Cell

You can also include inline Markdown format syntax such as links, bold, italics, or strike through:

| Name | Description          |
| ------------- | ----------- |
| Help      | ~~Display the~~ help window.|
| Close     | _Closes_ a window     |

You can have more formatting control by including colons : within the header row, you can define text to be left-aligned, right-aligned, or center-aligned:

| Left-Aligned  | Center Aligned  | Right Aligned |
| :------------ |:---------------:| -----:|
| col 3 is      | some wordy text | $1600 |
| col 2 is      | centered        |   $12 |
| zebra stripes | are neat        |    $1 |

A colon on the **left-most** side indicates a left-aligned column; a colon on the **right-most** side indicates a right-aligned column; a colon on **both** sides indicates a center-aligned column.


HTML
---
You can use a subset of HTML within your content. 
A full list of our supported tags and attributes can be found [here](https://github.com/github/markup/tree/master#html-sanitization)


  
