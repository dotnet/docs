---
title: "How to: Get type and member information by using reflection"
ms.date: "09/03/2019"
helpviewer_keywords: 
  - "reflection, obtaining member information"
  - "types [.NET Framework], obtaining member information from"
ms.assetid: 348ae651-ccda-4f13-8eda-19e8337e9438
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Get type and member information by using reflection
The <xref:System.Reflection> namespace contains many methods for obtaining information about types and their members. This article demonstrates one of these methods, <xref:System.Type.GetMembers%2A?displayProperty=nameWithType>. For additional information, see [Reflection overview](reflection.md).
  
## Example

The following example obtains type and member information by using reflection:

# [C++](#tab/cpp)
```cpp
using namespace System;
using namespace System::Reflection;

ref class Asminfo1
{
public:
    static void Main()
    {
        Console::WriteLine ("\nReflection.MemberInfo");

        // Get the Type and MemberInfo.
        // Insert the fully qualified class name inside the quotation marks in the
        // following statement.
        Type^ MyType = Type::GetType("System.IO.BinaryReader");
        array<MemberInfo^>^ Mymemberinfoarray = MyType->GetMembers(BindingFlags::Public |
            BindingFlags::NonPublic | BindingFlags::Static |
            BindingFlags::Instance | BindingFlags::DeclaredOnly);

        // Get and display the DeclaringType method.
        Console::Write("\nThere are {0} documentable members in ", Mymemberinfoarray->Length);
        Console::Write("{0}.", MyType->FullName);

        for each (MemberInfo^ Mymemberinfo in Mymemberinfoarray)
        {
            Console::Write("\n" + Mymemberinfo->Name);
        }
    }
};

int main()
{
    Asminfo1::Main();
}
```

# [C#](#tab/csharp)
```csharp
using System;
using System.Reflection;

class Asminfo1
{
    public static void Main()
    {
        Console.WriteLine ("\nReflection.MemberInfo");

        // Get the Type and MemberInfo.
        // Insert the fully qualified class name inside the quotation marks in the
        // following statement.
        Type MyType = Type.GetType("System.IO.BinaryReader");
        MemberInfo[] Mymemberinfoarray = MyType.GetMembers(BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Static |
            BindingFlags.Instance | BindingFlags.DeclaredOnly);

        // Get and display the DeclaringType method.
        Console.Write("\nThere are {0} documentable members in ", Mymemberinfoarray.Length);
        Console.Write("{0}.", MyType.FullName);

        foreach (MemberInfo Mymemberinfo in Mymemberinfoarray)
        {
            Console.Write("\n" + Mymemberinfo.Name);
        }
    }
}
```

# [Visual Basic](#tab/vb)
```vb
Imports System.Reflection

Class Asminfo1
    Public Shared Sub Main()
        Console.WriteLine ("\nReflection.MemberInfo")

        ' Get the Type and MemberInfo.
        ' Insert the fully qualified class name inside the quotation marks in the
        ' following statement.
        Dim MyType As Type = Type.GetType("System.IO.BinaryReader")
        Dim Mymemberinfoarray() As MemberInfo = MyType.GetMembers(BindingFlags.Public Or
            BindingFlags.NonPublic Or BindingFlags.Static Or
            BindingFlags.Instance Or BindingFlags.DeclaredOnly)

        ' Get and display the DeclaringType method.
        Console.Write("\nThere are {0} documentable members in ", Mymemberinfoarray.Length)
        Console.Write("{0}.", MyType.FullName)

        For Each Mymemberinfo As MemberInfo in Mymemberinfoarray
            Console.Write("\n" + Mymemberinfo.Name)
        Next
    End Sub
End Class
```
---

## See also

- [Program with application domains](../app-domains/application-domains.md#programming-with-application-domains)
- [Reflection](reflection.md)
- [Use application domains](../app-domains/use.md)
