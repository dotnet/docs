---
description: "Learn more about the <disableStackOverflowProbing> element"
title: "<disableStackOverflowProbing> Element"
ms.date: 04/20/2022
---
# \<disableStackOverflowProbing> Element

Specifies whether stack-overflow probing is disabled.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<disableStackOverflowProbing>**

## Syntax

```xml
<disableStackOverflowProbing enabled="true"|"false" />
```

## Attribute

| Attribute | Description                                                                          |
|-----------|--------------------------------------------------------------------------------------|
| `enabled` | Required attribute.<br /><br />Specifies whether stack-overflow probing is disabled. |

### enabled Attribute

| Value | Description                         |
|-------|-------------------------------------|
| true  | Stack-overflow probing is enabled.  |
| false | Stack-overflow probing is disabled. |

### Parent Elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|`runtime`|Contains information about runtime initialization options.|

## Remarks

The `<disableStackOverflowProbing>` specifies whether stack-overflow probing is disabled. If you specify a very small stack size when constructing a <xref:System.Threading.Thread> by calling <xref:System.Threading.Thread.%23ctor(System.Threading.ParameterizedThreadStart,System.Int32)>, you might need to disable stack-overflow probing. When the stack is severely constrained, the probing can itself cause a stack overflow.

## See also

- [Configure apps by using configuration files](../../index.md)
- [\<runtime> Element](runtime-element.md)
- [\<configuration> Element](../configuration-element.md)
