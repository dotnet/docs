---
description: "Learn more about: Overload Resolution (Visual Basic)"
title: "Overload Resolution"
ms.date: 01/31/2025
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "overload resolution"
  - "procedures [Visual Basic], overloading"
  - "procedures [Visual Basic], calling"
  - "procedure overloading [Visual Basic], overload resolution"
  - "signatures [Visual Basic], procedure"
  - "overloads [Visual Basic], resolution"
---
# Overload resolution (Visual Basic)

The Visual Basic compiler must decide which overload to call when a procedure is defined in several overloaded versions. It decides by performing the following steps:

1. **Accessibility.** It eliminates any overload with an access level that prevents the calling code from calling it.
1. **Number of Parameters.** It eliminates any overload that defines a different number of parameters than are supplied in the call.
1. **Parameter Data Types.** The compiler gives instance methods preference over extension methods. If any instance method is found that requires only widening conversions to match the procedure call, all extension methods are dropped. The compiler continues with only the instance method candidates. If no such instance method is found, it continues with both instance and extension methods.
   In this step, it eliminates any overload for which the data types of the calling arguments can't be converted to the parameter types defined in the overload.
1. **Narrowing Conversions.** It eliminates any overload that requires a narrowing conversion from the calling argument types to the defined parameter types. This step takes place whether the type checking switch ([Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)) is `On` or `Off`.
1. **Least Widening.** The compiler considers the remaining overloads in pairs. For each pair, it compares the data types of the defined parameters. If the types in one of the overloads all widen to the corresponding types in the other, the compiler eliminates the latter. That is, it retains the overload that requires the least amount of widening.
1. **Overload Resolution Priority.** The compiler removes any overload that has a lower <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute> than the highest value on any candidate overloads. Any overload without this attribute is assigned the default value of zero.
1. **Single Candidate.** It continues considering overloads in pairs until only one overload remains, and it resolves the call to that overload. If the compiler can't reduce the overloads to a single candidate, it generates an error.

The following illustration shows the process that determines which of a set of overloaded versions to call.

:::image type="content" source="./media/overload-resolution/determine-overloaded-version.gif" alt-text="Flow diagram of overload resolution process":::

The following example illustrates this overload resolution process.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb" id="Snippet62":::

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb" id="Snippet63":::

In the first call, the compiler eliminates the first overload because the type of the first argument (`Short`) narrows to the type of the corresponding parameter (`Byte`). It then eliminates the third overload because each argument type in the second overload (`Short` and `Single`) widens to the corresponding type in the third overload (`Integer` and `Single`). The second overload requires less widening, so the compiler uses it for the call.

In the second call, the compiler can't eliminate any of the overloads based on narrowing. It eliminates the third overload for the same reason as in the first call, because it can call the second overload with less widening of the argument types. However, the compiler can't resolve between the first and second overloads. Each has one defined parameter type that widens to the corresponding type in the other (`Byte` to `Short`, but `Single` to `Double`). The compiler therefore generates an overload resolution error.

## Overloaded `Optional` and `ParamArray` arguments

If two overloads of a procedure have identical signatures except that the last parameter is declared [Optional](../../../language-reference/modifiers/optional.md) in one and [ParamArray](../../../language-reference/modifiers/paramarray.md) in the other, the compiler resolves a call to that procedure as follows:

|If the call supplies the last argument as|The compiler resolves the call to the overload declaring the last argument as|
|---|---|
|No value (argument omitted)|`Optional`|
|A single value|`Optional`|
|Two or more values in a comma-separated list|`ParamArray`|
|An array of any length (including an empty array)|`ParamArray`|

## See also

- [Optional Parameters](./optional-parameters.md)
- [Parameter Arrays](./parameter-arrays.md)
- [Procedure Overloading](./procedure-overloading.md)
- [Troubleshooting Procedures](./troubleshooting-procedures.md)
- [How to: Define Multiple Versions of a Procedure](./how-to-define-multiple-versions-of-a-procedure.md)
- [How to: Call an Overloaded Procedure](./how-to-call-an-overloaded-procedure.md)
- [How to: Overload a Procedure that Takes Optional Parameters](./how-to-overload-a-procedure-that-takes-optional-parameters.md)
- [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](./how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)
- [Considerations in Overloading Procedures](./considerations-in-overloading-procedures.md)
- [Overloads](../../../language-reference/modifiers/overloads.md)
- [Extension Methods](./extension-methods.md)
