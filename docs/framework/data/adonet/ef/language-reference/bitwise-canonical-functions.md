---
description: "Learn more about: Bitwise Canonical Functions"
title: "Bitwise Canonical Functions"
ms.date: "03/30/2017"
ms.assetid: 993868ca-16e3-47b6-9915-c29cd63b0a21
---
# Bitwise Canonical Functions

Entity SQL includes bitwise canonical functions.

## Remarks

 The following table shows the bitwise Entity SQL canonical functions. These functions will return `Null` if `Null` input is provided. The return type of the functions is the same as the argument type(s). Arguments must be of the same type, if the function takes more than one argument. To perform bitwise operations across different types, you need to cast to the same type explicitly.

|Function|Description|
|--------------|-----------------|
|`BitWiseAnd (` `value1` `,`  `value2` `)`|Returns the bitwise conjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32`, and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 1.`<br /><br /> `BitWiseAnd(1,3)`|
|`BitWiseNot (` `value` `)`|Returns the bitwise negation of `value`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32`, and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns -4.`<br /><br /> `BitWiseNot(3)`|
|`BitWiseOr (` `value1` `,`  `value2` `)`|Returns the bitwise disjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32` and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 3.`<br /><br /> `BitWiseOr(1,3)`|
|`BitWiseXor (` `value1` `,`  `value2` `)`|Returns the bitwise exclusive disjunction of `value1` and `value2` as the type of `value1` and `value2`.<br /><br /> **Arguments**<br /><br /> A `Byte`, `Int16`, `Int32` and `Int64`.<br /><br /> **Example**<br /><br /> `-- The following example returns 2.`<br /><br /> `BitWiseXor (1,3)`|

## See also

- [Canonical Functions](canonical-functions.md)
