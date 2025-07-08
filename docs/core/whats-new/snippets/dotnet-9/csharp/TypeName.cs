using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

internal class RestrictedSerializationBinder
{
    Dictionary<string, Type> AllowList { get; set; }

    RestrictedSerializationBinder(Type[] allowedTypes)
        => AllowList = allowedTypes.ToDictionary(type => type.FullName!);

    Type? GetType(ReadOnlySpan<char> untrustedInput)
    {
        if (!TypeName.TryParse(untrustedInput, out TypeName? parsed))
        {
            throw new InvalidOperationException($"Invalid type name: '{untrustedInput.ToString()}'");
        }

        if (AllowList.TryGetValue(parsed.FullName, out Type? type))
        {
            return type;
        }
        else if (parsed.IsSimple // It's not generic, pointer, reference, or an array.
            && parsed.AssemblyName is not null
            && parsed.AssemblyName.Name == "MyTrustedAssembly"
            )
        {
            return Type.GetType(parsed.AssemblyQualifiedName, throwOnError: true);
        }

        throw new InvalidOperationException($"Not allowed: '{untrustedInput.ToString()}'");
    }
}
