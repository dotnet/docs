' System.Reflection.Emit.TypeBuilder.AddDeclarativeSecurity

' The following example demonstrates method AddDeclarativeSecurity
' of 'TypeBuilder' class.
' The program creates a dynamic assembly and a type in it that has
' a declarative security demand for ControlEvidence.
' Caller (main) is able to create an instance successfully with 
' default permission, because the local machine executes with a 
' full trust permission set. 

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security
Imports System.Security.Permissions

Namespace CustomAttribute_Sample

   Class MyApplication
      
      Shared Sub Main()
         ' Create a simple name for the assembly; create the assembly and the module.        
         Dim myAssemblyName As New AssemblyName("EmittedAssembly")
         Dim myAssemblyBuilder As AssemblyBuilder = _
                  AppDomain.CurrentDomain.DefineDynamicAssembly( _
                          myAssemblyName, AssemblyBuilderAccess.RunAndSave)
         Dim myModuleBuilder As ModuleBuilder = _
                  myAssemblyBuilder.DefineDynamicModule("EmittedAssembly", "EmittedAssembly.dll")

         ' Define a public class named "MyDynamicClass" in the assembly.
         Dim myTypeBuilder As TypeBuilder = _
                  myModuleBuilder.DefineType("MyDynamicClass", TypeAttributes.Public)


         ' Create a permission set and add a security permission
         ' with the ControlEvidence flag.
         '
         Dim myPermissionSet As New PermissionSet(PermissionState.None)
         Dim ce As New SecurityPermission(SecurityPermissionFlag.ControlEvidence)
         myPermissionSet.AddPermission(ce)

         ' Add the permission set to the MyDynamicClass type,
         ' as a declarative security demand.
         '
         myTypeBuilder.AddDeclarativeSecurity(SecurityAction.Demand, myPermissionSet)


         Dim myType As Type = myTypeBuilder.CreateType()
         myAssemblyBuilder.Save("EmittedAssembly.dll")
      End Sub 
   End Class 
End Namespace 
' </Snippet1>
