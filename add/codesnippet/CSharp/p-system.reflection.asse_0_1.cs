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