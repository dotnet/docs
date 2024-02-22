using System;
using System.Reflection;

// Sample class that contains a function pointer field.
public unsafe class UClass
{
    public delegate* unmanaged[Cdecl, SuppressGCTransition]<in int, void> _fp;
}

internal class FunctionPointerReflection
{
    public static void RunIt()
    {
        FieldInfo? fieldInfo = typeof(UClass).GetField(nameof(UClass._fp));

        // Obtain the function pointer type from a field.
        Type? fpType = fieldInfo?.FieldType;

        // New methods to determine if a type is a function pointer.
        Console.WriteLine(
        $"IsFunctionPointer: {fpType?.IsFunctionPointer}");
        Console.WriteLine(
            $"IsUnmanagedFunctionPointer: {fpType?.IsUnmanagedFunctionPointer}");

        // New methods to obtain the return and parameter types.
        Console.WriteLine($"Return type: {fpType?.GetFunctionPointerReturnType()}");

        if (fpType is not null)
        {
            foreach (Type parameterType in fpType.GetFunctionPointerParameterTypes())
            {
                Console.WriteLine($"Parameter type: {parameterType}");
            }
        }

        // Access to custom modifiers and calling conventions requires a "modified type".
        Type? modifiedType = fieldInfo?.GetModifiedFieldType();

        // A modified type forwards most members to its underlying type.
        Type? normalType = modifiedType?.UnderlyingSystemType;

        if (modifiedType is not null)
        {
            // New method to obtain the calling conventions.
            foreach (Type callConv in modifiedType.GetFunctionPointerCallingConventions())
            {
                Console.WriteLine($"Calling convention: {callConv}");
            }
        }

        // New method to obtain the custom modifiers.
        Type[]? modifiers =
            modifiedType?.GetFunctionPointerParameterTypes()[0].GetRequiredCustomModifiers();

        if (modifiers is not null)
        {
            foreach (Type modreq in modifiers)
            {
                Console.WriteLine($"Required modifier for first parameter: {modreq}");
            }
        }
    }
}
