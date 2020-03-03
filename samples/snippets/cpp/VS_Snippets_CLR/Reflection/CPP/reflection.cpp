// <Snippet1>
using namespace System;
using namespace System::Reflection;

static void Display(Int32 indent, String^ format, ... array<Object^>^param) 
{
    Console::Write("{0}", gcnew String (' ', indent));
    Console::WriteLine(format, param);
}
	
// Displays the custom attributes applied to the specified member.
static void DisplayAttributes(Int32 indent, MemberInfo^ mi)
{
    // Get the set of custom attributes; if none exist, just return.
    array<Object^>^attrs = mi->GetCustomAttributes(false);
		
    if (attrs->Length==0)
    {
        return;          
    }
		
    // Display the custom attributes applied to this member.
    Display(indent+1, "Attributes:");
    for each ( Object^ o in attrs )
    {
        Display(indent*2, "{0}", o);
    }				
}

void main()
{
    try
    {
        // This variable holds the amount of indenting that 
        // should be used when displaying each line of information.
        Int32 indent = 0; 
        // Display information about the EXE assembly.
        // <snippet2>
        Assembly^ a = System::Reflection::Assembly::GetExecutingAssembly();
		
        Display(indent, "Assembly identity={0}", gcnew array<Object^> {a->FullName});
        Display(indent+1, "Codebase={0}", gcnew array<Object^> {a->CodeBase});

        // Display the set of assemblies our assemblies reference.
  
        Display(indent, "Referenced assemblies:"); 

        for each ( AssemblyName^ an in a->GetReferencedAssemblies() )
        {
            Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", gcnew array<Object^> {an->Name, an->Version, an->CultureInfo, (BitConverter::ToString(an->GetPublicKeyToken()))});
        }
        // </snippet2>  
        Display(indent, "");  
        // Display information about each assembly loading into this AppDomain. 
        for each ( Assembly^ b in AppDomain::CurrentDomain->GetAssemblies()) 
        {
            Display(indent, "Assembly: {0}", gcnew array<Object^> {b});
            // Display information about each module of this assembly.
 
            for each ( Module^ m in b->GetModules(true) ) 
            {
                Display(indent+1, "Module: {0}", gcnew array<Object^> {m->Name});
            }
            // Display information about each type exported from this assembly.
           
            indent += 1; 
            for each ( Type^ t in b->GetExportedTypes() ) 
            {
                Display(0, "");  
                Display(indent, "Type: {0}", gcnew array<Object^> {t}); 

                // For each type, show its members & their custom attributes.
           
                indent += 1; 
                for each (MemberInfo^ mi in t->GetMembers() )
                {
                    Display(indent, "Member: {0}", gcnew array<Object^> {mi->Name}); 
                    DisplayAttributes(indent, mi);

                    // If the member is a method, display information about its parameters.         
                    if (mi->MemberType==MemberTypes::Method) 
                    {
					
                        for each ( ParameterInfo^ pi in (((MethodInfo^) mi)->GetParameters()))
                        {
                            Display(indent+1, "Parameter: Type={0}, Name={1}", gcnew array<Object^> {pi->ParameterType, pi->Name}); 
                        }
                    }

                    // If the member is a property, display information about the property's accessor methods.
                    if (mi->MemberType==MemberTypes::Property) 
                    {
                        for each ( MethodInfo^ am in (((PropertyInfo^) mi)->GetAccessors()) )
                        {
                            Display(indent+1, "Accessor method: {0}", gcnew array<Object^> {am});
                        }
                    }
                }
                // Display a formatted string indented by the specified amount.               
                indent -= 1;
            }
            indent -= 1;
        }
    }
    catch (Exception^ e)
    {
        Console::WriteLine(e->Message);
    }
}

// The output shown below is abbreviated.
//
//Assembly identity=Reflection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
//  Codebase=file:///C:/Reflection.exe
//Referenced assemblies:
//  Name=mscorlib, Version=1.0.5000.0, Culture=, PublicKey token=B7-7A-5C-56-19-34-E0-89
//  Name=Microsoft.VisualBasic, Version=7.0.5000.0, Culture=, PublicKey token=B0-3F-5F-7F-11-D5-0A-3A
//
//Assembly: mscorlib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//  Module: mscorlib.dll
//  Module: prc.nlp
//  Module: prcp.nlp
//  Module: ksc.nlp
//  Module: ctype.nlp
//  Module: xjis.nlp
//  Module: bopomofo.nlp
//  Module: culture.nlp
//  Module: region.nlp
//  Module: sortkey.nlp
//  Module: charinfo.nlp
//  Module: big5.nlp
//  Module: sorttbls.nlp
//  Module: l_intl.nlp
//  Module: l_except.nlp
//
//  Type: System.Object
//    Member: GetHashCode
//    Member: Equals
//      Parameter: Type=System.Object, Name=obj
//    Member: ToString
//    Member: Equals
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: ReferenceEquals
//      Parameter: Type=System.Object, Name=objA
//      Parameter: Type=System.Object, Name=objB
//    Member: GetType
//    Member: .ctor
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
//    Member: get_IsSynchronized
//    Member: get_SyncRoot
//    Member: get_Count
//    Member: CopyTo
//      Parameter: Type=System.Array, Name=array
//      Parameter: Type=System.Int32, Name=index
//    Member: Count
//      Accessor method: Int32 get_Count()
//    Member: SyncRoot
//      Accessor method: System.Object get_SyncRoot()
//    Member: IsSynchronized
//      Accessor method: Boolean get_IsSynchronized()
//
//</snippet1>
