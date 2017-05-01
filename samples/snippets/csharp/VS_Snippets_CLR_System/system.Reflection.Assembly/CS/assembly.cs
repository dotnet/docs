 using System;
 using System.Reflection;

 class Class1
 {
     static void Main(string[] args)
     {
         Class1 c1 = new Class1();
         c1.Snippet1();
         c1.Snippet2();
         c1.Snippet3();

         c1.Snippet5();
//         c1.Snippet6();
         c1.Snippet7();
         c1.Snippet8();
         c1.Snippet9();
         c1.Snippet10();
         c1.Snippet11();
     }

     public void Snippet1()
     {
         Assembly SampleAssembly;
         // Instantiate a target object.
         Int32 Integer1 = new Int32();
         Type Type1;
         // Set the Type instance to the target class type.
         Type1 = Integer1.GetType();
         // Instantiate an Assembly class to the assembly housing the Integer type.  
         SampleAssembly = Assembly.GetAssembly(Integer1.GetType());
         // Gets the location of the assembly using file: protocol.
         Console.WriteLine("CodeBase=" + SampleAssembly.CodeBase);
     }
     public void Snippet2()
     {
         Console.WriteLine("SNIPPET2:");
         // <Snippet2>
         Assembly SampleAssembly;
         // Instantiate a target object.
         Int32 Integer1 = new Int32();
         Type Type1;
         // Set the Type instance to the target class type.
         Type1 = Integer1.GetType();
         // Instantiate an Assembly class to the assembly housing the Integer type.  
         SampleAssembly = Assembly.GetAssembly(Integer1.GetType());
         // Write the display name of assembly including base name and version.
         Console.WriteLine("FullName=" + SampleAssembly.FullName);
         // The example displays the following output:
         //   FullName=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
         // </Snippet2>
         Console.WriteLine();
     }
     public void Snippet3()
     {
         Console.WriteLine("SNIPPET3:");
         // <Snippet3>
         Assembly SampleAssembly;
         // Instantiate a target object.
         Int32 Integer1 = new Int32();
         Type Type1;
         // Set the Type instance to the target class type.
         Type1 = Integer1.GetType();
         // Instantiate an Assembly class to the assembly housing the Integer type.  
         SampleAssembly = Assembly.GetAssembly(Integer1.GetType());
         // Display the physical location of the assembly containing the manifest.
         Console.WriteLine("Location=" + SampleAssembly.Location);
         // The example displays the following output:
         //   Location=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
         // </Snippet3>
         Console.WriteLine();
     }

     public void Snippet5()
     {
         Console.WriteLine("SNIPPET5:");
         // <Snippet5>
         Assembly SampleAssembly;
         // Instantiate a target object.
         Int32 Integer1 = new Int32();
         Type Type1;
         // Set the Type instance to the target class type.
         Type1 = Integer1.GetType();
         // Instantiate an Assembly class to the assembly housing the Integer type.  
         SampleAssembly = Assembly.GetAssembly(Integer1.GetType());
         // Display the name of the assembly currently executing
         Console.WriteLine("GetExecutingAssembly=" + Assembly.GetExecutingAssembly().FullName);
         // The example displays the following output:
         //    GetExecutingAssembly=assembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
         // </Snippet5>
         Console.WriteLine();
     }
     
     public void Snippet6()
     {
         Console.WriteLine("SNIPPET6:");
         // <Snippet6>
         Assembly SampleAssembly;
         // Load the assembly by providing the location of the assembly file.
         SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");
         foreach(Type ExportedType in SampleAssembly.GetExportedTypes())
         {
             Console.WriteLine(ExportedType.ToString());
         }
         // </Snippet6>
         Console.WriteLine();
     }
     
     public void Snippet7()
     {
         Console.WriteLine("SNIPPET7:");
         // <Snippet7>
         Assembly SampleAssembly;
         // Load the assembly by providing the type name.
         SampleAssembly = Assembly.Load("MyAssembly");
         foreach (String Resource in SampleAssembly.GetManifestResourceNames())
         {
             Console.WriteLine(Resource);
         }
         // </Snippet7>
         Console.WriteLine();
     }
   
     public void Snippet8()
     {
         Console.WriteLine("SNIPPET8:");
         // <Snippet8>
         Assembly SampleAssembly;
         SampleAssembly = Assembly.Load("System.Data");
         Type[] Types = SampleAssembly.GetTypes();
         foreach (Type oType in Types)
         {
             Console.WriteLine(oType.Name.ToString());
         }
         // </Snippet8>
         Console.WriteLine();
     }
   
     public void Snippet9()
     {
         Console.WriteLine("SNIPPET9:");
         // <Snippet9>
         Assembly SampleAssembly;
         SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");

         // Obtain a reference to the first class contained in the assembly.
         Type oType = SampleAssembly.GetTypes()[0];
         // Obtain a reference to the public properties of the type.
         PropertyInfo[] Props = oType.GetProperties();
         // Display information about public properties of assembly type.
         // Prop = Prop1
         //    DeclaringType = Sample.Assembly.Class1
         //    Type = System.String
         //    Readable = True
         //    Writable = False
         foreach (PropertyInfo Prop in Props)
         {
             Console.WriteLine("Prop=" + Prop.Name.ToString());
             Console.WriteLine("  DeclaringType=" + Prop.DeclaringType.ToString());
             Console.WriteLine("  Type=" + Prop.PropertyType.ToString());
             Console.WriteLine("  Readable=" + Prop.CanRead.ToString());
             Console.WriteLine("  Writable=" + Prop.CanWrite.ToString());
         }
         // </Snippet9>
         Console.WriteLine();
     }
   
     public void Snippet10()
     {
         Console.WriteLine("SNIPPET10:");
         // <Snippet10>
         Assembly SampleAssembly;
         SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");
         MethodInfo[] Methods = SampleAssembly.GetTypes()[0].GetMethods();
         // Obtain a reference to the method members
         foreach(MethodInfo Method in Methods)
         {
             Console.WriteLine("Method Name=" + Method.Name.ToString());
         }
         // </Snippet10>
         Console.WriteLine();
     }
   
     public void Snippet11()
     {
         Console.WriteLine("SNIPPET11:");
         // <Snippet11>
         Assembly SampleAssembly;
         SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");
         // Obtain a reference to a method known to exist in assembly.
         MethodInfo Method = SampleAssembly.GetTypes()[0].GetMethod("Method1");
         // Obtain a reference to the parameters collection of the MethodInfo instance.
         ParameterInfo[] Params = Method.GetParameters();
         // Display information about method parameters.
         // Param = sParam1
         //   Type = System.String
         //   Position = 0
         //   Optional=False
         foreach (ParameterInfo Param in Params)
         {
             Console.WriteLine("Param=" + Param.Name.ToString());
             Console.WriteLine("  Type=" + Param.ParameterType.ToString());
             Console.WriteLine("  Position=" + Param.Position.ToString());
             Console.WriteLine("  Optional=" + Param.IsOptional.ToString());
         }
         // </Snippet11>
         Console.ReadLine();
     }
 }

