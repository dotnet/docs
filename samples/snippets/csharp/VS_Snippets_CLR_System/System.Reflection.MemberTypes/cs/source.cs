// <Snippet1>
using System;
using System.Reflection;
 
class Example
{
    public static void Main() 
    {
        // Get the type of a chosen class.
        Type t = typeof(ReflectionTypeLoadException);
 
        // Get the MemberInfo array.
        MemberInfo[] members = t.GetMembers();
 
        // Get and display the name and the MemberType for each member.
        Console.WriteLine("Members of {0}", t.Name);
        foreach (var member in members) { 
            MemberTypes memberType = member.MemberType; 
            Console.WriteLine("   {0}: {1}", member.Name, memberType);
        }
    }
}
// The example displays the following output:
//       Members of ReflectionTypeLoadException
//          get_Types: Method
//          get_LoaderExceptions: Method
//          GetObjectData: Method
//          get_Message: Method
//          get_Data: Method
//          GetBaseException: Method
//          get_InnerException: Method
//          get_TargetSite: Method
//          get_StackTrace: Method
//          get_HelpLink: Method
//          set_HelpLink: Method
//          get_Source: Method
//          set_Source: Method
//          ToString: Method
//          get_HResult: Method
//          GetType: Method
//          Equals: Method
//          GetHashCode: Method
//          GetType: Method
//          .ctor: Constructor
//          .ctor: Constructor
//          Types: Property
//          LoaderExceptions: Property
//          Message: Property
//          Data: Property
//          InnerException: Property
//          TargetSite: Property
//          StackTrace: Property
//          HelpLink: Property
//          Source: Property
//          HResult: Property
// </Snippet1>

