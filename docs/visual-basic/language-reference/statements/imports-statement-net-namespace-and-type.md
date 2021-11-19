---
description: "Learn more about: Imports Statement (.NET Namespace and Type)"
title: "Imports Statement - .NET Namespace and Type"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Imports"
  - "imports"
helpviewer_keywords: 
  - "declared element names [Visual Basic], qualification"
  - "imports [Visual Basic]"
  - "Imports statement [Visual Basic]"
  - "aliases [Visual Basic], Imports statement"
  - "container elements [Visual Basic]"
  - "namespaces [Visual Basic], importing"
  - "Imports statement [Visual Basic], syntax"
  - "import aliases [Visual Basic]"
  - "aliases [Visual Basic], import"
  - "declared elements [Visual Basic], container elements"
ms.assetid: 7062f8aa-d890-4232-9eed-92836e13fb6e
---
# Imports Statement (.NET Namespace and Type)

Enables type names to be referenced without namespace qualification.

## Syntax

```vb
Imports [ aliasname = ] namespace
' -or-
Imports [ aliasname = ] namespace.element
```

## Parts

|Term|Definition|
|---|---|
|`aliasname`|Optional. An *import alias* or name by which code can refer to `namespace` instead of the full qualification string. See [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).|
|`namespace`|Required. The fully qualified name of the namespace being imported. Can be a string of namespaces nested to any level.|
|`element`|Optional. The name of a programming element declared in the namespace. Can be any container element.|

## Remarks

The `Imports` statement enables types that are contained in a given namespace to be referenced directly.

You can supply a single namespace name or a string of nested namespaces. Each nested namespace is separated from the next higher level namespace by a period (`.`), as the following example illustrates:

```vb
Imports System.Collections.Generic
```

Each source file can contain any number of `Imports` statements. These must follow any option declarations, such as the `Option Strict` statement, and they must precede any programming element declarations, such as `Module` or `Class` statements.

You can use `Imports` only at file level. This means the declaration context for importation must be a source file, and cannot be a namespace, class, structure, module, interface, procedure, or block.

Note that the `Imports` statement does not make elements from other projects and assemblies available to your project. Importing does not take the place of setting a reference. It only removes the need to qualify names that are already available to your project. For more information, see "Importing Containing Elements" in [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md).

> [!NOTE]
> You can define implicit `Imports` statements by using the [References Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/references-page-project-designer-visual-basic). For more information, see [How to: Add or Remove Imported Namespaces (Visual Basic)](/visualstudio/ide/how-to-add-or-remove-imported-namespaces-visual-basic).

## Import Aliases

An *import alias* defines the alias for a namespace or type. Import aliases are useful when you need to use items with the same name that are declared in one or more namespaces. For more information and an example, see "Qualifying an Element Name" in [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md).

You should not declare a member at module level with the same name as `aliasname`. If you do, the Visual Basic compiler uses `aliasname` only for the declared member and no longer recognizes it as an import alias.

Although the syntax used for declaring an import alias is like that used for importing an XML namespace prefix, the results are different. An import alias can be used as an expression in your code, whereas an XML namespace prefix can be used only in XML literals or XML axis properties as the prefix for a qualified element or attribute name.

### Element Names

If you supply `element`, it must represent a *container element*, that is, a programming element that can contain other elements. Container elements include classes, structures, modules, interfaces, and enumerations.

The scope of the elements made available by an `Imports` statement depends on whether you specify `element`. If you specify only `namespace`, all uniquely named members of that namespace, and members of container elements within that namespace, are available without qualification. If you specify both `namespace` and `element`, only the members of that element are available without qualification.

## Example 1

The following example returns all the folders in the *C:\\* directory by using the <xref:System.IO.DirectoryInfo> class:

The code has no `Imports` statements at the top of the file. Therefore, the <xref:System.IO.DirectoryInfo>, <xref:System.Text.StringBuilder>, and <xref:Microsoft.VisualBasic.ControlChars.CrLf> references are all fully qualified with the namespaces.

[!code-vb[VbVbalrStatements#152](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#152)]

## Example 2

The following example includes `Imports` statements for the referenced namespaces. Therefore, the types do not have to be fully qualified with the namespaces.

[!code-vb[VbVbalrStatements#153](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#153)]

[!code-vb[VbVbalrStatements#154](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#154)]
  
## Example 3

The following example includes `Imports` statements that create aliases for the referenced namespaces. The types are qualified with the aliases.

[!code-vb[VbVbalrStatements#155](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#155)]

[!code-vb[VbVbalrStatements#156](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#156)]

## Example 4

The following example includes `Imports` statements that create aliases for the referenced types. Aliases are used to specify the types.

[!code-vb[VbVbalrStatements#157](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#157)]

[!code-vb[VbVbalrStatements#158](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/class12.vb#158)]
  
## See also

- [Namespace Statement](namespace-statement.md)
- [Namespaces in Visual Basic](../../programming-guide/program-structure/namespaces.md)
- [References and the Imports Statement](../../programming-guide/program-structure/references-and-the-imports-statement.md)
- [Imports Statement (XML Namespace)](imports-statement-xml-namespace.md)
- [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md)
