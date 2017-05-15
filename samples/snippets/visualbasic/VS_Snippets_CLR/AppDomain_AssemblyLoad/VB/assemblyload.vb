
' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Reflection

Module Test
   
   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      AddHandler currentDomain.AssemblyLoad, AddressOf MyAssemblyLoadEventHandler
      
      PrintLoadedAssemblies(currentDomain)
      ' Lists mscorlib and this assembly

      ' You must supply a valid fully qualified assembly name here.      
      currentDomain.CreateInstance("System.Windows.Forms,Version,Culture,PublicKeyToken", "System.Windows.Forms.TextBox")
      ' Loads System, System.Drawing, System.Windows.Forms
      
      PrintLoadedAssemblies(currentDomain)
      ' Lists all five assemblies
   End Sub 'Main
   
   Sub PrintLoadedAssemblies(domain As AppDomain)
      Console.WriteLine("LOADED ASSEMBLIES:")
      Dim a As System.Reflection.Assembly
      For Each a In domain.GetAssemblies()
         Console.WriteLine(a.FullName)
      Next a
      Console.WriteLine()
   End Sub 'PrintLoadedAssemblies
   
   Sub MyAssemblyLoadEventHandler(sender As Object, args As AssemblyLoadEventArgs)
      Console.WriteLine("ASSEMBLY LOADED: " + args.LoadedAssembly.FullName)
      Console.WriteLine()
   End Sub 'MyAssemblyLoadEventHandler

End Module 'Test 
' </Snippet1>