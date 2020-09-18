---
title: Mixed Recommended Rules rule set
ms.date: 11/04/2016
ms.topic: reference
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- multiple
---
# Mixed Recommended Rules rule set

The Microsoft Mixed Recommended Rules focus on the most common and critical problems in your C++ projects that support the Common Language Runtime, including potential security holes, application crashes, and other important logic and design errors. This rule set includes all of the rules in the [Mixed Minimum Rules](mixed-minimum-rules-rule-set.md) rule set.

Include this rule set in any custom rule set you create for your C++ projects that support the Common Language Runtime.

|Rule|Description|
|----------|-----------------|
|[C6001](/cpp/code-quality/c6001)|Using Uninitialized Memory|
|[C6011](/cpp/code-quality/c6011)|Dereferencing Null Pointer|
|[C6029](/cpp/code-quality/c6029)|Use Of Unchecked Value|
|[C6031](/cpp/code-quality/c6031)|Return Value Ignored|
|[C6053](/cpp/code-quality/c6053)|Zero Termination From Call|
|[C6054](/cpp/code-quality/c6054)|Zero Termination Missing|
|[C6059](/cpp/code-quality/c6059)|Bad Concatenation|
|[C6063](/cpp/code-quality/c6063)|Missing String Argument To Format Function|
|[C6064](/cpp/code-quality/c6064)|Missing Integer Argument To Format Function|
|[C6066](/cpp/code-quality/c6066)|Missing Pointer Argument To Format Function|
|[C6067](/cpp/code-quality/c6067)|Missing String Pointer Argument To Format Function|
|[C6101](/cpp/code-quality/c6101)|Returning uninitialized memory|
|[C6200](/cpp/code-quality/c6200)|Index Exceeds Buffer Maximum|
|[C6201](/cpp/code-quality/c6201)|Index Exceeds Stack Buffer Maximum|
|[C6214](/cpp/code-quality/c6214)|Invalid Cast HRESULT To BOOL|
|[C6215](/cpp/code-quality/c6215)|Invalid Cast BOOL To HRESULT|
|[C6216](/cpp/code-quality/c6216)|Invalid Compiler-Inserted Cast BOOL To HRESULT|
|[C6217](/cpp/code-quality/c6217)|Invalid HRESULT Test With NOT|
|[C6220](/cpp/code-quality/c6220)|Invalid HRESULT Compare To -1|
|[C6226](/cpp/code-quality/c6226)|Invalid HRESULT Assignment To -1|
|[C6230](/cpp/code-quality/c6230)|Invalid HRESULT Use As Boolean|
|[C6235](/cpp/code-quality/c6235)|Non-Zero Constant With Logical-Or|
|[C6236](/cpp/code-quality/c6236)|Logical-Or With Non-Zero Constant|
|[C6237](/cpp/code-quality/c6237)|Zero With Logical-And Loses Side Effects|
|[C6242](/cpp/code-quality/c6242)|Local Unwind Forced|
|[C6248](/cpp/code-quality/c6248)|Creating Null DACL|
|[C6250](/cpp/code-quality/c6250)|Unreleased Address Descriptors|
|[C6255](/cpp/code-quality/c6255)|Unprotected Use Of Alloca|
|[C6258](/cpp/code-quality/c6258)|Using Terminate Thread|
|[C6259](/cpp/code-quality/c6259)|Dead Code In Bitwise-Or Limited Switch|
|[C6260](/cpp/code-quality/c6260)|Use Of Byte Arithmetic|
|[C6262](/cpp/code-quality/c6262)|Excessive Stack Usage|
|[C6263](/cpp/code-quality/c6263)|Using Alloca In Loop|
|[C6268](/cpp/code-quality/c6268)|Missing Parentheses In Cast|
|[C6269](/cpp/code-quality/c6269)|Pointer Dereference Ignored|
|[C6270](/cpp/code-quality/c6270)|Missing Float Argument To Format Function|
|[C6271](/cpp/code-quality/c6271)|Extra Argument To Format Function|
|[C6272](/cpp/code-quality/c6272)|Non-Float Argument To Format Function|
|[C6273](/cpp/code-quality/c6273)|Non-Integer Argument To Format Function|
|[C6274](/cpp/code-quality/c6274)|Non-Character Argument To Format Function|
|[C6276](/cpp/code-quality/c6276)|Invalid String Cast|
|[C6277](/cpp/code-quality/c6277)|Invalid CreateProcess Call|
|[C6278](/cpp/code-quality/c6278)|Array-New Scalar-Delete Mismatch|
|[C6279](/cpp/code-quality/c6279)|Scalar-New Array-Delete Mismatch|
|[C6280](/cpp/code-quality/c6280)|Memory Allocation-Deallocation Mismatch|
|[C6281](/cpp/code-quality/c6281)|Bitwise Relation Precedence|
|[C6282](/cpp/code-quality/c6282)|Assignment Replaces Test|
|[C6283](/cpp/code-quality/c6283)|Primitive Array-New Scalar-Delete Mismatch|
|[C6284](/cpp/code-quality/c6284)|Invalid Object Argument To Format Function|
|[C6285](/cpp/code-quality/c6285)|Logical-Or Of Constants|
|[C6286](/cpp/code-quality/c6286)|Non-Zero Logical-Or Losing Side Effects|
|[C6287](/cpp/code-quality/c6287)|Redundant Test|
|[C6288](/cpp/code-quality/c6288)|Mutual Inclusion Over Logical-And Is False|
|[C6289](/cpp/code-quality/c6289)|Mutual Exclusion Over Logical-Or Is True|
|[C6290](/cpp/code-quality/c6290)|Logical-Not Bitwise-And Precedence|
|[C6291](/cpp/code-quality/c6291)|Logical-Not Bitwise-Or Precedence|
|[C6292](/cpp/code-quality/c6292)|Loop Counts Up From Maximum|
|[C6293](/cpp/code-quality/c6293)|Loop Counts Down From Minimum|
|[C6294](/cpp/code-quality/c6294)|Loop Body Never Executed|
|[C6295](/cpp/code-quality/c6295)|Infinite Loop|
|[C6296](/cpp/code-quality/c6296)|Loop Only Executed Once|
|[C6297](/cpp/code-quality/c6297)|Result Of Shift Cast To Larger Size|
|[C6299](/cpp/code-quality/c6299)|Bitfield To Boolean Comparison|
|[C6302](/cpp/code-quality/c6302)|Invalid Character String Argument To Format Function|
|[C6303](/cpp/code-quality/c6303)|Invalid Wide Character String Argument To Format Function|
|[C6305](/cpp/code-quality/c6305)|Mismatched Size And Count Use|
|[C6306](/cpp/code-quality/c6306)|Incorrect Variable Argument Function Call|
|[C6308](/cpp/code-quality/c6308)|Realloc Leak|
|[C6310](/cpp/code-quality/c6310)|Illegal Exception Filter Constant|
|[C6312](/cpp/code-quality/c6312)|Exception Continue Execution Loop|
|[C6314](/cpp/code-quality/c6314)|Bitwise-Or Precedence|
|[C6317](/cpp/code-quality/c6317)|Not Not Complement|
|[C6318](/cpp/code-quality/c6318)|Exception Continue Search|
|[C6319](/cpp/code-quality/c6319)|Ignored By Comma|
|[C6324](/cpp/code-quality/c6324)|String Copy Instead Of String Compare|
|[C6328](/cpp/code-quality/c6328)|Potential Argument Type Mismatch|
|[C6331](/cpp/code-quality/c6331)|VirtualFree Invalid Flags|
|[C6332](/cpp/code-quality/c6332)|VirtualFree Invalid Parameter|
|[C6333](/cpp/code-quality/c6333)|VirtualFree Invalid Size|
|[C6335](/cpp/code-quality/c6335)|Leaking Process Handle|
|[C6381](/cpp/code-quality/c6381)|Shutdown Information Missing|
|[C6383](/cpp/code-quality/c6383)|Element-Count Byte-Count Buffer Overrun|
|[C6384](/cpp/code-quality/c6384)|Pointer Size Division|
|[C6385](/cpp/code-quality/c6385)|Read Overrun|
|[C6386](/cpp/code-quality/c6386)|Write Overrun|
|[C6387](/cpp/code-quality/c6387)|Invalid Parameter Value|
|[C6388](/cpp/code-quality/c6388)|Invalid Parameter Value|
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
|[C6995](/cpp/code-quality/c6995)|Failed to save XML Log file|
|[C26100](/cpp/code-quality/c26100)|Race condition|
|[C26101](/cpp/code-quality/c26101)|Failing to use interlocked operation properly|
|[C26110](/cpp/code-quality/c26110)|Caller failing to hold lock|
|[C26111](/cpp/code-quality/c26111)|Caller failing to release lock|
|[C26112](/cpp/code-quality/c26112)|Caller cannot hold any lock|
|[C26115](/cpp/code-quality/c26115)|Failing to release lock|
|[C26116](/cpp/code-quality/c26116)|Failing to acquire or to hold lock|
|[C26117](/cpp/code-quality/c26117)|Releasing unheld lock|
|[C26140](/cpp/code-quality/c26140)|Concurrency SAL annotation error|
|[C28020](/cpp/code-quality/c28020)|The expression is not true at this call|
|[C28021](/cpp/code-quality/c28021)|The parameter being annotated must be a pointer|
|[C28022](/cpp/code-quality/c28022)|The function class(es) on this function do not match the function class(es) on the typedef used to define it.|
|[C28023](/cpp/code-quality/c28023)|The function being assigned or passed should have a \_Function\_class\_ annotation for at least one of the class(es)|
|[C28024](/cpp/code-quality/c28024)|The function pointer being assigned to is annotated with the function class, which is not contained in the function class(es) list.|
|[C28039](/cpp/code-quality/c28039)|The type of actual parameter should exactly match the type|
|[C28112](/cpp/code-quality/c28112)|A variable which is accessed via an Interlocked function must always be accessed via an Interlocked function.|
|[C28113](/cpp/code-quality/c28113)|Accessing a local variable via an Interlocked function|
|[C28125](/cpp/code-quality/c28125)|The function must be called from within a try/except block|
|[C28137](/cpp/code-quality/c28137)|The variable argument should instead be a (literal) constant|
|[C28138](/cpp/code-quality/c28138)|The constant argument should instead be variable|
|[C28159](/cpp/code-quality/c28159)|Consider using another function instead.|
|[C28160](/cpp/code-quality/c28160)|Error annotation|
|[C28163](/cpp/code-quality/c28163)|The function should never be called from within a try/except block|
|[C28164](/cpp/code-quality/c28164)|The argument is being passed to a function that expects a pointer to an object (not a pointer to a pointer)|
|[C28182](/cpp/code-quality/c28182)|Dereferencing NULL pointer. The pointer contains the same NULL value as another pointer did.|
|[C28183](/cpp/code-quality/c28183)|The argument could be one value, and is a copy of the value found in the pointer|
|[C28193](/cpp/code-quality/c28193)|The variable holds a value that must be examined|
|[C28196](/cpp/code-quality/c28196)|The requirement is not satisfied. (The expression does not evaluate to true.)|
|[C28202](/cpp/code-quality/c28202)|Illegal reference to non-static member|
|[C28203](/cpp/code-quality/c28203)|Ambiguous reference to class member.|
|[C28205](/cpp/code-quality/c28205)|\_Success\_ or \_On\_failure\_ used in an illegal context|
|[C28206](/cpp/code-quality/c28206)|Left operand points to a struct, use '->'|
|[C28207](/cpp/code-quality/c28207)|Left operand is a struct, use '.'|
|[C28209](/cpp/code-quality/c28209)|The declaration for symbol has a conflicting declaration|
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
|[C28244](/cpp/code-quality/c28244)|The annotation for function has an unparsable parameter/external annotation|
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
|[C28306](/cpp/code-quality/c28306)|The annotation on parameter is obsolescent|
|[C28307](/cpp/code-quality/c28307)|The annotation on parameter is obsolescent|
|[C28350](/cpp/code-quality/c28350)|The annotation describes a situation that is not conditionally applicable.|
|[C28351](/cpp/code-quality/c28351)|The annotation describes where a dynamic value (a variable) cannot be used in the condition.|
|[CA1001](../code-quality/ca1001.md)|Types that own disposable fields should be disposable|
|[CA1009](../code-quality/ca1009.md)|Declare event handlers correctly|
|[CA1016](../code-quality/ca1016.md)|Mark assemblies with AssemblyVersionAttribute|
|[CA1033](../code-quality/ca1033.md)|Interface methods should be callable by child types|
|[CA1049](../code-quality/ca1049.md)|Types that own native resources should be disposable|
|[CA1060](../code-quality/ca1060.md)|Move P/Invokes to NativeMethods class|
|[CA1061](../code-quality/ca1061.md)|Do not hide base class methods|
|[CA1063](../code-quality/ca1063.md)|Implement IDisposable correctly|
|[CA1065](../code-quality/ca1065.md)|Do not raise exceptions in unexpected locations|
|[CA1301](../code-quality/ca1301.md)|Avoid duplicate accelerators|
|[CA1400](../code-quality/ca1400.md)|P/Invoke entry points should exist|
|[CA1401](../code-quality/ca1401.md)|P/Invokes should not be visible|
|[CA1403](../code-quality/ca1403.md)|Auto layout types should not be COM visible|
|[CA1404](../code-quality/ca1404.md)|Call GetLastError immediately after P/Invoke|
|[CA1405](../code-quality/ca1405.md)|COM visible type base types should be COM visible|
|[CA1410](../code-quality/ca1410.md)|COM registration methods should be matched|
|[CA1415](../code-quality/ca1415.md)|Declare P/Invokes correctly|
|[CA1821](../code-quality/ca1821.md)|Remove empty finalizers|
|[CA1900](../code-quality/ca1900.md)|Value type fields should be portable|
|[CA1901](../code-quality/ca1901.md)|P/Invoke declarations should be portable|
|[CA2002](../code-quality/ca2002.md)|Do not lock on objects with weak identity|
|[CA2100](../code-quality/ca2100.md)|Review SQL queries for security vulnerabilities|
|[CA2101](../code-quality/ca2101.md)|Specify marshaling for P/Invoke string arguments|
|[CA2108](../code-quality/ca2108.md)|Review declarative security on value types|
|[CA2111](../code-quality/ca2111.md)|Pointers should not be visible|
|[CA2112](../code-quality/ca2112.md)|Secured types should not expose fields|
|[CA2114](../code-quality/ca2114.md)|Method security should be a superset of type|
|[CA2116](../code-quality/ca2116.md)|APTCA methods should only call APTCA methods|
|[CA2117](../code-quality/ca2117.md)|APTCA types should only extend APTCA base types|
|[CA2122](../code-quality/ca2122.md)|Do not indirectly expose methods with link demands|
|[CA2123](../code-quality/ca2123.md)|Override link demands should be identical to base|
|[CA2124](../code-quality/ca2124.md)|Wrap vulnerable finally clauses in outer try|
|[CA2126](../code-quality/ca2126.md)|Type link demands require inheritance demands|
|[CA2131](../code-quality/ca2131.md)|Security critical types may not participate in type equivalence|
|[CA2132](../code-quality/ca2132.md)|Default constructors must be at least as critical as base type default constructors|
|[CA2133](../code-quality/ca2133.md)|Delegates must bind to methods with consistent transparency|
|[CA2134](../code-quality/ca2134.md)|Methods must keep consistent transparency when overriding base methods|
|[CA2137](../code-quality/ca2137.md)|Transparent methods must contain only verifiable IL|
|[CA2138](../code-quality/ca2138.md)|Transparent methods must not call methods with the SuppressUnmanagedCodeSecurity attribute|
|[CA2140](../code-quality/ca2140.md)|Transparent code must not reference security critical items|
|[CA2141](../code-quality/ca2141.md)|Transparent methods must not satisfy LinkDemands|
|[CA2146](../code-quality/ca2146.md)|Types must be at least as critical as their base types and interfaces|
|[CA2147](../code-quality/ca2147.md)|Transparent methods may not use security asserts|
|[CA2149](../code-quality/ca2149.md)|Transparent methods must not call into native code|
|[CA2200](../code-quality/ca2200.md)|Rethrow to preserve stack details|
|[CA2202](../code-quality/ca2202.md)|Do not dispose objects multiple times|
|[CA2207](../code-quality/ca2207.md)|Initialize value type static fields inline|
|[CA2212](../code-quality/ca2212.md)|Do not mark serviced components with WebMethod|
|[CA2213](../code-quality/ca2213.md)|Disposable fields should be disposed|
|[CA2214](../code-quality/ca2214.md)|Do not call overridable methods in constructors|
|[CA2216](../code-quality/ca2216.md)|Disposable types should declare finalizer|
|[CA2220](../code-quality/ca2220.md)|Finalizers should call base class finalizer|
|[CA2229](../code-quality/ca2229.md)|Implement serialization constructors|
|[CA2231](../code-quality/ca2231.md)|Overload operator equals on overriding ValueType.Equals|
|[CA2232](../code-quality/ca2232.md)|Mark Windows Forms entry points with STAThread|
|[CA2235](../code-quality/ca2235.md)|Mark all non-serializable fields|
|[CA2236](../code-quality/ca2236.md)|Call base class methods on ISerializable types|
|[CA2237](../code-quality/ca2237.md)|Mark ISerializable types with SerializableAttribute|
|[CA2238](../code-quality/ca2238.md)|Implement serialization methods correctly|
|[CA2240](../code-quality/ca2240.md)|Implement ISerializable correctly|
|[CA2241](../code-quality/ca2241.md)|Provide correct arguments to formatting methods|
|[CA2242](../code-quality/ca2242.md)|Test for NaN correctly|