
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class TypeBuilderMemberDemo
   
   
   Public Shared Sub DefineDynamicModuleDemo1()
      ' <Snippet1>
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      
      ' Create a transient dynamic module. Since no DLL name is specified with
      ' this constructor, it can not be saved. 
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule1")
    ' </Snippet1>
   End Sub 'DefineDynamicModuleDemo1
   
   Public Shared Sub DefineDynamicModuleDemo2()
      ' <Snippet2>
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      
      ' Create a transient dynamic module. Since no DLL name is specified with
      ' this constructor, it can not be saved. By specifying the second parameter
      ' of the constructor as false, we can suppress the emission of symbol info.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule2", _
										False)
   ' </Snippet2>
   End Sub 'DefineDynamicModuleDemo2
   
   Public Shared Sub DefineDynamicModuleDemo3()
      ' <Snippet3>
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      ' Create a dynamic module that can be saved as the specified DLL name.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule3", _
									"MyModule3.dll")
   ' </Snippet3>
   End Sub 'DefineDynamicModuleDemo3
   
   Public Shared Sub DefineDynamicModuleDemo4()
      ' <Snippet4>
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyAssembly"
      Dim myAsmBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      ' Create a dynamic module that can be saved as the specified DLL name. By
      ' specifying the third parameter as true, we can allow the emission of symbol info.
      Dim myModuleBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyModule4", _
									"MyModule4.dll", _
									True)
      ' </Snippet4>
   End Sub 'DefineDynamicModuleDemo4
End Class 'TypeBuilderMemberDemo

