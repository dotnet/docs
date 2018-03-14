//<Snippet1>
using System;
using System.Reflection;

class Module1
{
    public static void Main()
    {
        // This variable holds the amount of indenting that 
        // should be used when displaying each line of information.
        Int32 indent = 0;
        // <snippet2>
        // Display information about the EXE assembly.
        Assembly a = typeof(Module1).Assembly;
        Display(indent, "Assembly identity={0}", a.FullName);
        Display(indent+1, "Codebase={0}", a.CodeBase);

        // Display the set of assemblies our assemblies reference.
      
        Display(indent, "Referenced assemblies:");
        foreach (AssemblyName an in a.GetReferencedAssemblies() )
        {
             Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString (an.GetPublicKeyToken())));
        }
        // </snippet2>
        Display(indent, "");
        
        // Display information about each assembly loading into this AppDomain.
        foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
        {
            Display(indent, "Assembly: {0}", b);

            // Display information about each module of this assembly.
            foreach ( Module m in b.GetModules(true) )
            {
                Display(indent+1, "Module: {0}", m.Name);
            }

            // Display information about each type exported from this assembly.
           
            indent += 1;
            foreach ( Type t in b.GetExportedTypes() )
            {
                Display(0, "");
                Display(indent, "Type: {0}", t);

                // For each type, show its members & their custom attributes.
           
                indent += 1;
                foreach (MemberInfo mi in t.GetMembers() )
                {
                    Display(indent, "Member: {0}", mi.Name);
                    DisplayAttributes(indent, mi);

                    // If the member is a method, display information about its parameters.
                    
                    if (mi.MemberType==MemberTypes.Method)
                    {
                        foreach ( ParameterInfo pi in ((MethodInfo) mi).GetParameters() )
                        {
                            Display(indent+1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
                        }
                    }

                    // If the member is a property, display information about the property's accessor methods.
                    if (mi.MemberType==MemberTypes.Property)
                    {
                        foreach ( MethodInfo am in ((PropertyInfo) mi).GetAccessors() )
                        {
                            Display(indent+1, "Accessor method: {0}", am);
                        }
                    }
                }
                indent -= 1;
            }
            indent -= 1;
        }
    }

    // Displays the custom attributes applied to the specified member.
    public static void DisplayAttributes(Int32 indent, MemberInfo mi)
    {
        // Get the set of custom attributes; if none exist, just return.
        object[] attrs = mi.GetCustomAttributes(false);
        if (attrs.Length==0) {return;}

        // Display the custom attributes applied to this member.
        Display(indent+1, "Attributes:");
        foreach ( object o in attrs )
        {
            Display(indent+2, "{0}", o.ToString());
        }
    }

    // Display a formatted string indented by the specified amount.
    public static void Display(Int32 indent, string format, params object[] param) 

    {
        Console.Write(new string(' ', indent*2));
        Console.WriteLine(format, param);
    }
}

//The output shown below is abbreviated.
//
//Assembly identity=ReflectionCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//  Codebase=file:///C:/Documents and Settings/test/My Documents/Visual Studio 2005/Projects/Reflection/Reflection/obj/Debug/Reflection.exe
//Referenced assemblies:
//  Name=mscorlib, Version=2.0.0.0, Culture=, PublicKey token=B7-7A-5C-56-19-34-E0-89
//
//Assembly: mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//  Module: mscorlib.dll
//
//  Type: System.Object
//    Member: GetType
//    Member: ToString
//    Member: Equals
//      Parameter: Type=System.Object, Name=obj
//    Member: Equals
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: ReferenceEquals
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: GetHashCode
//    Member: .ctor
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//
//  Type: System.ICloneable
//    Member: Clone
//
//  Type: System.Collections.IEnumerable
//    Member: GetEnumerator
//      Attributes:
//        System.Runtime.InteropServices.DispIdAttribute
//
//  Type: System.Collections.ICollection
//    Member: CopyTo
//      Parameter: Type=System.Array, Name=array
//      Parameter: Type=System.Int32, Name=index
//    Member: get_Count
//    Member: get_SyncRoot
//    Member: get_IsSynchronized
//    Member: Count
//      Accessor method: Int32 get_Count()
//    Member: SyncRoot
//      Accessor method: System.Object get_SyncRoot()
//    Member: IsSynchronized
//      Accessor method: Boolean get_IsSynchronized()
//
//  Type: System.Collections.IList
//    Member: get_Item
//      Parameter: Type=System.Int32, Name=index
//    Member: set_Item
//      Parameter: Type=System.Int32, Name=index
//      Parameter: Type=System.Object, Name=value
//    Member: Add
//      Parameter: Type=System.Object, Name=value
//    Member: Contains
//      Parameter: Type=System.Object, Name=value
//    Member: Clear
//    Member: get_IsReadOnly
//    Member: get_IsFixedSize
//    Member: IndexOf
//      Parameter: Type=System.Object, Name=value
//    Member: Insert
//      Parameter: Type=System.Int32, Name=index
//      Parameter: Type=System.Object, Name=value
//    Member: Remove
//      Parameter: Type=System.Object, Name=value
//    Member: RemoveAt
//      Parameter: Type=System.Int32, Name=index
//    Member: Item
//      Accessor method: System.Object get_Item(Int32)
//      Accessor method: Void set_Item(Int32, System.Object)
//    Member: IsReadOnly
//      Accessor method: Boolean get_IsReadOnly()
//    Member: IsFixedSize
//      Accessor method: Boolean get_IsFixedSize()
//
//  Type: System.Array
//    Member: IndexOf
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//    Member: AsReadOnly
//      Parameter: Type=T[], Name=array
//    Member: Resize
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[]&, Name=array
//      Parameter: Type=System.Int32, Name=newSize
//    Member: BinarySearch
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//    Member: BinarySearch
//      Attributes:
//        System.Runtime.ConstrainedExecution.ReliabilityContractAttribute
//      Parameter: Type=T[], Name=array
//      Parameter: Type=T, Name=value
//      Parameter: Type=System.Collections.Generic.IComparer`1[T], Name=comparer
//</Snippet1>
