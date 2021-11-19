---
description: "Learn more about: Function Overload Resolution (Entity SQL)"
title: "Function Overload Resolution (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 9c648054-3808-4a69-9d3e-98e6a4f9c5ca
---
# Function Overload Resolution (Entity SQL)

This topic describes how Entity SQL functions are resolved.

 More than one function can be defined with the same name, as long as the functions have unique signatures.

 When this is the case, the following criteria must be applied to determine which function is referenced by a given expression. These criteria are applied in sequence. The first criterion that applies only to a single function is the resolved function.

1. **Parameter number**. The function has the same number of parameters specified in the expression.

2. **Exact match on type**. Each argument type of the function exactly matches the parameter type, or is the null literal.

3. **Match on subtype**. Each argument type of the function exactly matches or is a sub-type of the parameter type, or the argument is the null literal. In the event that several functions differ only in the number of sub-type conversions required, the function with the least number of sub-type conversions is the resolved function.

4. **Match on subtype or type promotion**. Each argument type of the function exactly matches, is a sub-type of, or can be promoted to the parameter type, or the argument is the null literal. Again, in the event that several functions differ only in the number of sub-type conversions and promotions, the function with the least number of sub-type conversions and promotions is the resolved function.

 If none of these criteria result in a single function being selected, the function invocation expression is ambiguous.

 Even if a single function can be extracted using these rules, the arguments still might not match the parameters. An error is raised in this case.

 For user-defined functions, the definition for an inline query function takes precedence even when a model-defined function exists with a signature that is a better match for the user-defined function.

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Overview](entity-sql-overview.md)
- [Functions](functions-entity-sql.md)
