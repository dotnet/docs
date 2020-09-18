---
title: Mixed Minimum Rules rule set
ms.date: 11/04/2016
ms.topic: reference
ms.assetid: bc8df61c-19af-40ab-a871-315807e5f4bf
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- multiple
---
# Mixed Minimum Rules rule set

The Microsoft Mixed Minimum Rules focus on the most critical problems in C++ projects that support the Common Language Runtime, including potential security holes and application crashes.

Include this rule set in any custom rule set you create for your C++ projects that support the Common Language Runtime.

|Rule|Description|
|----------|-----------------|
|[C6001](/cpp/code-quality/c6001)|Using Uninitialized Memory|
|[C6011](/cpp/code-quality/c6011)|Dereferencing Null Pointer|
|[C6029](/cpp/code-quality/c6029)|Use Of Unchecked Value|
|[C6053](/cpp/code-quality/c6053)|Zero Termination From Call|
|[C6059](/cpp/code-quality/c6059)|Bad Concatenation|
|[C6063](/cpp/code-quality/c6063)|Missing String Argument To Format Function|
|[C6064](/cpp/code-quality/c6064)|Missing Integer Argument To Format Function|
|[C6066](/cpp/code-quality/c6066)|Missing Pointer Argument To Format Function|
|[C6067](/cpp/code-quality/c6067)|Missing String Pointer Argument To Format Function|
|[C6101](/cpp/code-quality/c6101)|Returning uninitialized memory|
|[C6200](/cpp/code-quality/c6200)|Index Exceeds Buffer Maximum|
|[C6201](/cpp/code-quality/c6201)|Index Exceeds Stack Buffer Maximum|
|[C6270](/cpp/code-quality/c6270)|Missing Float Argument To Format Function|
|[C6271](/cpp/code-quality/c6271)|Extra Argument To Format Function|
|[C6272](/cpp/code-quality/c6272)|Non-Float Argument To Format Function|
|[C6273](/cpp/code-quality/c6273)|Non-Integer Argument To Format Function|
|[C6274](/cpp/code-quality/c6274)|Non-Character Argument To Format Function|
|[C6276](/cpp/code-quality/c6276)|Invalid String Cast|
|[C6277](/cpp/code-quality/c6277)|Invalid CreateProcess Call|
|[C6284](/cpp/code-quality/c6284)|Invalid Object Argument To Format Function|
|[C6290](/cpp/code-quality/c6290)|Logical-Not Bitwise-And Precedence|
|[C6291](/cpp/code-quality/c6291)|Logical-Not Bitwise-Or Precedence|
|[C6302](/cpp/code-quality/c6302)|Invalid Character String Argument To Format Function|
|[C6303](/cpp/code-quality/c6303)|Invalid Wide Character String Argument To Format Function|
|[C6305](/cpp/code-quality/c6305)|Mismatched Size And Count Use|
|[C6306](/cpp/code-quality/c6306)|Incorrect Variable Argument Function Call|
|[C6328](/cpp/code-quality/c6328)|Potential Argument Type Mismatch|
|[C6385](/cpp/code-quality/c6385)|Read Overrun|
|[C6386](/cpp/code-quality/c6386)|Write Overrun|
|[C6387](/cpp/code-quality/c6387)|Invalid Parameter Value|
|[C6500](/cpp/code-quality/c6500)|Invalid Attribute Property|
|[C6501](/cpp/code-quality/c6501)|Conflicting Attribute Property Values|
|[C6503](/cpp/code-quality/c6503)|References Cannot Be Null|
|[C6504](/cpp/code-quality/c6504)|Null On Non-Pointer|
|[C6505](/cpp/code-quality/c6505)|MustCheck On Void|
|[C6506](/cpp/code-quality/c6506)|Buffer Size On Non-Pointer Or Array|
|[C6508](/cpp/code-quality/c6508)|Write Access On Constant|
|[C6509](/cpp/code-quality/c6509)|Return Used On Precondition|
|[C6510](/cpp/code-quality/c6510)|Null Terminated On Non-Pointer|
|[C6511](/cpp/code-quality/c6511)|MustCheck Must Be Yes Or No|
|[C6513](/cpp/code-quality/c6513)|Element Size Without Buffer Size|
|[C6514](/cpp/code-quality/c6514)|Buffer Size Exceeds Array Size|
|[C6515](/cpp/code-quality/c6515)|Buffer Size On Non-Pointer|
|[C6516](/cpp/code-quality/c6516)|No Properties On Attribute|
|[C6517](/cpp/code-quality/c6517)|Valid Size On Non-Readable Buffer|
|[C6518](/cpp/code-quality/c6518)|Writable Size On Non-Writable Buffer|
|[C6522](/cpp/code-quality/c6522)|Invalid Size String Type|
|[C6525](/cpp/code-quality/c6525)|Invalid Size String Unreachable Location|
|[C6527](/cpp/code-quality/c6527)|Invalid annotation: 'NeedsRelease' property may not be used on values of void type|
|[C6530](/cpp/code-quality/c6530)|Unrecognized Format String Style|
|[C6540](/cpp/code-quality/c6540)|The use of attribute annotations on this function will invalidate all of its existing __declspec annotations|
|[C6551](/cpp/code-quality/c6551)|Invalid size specification: expression not parsable|
|[C6552](/cpp/code-quality/c6552)|Invalid Deref= or Notref=: expression not parsable|
|[C6701](/cpp/code-quality/c6701)|The value is not a valid Yes/No/Maybe value|
|[C6702](/cpp/code-quality/c6702)|The value is not a string value|
|[C6703](/cpp/code-quality/c6703)|The value is not a number|
|[C6704](/cpp/code-quality/c6704)|Unexpected Annotation Expression Error|
|[C6705](/cpp/code-quality/c6705)|Expected number of arguments for annotation does not match actual number of arguments for annotation|
|[C6706](/cpp/code-quality/c6706)|Unexpected Annotation Error for annotation|
|[C28021](/cpp/code-quality/c28021)|The parameter being annotated must be a pointer|
|[C28182](/cpp/code-quality/c28182)|Dereferencing NULL pointer. The pointer contains the same NULL value as another pointer did.|
|[C28202](/cpp/code-quality/c28202)|Illegal reference to non-static member|
|[C28203](/cpp/code-quality/c28203)|Ambiguous reference to class member.|
|[C28205](/cpp/code-quality/c28205)|\_Success\_ or \_On\_failure\_ used in an illegal context|
|[C28206](/cpp/code-quality/c28206)|Left operand points to a struct, use '->'|
|[C28207](/cpp/code-quality/c28207)|Left operand is a struct, use '.'|
|[C28210](/cpp/code-quality/c28210)|Annotations for the __on_failure context must not be in explicit pre context|
|[C28211](/cpp/code-quality/c28211)|Static context name expected for SAL_context|
|[C28212](/cpp/code-quality/c28212)|Pointer expression expected for annotation|
|[C28213](/cpp/code-quality/c28213)|The \_Use\_decl\_annotations\_ annotation must be used to reference, without modification, a prior declaration.|
|[C28214](/cpp/code-quality/c28214)|Attribute parameter names must be p1...p9|
|[C28215](/cpp/code-quality/c28215)|The typefix cannot be applied to a parameter that already has a typefix|
|[C28216](/cpp/code-quality/c28216)|The checkReturn annotation only applies to postconditions for the specific function parameter.|
|[C28217](/cpp/code-quality/c28217)|For function, the number of parameters to annotation does not match that found at file|
|[C28218](/cpp/code-quality/c28218)|For function parameter, the annotation's parameter does not match that found at file|
|[C28219](/cpp/code-quality/c28219)|Member of enumeration expected for annotation the parameter in the annotation|
|[C28220](/cpp/code-quality/c28220)|Integer expression expected for annotation the parameter in the annotation|
|[C28221](/cpp/code-quality/c28221)|String expression expected for the parameter in the annotation|
|[C28222](/cpp/code-quality/c28222)|__yes, \__no, or \__maybe expected for annotation|
|[C28223](/cpp/code-quality/c28223)|Did not find expected Token/identifier for annotation, parameter|
|[C28224](/cpp/code-quality/c28224)|Annotation requires parameters|
|[C28225](/cpp/code-quality/c28225)|Did not find the correct number of required parameters in annotation|
|[C28226](/cpp/code-quality/c28226)|Annotation cannot also be a PrimOp (in current declaration)|
|[C28227](/cpp/code-quality/c28227)|Annotation cannot also be a PrimOp (see prior declaration)|
|[C28228](/cpp/code-quality/c28228)|Annotation parameter: cannot use type in annotations|
|[C28229](/cpp/code-quality/c28229)|Annotation does not support parameters|
|[C28230](/cpp/code-quality/c28230)|The type of parameter has no member.|
|[C28231](/cpp/code-quality/c28231)|Annotation is only valid on array|
|[C28232](/cpp/code-quality/c28232)|pre, post, or deref not applied to any annotation|
|[C28233](/cpp/code-quality/c28233)|pre, post, or deref applied to a block|
|[C28234](/cpp/code-quality/c28234)|__at expression does not apply to current function|
|[C28235](/cpp/code-quality/c28235)|The function cannot stand alone as an annotation|
|[C28236](/cpp/code-quality/c28236)|The annotation cannot be used in an expression|
|[C28237](/cpp/code-quality/c28237)|The annotation on parameter is no longer supported|
|[C28238](/cpp/code-quality/c28238)|The annotation on parameter has more than one of value, stringValue, and longValue. Use paramn=xxx|
|[C28239](/cpp/code-quality/c28239)|The annotation on parameter has both value, stringValue, or longValue; and paramn=xxx. Use only paramn=xxx|
|[C28240](/cpp/code-quality/c28240)|The annotation on parameter has param2 but no param1|
|[C28241](/cpp/code-quality/c28241)|The annotation for function on parameter is not recognized|
|[C28243](/cpp/code-quality/c28243)|The annotation for function on parameter requires more dereferences than the actual type annotated allows|
|[C28245](/cpp/code-quality/c28245)|The annotation for function annotates 'this' on a non-member-function|
|[C28246](/cpp/code-quality/c28246)|The parameter annotation for function does not match the type of the parameter|
|[C28250](/cpp/code-quality/c28250)|Inconsistent annotation for function: the prior instance has an error.|
|[C28251](/cpp/code-quality/c28251)|Inconsistent annotation for function: this instance has an error.|
|[C28252](/cpp/code-quality/c28252)|Inconsistent annotation for function: parameter has another annotations on this instance.|
|[C28253](/cpp/code-quality/c28253)|Inconsistent annotation for function: parameter has another annotations on this instance.|
|[C28254](/cpp/code-quality/c28254)|dynamic_cast<>() is not supported in annotations|
|[C28262](/cpp/code-quality/c28262)|A syntax error in the annotation was found in function, for annotation|
|[C28263](/cpp/code-quality/c28263)|A syntax error in a conditional annotation was found for Intrinsic annotation|
|[C28267](/cpp/code-quality/c28267)|A syntax error in the annotations was found annotation in the function.|
|[C28272](/cpp/code-quality/c28272)|The annotation for function, parameter when examining is inconsistent with the function declaration|
|[C28273](/cpp/code-quality/c28273)|For function, the clues are inconsistent with the function declaration|
|[C28275](/cpp/code-quality/c28275)|The parameter to \_Macro\_value\_ is null|
|[C28279](/cpp/code-quality/c28279)|For symbol, a 'begin' was found without a matching 'end'|
|[C28280](/cpp/code-quality/c28280)|For symbol, an 'end' was found without a matching 'begin'|
|[C28282](/cpp/code-quality/c28282)|Format Strings must be in preconditions|
|[C28285](/cpp/code-quality/c28285)|For function, syntax error in parameter|
|[C28286](/cpp/code-quality/c28286)|For function, syntax error near the end|
|[C28287](/cpp/code-quality/c28287)|For function, syntax Error in \_At\_() annotation (unrecognized parameter name)|
|[C28288](/cpp/code-quality/c28288)|For function, syntax Error in \_At\_() annotation (invalid parameter name)|
|[C28289](/cpp/code-quality/c28289)|For function: ReadableTo or WritableTo did not have a limit-spec as a parameter|
|[C28290](/cpp/code-quality/c28290)|the annotation for function contains more Externals than the actual number of parameters|
|[C28291](/cpp/code-quality/c28291)|post null/notnull at deref level 0 is meaningless for function.|
|[C28300](/cpp/code-quality/c28300)|Expression operands of incompatible types for operator|
|[C28301](/cpp/code-quality/c28301)|No annotations for first declaration of function.|
|[C28302](/cpp/code-quality/c28302)|An extra \_Deref\_ operator was found on annotation.|
|[C28303](/cpp/code-quality/c28303)|An ambiguous \_Deref\_ operator was found on annotation.|
|[C28304](/cpp/code-quality/c28304)|An improperly placed \_Notref\_ operator was found applied to token.|
|[C28305](/cpp/code-quality/c28305)|An error while parsing a token was discovered.|
|[C28350](/cpp/code-quality/c28350)|The annotation describes a situation that is not conditionally applicable.|
|[C28351](/cpp/code-quality/c28351)|The annotation describes where a dynamic value (a variable) cannot be used in the condition.|
|[CA1001](../code-quality/ca1001.md)|Types that own disposable fields should be disposable|
|[CA1821](../code-quality/ca1821.md)|Remove empty finalizers|
|[CA2213](../code-quality/ca2213.md)|Disposable fields should be disposed|
|[CA2231](../code-quality/ca2231.md)|Overload operator equals on overriding ValueType.Equals|