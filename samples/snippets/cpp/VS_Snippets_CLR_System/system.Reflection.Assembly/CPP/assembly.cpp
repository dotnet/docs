using namespace System;
using namespace System::Reflection;
using namespace System::Collections;

void Snippet1()
{
   Assembly^ SampleAssembly;
   // Instantiate a target object.
   Int32 Integer1(0);
   Type^ Type1;
   // Set the Type instance to the target class type.
   Type1 = Integer1.GetType();
   // Instantiate an Assembly class to the assembly housing the Integer type.  
   SampleAssembly = Assembly::GetAssembly( Integer1.GetType() );
   // Gets the location of the assembly using file: protocol.
   Console::WriteLine( "CodeBase= {0}", SampleAssembly->CodeBase );
}
void Snippet2()
{
   // <Snippet2>
   Assembly^ SampleAssembly;
   // Instantiate a target object.
   Int32 Integer1(0);
   Type^ Type1;
   // Set the Type instance to the target class type.
   Type1 = Integer1.GetType();
   // Instantiate an Assembly class to the assembly housing the Integer type.  
   SampleAssembly = Assembly::GetAssembly( Integer1.GetType() );
   // Write the display name of assembly including base name and version.
   Console::WriteLine( "FullName= {0}", SampleAssembly->FullName );
   // The example displays the following output:
   //    FullName=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
   // </Snippet2>
}
void Snippet3()
{
   // <Snippet3>
   Assembly^ SampleAssembly;
   // Instantiate a target object.
   Int32 Integer1(0);
   Type^ Type1;
   // Set the Type instance to the target class type.
   Type1 = Integer1.GetType();
   // Instantiate an Assembly class to the assembly housing the Integer type.  
   SampleAssembly = Assembly::GetAssembly( Integer1.GetType() );
   // Display the physical location of the assembly containing the manifest.
   Console::WriteLine( "Location= {0}", SampleAssembly->Location );
   // The example displays the following output:
   //    Location=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll  
   // </Snippet3>
}

void Snippet5()
{
   // <Snippet5>
   Assembly^ SampleAssembly;
   // Instantiate a target object.
   Int32 Integer1(0);
   Type^ Type1;
   // Set the Type instance to the target class type.
   Type1 = Integer1.GetType();
   // Instantiate an Assembly class to the assembly housing the Integer type.  
   SampleAssembly = Assembly::GetAssembly( Integer1.GetType() );
   // Display the name of the assembly currently executing
   Console::WriteLine( "GetExecutingAssembly= {0}", Assembly::GetExecutingAssembly()->FullName );
   // The example displays the following output:
   //    GetExecutingAssembly=assembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null 
   // </Snippet5>
}
void Snippet6()
{
   // <Snippet6>
   Assembly^ SampleAssembly;
   // Load the assembly by providing the location of the assembly file.
   SampleAssembly = Assembly::LoadFrom( "c:\\Sample.Assembly.dll" );
   for each ( Type^ ExportedType in SampleAssembly->GetExportedTypes() )
   {
      Console::WriteLine( ExportedType );
   }
   // </Snippet6>
}
void Snippet7()
{
   // <Snippet7>
   Assembly^ SampleAssembly;
   // Load the assembly by providing the type name.
   SampleAssembly = Assembly::Load( "MyAssembly" );
   for each ( String^ Resource in SampleAssembly->GetManifestResourceNames() )
   {
      Console::WriteLine( Resource );
   }
   // </Snippet7>
}
void Snippet8()
{
   // <Snippet8>
   Assembly^ SampleAssembly;
   SampleAssembly = Assembly::Load( "System.Data" );
   array<Type^>^ Types = SampleAssembly->GetTypes();
   for each ( Type^ oType in Types )
   {
      Console::WriteLine( oType->Name );
   }
   // </Snippet8>
}
void Snippet9()
{
   // <Snippet9>
   Assembly^ SampleAssembly;
   SampleAssembly = Assembly::LoadFrom( "c:\\Sample.Assembly.dll" );
   
   // Obtain a reference to the first class contained in the assembly.
   Type^ oType = SampleAssembly->GetTypes()[ 0 ];
   // Obtain a reference to the public properties of the type.
   array<PropertyInfo^>^ Props = oType->GetProperties();
   // Display information about public properties of assembly type.
   // Prop = Prop1
   //    DeclaringType = Sample::Assembly.Class1
   //    Type = System::String
   //    Readable = True
   //    Writable = False
   for each ( PropertyInfo^ Prop in Props )
   {
      Console::WriteLine( "Prop= {0}", Prop->Name );
      Console::WriteLine( "  DeclaringType= {0}", Prop->DeclaringType );
      Console::WriteLine( "  Type= {0}", Prop->PropertyType );
      Console::WriteLine( "  Readable= {0}", Prop->CanRead );
      Console::WriteLine( "  Writable= {0}", Prop->CanWrite );
   }
   // </Snippet9>
}
void Snippet10()
{
   // <Snippet10>
   Assembly^ SampleAssembly;
   SampleAssembly = Assembly::LoadFrom( "c:\\Sample.Assembly.dll" );
   array<MethodInfo^>^ Methods = SampleAssembly->GetTypes()[ 0 ]->GetMethods();
   // Obtain a reference to the method members
   for each ( MethodInfo^ Method in Methods )
   {
      Console::WriteLine( "Method Name= {0}", Method->Name );
   }
   // </Snippet10>
}
void Snippet11()
{
   // <Snippet11>
   Assembly^ SampleAssembly;
   SampleAssembly = Assembly::LoadFrom( "c:\\Sample.Assembly.dll" );
   // Obtain a reference to a method known to exist in assembly.
   MethodInfo^ Method = SampleAssembly->GetTypes()[ 0 ]->GetMethod( "Method1" );
   // Obtain a reference to the parameters collection of the MethodInfo instance.
   array<ParameterInfo^>^ Params = Method->GetParameters();
   // Display information about method parameters.
   // Param = sParam1
   //   Type = System::String
   //   Position = 0
   //   Optional=False
   for each ( ParameterInfo^ Param in Params )
   {
      Console::WriteLine( "Param= {0}", Param->Name );
      Console::WriteLine( "  Type= {0}", Param->ParameterType );
      Console::WriteLine( "  Position= {0}", Param->Position );
      Console::WriteLine( "  Optional= {0}", Param->IsOptional );
   }
   // </Snippet11>
   Console::ReadLine();
}

void main()
{
   Snippet1();
   Snippet2();
   Snippet3();
   Snippet5();
   Snippet6();
   Snippet7();
   Snippet8();
   Snippet9();
   Snippet10();
   Snippet11();
}
