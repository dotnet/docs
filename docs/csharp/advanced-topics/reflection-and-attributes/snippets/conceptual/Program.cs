// See https://aka.ms/new-console-template for more information


using System.Reflection;

ReflectionExamples.TestAuthorAttribute.Test();

// <GetTypeInformation>
// Using GetType to obtain type information:
int i = 42;
Type type = i.GetType();
Console.WriteLine(type);
// </GetTypeInformation>

// <GetAssemblyInfo>
// Using Reflection to get information of an Assembly:
Assembly info = typeof(int).Assembly;
Console.WriteLine(info);
// </GetAssemblyInfo>

Query();

void Query()
{
    // <QueryReflection>
    Assembly assembly = Assembly.Load("System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
    var pubTypesQuery = from type in assembly.GetTypes()
                        where type.IsPublic
                        from method in type.GetMethods()
                        where method.ReturnType.IsArray == true
                            || (method.ReturnType.GetInterface(
                                typeof(System.Collections.Generic.IEnumerable<>).FullName!) != null
                            && method.ReturnType.FullName != "System.String")
                        group method.ToString() by type.ToString();

    foreach (var groupOfMethods in pubTypesQuery)
    {
        Console.WriteLine($"Type: {groupOfMethods.Key}");
        foreach (var method in groupOfMethods)
        {
            Console.WriteLine($"  {method}");
        }
    }
    // </QueryReflection>
}
