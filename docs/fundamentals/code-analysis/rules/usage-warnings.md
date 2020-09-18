---
title: Usage Warnings (code analysis)
description: "Learn about code analysis rule Usage Warnings"
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
- vs.codeanalysis.usagerules
helpviewer_keywords:
- warnings, usage
- managed code analysis warnings, usage warnings
- usage warnings
author: gewarren
ms.author: gewarren
---
# Usage warnings

Usage warnings support proper usage of .NET.

## In this section

|Rule|Description|
|----------|-----------------|
|[CA1801: Review unused parameters](ca1801.md)|A method signature includes a parameter that is not used in the method body.|
|[CA1816: Call GC.SuppressFinalize correctly](ca1816.md)|A method that is an implementation of Dispose does not call GC.SuppressFinalize; or a method that is not an implementation of Dispose calls GC.SuppressFinalize; or a method calls GC.SuppressFinalize and passes something other than this (Me in Visual Basic).|
|[CA2200: Rethrow to preserve stack details](ca2200.md)|An exception is rethrown and the exception is explicitly specified in the throw statement. If an exception is rethrown by specifying the exception in the throw statement, the list of method calls between the original method that threw the exception and the current method is lost.|
|[CA2201: Do not raise reserved exception types](ca2201.md)|This makes the original error hard to detect and debug.|
|[CA2202: Do not dispose objects multiple times](ca2202.md)|A method implementation contains code paths that could cause multiple calls to System.IDisposable.Dispose or a Dispose equivalent (such as a Close() method on some types) on the same object.|
|[CA2207: Initialize value type static fields inline](ca2207.md)|A value type declares an explicit static constructor. To fix a violation of this rule, initialize all static data when it is declared and remove the static constructor.|
|[CA2208: Instantiate argument exceptions correctly](ca2208.md)|A call is made to the default (parameterless) constructor of an exception type that is or derives from ArgumentException, or an incorrect string argument is passed to a parameterized constructor of an exception type that is or derives from ArgumentException.|
|[CA2211: Non-constant fields should not be visible](ca2211.md)|Static fields that are not constants or read-only are not thread-safe. Access to such a field must be carefully controlled and requires advanced programming techniques for synchronizing access to the class object.|
|[CA2213: Disposable fields should be disposed](ca2213.md)|A type that implements System.IDisposable declares fields that are of types that also implement IDisposable. The Dispose method of the field is not called by the Dispose method of the declaring type.|
|[CA2214: Do not call overridable methods in constructors](ca2214.md)|When a constructor calls a virtual method, it is possible that the constructor for the instance that invokes the method has not executed.|
|[CA2215: Dispose methods should call base class dispose](ca2215.md)|If a type inherits from a disposable type, it must call the Dispose method of the base type from its own Dispose method.|
|[CA2216: Disposable types should declare finalizer](ca2216.md)|A type that implements System.IDisposable, and has fields that suggest the use of unmanaged resources, does not implement a finalizer as described by Object.Finalize.|
|[CA2217: Do not mark enums with FlagsAttribute](ca2217.md)|An externally visible enumeration is marked with FlagsAttribute, and it has one or more values that are not powers of two or a combination of the other defined values on the enumeration.|
|[CA2219: Do not raise exceptions in exception clauses](ca2219.md)|When an exception is raised in a finally or fault clause, the new exception hides the active exception. When an exception is raised in a filter clause, the run time silently catches the exception. This makes the original error hard to detect and debug.|
|[CA2225: Operator overloads have named alternates](ca2225.md)|An operator overload was detected, and the expected named alternative method was not found. The named alternative member provides access to the same functionality as the operator, and is provided for developers who program in languages that do not support overloaded operators.|
|[CA2226: Operators should have symmetrical overloads](ca2226.md)|A type implements the equality or inequality operator, and does not implement the opposite operator.|
|[CA2227: Collection properties should be read only](ca2227.md)|A writable collection property allows a user to replace the collection with a different collection. A read-only property stops the collection from being replaced but still allows the individual members to be set.|
|[CA2229: Implement serialization constructors](ca2229.md)|To fix a violation of this rule, implement the serialization constructor. For a sealed class, make the constructor private; otherwise, make it protected.|
|[CA2231: Overload operator equals on overriding ValueType.Equals](ca2231.md)|A value type overrides `Object.Equals` but does not implement the equality operator.|
|[CA2232: Mark Windows Forms entry points with STAThread](ca2232.md)|STAThreadAttribute indicates that the COM threading model for the application is a single-threaded apartment. This attribute must be present on the entry point of any application that uses Windows Forms; if it is omitted, the Windows components might not work correctly.|
|[CA2233: Operations should not overflow](ca2233.md)|Arithmetic operations should not be performed without first validating the operands, to make sure that the result of the operation is not outside the range of possible values for the data types involved.|
|[CA2234: Pass System.Uri objects instead of strings](ca2234.md)|A call is made to a method that has a string parameter whose name contains "uri", "URI", "urn", "URN", "url", or "URL".  The declaring type of the method contains a corresponding method overload that has a System.Uri parameter.|
|[CA2235: Mark all non-serializable fields](ca2235.md)|An instance field of a type that is not serializable is declared in a type that is serializable.|
|[CA2236: Call base class methods on ISerializable types](ca2236.md)|To fix a violation of this rule, call the base type GetObjectData method or serialization constructor from the corresponding derived type method or constructor.|
|[CA2237: Mark ISerializable types with SerializableAttribute](ca2237.md)|To be recognized by the common language runtime as serializable, types must be marked with the SerializableAttribute attribute even if the type uses a custom serialization routine through implementation of the ISerializable interface.|
|[CA2238: Implement serialization methods correctly](ca2238.md)|A method that handles a serialization event does not have the correct signature, return type, or visibility.|
|[CA2239: Provide deserialization methods for optional fields](ca2239.md)|A type has a field that is marked with the System.Runtime.Serialization.OptionalFieldAttribute attribute, and the type does not provide de-serialization event handling methods.|
|[CA2240: Implement ISerializable correctly](ca2240.md)|To fix a violation of this rule, make the GetObjectData method visible and overridable, and make sure that all instance fields are included in the serialization process or explicitly marked with the NonSerializedAttribute attribute.|
|[CA2241: Provide correct arguments to formatting methods](ca2241.md)|The format argument passed to System.String.Format does not contain a format item that corresponds to each object argument, or vice versa.|
|[CA2242: Test for NaN correctly](ca2242.md)|This expression tests a value against Single.Nan or Double.Nan. Use Single.IsNan(Single) or Double.IsNan(Double) to test the value.|
|[CA2243: Attribute string literals should parse correctly](ca2243.md)|An attribute's string literal parameter does not parse correctly for a URL, a GUID, or a version.|
|[CA2244: Do not duplicate indexed element initializations](ca2244.md)|An object initializer has more than one indexed element initializer with the same constant index. All but the last initializer are redundant.|
|[CA2245: Do not assign a property to itself](ca2245.md)|A property was accidentally assigned to itself.|
|[CA2246: Do not assign a symbol and its member in the same statement](ca2246.md)|Assigning a symbol and its member, that is, a field or a property, in the same statement is not recommended. It is not clear if the member access was intended to use the symbol's old value prior to the assignment or the new value from the assignment in this statement.|
|[CA2247: Argument passed to TaskCompletionSource constructor should be TaskCreationOptions enum instead of TaskContinuationOptions enum](ca2246.md)|TaskCompletionSource has constructors that take TaskCreationOptions that control the underlying Task, and constructors that take object state that's stored in the task.  Accidentally passing a TaskContinuationOptions instead of a TaskCreationOptions will result in the call treating the options as state.|
|[CA2248: Provide correct 'enum' argument to 'Enum.HasFlag'](ca2248.md)|The enum type passed as an argument to the `HasFlag` method call is different from the calling enum type.|
|[CA2249: Consider using String.Contains instead of String.IndexOf](ca2249.md)|Calls to `string.IndexOf` where the result is used to check for the presence or absence of a substring can be replaced by `string.Contains`.|
