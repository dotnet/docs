---
description: "Learn more about: Attribute List (Visual Basic)"
title: "Attribute List"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "attribute list"
  - "attributes [Visual Basic], applying"
ms.assetid: 5880073a-68a4-4b6b-8a07-ace32959a4e2
---
# Attribute List (Visual Basic)

Specifies the attributes to be applied to a declared programming element. Multiple attributes are separated by commas. Following is the syntax for one attribute.  
  
## Syntax  
  
```vb  
[ attributemodifier ] attributename [ ( attributearguments | attributeinitializer ) ]  
```  
  
## Parts  

| Part                   | Description                                                                                                                                                 |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `attributemodifier`    | Required for attributes applied at the beginning of a source file. Can be [Assembly](../modifiers/assembly.md) or [Module](../modifiers/module-keyword.md). |
| `attributename`        | Required. Name of the attribute.                                                                                                                            |
| `attributearguments`   | Optional. List of positional arguments for this attribute. Multiple arguments are separated by commas.                                                      |
| `attributeinitializer` | Optional. List of variable or property initializers for this attribute. Multiple initializers are separated by commas.                                      |
  
## Remarks  

 You can apply one or more attributes to nearly any programming element (types, procedures, properties, and so forth). Attributes appear in your assembly's metadata, and they can help you annotate your code or specify how to use a particular programming element. You can apply attributes defined by Visual Basic and the .NET Framework, and you can define your own attributes.  

 For more information on when to use attributes, see [Attributes overview](../../programming-guide/concepts/attributes/index.md). For information on attribute names, see [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).  
  
## Rules  
  
- **Placement.** You can apply attributes to most declared programming elements. To apply one or more attributes, you place an *attribute block* at the beginning of the element declaration. Each entry in the attribute list specifies an attribute you wish to apply, and the modifier and arguments you are using for this invocation of the attribute.  
  
- **Angle Brackets.** If you supply an attribute list, you must enclose it in angle brackets ("`<`" and "`>`").  
  
- **Part of the Declaration.** The attribute must be part of the element declaration, not a separate statement. You can use the line-continuation sequence (" `_`") to extend the declaration statement onto multiple source-code lines.  
  
- **Modifiers.** An attribute modifier (`Assembly` or `Module`) is required on every attribute applied to a programming element at the beginning of a source file. Attribute modifiers are not allowed on attributes applied to elements that are not at the beginning of a source file.  
  
- **Arguments.** All positional arguments for an attribute must precede any variable or property initializers.  
  
## Example  

 The following example applies the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute to a skeleton definition of a `Function` procedure.  
  
 [!code-vb[VbVbalrStatements#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#1)]  
  
 <xref:System.Runtime.InteropServices.DllImportAttribute> indicates that the attributed procedure represents an entry point in an unmanaged dynamic-link library (DLL). The attribute supplies the DLL name as a positional argument and the other information as variable initializers.  
  
## See also

- [Assembly](../modifiers/assembly.md)
- [Module \<keyword>](../modifiers/module-keyword.md)
- [Attributes overview](../../programming-guide/concepts/attributes/index.md)
- [How to: Break and Combine Statements in Code](../../programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md)
