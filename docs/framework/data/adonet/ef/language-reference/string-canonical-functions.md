---
title: "String Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5e2cbebd-5df3-47c7-b0e2-49a17ab22bfb
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# String Canonical Functions
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] includes string canonical functions.  
  
## Remarks  
 The following table shows the string [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
|Function|Description|  
|--------------|-----------------|  
|`Concat (` `string1`, `string2``)`|Returns a string that contains `string2` appended to `string1`.<br /><br /> **Arguments**<br /><br /> `string1`: The string to which `string2` is appended.<br /><br /> `string2`: The string that is appended to `string1`.<br /><br /> **Return Value**<br /><br /> A `String`. An error will occur if the length of the return value string is greater than the maximum length allowed.<br /><br /> **Example**<br /><br /> `-- The following example returns abcxyz.`<br /><br /> `Concat('abc', 'xyz')`|  
|`Contains (` `string`, `target``)`|Returns `true` if `target` is contained in `string`.<br /><br /> **Arguments**<br /><br /> `string`: The string that is searched.<br /><br /> `target`: The target string that is searched for.<br /><br /> **Return Value**<br /><br /> `true` if `target` is contained in `string`; otherwise `false`.<br /><br /> **Example**<br /><br /> `-- The following example returns true.`<br /><br /> `Contains('abc', 'bc')`|  
|`EndsWith (` `string`, `target``)`|Returns `true` if `target` ends with `string`.<br /><br /> **Arguments**<br /><br /> `string`: The string that is searched.<br /><br /> `target`: The target string searched for at the end of `string`.<br /><br /> **Return Value**<br /><br /> `True` if `string` ends with `target`; otherwise `false`.<br /><br /> **Example**<br /><br /> `-- The following example returns true.`<br /><br /> `EndsWith('abc', 'bc')` **Note:**  If you are using the [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] data provider, this function returns `false` if the string is stored in a fixed length string column and `target` is a constant. In this case, the entire string is searched, including any padding trailing spaces. A possible workaround is to trim the data in the fixed length string, as in the following example: `EndsWith(TRIM(string), target)`|  
|`IndexOf(` `target`, `string``)`|Returns the position of `target` inside `string`, or 0 if not found. Returns 1 to indicate the beginning of `string`. Index numbering starts from 1.<br /><br /> **Arguments**<br /><br /> `target`: The string that is searched for.<br /><br /> `string`: The string that is searched.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 4.`<br /><br /> `IndexOf('xyz', 'abcxyz')`|  
|`Left (` `string`, `length``)`|Returns the first `length` characters from the left side of `string`. If the length of `string` is less than `length`, the entire string is returned.<br /><br /> **Arguments**<br /><br /> `string`: A `String`.<br /><br /> `length`: An `Int16`, `Int32`, `Int64`, or `Byte`. `length` cannot be less than zero.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns abc.`<br /><br /> `Left('abcxyz', 3)`|  
|`Length (` `string` `)`|Returns the (`Int32`) length, in characters, of the string.<br /><br /> **Arguments**<br /><br /> `string`: A `String`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 6.`<br /><br /> `Legth('abcxyz')`|  
|`LTrim(` `string` `)`|Returns `string` without leading whitespace.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns abc.`<br /><br /> `LTrim('   abc')`|  
|`Replace (` `string1`, `string2`, `string3``)`|Returns `string1`, with all occurrences of `string2` replaced by `string3`.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns abcxyz.`<br /><br /> `Concat('abc', 'xyz')`|  
|`Reverse (` `string` `)`|Returns `string` with the order of the characters reversed.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns dcba.`<br /><br /> `Reverse('abcd')`|  
|`Right (` `string`, `length``)`|Returns the last `length` characters from the `string`. If the length of `string` is less than `length`, the entire string is returned.<br /><br /> **Arguments**<br /><br /> `string`: A `String`.<br /><br /> `length`: An `Int16`, `Int32`, `Int64`, or `Byte`. `length` cannot be less than zero.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns xyz.`<br /><br /> `Right('abcxyz', 3)`|  
|`RTrim(` `string` `)`|Returns `string` without trailing whitespace.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.|  
|`Substring (` `string`, `start`, `length``)`|Returns the substring of the string starting at position `start`, with a length of `length` characters. A start of 1 indicates the first character of the string. Index numbering starts from 1.<br /><br /> **Arguments**<br /><br /> `string`: A `String`.<br /><br /> `start`: An `Int16`, `Int32`, `Int64` and `Byte`. `start` cannot be less than one.<br /><br /> `length`: An `Int16`, `Int32`, `Int64` and `Byte`. `length` cannot be less than zero.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns xyz.`<br /><br /> `Substring('abcxyz', 4, 3)`|  
|`StartsWith (` `string`, `target``)`|Returns `true` if `string` starts with `target`.<br /><br /> **Arguments**<br /><br /> `string`: The string that is searched.<br /><br /> `target`: The target string searched for at the start of `string`.<br /><br /> **Return Value**<br /><br /> `True` if `string` starts with `target`; otherwise `false`.<br /><br /> **Example**<br /><br /> `-- The following example returns true.`<br /><br /> `StartsWith('abc', 'ab')`|  
|`ToLower(` `string` `)`|Returns `string` with uppercase characters converted to lowercase.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns abc.`<br /><br /> `ToLower('ABC')`|  
|`ToUpper(` `string` `)`|Returns `string` with lowercase characters converted to uppercase.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns ABC.`<br /><br /> `ToUpper('abc')`|  
|`Trim(` `string` `)`|Returns `string` without leading and trailing whitespace.<br /><br /> **Arguments**<br /><br /> A `String`.<br /><br /> **Return Value**<br /><br /> A `String`.<br /><br /> **Example**<br /><br /> `-- The following example returns abc.`<br /><br /> `Trim('      abc   ')`|  
  
 These functions will return `null` if given `null` input.  
  
 Equivalent functionality is available in the Microsoft SQL Client Managed Provider. For more information, see [SqlClient for Entity Framework Functions](../../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).  
  
## See Also  
 [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
