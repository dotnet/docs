 ' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading
Imports System.Text
Imports System.Resources
Imports System.Collections
Imports System.IO

Friend Class NestedEnum
   Friend Shared enumType As TypeBuilder = Nothing
   Friend Shared tNested As Type = Nothing
   Friend Shared tNesting As Type = Nothing
   
   Public Shared Sub Main()
      Dim asmName As New AssemblyName()
      asmName.Name = "NestedEnum"
      Dim asmBuild As AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave)
      Dim modBuild As ModuleBuilder = asmBuild.DefineDynamicModule("ModuleOne", "NestedEnum.dll")
      
      ' Hook up the event listening.
      Dim typeResolveHandler As New TypeResolveHandler(modBuild)
      ' Add a listener for the type resolve events.
      Dim currentDomain As AppDomain = Thread.GetDomain()
      Dim resolveHandler As ResolveEventHandler = AddressOf typeResolveHandler.ResolveEvent
      AddHandler currentDomain.TypeResolve, resolveHandler 
      
      Dim tb As TypeBuilder = modBuild.DefineType("AType", TypeAttributes.Public)
      Dim eb As TypeBuilder = tb.DefineNestedType("AnEnum", TypeAttributes.NestedPublic Or TypeAttributes.Sealed, GetType([Enum]))
      eb.DefineField("value__", GetType(Integer), FieldAttributes.Private Or FieldAttributes.SpecialName)
      Dim fb As FieldBuilder = eb.DefineField("Field1", eb, FieldAttributes.Public Or FieldAttributes.Literal Or FieldAttributes.Static)
      fb.SetConstant(1)
      
      enumType = eb
      
      ' Comment out this field.
      ' When this field is defined, the loader cannot determine the size
      ' of the type. Therefore, a TypeResolve event is generated when the
      ' nested type is completed.
      tb.DefineField("Field2", eb, FieldAttributes.Public)
      
      tNesting = tb.CreateType()
      If tNesting Is Nothing Then
         Console.WriteLine("NestingType CreateType failed but didn't throw!")
      End If 
      Try
         tNested = eb.CreateType()
         If tNested Is Nothing Then
            Console.WriteLine("NestedType CreateType failed but didn't throw!")
         End If
      Catch
      End Try ' This is needed because you might have already completed the type in the TypeResolve event.
      
      If Not (tNested Is Nothing) Then
         Dim x As Type = tNested.DeclaringType
         If x Is Nothing Then
            Console.WriteLine("Declaring type is Nothing.")
         Else
            Console.WriteLine(x.Name)
         End If
      End If 
      asmBuild.Save("NestedEnum.dll")
      
      ' Remove the listener for the type resolve events.
      RemoveHandler currentDomain.TypeResolve, resolveHandler 
   End Sub 'Main
End Class 'NestedEnum


' Helper class called when a resolve type event is raised.
Friend Class TypeResolveHandler
   Private m_Module As [Module]
   
   
   Public Sub New([mod] As [Module])
      m_Module = [mod]
   End Sub 'New
   
   
   Public Function ResolveEvent(sender As [Object], args As ResolveEventArgs) As [Assembly]
      Console.WriteLine(args.Name)
      ' Use args.Name to look up the type name. In this case, you are getting AnEnum.
      Try
         NestedEnum.tNested = NestedEnum.enumType.CreateType()
      Catch
      End Try ' This is needed to throw away InvalidOperationException.
      ' Loader might send the TypeResolve event more than once
      ' and the type might be complete already.
      
      ' Complete the type.		    
      Return m_Module.Assembly
   End Function 'ResolveEvent
End Class 'TypeResolveHandler

' </Snippet1>


