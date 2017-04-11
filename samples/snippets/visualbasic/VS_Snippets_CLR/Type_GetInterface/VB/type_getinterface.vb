' System.Type.GetInterface(String)
' System.Type.GetInterface(String, bool)
' System.Type.GetInterfaceMap
'
'
' The following program get the type of Hashtable class and searches  
' for the interface with the specified name. Then prints the method 
' name of that interface.
'

Imports System
Imports System.Reflection
Imports System.Collections
Imports Microsoft.VisualBasic

Class MyInterfaceClass

' <Snippet1>
' <Snippet2>
' <Snippet3>
   Public Shared Sub Main()
      Dim hashtableObj As New Hashtable()
      Dim objType As Type = hashtableObj.GetType()
      Dim arrayMemberInfo() As MemberInfo
      Dim arrayMethodInfo() As MethodInfo
      Try
         ' Get the methods implemented in 'IDeserializationCallback' interface.
         arrayMethodInfo = objType.GetInterface("IDeserializationCallback").GetMethods()
         Console.WriteLine(ControlChars.Cr + "Methods of 'IDeserializationCallback' Interface :")
         Dim index As Integer
         For index = 0 To arrayMethodInfo.Length - 1
            Console.WriteLine(arrayMethodInfo(index).ToString())
         Next index
         ' Get FullName for interface by using Ignore case search.
         Console.WriteLine(ControlChars.Cr + "Methods of 'IEnumerable' Interface")
         arrayMethodInfo = objType.GetInterface("ienumerable", True).GetMethods()
         For index = 0 To arrayMethodInfo.Length - 1
            Console.WriteLine(arrayMethodInfo(index).ToString())
         Next index
         'Get the Interface methods for 'IDictionary' interface
         Dim interfaceMappingObj As InterfaceMapping
         interfaceMappingObj = objType.GetInterfaceMap(GetType(IDictionary))
         arrayMemberInfo = interfaceMappingObj.InterfaceMethods
         Console.WriteLine(ControlChars.Cr + "Hashtable class Implements the following IDictionary Interface methods :")
         For index = 0 To arrayMemberInfo.Length - 1
            Console.WriteLine(arrayMemberInfo(index).ToString())
         Next index
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.ToString()))
      End Try
   End Sub 'Main
End Class 'MyInterfaceClass 
' </Snippet3>
' </Snippet2>   
' </Snippet1>