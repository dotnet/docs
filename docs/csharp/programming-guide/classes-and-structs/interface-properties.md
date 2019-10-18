---
title: "Interface Properties - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "properties [C#], on interfaces"
  - "interfaces [C#], properties"
ms.assetid: 6503e9ed-33d7-44ec-b4c1-cc16c084b795
---
# Interface Properties (C# Programming Guide)

Properties can be declared on an [interface](../../language-reference/keywords/interface.md). The following is an example of an interface property accessor:

[!code-csharp[csProgGuideProperties#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#14)]

The accessor of an interface property does not have a body. Thus, the purpose of the accessors is to indicate whether the property is read-write, read-only, or write-only.

## Example

In this example, the interface `IEmployee` has a read-write property, `Name`, and a read-only property, `Counter`. The class `Employee` implements the `IEmployee` interface and uses these two properties. The program reads the name of a new employee and the current number of employees and displays the employee name and the computed employee number.

You could use the fully qualified name of the property, which references the interface in which the member is declared. For example:

[!code-csharp[csProgGuideProperties#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#16)]

This is called [Explicit Interface Implementation](../interfaces/explicit-interface-implementation.md). For example, if the class `Employee` is implementing two interfaces `ICitizen` and `IEmployee` and both interfaces have the `Name` property, the explicit interface member implementation will be necessary. That is, the following property declaration:

[!code-csharp[csProgGuideProperties#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#16)]

implements the `Name` property on the `IEmployee` interface, while the following declaration:

[!code-csharp[csProgGuideProperties#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#17)]

implements the `Name` property on the `ICitizen` interface.

[!code-csharp[csProgGuideProperties#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#15)]

**`210 Hazem Abolrous`**

## Sample output

```console
Enter number of employees: 210
Enter the name of the new employee: Hazem Abolrous
The employee information:
Employee number: 211
Employee name: Hazem Abolrous
```

## See also

- [C# Programming Guide](../index.md)
- [Properties](./properties.md)
- [Using Properties](./using-properties.md)
- [Comparison Between Properties and Indexers](../indexers/comparison-between-properties-and-indexers.md)
- [Indexers](../indexers/index.md)
- [Interfaces](../interfaces/index.md)
